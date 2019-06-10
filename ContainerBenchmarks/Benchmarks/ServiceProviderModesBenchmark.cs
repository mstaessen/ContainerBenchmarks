using System;
using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.DependencyInjection;

namespace ContainerBenchmarks.Benchmarks
{
    /// <summary>
    /// Not really relevant. Although there are 4 modes for the Container, they are not publicly exposed (yet). 
    /// </summary>
    [SimpleJob]
    [MinColumn, MaxColumn, MeanColumn, MedianColumn, RankColumn]
    [RPlotExporter]
    public class ServiceProviderModesBenchmark : ContainerBenchmark
    {
        private IServiceProvider ServiceProvider { get; set; }

        [Params(0, 1, 5)]
        public int Depth { get; set; }

        [ParamsAllValues]
        public string Mode { get; set; }

        [GlobalSetup]
        public void GlobalSetup()
        {
            ServiceProvider = BuildMicrosoftContainer(new ServiceProviderOptions( /* Can't set Mode.. */));
        }

        [Benchmark]
        public void GetService()
        {
            ServiceProvider.GetRequiredService(Types[Depth].serviceType);
        }
    }
}