using SilverhorseDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilverhorseServiceHelpers.Interfaces
{
    public interface ICollectionAggregator
    {
        Task<JsonPlaceHolderCollection> FetchAggrgatedCollectionAsync(string baseUri);
    }
}
