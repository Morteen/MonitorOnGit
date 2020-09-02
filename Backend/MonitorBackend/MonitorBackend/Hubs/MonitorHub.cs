using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace MonitorBackend.Hubs
{
    public class MonitorHub:Hub
    {
        public async Task SendToAll(string message)
        {
            await Clients.All.SendAsync("ReciveMessage", message);
        }
    }
}