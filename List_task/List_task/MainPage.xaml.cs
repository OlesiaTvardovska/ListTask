using List_task.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace List_task
{
	public partial class MainPage : ContentPage
	{
        private SearchService _searchService;
        private List<SearchGroup> _searchGroups;

        public MainPage()
		{
            _searchService = new SearchService();
            InitSearchGroups();
            InitializeComponent();

            listView.ItemsSource = _searchGroups;
        }
        public void InitSearchGroups()
        {
            _searchGroups = new List<SearchGroup>
            {
                new SearchGroup("Recent Searches", _searchService.CreateSearches())
            };
        }
        private void Delete_Clicked(object sender, EventArgs e)
        {
            var _search = (sender as MenuItem).CommandParameter as Search;
            _searchGroups[0].Remove(_search);
            _searchService.DeleteSearch(_search.Id);
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            _searchGroups = new List<SearchGroup>
            {
                new SearchGroup("Recent Searches", _searchService.GetRecentSearches(e.NewTextValue))
            };

            listView.ItemsSource = _searchGroups;
        }

        private void ListView_Refreshing(object sender, EventArgs e)
        {
            IEnumerable<Search> s = _searchService.GetRecentSearches();
            _searchGroups[0] = new SearchGroup("Recent searches", s);

            listView.ItemsSource = _searchGroups;

            listView.EndRefresh();
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var search = e.SelectedItem as Search;
            DisplayAlert("Selected", search.Location, "OK");
        }
    }
}
