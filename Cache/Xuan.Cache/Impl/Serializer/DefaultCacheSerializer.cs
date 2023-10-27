using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace Xuan.Cache
{
    ///<seealso cref="ICacheSerializer"/>
    public class DefaultCacheSerializer : ICacheSerializer
    {
        ///<seealso cref="ICacheSerializer.DeserializeAsync{T}(byte[])"/>
        public async Task<T> DeserializeAsync<T>(byte[] data) where T : class
        {
            if (data == null)
                return null;
            using var ms = new MemoryStream(data);
            return await JsonSerializer.DeserializeAsync<T>(ms);
        }

        ///<seealso cref="ICacheSerializer.SerializeAsync(object)"/>
        public async Task<byte[]> SerializeAsync(object obj)
        {
            if (obj == null)
                return default;
            using var ms = new MemoryStream();
            await JsonSerializer.SerializeAsync(ms, obj);
            return ms.ToArray();
        }
    }
}
