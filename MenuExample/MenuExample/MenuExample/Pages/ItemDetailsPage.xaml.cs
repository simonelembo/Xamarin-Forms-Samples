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
	public partial class ItemDetailsPage : ContentPage
	{
		public ItemDetailsPage (ItemModel itemModel)
		{
			InitializeComponent ();
            Title = itemModel.DisplayName;
            BindingContext = new ItemDetailsViewModel() { ItemToUpdate = itemModel, Id = itemModel.Id.ToString(), DisplayName = itemModel.DisplayName };
        }

        public async void btnSubmitClick(object sender, EventArgs e)
        {
            ItemDetailsViewModel bindingContext = (ItemDetailsViewModel)BindingContext;
            btnSubmit.IsVisible = false;
            btnCancel.IsVisible = false;
            bindingContext.IsBusy = true;
            if (!bindingContext.DisplayName.Equals(bindingContext.ItemToUpdate.DisplayName))
            {
                bindingContext.ItemToUpdate = await StringListRepository.UpdateItem(new ItemModel { Id = Int32.Parse(bindingContext.Id), DisplayName = bindingContext.DisplayName });
            }
            await Navigation.PopAsync();
        }

        public void btnCancelClick(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}