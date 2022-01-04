using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace TamTamBot.API.Client.Impl
{
    class JacksonSerializer:ITamTamSerializer
    {
        #region Fields
        JsonSerializerOptions serializerOptions;
        #endregion

        #region Constructor
        public JacksonSerializer()
        {
            serializerOptions = new JsonSerializerOptions()
            {
                Converters =
                {
                    new JsonStringEnumConverter(JsonNamingPolicy.CamelCase)
                }
            };
        }
        #endregion

        #region ITamTamSerializer implementation
        public T Deserialize<T>(string data)
        {
            return JsonSerializer.Deserialize<T>(data, serializerOptions);
        }

        public T Deserialize<T>(Stream data)
        {
            throw new NotImplementedException();
        }

        public T Deserialize<T>(byte[] data)
        {
            return JsonSerializer.Deserialize<T>(data, serializerOptions);
        }

        public byte[] Serialize<T>(T obj)
        {
            return JsonSerializer.SerializeToUtf8Bytes<T>(obj, serializerOptions);
        }

        public string SerializeToString<T>(T obj)
        {
            return JsonSerializer.Serialize<T>(obj, serializerOptions);
        }
        #endregion
    }
}
