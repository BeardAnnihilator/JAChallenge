﻿using JobAdderAssignement.Service;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobAdderAssignement.Web.App_Start
{
    public class NinjectResolver : System.Web.Mvc.IDependencyResolver
    {
        private readonly IKernel _kernel;

        public NinjectResolver()
        {
            _kernel = new StandardKernel();
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
            this._kernel.Bind<IProcessedJobService>().To<ProcessedJobService>();
        }
    }
}