using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace Hubs
{
    public interface IJsMethods
    {
        void PrintString(string msg);
    }

    public class ExampleHub : Hub
    {
        private static object _lock = new object();
        private static bool _isObserving;
        
        public ExampleHub()
        {
            lock (_lock)
            {
                if (!_isObserving)
                {
                    Observable.Interval(TimeSpan.FromSeconds(1))
                              .Subscribe(i => AllClients.PrintString("Everyone gets the time! " + DateTime.Now.ToString()));

                    _isObserving = true;
                }
            }


            Observable.Interval(TimeSpan.FromSeconds(1))
                              .Subscribe(i => CurrentClient.PrintString("But you get your id: " + Context.ConnectionId));
        }
        
        private IJsMethods AllClients
        {
            get { return (Clients.All as ClientProxy).AsStrongHub<IJsMethods>(); }
        }

        private IJsMethods CurrentClient
        {
            get
            {
                return (Clients.Client(Context.ConnectionId) as ConnectionIdProxy).AsStrongHub<IJsMethods>();
            }
        } 
    }


}
