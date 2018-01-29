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
	public partial class DynamicFormPage : ContentPage
	{
		public DynamicFormPage ()
		{
			InitializeComponent ();
        }

        private void BtnAddAddress_Clicked(object sender, EventArgs e)
        {
            var bindingContext = BindingContext as DynamicFormViewModel;
            bindingContext.AddressesList.Add(new AddressViewModel() { Id = "Indirizzo " + (bindingContext.AddressesList.Count + 1) });
            bindingContext.AddressesListHeight = bindingContext.AddressesList.Count * bindingContext.AddressesListRowHeight;
        }

        private void BtnAddContact_Clicked(object sender, EventArgs e)
        {
            var bindingContext = BindingContext as DynamicFormViewModel;
            bindingContext.ContactsList.Add(new VisitResultContactViewModel() { Id = "Contatto " + (bindingContext.ContactsList.Count + 1) });
            bindingContext.ContactsListHeight = bindingContext.ContactsList.Count * bindingContext.ContactsListRowHeight;
        }
    }
}