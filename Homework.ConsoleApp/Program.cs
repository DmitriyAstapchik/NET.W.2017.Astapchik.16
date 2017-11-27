using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework.ConsoleApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            URLWorker.SaveToXML(URLWorker.GetURLs("urls.txt", new Logger()), "urls.xml");

            Console.Read();
        }

        private class Logger : IURLLogger
        {
            public Logger()
            {
                Console.WriteLine("bad urls:");
            }

            public void Log(string badUrl)
            {
                if (!string.IsNullOrWhiteSpace(badUrl))
                {
                    Console.WriteLine(badUrl);
                }
            }
        }
    }
}
