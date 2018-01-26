using System.Collections.Generic;
using System.Collections.ObjectModel;
using Android.Content;
using Android.Provider;
using MenuExample.Android;
using MenuExample.Droid;
using MenuExample.Interfaces;
using MenuExample.Model;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(ReadContactsImpl))]
namespace MenuExample.Android
{
    public class ReadContactsImpl : IReadContacts
    {
        public ReadContactsImpl() { }

        public ObservableCollection<Contact> Read()
        {
            var uri = ContactsContract.Contacts.ContentUri;

            string[] projection = { ContactsContract.Contacts.InterfaceConsts.Id,
       ContactsContract.Contacts.InterfaceConsts.DisplayName };
                        
            //TODO: Commentato per Live Preview
            //var cursor = Forms.Context.ContentResolver.Query(uri, projection, null, null, ContactsContract.Contacts.InterfaceConsts.DisplayName);
            
            var contactList = new ObservableCollection<Contact>();

            //TODO: Commentato per Live Preview
            //if (cursor.MoveToFirst())
            //{
            //    do
            //    {
            //        contactList.Add(new Contact() { Id = cursor.GetString(cursor.GetColumnIndex(projection[0])), DisplayName = cursor.GetString(cursor.GetColumnIndex(projection[1])) });
            //    } while (cursor.MoveToNext());
            //}

            return contactList;
        }
        
    }
}