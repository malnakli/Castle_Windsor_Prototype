using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Castle.Windsor;
using Castle_Windsor_prototype;
using Castle.MicroKernel;

namespace Castle_Windsor_test
{
    [TestClass]
    public class UnitTest1
    {
       
        private IWindsorContainer container;

        [TestInitialize]
        public void Initialization_Method()
        {
            container = new WindsorContainer().Install(new Installers());
        }
        [TestMethod]
        [TestCategory("DI")]
        [Priority(1)]
        public void TestMethod1()
        {
            var allHandlers = GetAllHandlers(container);
            Assert.IsNotNull(allHandlers);
            Assert.AreEqual(6, allHandlers.Length);

        
                
           }
        [TestMethod]
        [TestCategory("DI")]
        [Priority(2)]
        public void TestSchoolObject()
        {
            var obj = container.Resolve<ISchool>();
            Assert.IsInstanceOfType(obj, typeof(School));
            container.Release(obj);

        }

        [TestCleanup]
        public void Clearnup() 
        {
            container.Dispose();
            
        }

        // private methods
        private IHandler[] GetAllHandlers(IWindsorContainer container)
        {
            return GetHandlersFor(typeof(object), container);
        }

        private IHandler[] GetHandlersFor(Type type, IWindsorContainer container)
        {
            return container.Kernel.GetAssignableHandlers(type);
        }
    }
    
}
