using System;
using System.Collections.Generic;

namespace SilverhorseDtos
{
    public class JsonPlaceHolderCollection
    {
        public List<Post> Posts { get; set; }
        public List<Album> Albums { get; set; }
        public List<User> Users { get; set; }
    }
}
