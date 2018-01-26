using MenuExample.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MenuExample.ViewModel
{
    class ContactDetailsViewModel : INotifyPropertyChanged
    {
        private Contact _contactToUpdate;
        public Contact ContactToUpdate
        {
            get
            {
                return _contactToUpdate;
            }
            set
            {
                if (!_contactToUpdate.Equals(value))
                {
                    _contactToUpdate = value;
                    OnPropertyChanged(nameof(ContactToUpdate));
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

        public ContactDetailsViewModel()
        {
            this._contactToUpdate = new Contact();
            this._id = "";
            this._displayName = "";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
