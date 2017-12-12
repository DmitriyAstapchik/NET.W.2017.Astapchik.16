using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Homework
{
    /// <summary>
    /// writes URL schemes to XML file
    /// </summary>
    public class XmlUrlWriter : IUrlWriter<UrlScheme>
    {
        /// <summary>
        /// path to XML file
        /// </summary>
        private string filePath;

        /// <summary>
        /// constructs new writer instance with specified <paramref name="filePath"/>
        /// </summary>
        /// <param name="filePath">path to XML file</param>
        public XmlUrlWriter(string filePath)
        {
            this.filePath = filePath;
        }

        /// <summary>
        /// writes URLs to XML file
        /// </summary>
        /// <param name="urls"></param>
        public void WriteUrls(IEnumerable<UrlScheme> urls)
        {
            var writer = new XmlTextWriter(filePath, Encoding.UTF8);
            writer.WriteStartDocument();
            writer.WriteStartElement("urlAddresses");
            foreach (var url in urls)
            {
                if (url == null)
                {
                    continue;
                }

                WriteURL(url);
            }

            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Flush();
            return;

            void WriteURL(UrlScheme url)
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
    }
}
