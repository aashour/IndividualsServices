using Microsoft.AspNet.Identity;
using System;

namespace Tamkeen.IndividualServices.IdentityServer.AspId.Crypto
{
    public class MolPasswordHasher : PasswordHasher
    {

        public bool KeepLegacyHashFormat { get; set; }
        MolLegacyEncryptionProvider _molLegacyEncryptionProvider { get; set; }

        public MolPasswordHasher(bool keepLegacyHashFormat, MolLegacyEncryptionProvider legacy)
        {
            KeepLegacyHashFormat = keepLegacyHashFormat;
            if (legacy != null)
                _molLegacyEncryptionProvider = legacy;
        }

        public override string HashPassword(string password)
        {
            if (KeepLegacyHashFormat)
                return _molLegacyEncryptionProvider.Encrypt(password);
            else
                return base.HashPassword(password);
        }


        public override PasswordVerificationResult VerifyHashedPassword(string hashedPassword, string providedPassword)
        {
            string[] passwordProperties = hashedPassword.Split('|');
            if (KeepLegacyHashFormat)
            {
                if (String.Equals(_molLegacyEncryptionProvider.Encrypt(providedPassword), hashedPassword, StringComparison.CurrentCultureIgnoreCase))
                    return PasswordVerificationResult.Success;
                else
                    return PasswordVerificationResult.Failed;
            }
            else
            {
                return base.VerifyHashedPassword(hashedPassword, providedPassword);
            }
        }

    }

}