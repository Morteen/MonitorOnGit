using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;
using System.Web.Http.Cors;

[assembly: OwinStartup(typeof(MonitorBackend.Startup))]

namespace MonitorBackend
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.MapSignalR();
            var cors = new EnableCorsAttribute("http://localhost:3000", "*", "*");
            SignalRConfig.Register(app, cors);


        }




    }
}
