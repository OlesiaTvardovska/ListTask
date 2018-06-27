using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace List_task.Models
{
    class SearchService
    {
        private List<Search> _searches = new List<Search>();
        public SearchService()
        {
            //CreateSearches();
        }

        public IEnumerable<Search> CreateSearches()
        {
            _searches.Add(new Search(1, "Lviv,Ukraine", new DateTime(2018, 6, 10), new DateTime(2018, 6, 15)));
            _searches.Add(new Search(2, "Lutsk,Ukraine", new DateTime(2018, 7, 29), new DateTime(2018, 7, 31)));
            _searches.Add(new Search(3, "Warsaw,Poland", new DateTime(2018, 11, 20), new DateTime(2018, 11, 28)));
            return _searches;
        }
        public IEnumerable<Search> GetRecentSearches(string filter=null)
        {
            
            if(String.IsNullOrWhiteSpace(filter))
            {
                return _searches;
            }
            return _searches.Where(c => c.Location.StartsWith(filter, StringComparison.CurrentCultureIgnoreCase));
        }
        public void DeleteSearch(int Id)
        {
            _searches.RemoveAt(SearchId(Id));
        }
        public int SearchId(int Id)
        {
            int i = 0;
            foreach(var search in _searches)
            {
                if(search.Id==Id)
                {
                    return i;
                }
                i++;
            }
            return i;
        }
    }
}
