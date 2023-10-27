using Microsoft.Extensions.DependencyInjection;

namespace Xuan.Cache
{
    /// <summary>
    /// CacheInstanceAttribute
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class CacheInstanceAttribute : Attribute
    {
        /// <summary>
        /// CacheInstance
        /// </summary>
        public string CacheInstance { get; set; }

        /// <summary>
        /// LifeTime
        /// </summary>
        public ServiceLifetime LifeTime { get; set; }

        /// <summary>
        /// CacheInstanceAttribute
        /// </summary>
        public CacheInstanceAttribute()
        {

        }

        /// <summary>
        /// CacheInstanceAttribute
        /// </summary>
        /// <param name="cacheInstanceType"></param>
        /// <param name="lifeTime"></param>
        public CacheInstanceAttribute(string cacheInstanceType, ServiceLifetime lifeTime)
        {
            this.CacheInstance = cacheInstanceType;
            this.LifeTime = lifeTime;
        }
    }
}
