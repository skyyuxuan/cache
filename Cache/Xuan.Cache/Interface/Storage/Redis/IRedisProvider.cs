using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xuan.Cache.Storage
{
    /// <summary>
    /// IRedisProvider
    /// </summary>
    public interface IRedisProvider
    {
        object GetDatabase();
    }
}
