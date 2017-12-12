using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework
{
    /// <summary>
    /// URL strings provider from a text file
    /// </summary>
    public class TextFileUrlProvider : IUrlProvider
    {
        /// <summary>
        /// path to text file
        /// </summary>
        private string filePath;

        /// <summary>
        /// constructs new provider instance with specified <paramref name="filePath"/>
        /// </summary>
        /// <param name="filePath">path to a text file with URLs</param>
        public TextFileUrlProvider(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new ArgumentException("file at this file path does not exists");
            }

            this.filePath = filePath;
        }

        /// <summary>
        /// gets URL strings
        /// </summary>
        /// <returns>URL strings</returns>
        public IEnumerable<string> GetUrls()
        {
            using (var reader = new StreamReader(File.OpenRead(filePath)))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    yield return line;
                }
            }
        }
    }
}
