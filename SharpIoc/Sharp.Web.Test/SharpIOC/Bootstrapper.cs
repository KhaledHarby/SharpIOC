using Sharp.Web.Test.Controllers;

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sharp.Web.Test.SharpIOC
{
    public static class BootStrapper
    {
        public static void Configure(IContainer container)
        {
            container.Register<DbContext, Models.masterEntities>(LifeCycle.Singleton);
            container.Register<HomeController, HomeController>(LifeCycle.Transient);
        }
    }
}