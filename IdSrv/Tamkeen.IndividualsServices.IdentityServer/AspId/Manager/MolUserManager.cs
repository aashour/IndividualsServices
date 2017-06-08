using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Tamkeen.IndividualServices.IdentityServer.AspId.Crypto;
using Tamkeen.IndividualServices.IdentityServer.AspId.Entities;
using Tamkeen.IndividualServices.IdentityServer.AspId.Store;
using System.Reflection;

namespace Tamkeen.IndividualServices.IdentityServer.AspId.Manager
{
    public class MolUserManager : UserManager<MolUser, int>
    {
        public MolUserManager(MolUserStore store)
            : base(store)
        {
            this.ClaimsIdentityFactory = new ClaimsFactory();

            this.PasswordHasher = new MolPasswordHasher(true,
                new MolLegacyEncryptionProvider
                {
                    EncryptionIV = "aaaabbbbccccdddd",
                    EncryptionPassPhrase = "SecretPhrase",
                    EncryptionSalt = "AnySalt",
                    PasswordFormat = PasswordFormat.Encrypt,

                });
        }

        protected async override Task<bool> VerifyPasswordAsync(IUserPasswordStore<MolUser, int> store, MolUser user, string password)
        {
            var hash = await store.GetPasswordHashAsync(user).ConfigureAwait(false);

            if (this.PasswordHasher.VerifyHashedPassword(hash, password) == PasswordVerificationResult.SuccessRehashNeeded)
            {
                // Make our new hash
                hash = PasswordHasher.HashPassword(password);

                // Save it to the DB
                await store.SetPasswordHashAsync(user, hash).ConfigureAwait(false);

                // Invoke internal method to upgrade the security stamp
                BindingFlags bindingFlags = BindingFlags.Instance | BindingFlags.NonPublic;
                MethodInfo minfo = typeof(UserManager<MolUser, int>).GetMethod("UpdateSecurityStampInternal", bindingFlags);
                var updateSecurityStampInternalTask = (Task)minfo.Invoke(this, new[] { user });
                await updateSecurityStampInternalTask.ConfigureAwait(false);

                // Update user
                await UpdateAsync(user).ConfigureAwait(false);
            }

            return PasswordHasher.VerifyHashedPassword(hash, password) != PasswordVerificationResult.Failed;
        }
    }
}