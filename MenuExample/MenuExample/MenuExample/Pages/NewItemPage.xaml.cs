using ListRepositoryService.Model;
using ListRepositoryService.Repositories;
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
	public partial class NewItemPage : ContentPage
	{
		public NewItemPage (List<ItemModel> itemsList)
		{
			InitializeComponent ();
            BindingContext = new NewItemViewModel(itemsList);
        }

        public async void btnSubmitClick(object sender, EventArgs e)
        {
            var bindingContext = BindingContext as NewItemViewModel;
            btnSubmit.IsVisible = false;
            btnCancel.IsVisible = false;
            bindingContext.IsBusy = true;
            string newItemName = entryNewName.Text;
            if (!String.IsNullOrEmpty(newItemName))
            {
                List<ItemModel> newItemsList = null;
                newItemsList = await StringListRepository.AddNewItem(newItemName);
                if (newItemsList != null)
                {
                    bindingContext.ItemsList = newItemsList;
                    //TODO: il nuovo item viene aggiunto in coda alla lista e neanche OrderBy ha effetto
                    bindingContext.IsBusy = false;
                    await Navigation.PopAsync();
                }
            }
        }

        public void btnCancelClick(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}