using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xuan.Cache.Storage
{
    /// <summary>
    /// IRedisProviderFactory
    /// </summary>
    public interface IRedisProviderFactory
    {
        /// <summary>
        /// CreateProvider
        /// </summary>
        /// <param name="instanceName"></param>
        /// <returns></returns>
        IRedisProvider CreateProvider(string instanceName);
    }
}
