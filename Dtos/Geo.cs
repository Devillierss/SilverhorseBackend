using System;
using System.Runtime.Serialization;

namespace SilverhorseDtos
{
    public class Geo
    {
        [DataMember(Name = "lat")]
        public string Lat { get; set; }
        [DataMember(Name = "lng")]
        public string Lng { get; set; }
    }
}
