
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Sharp.Web.Test.SharpIOC
{
    public class IocFactory : DefaultControllerFactory
    {
        private readonly IContainer container;

        public IocFactory(IContainer container)
        {
            this.container = container;
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return container.Resolve(controllerType) as Controller;
        }
    }
}