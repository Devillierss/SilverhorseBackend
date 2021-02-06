using System;
using System.Runtime.Serialization;

namespace SilverhorseDtos
{
    public class Company
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }
        [DataMember(Name = "catchPhrase")]
        public string CatchPhrase { get; set; }
        [DataMember(Name = "bs")]
        public string Bs { get; set; }
    }
}
