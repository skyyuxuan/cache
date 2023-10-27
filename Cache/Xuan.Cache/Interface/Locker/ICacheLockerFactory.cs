using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xuan.Cache
{
    /// <summary>
    /// ICacheLockerFactory
    /// </summary>
    public interface ICacheLockerFactory
    {
        /// <summary>
        /// 创建locker
        /// </summary>
        /// <param name="timeout"></param>
        /// <returns></returns>
        ICacheLocker CreateLocker(TimeSpan timeout);
    }
}
