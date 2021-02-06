using SilverhorseDtos;
using SilverhorseServiceHelpers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilverhorseServiceHelpers.Services
{
    public class CollectionAggregator : ICollectionAggregator
    {

        private readonly IWebRepository _WebRepository;
        private readonly IRandomListsItems _randomListsItems;

        private List<User> _userList = new List<User>();
        private List<Post> _postList = new List<Post>();
        private List<Album> _albumList = new List<Album>();



        public CollectionAggregator(IWebRepository webRepository, IRandomListsItems randomListsItems)
        {
            _WebRepository = webRepository;
            _randomListsItems = randomListsItems;
        }

        public async Task<JsonPlaceHolderCollection> FetchAggrgatedCollectionAsync(string baseUri)
        {
            await LoadAllLists(baseUri);

            return new JsonPlaceHolderCollection()
            {
                Albums = await _randomListsItems.ReturnRandomList<Album>(_albumList, 10),
                Posts = await _randomListsItems.ReturnRandomList<Post>(_postList, 10),
                Users = await _randomListsItems.ReturnRandomList<User>(_userList, 10)
            };
        }

        private async Task LoadAllLists(string baseUri)
        {
            _userList = await _WebRepository.GetWebRequest<List<User>>(baseUri, "users");
            _postList = await _WebRepository.GetWebRequest<List<Post>>(baseUri, "posts");
            _albumList = await _WebRepository.GetWebRequest<List<Album>>(baseUri, "albums");
        }
    }
}
