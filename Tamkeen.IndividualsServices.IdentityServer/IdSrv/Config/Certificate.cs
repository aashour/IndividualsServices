using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace Tamkeen.IndividualServices.IdentityServer.IdSrv.Config
{
    static class Certificate
    {
        public static X509Certificate2 Get()
        {
            X509Certificate2 cer = new X509Certificate2();
            X509Store store = new X509Store(StoreName.My, StoreLocation.LocalMachine);
            store.Open(OpenFlags.ReadOnly);

            X509Certificate2Collection cers = store.Certificates.Find(X509FindType.FindBySubjectName, "idsrv3test", false);
            if (cers.Count > 0)
            {
                cer = cers[0];
            }
            else
            {
                var assembly = typeof(Certificate).Assembly;
                using (var stream = assembly.GetManifestResourceStream("Tamkeen.IndividualServices.IdentityServer.IdSrv.idsrv3test.pfx"))
                {
                    cer = new X509Certificate2(ReadStream(stream), "idsrv3test");
                }
            }
            store.Close();
            return cer;


        }

        private static byte[] ReadStream(Stream input)
        {
            byte[] buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }
    }
}