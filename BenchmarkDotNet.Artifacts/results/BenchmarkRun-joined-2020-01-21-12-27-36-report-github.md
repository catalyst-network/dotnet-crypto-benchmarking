``` ini

BenchmarkDotNet=v0.11.3, OS=macOS 10.15.2 (19C57) [Darwin 19.2.0]
Intel Core i7-7700HQ CPU 2.80GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=3.0.100
  [Host]     : .NET Core 3.0.0 (CoreCLR 4.700.19.46205, CoreFX 4.700.19.46214), 64bit RyuJIT
  DefaultJob : .NET Core 3.0.0 (CoreCLR 4.700.19.46205, CoreFX 4.700.19.46214), 64bit RyuJIT


```
|                 Type |             Method |      Mean |     Error |    StdDev |     Median |
|--------------------- |------------------- |----------:|----------:|----------:|-----------:|
|  Ed25519BouncyCastle |  GeneratePublicKey |  74.09 us | 0.8838 us | 0.8267 us |  74.367 us |
|          Ed25519NSec |  GeneratePublicKey |  34.32 us | 0.5452 us | 0.5099 us |  34.230 us |
| Ed25519phCatalystFfi | GeneratePrivateKey |  10.27 us | 1.8984 us | 5.2287 us |   7.965 us |
|  Ed25519BouncyCastle |               Sign | 152.42 us | 1.8126 us | 1.6068 us | 152.161 us |
|          Ed25519NSec |               Sign |  25.29 us | 0.5057 us | 0.8166 us |  25.133 us |
| Ed25519phCatalystFfi |       GetPublicKey |  22.86 us | 0.1992 us | 0.1863 us |  22.771 us |
|  Ed25519BouncyCastle |             Verify | 196.54 us | 1.6296 us | 1.4446 us | 196.542 us |
|          Ed25519NSec |             Verify |  66.32 us | 0.9480 us | 0.8868 us |  66.374 us |
| Ed25519phCatalystFfi |               Sign |  49.66 us | 0.3663 us | 0.3247 us |  49.617 us |
| Ed25519phCatalystFfi |             Verify |  75.10 us | 0.6845 us | 0.6403 us |  75.078 us |
