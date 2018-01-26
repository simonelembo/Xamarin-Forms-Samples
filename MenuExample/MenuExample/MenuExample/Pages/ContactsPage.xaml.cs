using MenuExample.Model;
using MenuExample.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MenuExample.Pages
{
	public partial class ContactsPage : ContentPage
	{
		public ContactsPage ()
		{
			InitializeComponent ();
            BindingContext = new ContactsViewModel();
        }

        public void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            ContactDetailsPage contactDetailsPage = new ContactDetailsPage(e.Item as Contact);
            Navigation.PushAsync(contactDetailsPage);
        }

        public void btnAddNewClick(object sender, EventArgs e)
        {
            var bindingContext = BindingContext as ContactsViewModel;
            NewContactPage newContactPage = new NewContactPage(bindingContext.ContactsList);
            Navigation.PushAsync(newContactPage);
        }
    }
}