``` ini

BenchmarkDotNet=v0.11.3, OS=macOS Mojave 10.14.1 (18B75) [Darwin 18.2.0]
Intel Core i7-7700HQ CPU 2.80GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=2.2.101
  [Host]     : .NET Core 2.2.0 (CoreCLR 4.6.27110.04, CoreFX 4.6.27110.04), 64bit RyuJIT
  DefaultJob : .NET Core 2.2.0 (CoreCLR 4.6.27110.04, CoreFX 4.6.27110.04), 64bit RyuJIT


```
|                Type |            Method |      Mean |     Error |    StdDev | Gen 0/1k Op | Gen 1/1k Op | Gen 2/1k Op | Allocated Memory/Op |
|-------------------- |------------------ |----------:|----------:|----------:|------------:|------------:|------------:|--------------------:|
| Ed25519BouncyCastle | GeneratePublicKey |  64.59 us | 0.5027 us | 0.4457 us |      7.8125 |           - |           - |             24800 B |
|         Ed25519NSec | GeneratePublicKey |  34.32 us | 0.2858 us | 0.2674 us |           - |           - |           - |               152 B |
|    Secp256k1Wrapped | GeneratePublicKey |  26.20 us | 0.1780 us | 0.1578 us |      0.0305 |           - |           - |               176 B |
| Ed25519BouncyCastle |              Sign | 130.74 us | 1.1151 us | 1.0431 us |     15.6250 |           - |           - |             49200 B |
|         Ed25519NSec |              Sign |  22.97 us | 0.1877 us | 0.1755 us |           - |           - |           - |                88 B |
|    Secp256k1Wrapped |              Sign |  44.52 us | 0.2484 us | 0.2202 us |      0.0610 |           - |           - |               232 B |
| Ed25519BouncyCastle |            Verify | 179.47 us | 1.1489 us | 1.0185 us |     38.0859 |           - |           - |            120400 B |
|         Ed25519NSec |            Verify |  62.30 us | 0.5689 us | 0.5322 us |           - |           - |           - |                   - |
|    Secp256k1Wrapped |            Verify |  67.45 us | 0.7706 us | 0.7208 us |           - |           - |           - |               232 B |
