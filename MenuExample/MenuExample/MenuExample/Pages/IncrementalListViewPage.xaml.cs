using MenuExample.Plugin;
using MenuExample.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace MenuExample.Pages
{
    public partial class IncrementalListViewPage : ContentPage
    {
        public IncrementalListViewPage()
        {
            InitializeComponent();

            BindingContext = new IncrementalViewModel();
            InitListView();
        }

        private void InitListView()
        {
            var bindingContext = BindingContext as IncrementalViewModel;

            IncrementalListView listView = new IncrementalListView(ListViewCachingStrategy.RecycleElement);

            listView.ItemsSource = bindingContext.MyItems;
            listView.PreloadCount = 5;
            //listView.RowHeight = 88;
            listView.ItemTemplate = new DataTemplate(() => CreateListViewDataTemplate());
            ActivityIndicator activityIndicator = new ActivityIndicator();
            activityIndicator.Margin = 20;
            activityIndicator.SetBinding(ActivityIndicator.IsRunningProperty, nameof(bindingContext.IsLoadingIncrementally));
            activityIndicator.SetBinding(ActivityIndicator.IsVisibleProperty, nameof(bindingContext.IsLoadingIncrementally));
            listView.Footer = activityIndicator;

            layout.Children.Add(listView);
        }

        private ViewCell CreateListViewDataTemplate()
        {
            Label label = new Label();
            label.SetBinding(Label.TextProperty, ".");
            return new ViewCell() { View = label };
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            var vm = BindingContext as IncrementalViewModel;

            vm.LoadMoreItemsCommand.Execute(null);
        }
    }
}
