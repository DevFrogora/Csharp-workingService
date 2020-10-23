using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
        
                Console.WriteLine("Hello World!");
                var exitCode = HostFactory.Run(x =>
                {
                    x.Service<HeartBeat>(s =>
                    {
                        s.ConstructUsing(heartbeat => new HeartBeat());
                        s.WhenStarted(heartbeat => heartbeat.Start());
                        s.WhenStopped(heartbeat => heartbeat.Stop());
                    });

                    x.RunAsLocalSystem();

                    x.SetServiceName("HeartbeatService");
                    x.SetDisplayName("Heartbeat Service");
                    x.SetDescription("it will let you know that computer is alive or not");
                });

                int exitCodeValue = (int)Convert.ChangeType(exitCode, exitCode.GetTypeCode());
                Environment.ExitCode = exitCodeValue;


            
        }
    }
}
