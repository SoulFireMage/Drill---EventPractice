using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eventPractice
    {
    public class CustomEventArgs : EventArgs
        {
        public CustomEventArgs(string s)
            {
            message = s;
            }
        private string message;

        public string Message
            {
            get { return message; }
            set { message = value; }
            }
        }

    // Class that publishes an event
    class Publisher
        {

        public event EventHandler<CustomEventArgs> RaiseCustomEvent;

        public void DoSomething()
            {
              OnRaiseCustomEvent(new CustomEventArgs("Did something"));
            }

        
        protected virtual void OnRaiseCustomEvent(CustomEventArgs e)
            {
            EventHandler<CustomEventArgs> handler = RaiseCustomEvent;
                         
            if (handler != null)
                {
                e.Message += String.Format(" at {0}", DateTime.Now.ToString());
                handler(this, e);
                }
            }
        }

    }
