using System;
using System.Configuration;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;

namespace UnityIoC
{
    class Program
    {
        static void Main(string[] args)
        {
            Basic();
            //PassByMethod();

            //PassByParameter();
            Console.ReadLine();
        }

        private static void Basic()
        {
            UnityContainer unityContainer = new UnityContainer();
            unityContainer.RegisterType<IReader, FileReader>();
            unityContainer.RegisterType<IWriter, ServiceWriter>();
            var service = unityContainer.Resolve<Service>();
            service.Read();
            service.Write();
        }

        private static void PassByMethod()
        {
            UnityContainer unityContainer = new UnityContainer();
            unityContainer.RegisterType<IReader, DBReader>();
            unityContainer.RegisterType<IWriter, ServiceWriter>();
            //dependency

            unityContainer.RegisterType<Service2>(
                new InjectionMethod("Read", unityContainer.Resolve<IReader>()),
                new InjectionMethod("Write", unityContainer.Resolve<IWriter>()));
            var service = unityContainer.Resolve<Service2>();
            service.TryRead();
            service.TryWrite();
        }

        private static void PassByParameter()
        {
            UnityContainer unityContainer = new UnityContainer();
            unityContainer.RegisterType<IReader, DBReader>();
            unityContainer.RegisterType<IWriter, ServiceWriter>();
            //dependency
            //unityContainer.RegisterType<Service3>(
            //    new InjectionProperty("Writer", unityContainer.Resolve<IWriter>()), 
            //    new InjectionProperty("Reader", unityContainer.Resolve<IReader>()));

            var service = unityContainer.Resolve<Service3>();
            service.Read();
            service.Write();
        }

        private static void InitByConfig()
        {
            var container = new UnityContainer();
            var section = (UnityConfigurationSection)ConfigurationManager.GetSection("unity");
            section.Configure(container);
            var service = container.Resolve<Service3>();
            service.Write();
            service.Read();
        }
        
    }
}
