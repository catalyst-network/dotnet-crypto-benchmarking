``` ini

BenchmarkDotNet=v0.11.3, OS=macOS 10.15.2 (19C57) [Darwin 19.2.0]
Intel Core i7-7700HQ CPU 2.80GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=3.0.100
  [Host]     : .NET Core 2.2.3 (CoreCLR 4.6.27414.05, CoreFX 4.6.27414.05), 64bit RyuJIT
  DefaultJob : .NET Core 2.2.3 (CoreCLR 4.6.27414.05, CoreFX 4.6.27414.05), 64bit RyuJIT


```
|                 Type |             Method |       Mean |     Error |    StdDev |     Median |
|--------------------- |------------------- |-----------:|----------:|----------:|-----------:|
|  Ed25519BouncyCastle |  GeneratePublicKey |  66.524 us | 0.9768 us | 0.9137 us |  66.431 us |
|          Ed25519NSec |  GeneratePublicKey |  34.771 us | 0.6869 us | 1.0490 us |  34.784 us |
| Ed25519phCatalystFfi | GeneratePrivateKey |   3.616 us | 0.6475 us | 1.8049 us |   2.850 us |
|  Ed25519BouncyCastle |               Sign | 139.096 us | 2.1575 us | 2.0181 us | 138.926 us |
|          Ed25519NSec |               Sign |  25.288 us | 0.4862 us | 0.4992 us |  25.395 us |
| Ed25519phCatalystFfi |       GetPublicKey |  22.748 us | 0.2613 us | 0.2444 us |  22.663 us |
|  Ed25519BouncyCastle |             Verify | 187.029 us | 2.0279 us | 1.7977 us | 186.770 us |
|          Ed25519NSec |             Verify |  64.934 us | 0.7910 us | 0.7399 us |  64.653 us |
| Ed25519phCatalystFfi |               Sign |  77.390 us | 0.9106 us | 0.8518 us |  77.704 us |
| Ed25519phCatalystFfi |             Verify |  73.813 us | 0.6389 us | 0.5976 us |  73.771 us |
