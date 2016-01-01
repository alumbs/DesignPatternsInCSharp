using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Cascade
{
    //The idea is to chain methods together, so we dont 
    //keep calling mailer on each line
    class Cascade
    {
        static void Main(string[] args)
        {
            //OLD
            //Mailer mailer = new Mailer();
            //mailer.from("builder@agiledeveloper.com");
            //mailer.to("test@agile.com");
            //mailer.subject("Subject");
            //mailer.message("Some message");
            //mailer.send();

            //NEW
            new Mailer()
                .from("builder@agiledeveloper.com")
                .to("test@agile.com")
                .subject("Subject")
                .message("Some message")
                .send();
        }
    }

    class Mailer
    {
        //Return Mailer instead of void, in order to cascade the calls
        //on Mailer
        public Mailer to(string toAddr) { return this; }      
        public Mailer from(string fromAddr) { return this; }  
        public Mailer subject(string subject) { return this; }
        public Mailer message(string msg) { return this; }    
        public void send() { Console.WriteLine("Send got called"); }
        
        //NOTE: We could be returning other non-Mailer types,
        //and calling methods on them, based on what the application
        //does                                    
    }
}
