using System;
using Autofac;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using ContainerBenchmarks.Services;
using Microsoft.Extensions.DependencyInjection;
using StructureMap;
using Unity;
using UnityContainer = Unity.UnityContainer;
using IWindsorContainer = Castle.Windsor.IWindsorContainer;
using IAutofacContainer = Autofac.IContainer;
using StructureMapContainer = StructureMap.Container;
using SimpleInjectorContainer = SimpleInjector.Container;
using NinjectContainer = Ninject.StandardKernel;

namespace ContainerBenchmarks.Benchmarks
{
    public abstract class ContainerBenchmark
    {
        protected static readonly (Type serviceType, Type implementationType)[] Types = {
            (typeof(IService0), typeof(Service0)),
            (typeof(IService1), typeof(Service1)),
            (typeof(IService2), typeof(Service2)),
            (typeof(IService3), typeof(Service3)),
            (typeof(IService4), typeof(Service4)),
            (typeof(IService5), typeof(Service5)),
        };

        protected static IServiceProvider BuildMicrosoftContainer(ServiceProviderOptions options = null)
        {
            var services = new ServiceCollection();
            foreach (var (serviceType, implementationType) in Types) {
                services.AddTransient(serviceType, implementationType);
            }

            return options == null
                ? services.BuildServiceProvider()
                : services.BuildServiceProvider(options);
        }

        protected static IAutofacContainer BuildAutofacContainer()
        {
            var containerBuilder = new ContainerBuilder();
            foreach (var (serviceType, implementationType) in Types) {
                containerBuilder.RegisterType(implementationType).As(serviceType);
            }

            return containerBuilder.Build();
        }

        protected static IWindsorContainer BuildWindsorContainer()
        {
            var container = new WindsorContainer();
            foreach (var (serviceType, implementationType) in Types) {
                container.Register(Component.For(serviceType)
                    .ImplementedBy(implementationType).LifestyleTransient());
            }

            return container;
        }

        protected static UnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();
            foreach (var (serviceType, implementationType) in Types) {
                container.RegisterType(serviceType, implementationType);
            }

            return container;
        }

        protected static NinjectContainer BuildNinjectContainer()
        {
            var container = new NinjectContainer();
            foreach (var (serviceType, implementationType) in Types) {
                container.Bind(serviceType).To(implementationType);
            }

            return container;
        }

        protected static StructureMapContainer BuildStructureMapContainer()
        {
            var container = new Container(_ => {
                foreach (var (serviceType, implementationType) in Types) {
                    _.For(serviceType).Use(implementationType);
                }
            });
            return container;
        }

        protected static SimpleInjectorContainer BuildSimpleInjectorContainer()
        {
            var container = new SimpleInjectorContainer();
            foreach (var (serviceType, implementationType) in Types) {
                container.Register(serviceType, implementationType);
            }

            return container;
        }
    }
}