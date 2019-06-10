using BenchmarkDotNet.Running;
using ContainerBenchmarks.Benchmarks;

namespace ContainerBenchmarks
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<ResolveTransientBenchmark>();
        }
    }
}