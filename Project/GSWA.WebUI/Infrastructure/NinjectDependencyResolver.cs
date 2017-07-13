using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;
using GSWA.Domain.Abstract;
using GSWA.Domain.Concrete;

namespace GSWA.WebUI.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public static NinjectDependencyResolver Instance;


        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
            Instance = this;
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            // Здесь размещаются привязки
            kernel.Bind(typeof(IRepository<>)).To(typeof(EFRepository<>));
            kernel.Bind<ICatalog>().To<Catalog>();
            kernel.Bind<ICart>().To<Cart>();
            kernel.Bind<IOrderManager>().To<OrderManager>();

        }
    }
}