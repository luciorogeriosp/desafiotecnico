using ProcessoSeletivoDataContext.DAL;
using ProcessoSeletivoDataContext.Interfaces;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ProcessoSeletivoDataContext
{
    public class IoC<T> where T : class
    {
        private static Container _container;
        private static Container Container
        {
            get
            {
                if (_container == null)
                {
                    InitializeContainer();
                }
                    
                return _container;
            }
        }

        private static void InitializeContainer()
        {
            #region Explicito

            

            _container = new Container(x =>
            {                
                x.Scan(scan =>
                {
                    scan.TheCallingAssembly();
                    scan.WithDefaultConventions();
                });

                x.For<INivelExperienciaDAL>().Use<NivelExperienciaDAL>();
                x.For<IVagaDAL>().Use<VagaDAL>();
            });

            #endregion
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
                x.For<IPessoaDAL>().Use<PessoaDAL>();
            });
        }

        public static T ObterInstancia()
        {
            return Container.GetInstance<T>();
        }

        public static T ObterInstancia(ProcessoSeletivoContext context)
        {
            StructureMap.Pipeline.ExplicitArguments args = new StructureMap.Pipeline.ExplicitArguments();
            args.Set(typeof(ProcessoSeletivoContext), context);
            return Container.GetInstance<T>(args);
        }
    }
}
