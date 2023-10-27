using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xuan.Cache
{
    /// <summary>
    /// ICacheConfiguration
    /// </summary>
    public interface ICacheServiceConfiguration
    {
        /// <summary>
        /// 服务
        /// </summary>
        public string? Server { get; set; }

        /// <summary>
        /// 实例名称
        /// </summary>
        public string? InstanceName { get; set; }

        /// <summary>
        /// 过期时间下线（包含）
        /// </summary>
        public int? ExpireTimeFromInclusive { get; set; }

        /// <summary>
        /// 过期时间上线（不包含）
        /// </summary>
        public int? ExpireTimeToExclusive { get; set; }

        /// <summary>
        /// 最大并行处理cache
        /// </summary>
        public int MaxParallelCache { get; set; }

        /// <summary>
        /// CacheLockerTimeOut Seconds
        /// </summary>
        public int CacheLockerTimeOut { get; set; }

        /// <summary>
        /// BatchCacheLockerTimeOut Seconds
        /// </summary>
        public int BatchCacheLockerTimeOut { get; set; }

        /// <summary>
        /// UseCompress
        /// </summary>
        public bool UseCompress { get; set; }

        /// <summary>
        /// UseMemoryCache
        /// </summary>
        public bool UseMemoryCache { get; set; }

        /// <summary>
        /// SizeLimit
        /// </summary>
        public long? SizeLimit { get; set; }

        /// <summary>
        /// CacheInstances
        /// </summary>
        public List<string> CacheInstances { get; set; }

        /// <summary>
        /// ExceptionHandler
        /// </summary>
        public Action<object, Exception> CacheExceptionHandler { get; set; }
    }
}
