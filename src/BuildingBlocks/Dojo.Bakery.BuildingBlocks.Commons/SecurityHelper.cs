using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography.X509Certificates;

namespace Dojo.Bakery.BuildingBlocks.Commons
{
    public static class SecurityHelper
    {
        public static AsymmetricSecurityKey PrivateKey;
        public static AsymmetricSecurityKey PublicKey;
        public static X509Certificate2 Certificate;
        public static string Algorithm;
        static SecurityHelper()
        {
            string certPath;
            string certPass = "test";
            certPath = Path.Combine(AppContext.BaseDirectory, "Dojo001.p12");
            byte[] bytes = File.ReadAllBytes(certPath);
            X509Certificate2Collection collection = new X509Certificate2Collection();
            collection.Import(bytes, certPass, X509KeyStorageFlags.PersistKeySet | X509KeyStorageFlags.MachineKeySet);
            Certificate = collection[1];
            PrivateKey = new RsaSecurityKey(Certificate.GetRSAPrivateKey());
            PublicKey = new RsaSecurityKey(Certificate.GetRSAPublicKey());
            Algorithm = SecurityAlgorithms.RsaSha256;
        }
        /*
        public static string privateKey = "-----BEGIN RSA PRIVATE KEY-----\r\nMIIBOQIBAAJAftBVJ385yWKRO61PDbUVBT/4m7awfyhbrJw431DOqEhwAt5uGXxK\r\nJJEcGpxWM0drvwlaPbytmoan14hLyijKQQIDAQABAkBUIrKsjstvIldLKbPuWzsE\r\nDapK3U2CP+t6vPc6qmlB2j6IJKsvqKNn34hZq4l90thquD5YNstfK63b424mlCu1\r\nAiEA6L87Qvw/QdgGeOUfo4P7wgs7cftHGf8zinaDZ0opGkMCIQCLe71KNfMncQiP\r\nko81LpKE47tLzI8GfgQILh/vKZWLKwIgV7OPahtQ3se/EJkNxfi6yhCfcsDDtwkR\r\n68/ije5E9K8CIDddsK9qZtA7H+jNhibYC7TQKKJX2lX7Y2JT3L00RnXtAiEA2C8u\r\nkJGsx4VA0DMNEbG4J+Iyc2sQy6yhBZGi9S7IiI8=\r\n-----END RSA PRIVATE KEY-----";
        public static string publicKey = "-----BEGIN PUBLIC KEY-----\r\nMFswDQYJKoZIhvcNAQEBBQADSgAwRwJAftBVJ385yWKRO61PDbUVBT/4m7awfyhb\r\nrJw431DOqEhwAt5uGXxKJJEcGpxWM0drvwlaPbytmoan14hLyijKQQIDAQAB\r\n-----END PUBLIC KEY-----";
        static SecurityHelper()
        {
            Algorithm = SecurityAlgorithms.RsaSha512;
            byte[] privateKeyPkcs1DER = ConvertPKCS1PemToDer(privateKey, "RSA PRIVATE");
            byte[] publicKeyPkcs1DER = ConvertPKCS1PemToDer(publicKey, "PUBLIC");
            RSA rsa = RSA.Create();
            rsa.ImportRSAPrivateKey(privateKeyPkcs1DER, out _);
            rsa.ImportRSAPublicKey(publicKeyPkcs1DER, out _);
            RsaSecurityKey SecurityKey = new RsaSecurityKey(rsa);
            Key = SecurityKey;
        }
        private static byte[] ConvertPKCS1PemToDer(string pemContents, string type)
        {
            return Convert.FromBase64String(pemContents
                .TrimStart(("-----BEGIN RSA " + type + " KEY-----").ToCharArray())
                .TrimEnd(("-----END RSA " + type + " KEY-----").ToCharArray())
                .Replace("\r\n", String.Empty));
        }
        */
    }
}
