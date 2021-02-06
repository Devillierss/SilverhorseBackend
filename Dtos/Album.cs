using System;
using System.Runtime.Serialization;

namespace SilverhorseDtos
{
    public class Album
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "userId")]
        public int UserId { get; set; }

        [DataMember(Name = "title")]
        public string Title { get; set; }

    }
}
