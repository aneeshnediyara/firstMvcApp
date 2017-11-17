using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;
using firstMvcApp.Models;
using System.Web.Routing;

namespace firstMvcApp.Infrastructure
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        StandardKernel kernal;
        public NinjectControllerFactory()
        {
            kernal = new StandardKernel();
            AddBindings();
        }
        private void AddBindings()
        {
            kernal.Bind<IRepository<Product, int>>().To<EFProductRepository>();
            kernal.Bind<IRepository<Category, int>>().To<CategoryRepository>();
            kernal.Bind<IAuthProvider>().To<FormsAuthenticationProvider>();
        }
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return (controllerType == null) ? null : (IController)kernal.Get(controllerType);
        }
    }
}