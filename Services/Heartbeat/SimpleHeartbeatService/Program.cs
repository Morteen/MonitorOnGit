using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace SimpleHeartbeatService
{
    class Program
    {
        static void Main(string[] args)
        {
            var exitCode = HostFactory.Run(x =>
             {
                 x.Service<Heartbeat>(s => {
                     s.ConstructUsing(heartbeat => new Heartbeat());
                     s.WhenStarted(hearbeat => hearbeat.Start());
                     s.WhenStopped(hearbeat => hearbeat.Stop());
                 });
                 x.RunAsLocalSystem();
                 x.SetInstanceName("HeartbeatService");
                 x.SetDisplayName("Heartbeat service");
                 x.SetDescription("Dette er en service som jeg har laget");

             });

            int exitCodeValue = (int)Convert.ChangeType(exitCode, exitCode.GetTypeCode());
            Environment.ExitCode = exitCodeValue;

        }
    }
}
