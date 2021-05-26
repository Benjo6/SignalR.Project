using Microsoft.Owin;
using Owin;
using SignalR.Framework.Connection;
using System;
using System.Threading.Tasks;

[assembly: OwinStartup(typeof(SignalR.Framework.Startup))]

namespace SignalR.Framework
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //Hubs
            app.MapSignalR();

            //Persistent Connection
            app.MapSignalR<TrackerConnection>("/tracker");
        }
    }
}