using Sharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SharpIn.Windows.Test
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            var container = new SharpIocContainter();
            container.Register<ILog, Logger>(LifeCycle.Singleton);

            bool xx = container.IsRegistered<ILog>();
            //  var xx = container.Resolve<ILog>();

            //   Application.Run(new Form1(xx));


        }
    }
}
