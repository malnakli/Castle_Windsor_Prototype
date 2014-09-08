using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.Windsor;
using Castle.Windsor.Installer;
namespace Castle_Windsor_prototype
{
    public enum DayPeriod {morning, afternoon, night}
    class Program
    {
        static void Main(string[] args)
        {
            IWindsorContainer container = new WindsorContainer();
            // This just allows castle to look at the current assembly and look for implementations of the IWindsorInstaller interface
            container.Install(FromAssembly.This());
            var obj =   container.Resolve<ISchool>();
            obj.ToString();
            container.Release(obj);
          


            Console.ReadLine();

        }
    }
}
