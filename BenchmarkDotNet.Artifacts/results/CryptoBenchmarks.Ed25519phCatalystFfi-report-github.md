``` ini

BenchmarkDotNet=v0.11.3, OS=macOS 10.15.2 (19C57) [Darwin 19.2.0]
Intel Core i7-7700HQ CPU 2.80GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=3.0.100
  [Host]     : .NET Core 3.0.0 (CoreCLR 4.700.19.46205, CoreFX 4.700.19.46214), 64bit RyuJIT
  DefaultJob : .NET Core 3.0.0 (CoreCLR 4.700.19.46205, CoreFX 4.700.19.46214), 64bit RyuJIT


```
|      Method |    N |         Mean |       Error |      StdDev |
|------------ |----- |-------------:|------------:|------------:|
|      **Verify** |    **1** |     **72.23 us** |   **0.3506 us** |   **0.3279 us** |
| BatchVerify |    1 |     99.23 us |   0.6915 us |   0.6468 us |
|      **Verify** |   **10** |     **72.68 us** |   **0.4425 us** |   **0.3923 us** |
| BatchVerify |   10 |    452.37 us |   2.4353 us |   2.2780 us |
|      **Verify** |  **100** |     **73.18 us** |   **0.2813 us** |   **0.2494 us** |
| BatchVerify |  100 |  4,005.34 us |  20.4333 us |  19.1134 us |
|      **Verify** | **1000** |     **72.56 us** |   **0.3180 us** |   **0.2655 us** |
| BatchVerify | 1000 | 32,225.51 us | 311.0567 us | 290.9626 us |
