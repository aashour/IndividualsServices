using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tamkeen.IndividualServices.IdentityServer.AspId.Crypto
{
    public class MolLegacyEncryptionProvider
    {

        public string LegacyAlgorithm { get; set; }

        public PasswordFormat PasswordFormat { get; set; }

        public string EncryptionSalt { get; set; }
        public string EncryptionPassPhrase { get; set; }
        public string EncryptionIV { get; set; }

        public string Encrypt(string password)
        {
            return AESLibrary.AESLibrary.Encrypt(password, EncryptionSalt, EncryptionPassPhrase, EncryptionIV);

        }

        public string Decrypt(string password)
        {
            return AESLibrary.AESLibrary.Decrypt(password, EncryptionSalt, EncryptionPassPhrase, EncryptionIV);
        }
    }


    public enum PasswordFormat
    {
        Hashed = 0,
        Clear = 1,
        Encrypt = 2,
    }
}