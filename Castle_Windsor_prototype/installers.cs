using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.MicroKernel.Registration;
using Castle.Facilities.TypedFactory;
using Castle.MicroKernel.Resolvers.SpecializedResolvers;
using Castle.DynamicProxy;
using Castle.Core;

namespace Castle_Windsor_prototype
{
    public class Installers : IWindsorInstaller
    {
        public void Install(Castle.Windsor.IWindsorContainer container, Castle.MicroKernel.SubSystems.Configuration.IConfigurationStore store)
        {
          //  container.AddFacility<TypedFactoryFacility>();
            // when the lifestyle is not set explicitly, the default Singleton lifestyle will be used.
           
            container
             //   .Register(Component.For<IMYFirstFactory>().AsFactory())
                
                .Register(Component.For<IInterceptor>().ImplementedBy<GraduateCourseInterceptor>().Named("GCI"))
                .Register(Component.For<ISchool>().ImplementedBy<School>().LifestyleTransient())

                .Register(Component.For<IDepartment>().ImplementedBy<Department>().LifestyleTransient())
                // Singleton is the default lifestyle
              // .Register(Classes.FromThisAssembly().BasedOn<ICourse>().WithService.Base().LifestyleTransient())
                .Register(Component.For<ICourse>().ImplementedBy<Course>().DependsOn(Property.ForKey("night").Eq(DayPeriod.night)).LifestyleTransient())
                 .Register(Component.For<ICourse>().ImplementedBy<Course2>().DependsOn(Property.ForKey("morning").Eq(DayPeriod.morning)).LifestyleTransient().Interceptors(InterceptorReference.ForKey("GCI")).Anywhere)

                .Register(Component.For<ITeacher>().ImplementedBy<Teacher>().LifestyleTransient());
            container.Kernel.Resolver.AddSubResolver(new CollectionResolver(container.Kernel, true));
           container.Resolve<ICourse>();

        }
    }
}
