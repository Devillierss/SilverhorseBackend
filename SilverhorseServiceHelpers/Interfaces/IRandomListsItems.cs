using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilverhorseServiceHelpers.Interfaces
{
    public interface IRandomListsItems
    {
        Task<List<T>> ReturnRandomList<T>(List<T> list, int noOfItems);
    }
}
