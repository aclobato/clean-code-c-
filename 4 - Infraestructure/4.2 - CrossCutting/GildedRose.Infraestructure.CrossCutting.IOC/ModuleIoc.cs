using Autofac;

namespace GildedRose.Infraestructure.CrossCutting.IOC
{
    public class ModuleIoc: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            ConfigurationIoc.Load(builder);
        }
    }
}
