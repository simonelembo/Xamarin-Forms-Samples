using MenuExample.Interfaces;
using MenuExample.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;
using MenuExample.Repositories;
using ListRepositoryService.Repositories;
using ListRepositoryService.Model;
using System.Threading.Tasks;

namespace MenuExample.ViewModel
{
    class ItemsViewModel : INotifyPropertyChanged
    {
        private string _searchText;
        public string SearchText
        {
            get
            {
                return _searchText;
            }
            set
            {
                if (!_searchText.Equals(value))
                {
                    _searchText = value;
                    OnPropertyChanged(nameof(SearchText));
                    IsBusy = true;
                    FilterList();
                }
            }
        }

        private bool _isBusy;
        public bool IsBusy
        {
            get
            {
                return _isBusy;
            }
            set
            {
                if (_isBusy != value)
                {
                    _isBusy = value;
                    OnPropertyChanged(nameof(IsBusy));
                }
            }
        }

        private List<ItemModel> _itemsList;
        public List<ItemModel> ItemsList
        {
            get
            {
                return _itemsList;
            }
            set
            {
                if (!_itemsList.GetHashCode().Equals(value.GetHashCode()))
                {
                    _itemsList = value;
                    OnPropertyChanged(nameof(ItemsList));
                }
                
            }
        }

        public ItemsViewModel()
        {
            _itemsList = new List<ItemModel>();
            _searchText = "";
            _isBusy = false;
            LoadList();

        }

        private async void LoadList()
        {
            IsBusy = true;
            int numItems = Convert.ToInt32(Application.Current.Resources["numItems"]);
            ItemsList = await StringListRepository.GetAll(numItems, "String_") as List<ItemModel>;
            IsBusy = false;
        }

        private async void FilterList()
        {
            ItemsList = await StringListRepository.FilterList(_searchText);
            IsBusy = false;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
