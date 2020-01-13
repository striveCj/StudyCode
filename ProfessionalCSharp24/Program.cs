﻿using System;
using System.Collections.Generic;
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
            WindowsIdentity identity=WindowsIdentity.GetCurrent();
            if (identity==null)
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
            WindowsPrincipal principal=new WindowsPrincipal(identity);
            if (principal==null)
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
                foreach (var prop in claim.Properties)            {
                    Console.WriteLine(prop.Key);
                    Console.WriteLine(prop.Value);
                }
                Console.WriteLine();
            }
        }




        private CngKey _aliceKeySignature;
        private byte[] _alicePubKeyBlob;

        public void Run()
        {
            InitAliceKeys();
            byte[] aliceData = Encoding.UTF8.GetBytes("Alice");
            byte[] aliceSignature = CreateSignature(aliceData, _aliceKeySignature);
            Console.WriteLine(alicesSignature);
            if (VerifySignature(aliceDatamaliceSignature,alicePubKeyBlob))
            {
                Console.WriteLine("successfully");
                
            }
        }

        private void InitAliceKeys()
        {
            _aliceKeySignature=CngKey.Create(CngAlgorithm.Sha512);
            _alicePubKeyBlob = _aliceKeySignature.Export(CngKeyBlobFormat.GenericPublicBlob);
        }

        public bool VerifySignature(byte[] data, byte[] signature, byte[] pubKeys)
        {
            bool retValue = false;
            using (CngKey key=CngKey.Import(pubKeys,CngKeyBlobFormat.GenericPrivateBlob))
            {
                using (var signungAlg=new ECDsaCng(key))
                {
                    retValue = signungAlg.VerifyData(data, signature, HashAlgorithmName.SHA512);
                    signungAlg.Clear();
                }
                return retValue;
            }
        }
    }
}
