using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.DynamicProxy;
using Microsoft.AspNet.SignalR.Hubs;
using Microsoft.AspNet.SignalR.Hubs;

namespace Hubs
{
    public static class HubExtensions
    {
        private static readonly ProxyGenerator Generator = new ProxyGenerator();

        public static T AsStrongHub<T>(this IClientProxy source)
        {
            return (T)Generator.CreateInterfaceProxyWithoutTarget(typeof(T), new StrongClientProxy(source));
        }
    }

    public class StrongClientProxy : IInterceptor
    {
        public IClientProxy Source { get; set; }

        public StrongClientProxy(IClientProxy source)
        {
            Source = source;
        }

        public void Intercept(IInvocation invocation)
        {
            var methodName = StringUtil.FirstLower(invocation.Method.Name);

            Source.Invoke(methodName, invocation.Arguments);
        }
    }
}
