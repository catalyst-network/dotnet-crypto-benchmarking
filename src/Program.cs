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
    
    

    
    
    public class Program
    {
        public static void Main(string[] args)
        {   
           BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
        }

    }
}

