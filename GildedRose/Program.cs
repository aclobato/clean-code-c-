
using Autofac;
using GildedRose.Infraestructure.CrossCutting.IOC;

namespace GildedRoseKata
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var container = ConfigureContainer();
            var application = container.Resolve<ApplicationGildedRose>();

            application.Run(args); // Pass 
        }

        private static IContainer ConfigureContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<ApplicationGildedRose>().AsSelf();
            builder.RegisterModule(new ModuleIoc());

            return builder.Build();
        }
    }
}
