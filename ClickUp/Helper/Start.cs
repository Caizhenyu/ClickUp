using System;
using System.Collections.Generic;
using System.Text;

namespace ClickUp.Helper
{
    public class StartUrlEventArgs : EventArgs
    {
        public StartUrlEventArgs(string url)
        {
            Url = url;
        }
        public string Url { get; private set; }
    }
    class Start
    {
        public event EventHandler<StartUrlEventArgs> NewStartUrlInfo;

        public void NewStart(string str)
        {
            Console.WriteLine($"{DateTime.Now} Start with {str}");
            RaiseNewStartEvent(str);
        }

        protected virtual void RaiseNewStartEvent(string str)
        {
            EventHandler<StartUrlEventArgs> newStartEvent = NewStartUrlInfo;
            newStartEvent?.Invoke(this, new StartUrlEventArgs(str));
        }
    }
}
