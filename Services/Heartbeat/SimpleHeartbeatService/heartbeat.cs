using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;


namespace SimpleHeartbeatService
{
   public class Heartbeat
    {
        private readonly Timer _timer;

        public Heartbeat()
        {
            _timer = new Timer(10000) { AutoReset = true };
            _timer.Elapsed += TimerElapsed;
        }
         static HttpClient client = new HttpClient();
    


        public class MyService
        {
            public string Id { get; set; }
            public int TmsId { get; set; }
            public int ServiceId { get; set; }
            public string displayName { get; set; }
            public string name { get; set; }
            public string  status { get; set; }
            public string MachineName { get; set; }


        }


        private static async Task RunAsync(MyService service)
        {




            var connection = new HubConnectionBuilder()
           .WithUrl("https://localhost:44306/Message")
            .Build();




            await connection.StartAsync();

          

            await connection.InvokeAsync("SendMessage", "Webpage", service);



           /* using (var client = new HttpClient())
            {


                client.BaseAddress = new Uri("https://localhost:44306/Message");
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("OAuth","xyz");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


               
                

               

                HttpResponseMessage response;
                
               
                response = await client.PostAsJsonAsync("https://localhost:44306/Message", service);
                if (response.IsSuccessStatusCode)
                {
                    
                    Console.WriteLine("Denne tjenesten kjører ikke:" + service.displayName);
                }
                else { Console.WriteLine("Det er noe galt: " + response.StatusCode); }

            }*/
        }



        private void TimerElapsed(object sender, ElapsedEventArgs e)
        {
        

            string[] MyServices = { "CscService", "ose64", "MozillaMaintenance", "XboxNetApiSvc" };
            foreach(string service in MyServices)
            {
                var srv = new ServiceController(service);
                if (srv.Status != ServiceControllerStatus.Running)
                {

                    Random rnd = new Random();
                    int randomTMSId = rnd.Next(1,5);
                   Console.WriteLine("Dette blir TMS Id:"+ randomTMSId );
                   int  srvId= 1;
                    if( srv.ServiceName=="XboxNetApiSvc"){

                          srvId=7;
                        }
                    else if(srv.ServiceName=="ose64"){

                            srvId=6;
                    }else if( srv.ServiceName=="MozillaMaintenance"){
                           srvId=5;
                    }
                    
                     
                    
                     


                RunAsync(new MyService { ServiceId =srvId,TmsId = randomTMSId,displayName = srv.DisplayName, status=srv.Status.ToString(),name = srv.ServiceName,MachineName=srv.MachineName}).Wait();
                Console.WriteLine("RunAsync kjører");
                string[] lines = new string[]{ "Servicenavn: "+srv.DisplayName.ToString()+" Status:"+ srv.Status.ToString()+"  Maskinnavn:" + srv.MachineName+" TMSID:" +randomTMSId };
                File.AppendAllLines(@"C:\Users\morten.olsen\Documents\Morten\Heartbeat\Heartbeat.txt", lines);

                }



               


        
             }
                   
                  
                

               

               


           }

           
         
           
          
          
            //if (srv.Status != ServiceControllerStatus.Running) ;
                //srv.Start();
        
        public void Start()
        {
            _timer.Start();
 
        }
        public void Stop()
        {
            _timer.Stop();
        }
    }





    
}
