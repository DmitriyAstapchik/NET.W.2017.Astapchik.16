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
    /// URL worker
    /// </summary>
    /// <typeparam name="TScheme">URL scheme to work with</typeparam>
    public class UrlWorker<TScheme>
    {
        /// <summary>
        /// URL string provider
        /// </summary>
        private IUrlProvider provider;

        /// <summary>
        /// URL scheme parser
        /// </summary>
        private IUrlParser<TScheme> parser;

        /// <summary>
        /// URL schemes writer
        /// </summary>
        private IUrlWriter<TScheme> writer;

        /// <summary>
        /// bad URLs logger
        /// </summary>
        private IUrlLogger logger;

        /// <summary>
        /// constructs a worker instance with specified components
        /// </summary>
        /// <param name="provider">URL string provider</param>
        /// <param name="parser">URL scheme parser</param>
        /// <param name="writer">URL schemes writer</param>
        /// <param name="logger">bad URLs logger</param>
        public UrlWorker(IUrlProvider provider, IUrlParser<TScheme> parser, IUrlWriter<TScheme> writer, IUrlLogger logger)
        {
            this.provider = provider;
            this.parser = parser;
            this.writer = writer;
            this.logger = logger;
        }

        /// <summary>
        /// writes parsed URLs to output
        /// </summary>
        public void Convert()
        {
            var urls = provider.GetUrls();
            var parsed = urls.Select(u =>
            {
                var result = parser.Parse(u);
                if (result == null)
                {
                    logger.Log(u);
                }

                return result;
            });
            writer.WriteUrls(parsed);
        }
    }
}
