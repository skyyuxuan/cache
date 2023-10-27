using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xuan.Cache
{
    /// <summary>
    /// CacheManyOperationModel
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    public class CacheManyOperationModel<TKey, TValue>
    {
        /// <summary>
        /// Key
        /// </summary>
        public TKey Key { set; get; }

        /// <summary>
        /// Value
        /// </summary>
        public TValue Value { set; get; }

        /// <summary>
        /// ExpireTime
        /// </summary>
        public TimeSpan? ExpireTime { set; get; }
    }
}
