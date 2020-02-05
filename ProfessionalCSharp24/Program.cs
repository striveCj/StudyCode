using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.DesignerServices;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace ProfessionalCSharp24
{
    class Program
    {
        static void Main(string[] args)
        {
            WindowsIdentity identity = ShowIdentityInformation();
            WindowsIdentity principal = ShowPrincipal(identity);
            ShowClaims(principal.Claims);
        }

        public static WindowsIdentity ShowIdentityInformation()
        {
            WindowsIdentity identity = WindowsIdentity.GetCurrent();
            if (identity == null)
            {
                Console.WriteLine("not a windows identity");
                return null;
            }
            Console.WriteLine(identity);
            Console.WriteLine(identity.Name);
            Console.WriteLine(identity.IsAuthenticated);
            Console.WriteLine(identity.AuthenticationType);
            Console.WriteLine(identity.IsAnonymous);
            Console.WriteLine(identity.AccessToken.DangerousGetHandle());
            return identity;
        }

        public static WindowsPrincipal ShowPrincipal(WindowsIdentity identity)
        {
            Console.WriteLine("Show principal information");
            WindowsPrincipal principal = new WindowsPrincipal(identity);
            if (principal == null)
            {
                Console.WriteLine("not a Windows Principal");
                return null;
            }
            Console.WriteLine($"Users?{principal.IsInRole(WindowsBuiltInRole.User)}");
            Console.WriteLine($"Administrator?{principal.IsInRole(WindowsBuiltInRole.Administrator)}");
            return principal;
        }
        public static void ShowClaims(IEnumerable<Claim> claims)
        {
            Console.WriteLine("Claims");
            foreach (var claim in claims)
            {
                Console.WriteLine($"Subject:{claim.Subject}");
                Console.WriteLine($"Subject:{claim.Issuer}");
                Console.WriteLine($"Subject:{claim.Type}");
                Console.WriteLine($"Subject:{claim.ValueType}");
                Console.WriteLine($"Subject:{claim.Value}");
                foreach (var prop in claim.Properties) {
                    Console.WriteLine(prop.Key);
                    Console.WriteLine(prop.Value);
                }
                Console.WriteLine();
            }
        }




        private CngKey _aliceKeySignature;
        private byte[] _alicePubKeyBlob;
        private CngKey _aliceKey;


        public void Run()
        {
            InitAliceKeys();
            byte[] aliceData = Encoding.UTF8.GetBytes("Alice");
            byte[] aliceSignature = CreateSignature(aliceData, _aliceKeySignature);
            Console.WriteLine(aliceSignature);
            if (VerifySignature(aliceData, aliceSignature, _alicePubKeyBlob))
            {
                Console.WriteLine("successfully");

            }
        }

        private void InitAliceKeys()
        {
            _aliceKeySignature = CngKey.Create(CngAlgorithm.Sha512);
            _alicePubKeyBlob = _aliceKeySignature.Export(CngKeyBlobFormat.GenericPublicBlob);
        }

        private void InitAliceKeysRsa()
        {
            _aliceKey = CngKey.Create(CngAlgorithm.Rsa);
            _alicePubKeyBlob = _aliceKey.Export(CngKeyBlobFormat.GenericPrivateBlob);
        }
        private byte[] HashDocumentRsa(byte[] data)
        {
            using (var hashAlg = SHA384.Create())
            {
                return hashAlg.ComputeHash(data);
            }
        }

        private byte[] AddSignatureToHashRsa(byte[] hash, CngKey key)
        {
            using (var signingAlg = new RSACng(key))
            {
                byte[] signed = signingAlg.SignHash(hash, HashAlgorithmName.SHA384, RSASignaturePadding.Pss);
                return signed;
            }
        }

        public void BobTasks(byte[] data, byte[] hash, byte[] signature)
        {
            CngKey aliceKey = CngKey.Import(_alicePubKeyBlob, CngKeyBlobFormat.GenericPublicBlob);
            if (IsSignatureValid(hash, signature, aliceKey))
            {
                Console.WriteLine("signature not valid");
                return;
            }
            if (!IsDocumentUnchanged(hash, data))
            {
                Console.WriteLine("document was changed");
                return;
            }

            Console.WriteLine("signature valid , document unchanged");
            Console.WriteLine(Encoding.UTF8.GetString(data));

        }
        private bool IsSignatureValid(byte[] hash, byte[] signature, CngKey key)
        {
            using (var signingAlg = new RSACng(key))
            {
                return signingAlg.VerifyHash(hash, signature, HashAlgorithmName.SHA384, RSASignaturePadding.Pss);
            }
        }
        private bool IsDocumentUnchanged(byte[] hash, byte[] data)
        {
            byte[] newHash = HashDocument(data);
            return newHash.SequenceEqual(hash);
        }

        private byte[] HashDocument(byte[] data)
        {
            using (var hashAlg = SHA384.Create())
            {
                return hashAlg.ComputeHash(data);
            }
        }

        public byte[] CreateSignature(byte[] data, CngKey key)
        {
            byte[] signature;
            using (var signingAlg = new ECDsaCng(key))
            {
                signature = signingAlg.SignData(data, HashAlgorithmName.SHA512);
                signingAlg.Clear();
            }
            return signature;
        }
        public bool VerifySignature(byte[] data, byte[] signature, byte[] pubKeys)
        {
            bool retValue = false;
            using (CngKey key = CngKey.Import(pubKeys, CngKeyBlobFormat.GenericPrivateBlob))
            {
                using (var signungAlg = new ECDsaCng(key))
                {
                    retValue = signungAlg.VerifyData(data, signature, HashAlgorithmName.SHA512);
                    signungAlg.Clear();
                }
                return retValue;
            }
        }



        public void CreateKeys()
        {
            _aliceKeySignature = CngKey.Create(CngAlgorithm.ECDiffieHellmanP521);
            bobkey = CngKey.Create(CngAlgorithm.ECDiffieHellmanP521);
            alicePubKeyBlob = aliceKey.Export(CngKeyBlobFormat.EccPublicBlob);
            bobPubKeyBlob = bobKey.Export(CngKeyBlobFormat.EccPublicBlob);


        }
        public async Task<byte[]> AliceSendsDataAsync(string message)
        {
            Console.WriteLine($"Alice sends message:{message}");
            byte[] rawData = Encoding.UTF8.GetBytes(message);
            byte[] encryptedData = null;
            using (var aliceAlgorithm = new ECDiffieHellmanCng(aliceKey))
            {
                using (CngKey bobPubKey = CngKey.Import(bobPubKeyBlob, CngKeyBlobFormat.EccPublicBlob))
                {
                    byte[] symmKey = aliceAlgorithm.DeriveKeyMaterial(bobPubKey);
                    Console.WriteLine($"Alice creates this symmetric key with{Convert.ToBase64String(symmKey)}");
                    using (var aes = new AesCryptoServiceProvider())
                    {
                        aes.Key = symmKey;
                        aes.GenerateIV();
                        using (ICryptoTransform encryptor = aes.CreateEncryptor)
                        {
                            using (var ms = new MemoryStream())
                            {
                                using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                                {
                                    await ms.WriteAsync(aes.IV, 0, aes.IV.Length);
                                    cs.Write(rawData, 0, rawData.Length);
                                }
                                encryptedData = ms.ToArray();
                            }
                            aes.Clear();
                        }
                    }
                }
            }
            Console.WriteLine(Convert.ToBase64String(encryptedData));
            return encryptedData;
        }

        public async Task BobReceivesDataAsync(byte[] encryptedData)
        {
            Console.WriteLine("Bob receives encrypted data");
            byte[] rawData = null;
            var aes = new AesCryptoServiceProvider();
            int nBytes = aes.BlockSize;
            byte[] iv = new byte[nBytes];
            for (int i = 0; i < iv.Length; i++)
            {
                iv[i] = encryptedData[i];
            }
            using (var bobAlgorithm = new ECDiffieHellmanCng(bobKey))
            {
                using (CngKey alicePubKey = CngKey.Import(_alicePubKeyBlob, CngKeyBlobFormat.EccFullPublicBlob))
                {
                    byte[] symmKey = bobAlgorithm.DeriveKeyMaterial(alicePubKey);
                    Console.WriteLine(Convert.ToBase64String(symmKey));
                    aes.Key = symmKey;
                    aes.IV = iv;
                    using (ICryptoTransform decryptor = aes.CreateDecryptor())
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            using (var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Write))
                            {
                                await cs.WriteAsync(encryptedData, nBytes, encryptedData.Length - nBytes);
                            }
                            rawData = ms.ToArray();
                            Console.WriteLine(Encoding.UTF8.GetString(rawData));
                        }
                        aes.Clear();
                    }
                }
            }

        }
        private const string readOption = "-r";
        private const string writeOption = "-w";
        private static readonly string[] options = { readOption, writeOption };
        private static void dp(string[] args){
            if (args.Length!=2||args.Intersect(options).Count()!=1)
            {
                ShowUsage();
                return;
            }
            string fileName = args[i];
            Mysafe safe = SetupDataprotection();
            switch (args[0])
            {
                case writeOption:
                    Write(safe, flieName);
                    break;
                case readOption:
                    Read(safe, fileName);
                    break;
                default:
                    ShowUsage();
                    break;
            }
        }

        public class MySafe
        {
            private IDataProtector _protector;
            public MySafe(IDataProtectionProvider provider) => _protector = provider.CreateProtector("MySafe.MyProtetion.v2");
            public string Encrypt(string input) => _protector.Protect(input);   
        }


    }
}
