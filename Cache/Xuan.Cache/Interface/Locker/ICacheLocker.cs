using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xuan.Cache
{
    /// <summary>
    /// ICacheLocker
    /// </summary>
    public interface ICacheLocker : IDisposable
    {
        /// <summary>
        /// 尝试着获取指定名称的锁，获取成功返回true
        /// 如果不等待，则立即返回false
        /// 如果等待，将等待直到获取锁
        /// </summary>
        /// <param name="lockName">锁名</param>
        /// <param name="wait">是否等待直到获取到锁</param>
        /// <returns>锁获取返回true，否则返回false</returns>
        Task<bool> TryLockAsync(string lockName, bool wait, CancellationToken? ct = null);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lockNames"></param>
        /// <param name="wait"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<IEnumerable<KeyValuePair<string, bool>>> TryLockAsync(string[] lockNames, bool wait, CancellationToken? ct = null);
    }
}
