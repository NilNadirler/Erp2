using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concentre;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using DataAccess.Abstract;
using DataAccess.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolvers
{
    public class AutofacBusinessModule :Module
    {

        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterType<ErpManager>().As<IErpService>();
            builder.RegisterType<EfErpDal>().As<IErpDal>();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }

      }
}
