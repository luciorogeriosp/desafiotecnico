using ProcessoSeletivoDataContext.DAL;
using ProcessoSeletivoDataContext.Interfaces;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ProcessoSeletivoDataContext
{
    public static class ObjectFactory1
    {
        private static readonly Lazy<Container> _containerBuilder =
                new Lazy<Container>(defaultContainer, LazyThreadSafetyMode.ExecutionAndPublication);

        public static IContainer Container
        {
            get {
                return _containerBuilder.Value;
            }
        }

        private static Container defaultContainer()
        {
            return new Container(x =>
            {
                x.Scan(scan =>
                {
                    scan.WithDefaultConventions();
                    scan.TheCallingAssembly();
                });

                x.For<INivelExperienciaDAL>().Use<NivelExperienciaDAL>();
                x.For<IVagaDAL>().Use<VagaDAL>();
            });
        }
    }
}
