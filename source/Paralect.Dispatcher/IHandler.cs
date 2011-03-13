using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Paralect.Dispatcher
{
    public interface IHandler<T>
    {
        void Handle(T message);
    }
}
