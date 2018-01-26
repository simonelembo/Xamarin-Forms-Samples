using MenuExample.Interfaces;
using MenuExample.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;
using System.Linq;

namespace MenuExample.Repositories
{
    public static class ContactsLocalRepository
    {
        public static ObservableCollection<Contact> initialList = new ObservableCollection<Contact>();

        public static ObservableCollection<Contact> ReadAll()
        {
            initialList = DependencyService.Get<IReadContacts>().Read();
            return initialList;
        }

        public static ObservableCollection<Contact> FilterList(string searchText)
        {
            if (!String.IsNullOrEmpty(searchText))
            {
                IEnumerable<Contact> resultQuery = initialList.Where<Contact>(x => x.DisplayName.ToLower().Contains(searchText.ToLower()));
                return new ObservableCollection<Contact>(resultQuery);
            }
            else
            {
                return initialList;
            }
        }

        public static Contact AddNewContact(string newContactName)
        {
            string newContactId = GenerateNewId();
            Contact contact = new Contact() { Id = newContactId, DisplayName = newContactName };
            return contact;
        }

        private static string GenerateNewId()
        {
            int maxId = initialList.Max<Contact>(x => Int32.Parse(x.Id));
            int newId = maxId + 1;
            return newId.ToString();
        }
    }
}
