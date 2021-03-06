﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using Microsoft.Practices.Unity;

namespace Paralect.Dispatcher
{
    public class HandlerRegistrator
    {
        private readonly IUnityContainer _container;

        /// <summary>
        /// Message type -> Handler type
        /// </summary>
        private Dictionary<Type, List<Type>> _subscription = new Dictionary<Type, List<Type>>();

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Object"/> class.
        /// </summary>
        public HandlerRegistrator(IUnityContainer container)
        {
            _container = container;
        }

        public void RegisterAssemblies(Assembly[] assemblies)
        {
            var searchTarget = typeof(IHandler<>);

            var dict = assemblies.SelectMany(a => a.GetTypes())
                .SelectMany(t => t.GetInterfaces()
                                    .Where(i => i.IsGenericType
                                        && (i.GetGenericTypeDefinition() == searchTarget)
                                        && !i.ContainsGenericParameters),
                            (t, i) => new { Key = i.GetGenericArguments()[0], Value = t })
                .GroupBy(x => x.Key, x => x.Value)
                .ToDictionary(g => g.Key, g => g.ToList());

            _subscription = dict; 
        }

        public List<Type> GetHandlersType(Type messageType)
        {
            String errorMessage = String.Format("Handler for type {0} don't found.", messageType.FullName);

            if (!_subscription.ContainsKey(messageType))
                throw new Exception(errorMessage);

            var handlers = _subscription[messageType];

            if (handlers.Count < 1)
                throw new Exception(errorMessage);

            return handlers;
        }
    }
}
