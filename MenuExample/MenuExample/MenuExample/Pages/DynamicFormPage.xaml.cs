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
            var bindingContext = BindingContext as VisitResultViewModel;
            bindingContext.AddressesList.Add(new AddressViewModel() { Id = "Indirizzo " + (bindingContext.AddressesList.Count + 1) });
            bindingContext.AddressesListHeight = bindingContext.AddressesList.Count * bindingContext.AddressesListRowHeight;
        }
    }
}