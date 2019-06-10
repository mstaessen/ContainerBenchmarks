using System;
using Autofac;
using BenchmarkDotNet.Attributes;
using Castle.Windsor;
using Microsoft.Extensions.DependencyInjection;
using Ninject;
using SimpleInjector;
using Unity;

namespace ContainerBenchmarks.Benchmarks
{
    [SimpleJob]
    [MinColumn, MaxColumn, MeanColumn, MedianColumn, RankColumn]
    [RPlotExporter, MarkdownExporter, HtmlExporter]
    public class ResolveTransientBenchmark : ContainerBenchmark
    {
        private IServiceProvider microsoftContainer;
        private IContainer autofacContainer;
        private IWindsorContainer windsorContainer;
        private IUnityContainer unityContainer;
        private IKernel ninjectContainer;
        private StructureMap.IContainer structureMapContainer;
        private Container simpleInjectorContainer;

        [Params(0, 1, 5)]
        public int Depth { get; set; }

        [GlobalSetup]
        public void GlobalSetup()
        {
            microsoftContainer = BuildMicrosoftContainer();
            autofacContainer = BuildAutofacContainer();
            windsorContainer = BuildWindsorContainer();
            unityContainer = BuildUnityContainer();
            ninjectContainer = BuildNinjectContainer();
            structureMapContainer = BuildStructureMapContainer();
            simpleInjectorContainer = BuildSimpleInjectorContainer();
        }

        [Benchmark(Baseline = true)]
        public void Microsoft()
        {
            microsoftContainer.GetRequiredService(Types[Depth].serviceType);
        }

        [Benchmark]
        public void Autofac()
        {
            autofacContainer.Resolve(Types[Depth].serviceType);
        }

        [Benchmark]
        public void Windsor()
        {
            windsorContainer.Resolve(Types[Depth].serviceType);
        }

        [Benchmark]
        public void Unity()
        {
            unityContainer.Resolve(Types[Depth].serviceType);
        }

        [Benchmark]
        public void Ninject()
        {
            ninjectContainer.GetService(Types[Depth].serviceType);
        }

        [Benchmark]
        public void StructureMap()
        {
            structureMapContainer.GetInstance(Types[Depth].serviceType);
        }

        [Benchmark]
        public void SimpleInjector()
        {
            simpleInjectorContainer.GetInstance(Types[Depth].serviceType);
        }
    }
}