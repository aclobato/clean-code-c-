using Autofac;
using GildedRose.Application.Factories;
using GildedRose.Application.Interfaces;
using GildedRose.Application.Services;
using GildedRose.Application.Strategies;

namespace GildedRose.Infraestructure.CrossCutting.IOC
{
    public static class ConfigurationIoc
    {

        public static void Load(ContainerBuilder builder)
        {
            builder.RegisterType<QualityUpdatingService>().As<IQualityUpdatingService>();

            builder.RegisterType<QualityUpdatingStrategyFactory>().As<IQualityUpdatingStrategyFactory>();

            builder.RegisterType<AgedBrieStrategy>().As<IQualityUpdatingStrategy>();
            builder.RegisterType<BackstagePassesStrategy>().As<IQualityUpdatingStrategy>();
            builder.RegisterType<ConjuredStrategy>().As<IQualityUpdatingStrategy>();
            builder.RegisterType<NormalItemStrategy>().As<IQualityUpdatingStrategy>();
            builder.RegisterType<SulfurasStrategy>().As<IQualityUpdatingStrategy>();
        }
    }
}
