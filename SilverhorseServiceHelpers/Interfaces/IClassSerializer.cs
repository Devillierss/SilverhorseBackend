using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilverhorseServiceHelpers.Interfaces
{
    public interface IClassSerializer
    {
        T Deserialize<T>(string jsonString);
        string Serialize<T>(T dto);
    }
}
