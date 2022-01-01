using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DependenceInjection.Demo2
{
    public static class DemoP2
    {
        /*
        * Thư viện Dependency Injection
        * DI Container: ServiceCollection
        * - Đăng kí  các dịch vụ ( các lớp)
        * - Severice Provider --> Get Severice
        */
        public static IClassB CreateB2(IServiceProvider provider)
        {
            var b2 = new ClassB2(provider.GetService<IClassC>(),
                                "Thực hiên trong B2");
            return b2;

        }

        public static void Singleton(ServiceCollection services)
        {
            services.AddSingleton<IClassC, ClassC1>();

            var provider = services.BuildServiceProvider();
            for (int i = 0; i < 5; i++)
            {
                IClassC C = provider.GetService<IClassC>();
                Console.WriteLine(C.GetHashCode());
            }
        }

        public static void Delegate(ServiceCollection services)
        {
            services.AddSingleton<ClassA, ClassA>();

            services.AddSingleton<IClassB, ClassB2>(
                (provider) => {
                    var b2 = new ClassB2(provider.GetService<IClassC>(), "Thực hiên trong B2");
                    return b2;
                });
            services.AddSingleton<IClassC, ClassC1>();

            var provider = services.BuildServiceProvider();

            ClassA a = provider.GetService<ClassA>();
            a.ActionA();
        }
        public static void Factory(ServiceCollection services)
        {
            services.AddSingleton<MyService>();
            services.Configure<MyServiceOptions>(
                (MyServiceOptions options) => {
                    options.Data1 = "Xin chao cac ban ";
                    options.Data2 = 2022;
                });
            services.AddSingleton<MyService>();
            var provider = services.BuildServiceProvider();

            var myservice = provider.GetService<MyService>();
            myservice.PrintData();
        }

        public static void Options(ServiceCollection services)
        {
            services.AddSingleton<ClassA, ClassA>();
            // Factory
            services.AddSingleton<IClassB>(CreateB2);
            services.AddSingleton<IClassC, ClassC1>();

            var provider = services.BuildServiceProvider();

            ClassA a = provider.GetService<ClassA>();
            a.ActionA();
        }

        public static void InjectFileJson()
        {
            IConfigurationRoot configurationRoot;
            ConfigurationBuilder configbuilder = new ConfigurationBuilder();
            configbuilder.SetBasePath(Directory.GetCurrentDirectory());
            configbuilder.AddJsonFile("C:\\Users\\Admin\\Documents\\CSharpAdvanced\\CSharpAdvanced\\DependenceInjection\\Cauhinh.json");

            configurationRoot = configbuilder.Build();

            var key1 = configurationRoot.GetSection("section1")
                                        .GetSection("key1").Value;

            var data1 = configurationRoot.GetSection("MySericeOptions")
                                      .GetSection("data1").Value;

            Console.WriteLine($"{key1} : {data1}");


        }

        public static void Init()
        {
            // Đăng kí các dịch vụ  ...
            //IClassC, ClassC, ClassC1
            var services = new ServiceCollection();


            //Singleton
            // Singleton(services);

            // ClassA
            //IClassC, ClassC1,ClassC
            //IClassB,ClassB,ClassB1,ClassB2....


            //Delegate
            //Delegate(services);

            //// Factory
            //Factory(services);

            //Options
            //Options(services);

            // Inject File Json
            InjectFileJson();

        }

    }
}
