using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TamTamBot.API.Client
{
    public interface ITamTamSerializer
    {
        byte[] Serialize<T>(T obj);
        string SerializeToString<T>(T obj);
        T Deserialize<T>(string data);
        T Deserialize<T>(Stream data);
        T Deserialize<T>(byte[] data);
    }
}
