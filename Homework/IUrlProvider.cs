using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework
{
    /// <summary>
    /// provides with URL strings
    /// </summary>
    public interface IUrlProvider
    {
        /// <summary>
        /// get URL strings
        /// </summary>
        /// <returns>URL strings</returns>
        IEnumerable<string> GetUrls();
    }
}
