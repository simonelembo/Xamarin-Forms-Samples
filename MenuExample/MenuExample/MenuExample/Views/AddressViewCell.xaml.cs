using MenuExample.Model;
using MenuExample.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MenuExample.Views
{
	public partial class AddressViewCell : ViewCell
	{
		public AddressViewCell ()
		{
			InitializeComponent ();
            BindingContext = new AddressViewModel();
        }

        private void btnEliminaClicked(object sender, EventArgs e)
        {
            if (this.Parent.BindingContext.GetType().Equals(typeof(VisitResultViewModel)))
            {
                var parentBindingContext = this.Parent.BindingContext as VisitResultViewModel;
                parentBindingContext.AddressesList.Remove(BindingContext as AddressViewModel);
                parentBindingContext.AddressesListHeight = parentBindingContext.AddressesList.Count * parentBindingContext.AddressesListRowHeight;
            }
            if (this.Parent.BindingContext.GetType().Equals(typeof(DynamicFormViewModel)))
            {
                var parentBindingContext = this.Parent.BindingContext as DynamicFormViewModel;
                parentBindingContext.AddressesList.Remove(BindingContext as AddressViewModel);
                parentBindingContext.AddressesListHeight = parentBindingContext.AddressesList.Count * parentBindingContext.AddressesListRowHeight;
            }
        }
    }
}