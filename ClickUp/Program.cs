using ClickUp.Helper;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Timers;

namespace ClickUp
{
    class Program
    {
        public static IConfiguration _configuration { get; set; }
        private static System.Timers.Timer _timer;
        private static string _url;
        private static Start _starter = new Start();

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json");

            _configuration = builder.Build();
            _url = _configuration["ClickUrl"];

            if(string.IsNullOrEmpty(_url))
            {
                Console.WriteLine("ClickUrl is null");
                Console.ReadKey();
                return;
            }

            SetTimer();

            Console.ReadKey();

            _timer.Stop();
            _timer.Dispose();

           
        }

        private static void SetTimer()
        {
            // Create a timer with a two second interval.
            _timer = new System.Timers.Timer(2000);
            // Hook up the Elapsed event for the timer. 
            _timer.Elapsed += OnTimedEvent;
            _timer.AutoReset = true;
            
            _timer.Enabled = true;
        }

        private static void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            _starter.NewStartUrlInfo += Click.ClickUrl;
            _starter.NewStart(_url);

            var random = new Random();
            _timer.Interval = random.Next(1000 * 10, 1000 * 60);
        }
    }
}
