using System;
using System.Security.Cryptography;
using BenchmarkDotNet.Attributes;
using Org.BouncyCastle.Security;
using Secp256k1Net;

namespace CryptoBenchmarks
{
    public class Secp256k1Wrapped
    {
        private static readonly SecureRandom Random = new SecureRandom();
        
        byte[] m ;
        byte[] sig1;
        int mLen;

        byte[] privateKey;
        byte[] publicKey;

        Secp256k1 secp256k1;

        byte[] signature;
        
        public Secp256k1Wrapped()
        {
            secp256k1 = new Secp256k1();
        }

        Span<byte> GeneratePrivateKey()
        {
            Span<byte> privateKey = new byte[32];
            do
            {
                Random.NextBytes(privateKey);
            }
            while (!secp256k1.SecretKeyVerify(privateKey));
            return privateKey;
        }


        [GlobalSetup(Target = nameof(GeneratePublicKey))]
        public void SetupGenerateKey(){
            Span<byte> sk = GeneratePrivateKey();
            privateKey = sk.ToArray();    
        }

        [Benchmark]
        [BenchmarkCategory("keygen")]
        public void GeneratePublicKey(){
            Span<byte> sk = new byte[64];
            sk = privateKey;
            Span<byte> pk = new byte[64];
            
            secp256k1.PublicKeyCreate(pk,sk);  
        }

        [GlobalSetup(Target = nameof(Sign))]
        public void SetupSign(){
            SetupGenerateKey();
            Span<byte> sk = new byte[64];
            sk = privateKey;
            Span<byte> pk = new byte[64];
            secp256k1.PublicKeyCreate(pk,sk);
            publicKey=pk.ToArray();
            
            Span<byte> message = new byte[32];
            Random.NextBytes(message);
            m= message.ToArray();
            sig1 = new byte[64];
        }

        [Benchmark]
        [BenchmarkCategory("sign")]
        public void Sign()
        {
            Span<byte> mess = new byte[32];
            mess = m;
            Span<byte> sig = new byte[64];
            Span<byte> sk = new byte[64];
            sk=privateKey;
            secp256k1.Sign(sig, mess, sk);   
        }

        [GlobalSetup(Target = nameof(Verify))]
        public void SetupVerify(){
            SetupSign();
            Span<byte> sk = new byte[64];
            sk = privateKey;
            Span<byte> message = new byte[32];
            Random.NextBytes(message);
            m= message.ToArray();
            Span<byte> sig = new byte[64];
            secp256k1.Sign(sig, message, sk);
            sig1 = new byte[64];
            sig1=sig.ToArray();
        }

        [Benchmark]
        [BenchmarkCategory("verify")]
        public bool Verify()
        {
            Span<byte> sig = new byte[64];
            sig=sig1;
            Span<byte> mess = new byte[32];
            mess = m;
            Span<byte> pk = new byte[64];
            pk= publicKey;
            return secp256k1.Verify(sig,mess,pk);
    
        }

    }
}