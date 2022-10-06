using Library.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltiConsoleApp
{
    public class App
    {
        private readonly IMessages messages;

        public App(IMessages messages)
        {
            this.messages = messages;
        }

        public void Run(string[] args)
        {
            string lang = "en";

            for( int i = 0; i < args.Length; i++ )
            {
                if(args[i].ToLower().StartsWith("lang="))
                {
                    lang = args[i].Substring(5);
                    break;
                }
            }

            string message = this.messages.Greeting(lang);  

            Console.WriteLine(message);
        }
    }
}
