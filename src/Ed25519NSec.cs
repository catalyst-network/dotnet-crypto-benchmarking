using System;
using System.Security.Cryptography;
using BenchmarkDotNet.Attributes;
using Org.BouncyCastle.Security;
using NSec.Cryptography;

namespace CryptoBenchmarks
{
    public class Ed25519NSec
    {
        private static readonly SecureRandom Random = new SecureRandom();
        
        SignatureAlgorithm algorithm = SignatureAlgorithm.Ed25519;
        byte[] m ;
        byte[] sig1;
        int mLen;

        byte[] privateKey;
        byte[] publicKey;

        byte[] signature;
        Key key;
        public Ed25519NSec()
        {
        }


        [GlobalSetup(Target = nameof(GeneratePublicKey))]
        public void SetupGenerateKey(){
            key = new Key(algorithm);
        }

        [Benchmark]
        [BenchmarkCategory("keygen")]
        public void GeneratePublicKey(){
            key=Key.Create(algorithm);
        }

        [GlobalSetup(Target = nameof(Sign))]
        public void SetupSign(){
            SetupGenerateKey();
            key = Key.Create(algorithm);
            m = new byte[32];
            Random.NextBytes(m);
            sig1 = new byte[64];
        }

        [Benchmark]
        [BenchmarkCategory("sign")]
        public void Sign()
        {
            ReadOnlySpan<byte> message = m;
            algorithm.Sign(key, message); 
        }

        [GlobalSetup(Target = nameof(Verify))]
        public void SetupVerify(){
            SetupSign();
            ReadOnlySpan<byte> message = m;
            sig1 = algorithm.Sign(key, message); 
        }

        [Benchmark]
        [BenchmarkCategory("verify")]
        public bool Verify()
        {
            ReadOnlySpan<byte> message = m;
            ReadOnlySpan<byte> signature = sig1;
            return algorithm.Verify(key.PublicKey,message,signature);
        }

    }
}