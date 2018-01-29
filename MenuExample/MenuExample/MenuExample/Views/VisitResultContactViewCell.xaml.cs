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
	public partial class VisitResultContactViewCell : ViewCell
	{
		public VisitResultContactViewCell()
		{
			InitializeComponent ();
            BindingContext = new VisitResultContactViewModel();
        }

        private void btnEliminaClicked(object sender, EventArgs e)
        {
            DynamicFormViewModel parentBindingContext = this.Parent.BindingContext as DynamicFormViewModel;
            parentBindingContext.ContactsList.Remove(BindingContext as VisitResultContactViewModel);
            parentBindingContext.ContactsListHeight = parentBindingContext.ContactsList.Count * parentBindingContext.ContactsListRowHeight;
        }
    }
}