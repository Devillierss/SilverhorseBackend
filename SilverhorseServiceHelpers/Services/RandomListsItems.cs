using SilverhorseServiceHelpers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilverhorseServiceHelpers.Services
{
    public class RandomListsItems : IRandomListsItems
    {
        public async Task<List<T>> ReturnRandomList<T>(List<T> list, int noOfItems)
        {
            return await Task.Run(() =>
            {

                var newList = new List<T>();
                var listArray = list.ToArray();
                var usedItem = new List<int>();

                if (list.Count <= noOfItems)
                {
                    return list;
                }

                for (int i = 0; i < noOfItems; i++)
                {
                    var random = new Random();
                    int index = random.Next(list.Count);
                    if (usedItem.Contains(index))
                    {
                        i--;
                    }
                    else
                    {
                        newList.Add(listArray[index]);
                    }

                }

                return newList;

            });

        }
    }
}
