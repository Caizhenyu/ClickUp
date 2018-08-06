using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;

namespace ClickUp.Helper
{
    class Click
    {
        private static WebClient _webClient = new WebClient();
        

        public static void ClickUrl(object sender, StartUrlEventArgs eventArgs)
        {
            //string strHTML = "";
            
            //Stream myStream = _webClient.OpenRead(eventArgs.Url);
            //StreamReader sr = new StreamReader(myStream, System.Text.Encoding.GetEncoding("utf-8"));
            //strHTML = sr.ReadToEnd();
            //myStream.Close();

            _webClient.OpenRead(eventArgs.Url);
            Console.WriteLine($"Click : {eventArgs.Url}");          
        }
    }
}
