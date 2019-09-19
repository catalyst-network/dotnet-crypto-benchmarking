using System;
using System.Security.Cryptography;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Utilities;
using Org.BouncyCastle.Utilities.Encoders;
using Org.BouncyCastle.Math.EC.Rfc8032;



namespace CryptoBenchmarks
{
    [CategoriesColumn]
    [BenchmarkCategory("ed25519")]
    public class Ed25519BouncyCastle
    {
        private static readonly SecureRandom Random = new SecureRandom();
        byte[] _privateKey;
        byte[] _publicKey;
        byte[] message;
        byte[] signature;
        int messageLength = 32;
        
        public Ed25519BouncyCastle()
        {
            Ed25519.Precompute();
        }

        [GlobalSetup(Target = nameof(GeneratePrivateKey))]
        public void SetupGeneratePrivateKey(){
            _privateKey = new byte[Ed25519.SecretKeySize];
            _publicKey = new byte[Ed25519.PublicKeySize];
        }

        [GlobalSetup(Target = nameof(GetPublicKey))]
        public void SetupGetPublicKey()
        {
            SetupGeneratePrivateKey();
            Random.NextBytes(_privateKey);
        }

        [GlobalSetup(Target = nameof(Sign))]
        public void SetupSign(){
            message = new byte[32];
            signature = new byte[Ed25519.SignatureSize];
            
            SetupGeneratePrivateKey();
            
            Ed25519.GeneratePublicKey(_privateKey, 0, _publicKey, 0);
            Random.NextBytes(message);
        }

        [GlobalSetup(Target = nameof(Verify))]
        public void SetupVerify(){
            SetupSign();
            Ed25519.Sign(_privateKey, 0, message, 0, messageLength, signature, 0);

        }

        [Benchmark]
        [BenchmarkCategory("keygen")]
        public void GeneratePrivateKey()
        {
            Random.NextBytes(_privateKey);
        }

		[Benchmark]
        [BenchmarkCategory("keygen")]
        public void GetPublicKey()
        {
            Ed25519.GeneratePublicKey(_privateKey, 0, _publicKey, 0);
        }

        [Benchmark]
        [BenchmarkCategory("sign")]
        public void Sign()
        {
            Ed25519.Sign(_privateKey, 0, message, 0, messageLength, signature, 0);
        }

        [Benchmark]
        [BenchmarkCategory("verify")]
        public bool Verify()
        {   
            return Ed25519.Verify(signature, 0, _publicKey, 0, message, 0, messageLength);
        }
    }
}