using System;
using System.Security.Cryptography;
using BenchmarkDotNet.Attributes;
using Org.BouncyCastle.Security;
using Secp256k1Net;

namespace CryptoBenchmarks
{
    [CategoriesColumn]
    [BenchmarkCategory("secp256k1")]
    public class Secp256k1Wrapped
    {
        private static readonly SecureRandom Random = new SecureRandom();
        
        byte[] _privateKey = new byte[64];
        byte[] _publicKey = new byte[64];
        byte[] _message = new byte[32];
        byte[] _signature = new byte[64];
        Secp256k1 secp256k1;
        
        public Secp256k1Wrapped()
        {
            secp256k1 = new Secp256k1();
        }

        Span<byte> GeneratePrivateKeyHelper()
        {
            Span<byte> sk = new byte[32];
            do
            {
                Random.NextBytes(sk);
            }
            while (!secp256k1.SecretKeyVerify(sk));
            return sk;
        }


        [GlobalSetup(Target = nameof(GetPublicKey))]
        public void SetupGetPublicKey(){
            Span<byte> sk = GeneratePrivateKeyHelper();
            _privateKey = sk.ToArray();    
        }

        [GlobalSetup(Target = nameof(Sign))]
        public void SetupSign(){
            
            SetupGetPublicKey();           
            secp256k1.PublicKeyCreate(_publicKey, _privateKey);
             
        }

        [GlobalSetup(Target = nameof(Verify))]
        public void SetupVerify(){
            SetupSign();        
            secp256k1.Sign(_signature, _message, _privateKey);

        }

        [Benchmark]
        [BenchmarkCategory("keygen")]
        public void GeneratePrivateKey(){

            secp256k1.PublicKeyCreate(_publicKey,_privateKey);  
        }

        [Benchmark]
        [BenchmarkCategory("keygen")]
        public void GetPublicKey(){
            Span<byte> pk = new byte[64];
            secp256k1.PublicKeyCreate(_publicKey,_privateKey);  
        }

        [Benchmark]
        [BenchmarkCategory("sign")]
        public void Sign()
        {
            secp256k1.Sign(_signature, _message, _privateKey);   
        }

        [Benchmark]
        [BenchmarkCategory("verify")]
        public bool Verify()
        {
            return secp256k1.Verify(_signature, _message, _publicKey);
    
        }

    }
}