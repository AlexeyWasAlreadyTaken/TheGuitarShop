using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;
using Store.BLL.Interfaces;
using Store.BLL.Services;
using System.Reflection;
//using GSWA.Domain.Abstract;
//using GSWA.Domain.Concrete;

namespace Store.WEB.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel _kernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            _kernel = kernelParam;
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return _kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            _kernel.Bind<ICatalog>().To<Catalog>();
            _kernel.Bind<IOrderManager>().To<OrderManager>();
            _kernel.Bind<INewsManager>().To<NewsManager>();
            _kernel.Bind<ICart>().To<Cart>();

        }
    }
}