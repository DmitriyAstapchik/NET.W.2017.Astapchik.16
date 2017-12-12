using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework
{
    /// <summary>
    /// URL scheme
    /// </summary>
    public class UrlScheme : IUrlParser<UrlScheme>
    {
        /// <summary>
        /// original URL string
        /// </summary>
        public string OriginalString { get; private set; }

        /// <summary>
        /// URL scheme
        /// </summary>
        public string Scheme { get; private set; }

        /// <summary>
        /// URL host
        /// </summary>
        public string Host { get; private set; }

        /// <summary>
        /// URL path segments
        /// </summary>
        public string[] Segments { get; private set; }

        /// <summary>
        /// URL parameters from query string
        /// </summary>
        public KeyValuePair<string, string>[] Parameters { get; private set; }

        /// <summary>
        /// parses URL string to a scheme
        /// </summary>
        /// <param name="url">URL to parse</param>
        /// <returns>URL scheme if parsed successfully; otherwise null</returns>
        public UrlScheme Parse(string url)
        {
            if (Uri.TryCreate(url, UriKind.Absolute, out Uri uri))
            {
                OriginalString = uri.OriginalString;
                Scheme = uri.Scheme;
                Host = uri.Host;
                Segments = uri.Segments.Length > 0 ? uri.Segments.Skip(1).Select(str => new string(str.TakeWhile(ch => ch != '/').ToArray())).ToArray() : null;
                Parameters = uri.Query.Length > 0 ? new string(uri.Query.Skip(1).ToArray()).Split('&').Select(str => new KeyValuePair<string, string>(new string(str.TakeWhile(ch => ch != '=').ToArray()), new string(str.SkipWhile(ch => ch != '=').Skip(1).ToArray()))).ToArray() : null;

                if (Parameters != null && !Parameters.All(kvp => kvp.Key != string.Empty && kvp.Value != string.Empty))
                {
                    return null;
                }
                else
                {
                    return this;
                }
            }
            else
            {
                return null;
            }
        }
    }
}
