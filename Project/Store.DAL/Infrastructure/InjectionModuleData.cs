using Ninject.Modules;
using Ninject.Web.Common;
using Store.DAL.Concrete;
using Store.DAL.Interfaces;
using Store.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.DAL.Infrastructure
{
    public class InjectionModuleData : NinjectModule
    {
        public override void Load()
        {
            Kernel.Bind(typeof(IRepository<>)).To(typeof(EFRepository<>)).InRequestScope();
        }
    }
}