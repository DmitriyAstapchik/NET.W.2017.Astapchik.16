using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework
{
    /// <summary>
    /// writes URLs to some output
    /// </summary>
    /// <typeparam name="TScheme">scheme of written URLs</typeparam>
    public interface IUrlWriter<TScheme>
    {
        /// <summary>
        /// writes URL schemes to output
        /// </summary>
        /// <param name="urls">URL schemes</param>
        void WriteUrls(IEnumerable<TScheme> urls);
    }
}
