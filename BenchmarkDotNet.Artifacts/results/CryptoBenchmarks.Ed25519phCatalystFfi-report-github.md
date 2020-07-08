``` ini

BenchmarkDotNet=v0.11.3, OS=macOS 10.15.2 (19C57) [Darwin 19.2.0]
Intel Core i7-7700HQ CPU 2.80GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=3.0.100
  [Host]     : .NET Core 3.0.0 (CoreCLR 4.700.19.46205, CoreFX 4.700.19.46214), 64bit RyuJIT
  DefaultJob : .NET Core 3.0.0 (CoreCLR 4.700.19.46205, CoreFX 4.700.19.46214), 64bit RyuJIT


```
|      Method |      N |            Mean |          Error |         StdDev |
|------------ |------- |----------------:|---------------:|---------------:|
|      **Verify** |      **1** |        **72.60 us** |      **0.2631 us** |      **0.2197 us** |
| BatchVerify |      1 |        99.82 us |      0.5704 us |      0.5336 us |
|      **Verify** |     **10** |        **72.75 us** |      **0.2526 us** |      **0.2239 us** |
| BatchVerify |     10 |       456.64 us |      4.3475 us |      3.8539 us |
|      **Verify** |    **100** |        **73.17 us** |      **0.2255 us** |      **0.2110 us** |
| BatchVerify |    100 |     4,056.27 us |     59.4508 us |     52.7016 us |
|      **Verify** |   **1000** |        **72.87 us** |      **0.8324 us** |      **0.7786 us** |
| BatchVerify |   1000 |    32,404.46 us |    387.2532 us |    343.2899 us |
|      **Verify** |  **10000** |        **72.88 us** |      **0.2871 us** |      **0.2686 us** |
| BatchVerify |  10000 |   310,945.05 us |  2,040.2936 us |  1,703.7375 us |
|      **Verify** | **100000** |        **73.14 us** |      **0.7779 us** |      **0.7277 us** |
| BatchVerify | 100000 | 3,142,881.71 us | 17,780.4375 us | 16,631.8323 us |
