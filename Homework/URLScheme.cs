using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework
{
    /// <summary>
    /// represents URL structure
    /// </summary>
    public struct URLScheme
    {
        /// <summary>
        /// original URL string
        /// </summary>
        private string original;

        /// <summary>
        /// URL scheme
        /// </summary>
        private string scheme;

        /// <summary>
        /// URL host
        /// </summary>
        private string host;

        /// <summary>
        /// URL path segments
        /// </summary>
        private string[] segments;

        /// <summary>
        /// URL query parameters
        /// </summary>
        private KeyValuePair<string, string>[] parameters;

        /// <summary>
        /// original url string getter
        /// </summary>
        public string Original => original;

        /// <summary>
        /// url scheme getter
        /// </summary>
        public string Scheme => scheme;

        /// <summary>
        /// url host getter
        /// </summary>
        public string Host => host;

        /// <summary>
        /// url path segments getter
        /// </summary>
        public string[] Segments => segments;

        /// <summary>
        /// url query parameters getter
        /// </summary>
        public KeyValuePair<string, string>[] Parameters => parameters;

        /// <summary>
        /// tries to parse url as a string
        /// </summary>
        /// <param name="urlString">url string to parse</param>
        /// <param name="url">parsing result</param>
        /// <returns>true if parsed successful; otherwise false</returns>
        public static bool TryParse(string urlString, out URLScheme url)
        {
            if (Uri.TryCreate(urlString, UriKind.Absolute, out Uri uri))
            {
                url = new URLScheme
                {
                    original = uri.OriginalString,
                    scheme = uri.Scheme,
                    host = uri.Host,
                    segments = uri.Segments.Length > 0 ? uri.Segments.Skip(1).Select(str => new string(str.TakeWhile(ch => ch != '/').ToArray())).ToArray() : null,
                    parameters = uri.Query.Length > 0 ? new string(uri.Query.Skip(1).ToArray()).Split('&').Select(str => new KeyValuePair<string, string>(new string(str.TakeWhile(ch => ch != '=').ToArray()), new string(str.SkipWhile(ch => ch != '=').Skip(1).ToArray()))).ToArray() : null
                };

                if (url.parameters != null && !url.parameters.All(kvp => kvp.Key != string.Empty && kvp.Value != string.Empty))
                {
                    return false;
                }

                return true;
            }

            url = default(URLScheme);
            return false;
        }
    }
}
