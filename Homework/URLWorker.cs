using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Homework
{
    /// <summary>
    /// class for work with URLs - reading URLs from a text file and saves them to xml file
    /// </summary>
    public static class URLWorker
    {
        /// <summary>
        /// saves url to xml file
        /// </summary>
        /// <param name="urls">URLs to save</param>
        /// <param name="xmlFile">path to xml file</param>
        public static void SaveToXML(IEnumerable<URLScheme> urls, string xmlFile)
        {
            var writer = new XmlTextWriter(xmlFile, Encoding.UTF8);
            writer.WriteStartDocument();
            writer.WriteStartElement("urlAddresses");
            foreach (var url in urls)
            {
                WriteURL(url);
            }

            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Flush();
            return;

            void WriteURL(URLScheme url)
            {
                writer.WriteStartElement("urlAddress");
                writer.WriteAttributeString("scheme", url.Scheme);
                WriteHost();
                WritePath();
                WriteParameters();
                writer.WriteEndElement();
                return;

                void WriteHost()
                {
                    writer.WriteStartElement("host");
                    writer.WriteAttributeString("name", url.Host);
                    writer.WriteEndElement();
                }

                void WritePath()
                {
                    if (url.Segments?.Length > 0)
                    {
                        writer.WriteStartElement("uri");
                        foreach (var segment in url.Segments)
                        {
                            writer.WriteElementString("segment", segment);
                        }

                        writer.WriteEndElement();
                    }
                }

                void WriteParameters()
                {
                    if (url.Parameters?.Length > 0)
                    {
                        writer.WriteStartElement("parameters");
                        foreach (var param in url.Parameters)
                        {
                            writer.WriteStartElement("parameter");
                            writer.WriteAttributeString("key", param.Key);
                            writer.WriteAttributeString("value", param.Value);
                            writer.WriteEndElement();
                        }

                        writer.WriteEndElement();
                    }
                }
            }
        }

        /// <summary>
        /// gets URLs from a text file and logs invalid URLs
        /// </summary>
        /// <param name="textFilePath">text file path</param>
        /// <param name="logger">url logger</param>
        /// <returns>array of URLs</returns>
        public static URLScheme[] GetURLs(string textFilePath, IURLLogger logger)
        {
            using (var reader = new StreamReader(File.OpenRead(textFilePath)))
            {
                var list = new List<URLScheme>();
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (URLScheme.TryParse(line, out URLScheme url))
                    {
                        list.Add(url);
                    }
                    else
                    {
                        logger.Log(line);
                    }
                }

                return list.ToArray();
            }
        }
    }
}
