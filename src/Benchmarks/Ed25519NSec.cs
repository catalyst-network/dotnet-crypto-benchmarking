using System;
using BenchmarkDotNet.Attributes;
using Org.BouncyCastle.Security;
using NSec.Cryptography;

namespace CryptoBenchmarks
{
    [CategoriesColumn]
    [BenchmarkCategory("ed25519")]
    public class Ed25519NSec
    {
        private static readonly SecureRandom Random = new SecureRandom();
        
        SignatureAlgorithm _algorithm = SignatureAlgorithm.Ed25519;
        byte[] _message;
        byte[] _signature;
        Key _privateKey;

        [GlobalSetup(Target = nameof(GeneratePrivateKey))]
        public void SetupGeneratePrivateKey(){
            _privateKey = new Key(_algorithm);
        }
        
        [GlobalSetup(Target = nameof(GetPublicKey))]
        public void SetupGetPublicKey(){
            _privateKey = new Key(_algorithm);
        }

        [GlobalSetup(Target = nameof(Sign))]
        public void SetupSign(){
            SetupGetPublicKey();
            _privateKey = Key.Create(_algorithm);
            Random.NextBytes(_message);
        }

        [GlobalSetup(Target = nameof(Verify))]
        public void SetupVerify(){
            SetupSign();
            _signature = _algorithm.Sign(_privateKey, _message); 
        }

        [Benchmark]
        [BenchmarkCategory("keygen")]
        public void GeneratePrivateKey(){
            _privateKey=Key.Create(_algorithm);
        }

        [Benchmark]
        [BenchmarkCategory("keygen")]
        public void GetPublicKey(){
            _privateKey=Key.Create(_algorithm);
        }

        [Benchmark]
        [BenchmarkCategory("sign")]
        public void Sign()
        {
            _algorithm.Sign(_privateKey, _message); 
        }

        [Benchmark]
        [BenchmarkCategory("verify")]
        public bool Verify()
        {
            return _algorithm.Verify(_privateKey.PublicKey,_message, _signature);
        }

    }
}