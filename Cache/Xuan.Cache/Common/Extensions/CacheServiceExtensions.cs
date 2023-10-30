using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Xuan.Cache.Extensions
{
    /// <summary>
    /// CacheServiceExtensions
    /// </summary>
    public static class CacheServiceExtensions
    {
        public static void AddCacheService(this IServiceCollection services, Action<ICacheServiceConfiguration> setupAction)
        {
            //if (services == null)
            //{
            //    throw new ArgumentNullException("services");
            //}

            //if (setupAction == null)
            //{
            //    throw new ArgumentNullException("setupAction");
            //}
            //var configuration = new CacheServiceConfiguration()
            //{
            //    CacheInstances = new List<string>()
            //};
            //setupAction(configuration);
            ////根据配置缓存实例注入
            //if (configuration.CacheInstances?.Count() > 0)
            //{
            //    HashSet<string> cacheInstanceSet = configuration.CacheInstances.ToHashSet();
            //    IEnumerable<Type> implTypes = Assembly.GetAssembly(typeof(CacheServiceExtensions)).GetTypes().Where(o => o.IsClass && !o.IsAbstract && o.GetInterfaces().Any(o => o.Name == typeof(ICacheService<,>).Name) && o.GetCustomAttribute<CacheInstanceAttribute>() != null).ToList();
            //    foreach (var impl in implTypes)
            //    {
            //        var cacheAttr = impl.GetCustomAttribute<CacheInstanceAttribute>();
            //        if (!cacheInstanceSet.Contains(cacheAttr.CacheInstance))
            //            continue;
            //        Type[] interfaces = impl.GetInterfaces().Where(_ => _.IsTypeDefinition).ToArray();
            //        foreach (Type implType in interfaces)
            //        {
            //            switch (cacheAttr.LifeTime)
            //            {
            //                case ServiceLifetime.Singleton:
            //                    services.AddSingleton(implType, impl);
            //                    break;
            //                case ServiceLifetime.Scoped:
            //                    services.AddScoped(implType, impl);
            //                    break;
            //                case ServiceLifetime.Transient:
            //                    services.AddTransient(implType, impl);
            //                    break;
            //            }
            //        }
            //    }
            //}
            ////压缩配置
            //if (configuration.UseCompress)
            //{
            //    services.AddScoped<ICacheSerializer, CompressCacheSerializer>();
            //}
            //else
            //{
            //    services.AddScoped<ICacheSerializer, DefaultCacheSerializer>();
            //}

            //services.AddSingleton<ICacheServiceConfiguration>(configuration);
        }
    }
}
