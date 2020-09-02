using Microsoft.AspNet.SignalR;
using MonitorBackend.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MonitorBackend.Controllers
{
    public class MonitorController : ApiController
    {
        public MonitorController()
        {
            
        }
        // GET: api/Monitor
        public IEnumerable<string> Get()
        {
            var hubContext = GlobalHost.ConnectionManager.GetHubContext<MonitorHub>();
            hubContext.Clients.All.send("Called from Controller");
            return new string[] { "value1", "Dette er hubContext :"+hubContext.Clients.All.send("Test")};
        }

        // GET: api/Monitor/5
        public string Get(int id)
        {
            var hubContext = GlobalHost.ConnectionManager.GetHubContext<MonitorHub>();
            hubContext.Clients.All.send("Called from Controller");
            return "Value " + id;
        }
          
     

        // POST: api/Monitor
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Monitor/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Monitor/5
        public void Delete(int id)
        {
        }
    }
}
