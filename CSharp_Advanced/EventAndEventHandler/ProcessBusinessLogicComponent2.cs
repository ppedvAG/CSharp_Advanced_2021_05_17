using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventAndEventHandler
{
    public class ProcessBusinessLogicComponent2
    {
        public event EventHandler ProcessCompleted;

        public event EventHandler ProcessCompletedNew;

        public void Start()
        {
            Console.WriteLine("Process start");

            //ganz viel Logik


            //Erfolgsmeldung wird nach draussen gesendet
            OnProcessCompleted(EventArgs.Empty);


            MyEventArg myEventArg = new MyEventArg();
            myEventArg.Uhrzeit = DateTime.Now;

            OnProcessCompletedNew(myEventArg);
        }

        public virtual void OnProcessCompleted(EventArgs e)
        {
            ProcessCompleted?.Invoke(this, e);
        }

        protected virtual void OnProcessCompletedNew(MyEventArg e)
        {
            ProcessCompletedNew?.Invoke(this, e);
        }
    }


    public class MyEventArg : EventArgs
    {
        public DateTime Uhrzeit { get; set; }
    }
}
