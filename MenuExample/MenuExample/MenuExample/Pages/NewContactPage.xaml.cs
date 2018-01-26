using MenuExample.Model;
using MenuExample.Repositories;
using MenuExample.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MenuExample.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NewContactPage : ContentPage
	{
        public NewContactPage(ObservableCollection<Contact> contactsList)
        {
            InitializeComponent();
            BindingContext = new NewContactViewModel(contactsList);
        }

        public void btnSubmitClick(object sender, EventArgs e)
        {
            var bindingContext = BindingContext as NewContactViewModel;
            string newContactName = entryNewName.Text;
            if (!String.IsNullOrEmpty(newContactName))
            {
                var contactsList = bindingContext.ContactsList;
                contactsList.Add(ContactsLocalRepository.AddNewContact(newContactName));
                bindingContext.ContactsList = new ObservableCollection<Contact>(contactsList.OrderByDescending<Contact, string>(x => x.DisplayName));
                //TODO: il nuovo item viene aggiunto in coda alla lista e neanche OrderBy ha effetto
            }
            Navigation.PopAsync();
        }

        public void btnCancelClick(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}