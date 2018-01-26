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
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ContactDetailsPage : ContentPage
	{
		public ContactDetailsPage (Contact contact)
		{
			InitializeComponent ();
            Title = contact.DisplayName;
            BindingContext = new ContactDetailsViewModel() { ContactToUpdate = contact, Id=contact.Id, DisplayName=contact.DisplayName };
        }

        public void OnSalvaClick(object sender, EventArgs e)
        {
            ContactDetailsViewModel bindingContext = (ContactDetailsViewModel)BindingContext;
            if (!bindingContext.DisplayName.Equals(bindingContext.ContactToUpdate.DisplayName))
            {
                bindingContext.ContactToUpdate.DisplayName = bindingContext.DisplayName;
            }
            Navigation.PopAsync();
        }

        public void OnAnnullaClick(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

    }
}