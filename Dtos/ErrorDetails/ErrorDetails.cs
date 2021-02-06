using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilverhorseDtos.ErrorDetails
{
    public class ErrorDetails
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public override string ToString()
        {
            var result = Utf8Json.JsonSerializer.Serialize(this);
            return Encoding.UTF8.GetString(result);
        }
    }
}
