using MenuExample.Interfaces;
using MenuExample.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;
using MenuExample.Repositories;

namespace MenuExample.ViewModel
{
    class ContactsViewModel : INotifyPropertyChanged
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
                    ContactsList = ContactsLocalRepository.FilterList(_searchText);
                }
            }
        }

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

        public ContactsViewModel()
        {
            _contactsList = new ObservableCollection<Contact>();
            _searchText = "";
            ContactsList = ContactsLocalRepository.ReadAll();

        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
