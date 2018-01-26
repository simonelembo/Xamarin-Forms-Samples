using MenuExample.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace MenuExample.ViewModel
{
    class NewContactViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Contact> _contactsList;
        public ObservableCollection<Contact> ContactsList
        {
            get
            {
                return _contactsList;
            }
            set
            {
                if (!_contactsList.GetHashCode().Equals(value.GetHashCode()))
                {
                    _contactsList = value;
                    OnPropertyChanged(nameof(ContactsList));
                }

            }
        }

        public NewContactViewModel(ObservableCollection<Contact> contactList)
        {
            this._contactsList = new ObservableCollection<Contact>();
            ContactsList = contactList;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
