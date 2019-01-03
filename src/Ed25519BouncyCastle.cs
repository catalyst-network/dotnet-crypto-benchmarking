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
    public class Ed25519BouncyCastle
    {
        private static readonly SecureRandom Random = new SecureRandom();
        byte[] sk;
        byte[] pk;
        byte[] m ;
        byte[] sig1;
        int mLen;

        
        public Ed25519BouncyCastle()
        {
            Ed25519.Precompute();

        }

        [GlobalSetup(Target = nameof(GeneratePublicKey))]
        public void SetupGenerateKey(){
            sk = new byte[Ed25519.SecretKeySize];
            pk = new byte[Ed25519.PublicKeySize];
            Random.NextBytes(sk);
        }

        [GlobalSetup(Target = nameof(Sign))]
        public void SetupSign(){
            SetupGenerateKey();
            Ed25519.GeneratePublicKey(sk, 0, pk, 0);
            m = new byte[32];
            Random.NextBytes(m);
            mLen = Random.NextInt() & 32;
            sig1 = new byte[Ed25519.SignatureSize];

        }

        [GlobalSetup(Target = nameof(Verify))]
        public void SetupVerify(){
            SetupSign();
            Ed25519.Sign(sk, 0, m, 0, mLen, sig1, 0);

        }

		[Benchmark]
        [BenchmarkCategory("keygen")]
        public void GeneratePublicKey()
        {
            Ed25519.GeneratePublicKey(sk, 0, pk, 0);
        }

        [Benchmark]
        [BenchmarkCategory("sign")]
        public void Sign()
        {
            Ed25519.Sign(sk, 0, m, 0, mLen, sig1, 0);
        }

        [Benchmark]
        [BenchmarkCategory("verify")]
        public bool Verify()
        {   
            return Ed25519.Verify(sig1, 0, pk, 0, m, 0, mLen);
        }
    }
}