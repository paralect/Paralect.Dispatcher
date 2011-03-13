using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Unity;
using Paralect.Dispatcher.Test.Messages;

namespace Paralect.Dispatcher.Test.Handlers
{
    public class SimpleHandler : 
        IHandler<SimpleMessage>,
        IHandler<SimpleMessage2>
    {
        [Dependency]
        public Tracker Tracker { get; set; }

        public void Handle(SimpleMessage message)
        {
            Tracker.Handlers.Add(message.GetType());
        }

        public void Handle(SimpleMessage2 message)
        {
            Tracker.Handlers.Add(message.GetType());
        }
    }
}
