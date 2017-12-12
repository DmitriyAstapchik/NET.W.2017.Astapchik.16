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
            var inputPath = "urls.txt";
            var outputPath = "urls.xml";
            var provider = new TextFileUrlProvider(inputPath);
            var parser = new UrlScheme();
            var writer = new XmlUrlWriter(outputPath);
            var worker = new UrlWorker<UrlScheme>(provider, parser, writer, new Logger());
            worker.Convert();

            Console.Read();
        }

        private class Logger : IUrlLogger
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
