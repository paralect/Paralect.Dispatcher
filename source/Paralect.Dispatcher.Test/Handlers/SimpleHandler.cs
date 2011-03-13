using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Paralect.Dispatcher.Test.Messages;

namespace Paralect.Dispatcher.Test.Handlers
{
    public class SimpleHandler : IHandler<SimpleMessage>,
        IHandler<SimpleMessage2>

    {
        public void Handle(SimpleMessage message)
        {
            var i = 6;
        }

        public void Handle(SimpleMessage2 message)
        {
            var a = 7;
        }
    }
}
