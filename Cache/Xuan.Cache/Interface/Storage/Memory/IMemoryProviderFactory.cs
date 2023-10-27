using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xuan.Cache
{
    /// <summary>
    /// IMemoryProviderFactory
    /// </summary>
    public interface IMemoryProviderFactory
    {
        /// <summary>
        /// CreateProvider
        /// </summary>
        /// <param name="instanceName"></param>
        /// <returns></returns> 
        IMemoryCache CreateProvider(string instanceName);
    }
}
