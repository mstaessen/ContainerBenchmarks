namespace ContainerBenchmarks.Services
{
    public class Service0 : IService0 { }

    public class Service1 : IService1
    {
        public IService0 S0 { get; }

        public Service1(IService0 s0)
        {
            S0 = s0;
        }
    }

    public class Service2 : IService2
    {
        public IService1 S1 { get; }

        public Service2(IService1 s1)
        {
            S1 = s1;
        }
    }

    public class Service3 : IService3
    {
        public IService2 S2 { get; }

        public Service3(IService2 s2)
        {
            S2 = s2;
        }
    }

    public class Service4 : IService4
    {
        public IService3 S3 { get; }

        public Service4(IService3 s3)
        {
            S3 = s3;
        }
    }

    public class Service5 : IService5
    {
        public IService4 S4 { get; }

        public Service5(IService4 s4)
        {
            this.S4 = s4;
        }
    }
}