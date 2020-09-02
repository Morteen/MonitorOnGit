﻿using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SinalRtest.Hubs
{
    public class MessageHub:Hub
    {
        [EnableCors()]
        public async Task SendMessage(string message)
        {
            await Clients.All.SendAsync("Send",  message);
        }
    }
}
