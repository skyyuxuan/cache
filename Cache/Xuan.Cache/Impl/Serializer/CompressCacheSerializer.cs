using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO.Compression;

namespace Xuan.Cache
{
    ///<seealso cref="ICacheSerializer"/>
    public class CompressCacheSerializer : ICacheSerializer
    {
        ///<seealso cref="ICacheSerializer.DeserializeAsync{T}(byte[])"/>
        public async Task<T> DeserializeAsync<T>(byte[] data) where T : class
        {
            if (data == null)
                return null;
            using var ms = new MemoryStream(data);
            using var compressionStream = new GZipStream(ms, CompressionMode.Decompress);
            var result = await JsonSerializer.DeserializeAsync<T>(compressionStream);
            return result;
        }

        ///<seealso cref="ICacheSerializer.SerializeAsync(object)"/>
        public async Task<byte[]> SerializeAsync(object obj)
        {
            if (obj == null)
                return default;
            var bytes = JsonSerializer.SerializeToUtf8Bytes(obj);
            using var compressedStream = new MemoryStream();
            using var gs = new GZipStream(compressedStream, CompressionMode.Compress);
            await gs.WriteAsync(bytes, 0, bytes.Length);
            gs.Dispose();
            return compressedStream.ToArray();
        }
    }
}
