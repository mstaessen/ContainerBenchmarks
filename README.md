# ContainerBenchmarks

Performance benchmark for the most popular Dependency Injection Containers (by NuGet downloads).

1. [Microsoft.Extensions.DependencyInjection](https://www.nuget.org/packages/Microsoft.Extensions.DependencyInjection) (about 54k downloads per day)
2. [Autofac](https://www.nuget.org/packages/Autofac) (about 8.5k downloads per day)
3. [Unity](https://www.nuget.org/packages/Unity) (about 6k downloads per day)
4. [Ninject](https://www.nuget.org/packages/Ninject) (about 3.2k downloads per day)
5. [StructureMap](https://www.nuget.org/packages/StructureMap) (about 2.2k downloads per day)
6. [SimpleInjector](https://www.nuget.org/packages/SimpleInjector) (about 2k downloads per day)
7. [Castle.Windsor](https://www.nuget.org/packages/Castle.Windsor) (about 1.8k downloads per day)

# Results

``` ini

BenchmarkDotNet=v0.11.5, OS=macOS Mojave 10.14.4 (18E226) [Darwin 18.5.0]
Intel Core i7-3520M CPU 2.90GHz (Ivy Bridge), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=2.2.204
  [Host]     : .NET Core 2.2.5 (CoreCLR 4.6.27617.05, CoreFX 4.6.27618.01), 64bit RyuJIT
  DefaultJob : .NET Core 2.2.5 (CoreCLR 4.6.27617.05, CoreFX 4.6.27618.01), 64bit RyuJIT


```
|         Method | Depth |         Mean |         Error |        StdDev |          Min |          Max |       Median |  Ratio | RatioSD | Rank |
|--------------- |------ |-------------:|--------------:|--------------:|-------------:|-------------:|-------------:|-------:|--------:|-----:|
|      **Microsoft** |     **0** |     **53.19 ns** |     **0.7895 ns** |     **0.6998 ns** |     **51.88 ns** |     **54.09 ns** |     **53.13 ns** |   **1.00** |    **0.00** |    **2** |
|        Autofac |     0 |    775.41 ns |     9.5344 ns |     8.9184 ns |    759.96 ns |    794.07 ns |    773.65 ns |  14.57 |    0.19 |    4 |
|        Windsor |     0 |  2,811.13 ns |    38.0518 ns |    33.7319 ns |  2,739.85 ns |  2,864.67 ns |  2,814.12 ns |  52.87 |    1.00 |    6 |
|          Unity |     0 |    188.55 ns |     2.7497 ns |     2.5721 ns |    183.24 ns |    192.28 ns |    188.98 ns |   3.55 |    0.08 |    3 |
|        Ninject |     0 |  8,680.10 ns |   169.5578 ns |   237.6964 ns |  8,311.88 ns |  9,103.99 ns |  8,738.05 ns | 161.46 |    5.21 |    7 |
|   StructureMap |     0 |    954.95 ns |    16.8358 ns |    15.7482 ns |    928.63 ns |    974.22 ns |    959.44 ns |  17.93 |    0.30 |    5 |
| SimpleInjector |     0 |     36.99 ns |     0.6655 ns |     0.6225 ns |     35.62 ns |     37.92 ns |     37.06 ns |   0.70 |    0.02 |    1 |
|                |       |              |               |               |              |              |              |        |         |      |
|      **Microsoft** |     **1** |     **61.25 ns** |     **0.9286 ns** |     **0.8686 ns** |     **60.04 ns** |     **62.94 ns** |     **61.17 ns** |   **1.00** |    **0.00** |    **2** |
|        Autofac |     1 |  1,554.01 ns |    23.4959 ns |    21.9781 ns |  1,516.62 ns |  1,592.42 ns |  1,557.83 ns |  25.38 |    0.59 |    4 |
|        Windsor |     1 |  9,736.58 ns |   174.9839 ns |   163.6800 ns |  9,497.76 ns | 10,039.85 ns |  9,774.69 ns | 159.00 |    3.70 |    6 |
|          Unity |     1 |    443.25 ns |     6.7805 ns |     6.3425 ns |    430.81 ns |    453.37 ns |    443.15 ns |   7.24 |    0.16 |    3 |
|        Ninject |     1 | 19,432.98 ns |   385.2253 ns |   732.9311 ns | 17,883.86 ns | 20,970.68 ns | 19,274.23 ns | 320.31 |   12.42 |    7 |
|   StructureMap |     1 |  1,660.99 ns |    17.5876 ns |    15.5909 ns |  1,634.19 ns |  1,677.52 ns |  1,667.59 ns |  27.18 |    0.49 |    5 |
| SimpleInjector |     1 |     44.34 ns |     0.7823 ns |     0.7318 ns |     43.18 ns |     45.84 ns |     44.29 ns |   0.72 |    0.02 |    1 |
|                |       |              |               |               |              |              |              |        |         |      |
|      **Microsoft** |     **5** |     **92.36 ns** |     **1.6493 ns** |     **1.3773 ns** |     **90.06 ns** |     **94.90 ns** |     **92.13 ns** |   **1.00** |    **0.00** |    **2** |
|        Autofac |     5 |  5,766.09 ns |   126.2513 ns |   302.4899 ns |  5,290.42 ns |  6,522.84 ns |  5,734.98 ns |  65.57 |    2.59 |    5 |
|        Windsor |     5 | 37,583.64 ns |   741.1838 ns |   793.0583 ns | 35,816.24 ns | 38,680.31 ns | 37,802.49 ns | 405.06 |   12.75 |    6 |
|          Unity |     5 |  1,700.55 ns |    31.6039 ns |    31.0392 ns |  1,635.44 ns |  1,756.91 ns |  1,702.73 ns |  18.40 |    0.43 |    3 |
|        Ninject |     5 | 56,580.21 ns | 1,126.9539 ns | 2,566.6443 ns | 52,067.18 ns | 62,406.09 ns | 56,613.85 ns | 641.61 |   28.75 |    7 |
|   StructureMap |     5 |  5,315.92 ns |    75.2878 ns |    70.4243 ns |  5,162.83 ns |  5,428.04 ns |  5,312.57 ns |  57.52 |    1.16 |    4 |
| SimpleInjector |     5 |     76.81 ns |     1.1808 ns |     1.1045 ns |     75.27 ns |     79.59 ns |     76.85 ns |   0.83 |    0.02 |    1 |

