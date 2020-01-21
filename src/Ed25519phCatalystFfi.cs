using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Toolchains.Results;
using Catalyst.Abstractions.Cryptography;
using Catalyst.Core.Modules.Cryptography.BulletProofs;

namespace CryptoBenchmarks
{
    [CategoriesColumn]
    [BenchmarkCategory("ed25519", "ed25519ph")]
    public class Ed25519phCatalystFfi
    {
        IWrapper _wrapper = new CryptoWrapper();
        IPrivateKey _privateKey;
        private IPublicKey _publicKey;
        byte[] _message;
        byte[] _context;
        ISignature _signature;

        [GlobalSetup(Target = nameof(GetPublicKey))]
        public void SetupGetPublicKey()
        {
            _privateKey = _wrapper.GeneratePrivateKey();
        }

        [GlobalSetup(Target = nameof(Sign))]
        public void SetupSign()
        {
            _message = new byte[32];
            _context = new byte[32];
            SetupGetPublicKey();
        }

        [GlobalSetup(Target = nameof(Verify))]
        public void SetupVerify()
        {
            SetupSign();
            _signature = _wrapper.StdSign(_privateKey, _message, _context);
        }

        [Benchmark]
        [BenchmarkCategory("keygen")]
        public void GeneratePrivateKey()
        {
            _privateKey = _wrapper.GeneratePrivateKey();

        }

        [Benchmark]
        [BenchmarkCategory("getpublickey")]
        public void GetPublicKey()
        {
            _publicKey = _wrapper.GetPublicKeyFromPrivate(_privateKey);
        }

  

        [Benchmark]
        [BenchmarkCategory("sign")]
        public void Sign()
        {
            _signature = _wrapper.StdSign(_privateKey, _message, _context);
        }

        [Benchmark]
        [BenchmarkCategory("verify")]
        public bool Verify()
        {
            return _wrapper.StdVerify(_signature, _message, _context);
        }

    }
}