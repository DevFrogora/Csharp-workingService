using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ConsoleApp2
{
    public class HeartBeat
    {
        private readonly Timer _timer;

        public HeartBeat()
        {
            _timer = new Timer(1000) { AutoReset = true };
            // 1 sec interval , it will start after every 1 sec
            _timer.Elapsed += TimerElapsed;
        }

        private void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            string[] lines = new string[] { DateTime.Now.ToString() };
            File.AppendAllLines(@"C:\Temp\Demos\HeartBeat.txt", lines);
        }

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
