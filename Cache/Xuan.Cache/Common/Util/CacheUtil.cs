using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Xuan.Cache
{
    /// <summary>
    /// CacheUtil
    /// </summary>
    internal static class CacheUtil
    {

        /// <summary>
        /// CreateLogMessagePrefix
        /// </summary>
        /// <param name="method"></param>
        /// <returns></returns>
        internal static string CreateLogMessagePrefix(string method)
        {
            return $"trackingId:{Guid.NewGuid()}.{method}";
        }

        /// <summary>
        /// AssertConfiguration
        /// </summary>
        internal static void AssertConfiguration(ICacheServiceConfiguration cacheServiceOptions)
        {
            if (cacheServiceOptions == null)
                throw new ArgumentNullException("CacheServiceOptions");

            if (cacheServiceOptions.MaxParallelCache <= 0)
                throw new ArgumentNullException("MaxParallelCache");

            if (string.IsNullOrWhiteSpace(cacheServiceOptions.InstanceName))
                throw new ArgumentNullException("InstanceName");

            if (string.IsNullOrWhiteSpace(cacheServiceOptions.Server))
                throw new ArgumentNullException("Server");

            if (cacheServiceOptions.CacheLockerTimeOut <= 0)
                throw new ArgumentNullException("CacheLockerTimeOut");

            if (cacheServiceOptions.BatchCacheLockerTimeOut <= 0)
                throw new ArgumentNullException("BatchCacheLockerTimeOut");
        }

        /// <summary>
        /// 返回过期时间
        /// </summary>
        /// <returns></returns>
        internal static TimeSpan? GetExpireTime(ICacheServiceConfiguration configuration)
        {
            if (!configuration.ExpireTimeToExclusive.HasValue || !configuration.ExpireTimeFromInclusive.HasValue)
                return null;
            return TimeSpan.FromSeconds(RandomNumberGenerator.GetInt32(configuration.ExpireTimeFromInclusive.Value, configuration.ExpireTimeToExclusive.Value));
        }
    }
}
