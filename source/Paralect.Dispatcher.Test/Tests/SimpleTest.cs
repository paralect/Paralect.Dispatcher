using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Microsoft.Practices.Unity;
using NUnit.Framework;
using System.Linq;
using Paralect.Dispatcher.Test.Messages;

namespace Paralect.Dispatcher.Test.Tests
{
    [TestFixture()]
    public class SimpleTest
    {
        [Test]
        public void Simple()
        {
            var unity = new UnityContainer();
            var registar = new HandlerRegistrator(unity);
            registar.RegisterAssemblies(new Assembly[] { Assembly.GetExecutingAssembly() });

            var dispatcher = new Dispatcher(unity, registar);

            var message = new SimpleMessage();
            dispatcher.Dispatch(message);

            var message2 = new SimpleMessage2();
            dispatcher.Dispatch(message2);


        }
    }
}
