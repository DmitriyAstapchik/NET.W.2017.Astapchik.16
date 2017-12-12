using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework
{
    /// <summary>
    /// parses URL string to <typeparamref name="TScheme"/>
    /// </summary>
    /// <typeparam name="TScheme">url parse scheme</typeparam>
    public interface IUrlParser<TScheme>
    {
        /// <summary>
        /// parses URL string to scheme
        /// </summary>
        /// <param name="url">URL string to parse</param>
        /// <returns>url scheme object</returns>
        TScheme Parse(string url);
    }
}
