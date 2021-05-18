using System;

namespace Übung_Solid2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }


    #region Bad Sample
    public class BadEmail
    {
        public void SendEmail()
        {
            // code to send mail
        }
    }

    public class BadNotification
    {
        private BadEmail _email;
        public BadNotification()
        {
            _email = new BadEmail();
        }

        public void PromotionalNotification()
        {
            _email.SendEmail();
        }
    }
    #endregion


    #region GoodCode
    public interface IEmail
    {
        void SendEmail();
    }

    public class Email : IEmail
    {
        public void SendEmail()
        {
            throw new NotImplementedException();
        }
    }


    public class Notification
    {
        private IEmail _email;
        public Notification()
        {
            _email = new Email();
        }

        public void PromotionalNotification()
        {
            _email.SendEmail();
        }
    }


    #endregion

}
