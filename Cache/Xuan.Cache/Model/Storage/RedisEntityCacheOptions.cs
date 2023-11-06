using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xuan.Cache.Model.Storage
{
    /// <summary>
    /// RedisEntityCacheOptions
    /// </summary>
    public class RedisEntityCacheOptions
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
        /// 最大并行处理cache
        /// </summary>
        public virtual int MaxParallelCache { get; } = 1000;

        /// <summary>
        /// ExceptionHandler
        /// </summary>
        Action<object, Exception>? ExceptionHandler { get; set; }

    }
}
