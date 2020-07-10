using System;
using System.Linq;
using System.Security.Cryptography;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Validators;
using Microsoft.EntityFrameworkCore.Internal;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Utilities;
using Org.BouncyCastle.Utilities.Encoders;
using Org.BouncyCastle.Math.EC.Rfc8032;

namespace CryptoBenchmarks
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args, new AllowNonOptimized());
        }

        private class AllowNonOptimized : ManualConfig
        {
            public AllowNonOptimized()
            {
                AddValidator(JitOptimizationsValidator.DontFailOnError);
                AddLogger(DefaultConfig.Instance.GetLoggers().ToArray());
                AddExporter(DefaultConfig.Instance.GetExporters().ToArray()); 
                AddColumnProvider(DefaultConfig.Instance.GetColumnProviders().ToArray());
            }
        }
    }
}

