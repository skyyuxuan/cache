using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xuan.Cache
{
    /// <summary>
    /// CacheServiceInternalHelper
    /// </summary>
    internal static class CacheServiceInternalHelper
    {
        /// <summary>
        /// BatchInvoke
        /// </summary>
        /// <param name="dataList"></param>
        /// <param name="size"></param>
        /// <param name="action"></param> 
        internal static void BatchInvoke<T>(IEnumerable<T> dataList, int size, Action<IEnumerable<T>> action)
        {
            var totalCount = dataList.Count();
            BatchInvoke(totalCount, size, (i) =>
            {
                var invokeDataList = dataList.Skip(i * size).Take(size).ToList();
                action.Invoke(invokeDataList);
            });
        }

        /// <summary>
        /// BatchInvoke
        /// </summary>
        /// <param name="totalCount"></param>
        /// <param name="size"></param>
        /// <param name="action"></param> 
        internal static void BatchInvoke(int totalCount, int size, Action<int> action)
        {
            int totalPage = totalCount / size;
            for (int i = 0; i <= totalPage; i++)
            {
                if (i * size == totalCount)
                {
                    break;
                }
                action.Invoke(i);
            }
        }
    }
}
