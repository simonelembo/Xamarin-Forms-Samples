using ListRepositoryService.Model;
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
	public partial class ItemsPage : ContentPage
	{
		public ItemsPage ()
		{
			InitializeComponent ();
            BindingContext = new ItemsViewModel();
        }

        public void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            ItemDetailsPage itemDetailsPage = new ItemDetailsPage(e.Item as ItemModel);
            Navigation.PushAsync(itemDetailsPage);
        }

        public void btnAddNewClick(object sender, EventArgs e)
        {
            var bindingContext = BindingContext as ItemsViewModel;
            NewItemPage newItemPage = new NewItemPage(bindingContext.ItemsList);
            Navigation.PushAsync(newItemPage);
        }
    }
}