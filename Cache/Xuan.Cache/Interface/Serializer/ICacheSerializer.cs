using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xuan.Cache
{
    /// <summary>
    /// ICacheSerializer
    /// </summary>
    public interface ICacheSerializer
    {
        /// <summary>
        /// Serialize
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        Task<byte[]> SerializeAsync(object obj);

        /// <summary>
        /// Deserialize
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        Task<T?> DeserializeAsync<T>(byte[] data) where T : class;
    }
}
