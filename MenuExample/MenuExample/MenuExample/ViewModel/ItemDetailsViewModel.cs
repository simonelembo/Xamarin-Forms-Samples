using ListRepositoryService.Model;
using MenuExample.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MenuExample.ViewModel
{
    class ItemDetailsViewModel : INotifyPropertyChanged
    {
        private ItemModel _itemToUpdate;
        public ItemModel ItemToUpdate
        {
            get
            {
                return _itemToUpdate;
            }
            set
            {
                if (!_itemToUpdate.Equals(value))
                {
                    _itemToUpdate = value;
                    OnPropertyChanged(nameof(ItemToUpdate));
                }
            }
        }

        private string _id;
        public string Id
        {
            get
            {
                return _id;
            }
            set
            {
                if (!_id.Equals(value))
                {
                    _id = value;
                    OnPropertyChanged(nameof(Id));
                }
            }
        }

        private string _displayName;
        public string DisplayName
        {
            get
            {
                return _displayName;
            }
            set
            {
                if (!_displayName.Equals(value))
                {
                    _displayName = value;
                    OnPropertyChanged(nameof(DisplayName));
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

        public ItemDetailsViewModel()
        {
            this._itemToUpdate = new ItemModel();
            this._id = "";
            this._displayName = "";
            this._isBusy = false;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
