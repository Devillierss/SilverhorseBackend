using SilverhorseServiceHelpers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilverhorseServiceHelpers.Services
{
    public class ClassSerializer : IClassSerializer
    {
        public T Deserialize<T>(string jsonString)
        {
            return Utf8Json.JsonSerializer.Deserialize<T>(jsonString, Utf8Json.JsonSerializer.DefaultResolver);
        }

        public string Serialize<T>(T dto)
        {
            var result = Utf8Json.JsonSerializer.Serialize(dto);

            return Encoding.UTF8.GetString(result);
        }

    }
}
