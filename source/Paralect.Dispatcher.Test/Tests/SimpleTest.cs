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
            var tracker = new Tracker();
            unity.RegisterInstance(tracker);

            var registrator = new HandlerRegistrator(unity);
            registrator.RegisterAssemblies(new[] { Assembly.GetExecutingAssembly() });

            var dispatcher = new Dispatcher(unity, registrator);

            var message = new SimpleMessage();
            dispatcher.Dispatch(message);

            var message2 = new SimpleMessage2();
            dispatcher.Dispatch(message2);

            Assert.AreEqual(2, tracker.Handlers.Count);
            Assert.AreEqual(typeof(SimpleMessage), tracker.Handlers[0]);
            Assert.AreEqual(typeof(SimpleMessage2), tracker.Handlers[1]);
        }
    }
}
