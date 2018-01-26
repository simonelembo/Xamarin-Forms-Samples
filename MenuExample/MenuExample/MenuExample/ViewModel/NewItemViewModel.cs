using ListRepositoryService.Model;
using MenuExample.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace MenuExample.ViewModel
{
    class NewItemViewModel : INotifyPropertyChanged
    {
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

        public NewItemViewModel(List<ItemModel> itemsList)
        {
            this._itemsList = new List<ItemModel>();
            ItemsList = itemsList;
            this._isBusy = false;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
