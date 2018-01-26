using MenuExample.Model;
using MenuExample.ViewModel;
using MenuExample.Views;
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
	public partial class VisitResultPage : ContentPage
	{
		public VisitResultPage ()
		{
			InitializeComponent ();

            BindingContext = new VisitResultViewModel();

            InitTableView();
		}

        private void InitTableView()
        {
            var bindingContext = BindingContext as VisitResultViewModel;
            int paddingLeft = Convert.ToInt32(Application.Current.Resources["paddingLeftFormViewCell"]);

            TableView tableView = new TableView
            {
                Intent = TableIntent.Form,
                Root = new TableRoot("Esito visita"),
                HasUnevenRows = true
            };
            tableView.SetBinding(TableView.IsVisibleProperty, nameof(bindingContext.IsReady));

            #region Clients List Picker
            Picker clientsListPicker = new Picker();
            clientsListPicker.Title = "Seleziona cliente";
            clientsListPicker.SetBinding(Picker.ItemsSourceProperty, nameof(bindingContext.ClientsList));
            clientsListPicker.SetBinding(Picker.SelectedItemProperty, nameof(bindingContext.ClientName));
            tableView.Root.Add(new TableSection("Cliente")
            {
                new ViewCell()
                {
                    View = clientsListPicker
                }
            });
            #endregion

            #region Contact
            EntryCell contactName = new EntryCell();
            contactName.Label = "Contatto:";
            contactName.Placeholder = "Nome Contatto";
            contactName.SetBinding(EntryCell.TextProperty, nameof(bindingContext.ContactName));
            EntryCell contactPhone = new EntryCell();
            contactPhone.Label = "Telefono:";
            contactPhone.Placeholder = "Numero di telefono";
            contactPhone.Keyboard = Keyboard.Telephone;
            contactPhone.SetBinding(EntryCell.TextProperty, nameof(bindingContext.ContactPhone));
            EntryCell contactEmail = new EntryCell();
            contactEmail.Label = "Email:";
            contactEmail.Placeholder = "Indirizzo email";
            contactEmail.Keyboard = Keyboard.Email;
            contactEmail.SetBinding(EntryCell.TextProperty, nameof(bindingContext.ContactEmail));
            EntryCell contactWebSite = new EntryCell();
            contactWebSite.Label = "Web:";
            contactWebSite.Placeholder = "Indirizzo sito web";
            contactWebSite.Keyboard = Keyboard.Url;
            contactWebSite.SetBinding(EntryCell.TextProperty, nameof(bindingContext.ContactWebSite));
            tableView.Root.Add(new TableSection("Contatto")
            {
                contactName,
                contactPhone,
                contactEmail,
                contactWebSite
            });
            #endregion

            #region Visit Date and Time
            DatePicker visitDatePicker = new DatePicker();
            visitDatePicker.SetBinding(DatePicker.DateProperty, nameof(bindingContext.VisitDate));
            TimePicker visitTimePicker = new TimePicker();
            visitTimePicker.SetBinding(TimePicker.TimeProperty, nameof(bindingContext.VisitTime));
            tableView.Root.Add(new TableSection("Data e Ora Visita")
            {
                new ViewCell()
                {
                    View = new StackLayout()
                    {
                        Orientation = StackOrientation.Horizontal,
                        HorizontalOptions = LayoutOptions.Center,
                        Children = { visitDatePicker, visitTimePicker }
                    }
                }
            });
            #endregion

            #region Visit Interview

            #region Is Interested
            SwitchCell isInterested = new SwitchCell() { Text = "Interessato" };
            isInterested.SetBinding(SwitchCell.OnProperty, nameof(bindingContext.IsInterested));
            #endregion

            #region Quantity
            Entry quantity = new Entry() { HorizontalOptions = LayoutOptions.FillAndExpand, HorizontalTextAlignment = TextAlignment.End };
            quantity.SetBinding(Entry.TextProperty, nameof(bindingContext.Quantity));
            Stepper quantityStepper = new Stepper();
            quantityStepper.SetBinding(Stepper.ValueProperty, nameof(bindingContext.Quantity));
            #endregion

            #region Rating
            Entry rating = new Entry() { HorizontalOptions = LayoutOptions.FillAndExpand, HorizontalTextAlignment = TextAlignment.End };
            rating.SetBinding(Entry.TextProperty, nameof(bindingContext.Rating));
            Slider ratingSlider = new Slider() { Minimum = 0, Maximum = 10 };
            ratingSlider.SetBinding(Slider.ValueProperty, nameof(bindingContext.Rating));
            ratingSlider.HorizontalOptions = LayoutOptions.FillAndExpand;
            #endregion

            #region Comment
            Editor comment = new Editor();
            comment.SetBinding(Editor.TextProperty, nameof(bindingContext.Comment));
            comment.HorizontalOptions = LayoutOptions.FillAndExpand;
            comment.VerticalOptions = LayoutOptions.FillAndExpand;
            #endregion

            #region Add controls to the Table Section
            tableView.Root.Add(new TableSection("Intervista")
            {
                isInterested,
                new ViewCell()
                {
                    View = new StackLayout()
                    {
                        Orientation = StackOrientation.Horizontal,
                        Padding = new Thickness(){ Left = paddingLeft },
                        Children =
                        {
                            new Label()
                            {
                                Text = "Quantità",
                                HorizontalOptions = LayoutOptions.StartAndExpand,
                                VerticalOptions = LayoutOptions.Center,
                            },
                            quantity,
                            quantityStepper
                        }
                    }
                },
                new ViewCell()
                {
                    View = new StackLayout()
                    {
                        Orientation = StackOrientation.Horizontal,
                        Padding = new Thickness(){ Left = paddingLeft },
                        Children =
                        {
                            new Label()
                            {
                                Text = "Valutazione",
                                HorizontalOptions = LayoutOptions.StartAndExpand,
                                VerticalOptions = LayoutOptions.Center,
                            },
                            rating,
                            ratingSlider
                        }
                    }
                },
                new ViewCell()
                {
                    View = new StackLayout()
                    {
                        Orientation = StackOrientation.Horizontal,
                        Padding = new Thickness(){ Left = paddingLeft },
                        Children =
                        {
                            new Label()
                            {
                                Text = "Commento",
                                HorizontalOptions = LayoutOptions.Start,
                                VerticalOptions = LayoutOptions.Center,
                            },
                            comment
                        }
                    }
                }
            });
            #endregion

            #endregion

            #region Addresses
            //List<AddressViewCell> addressViewsList = new List<AddressViewCell>();
            //TableSection addressesTableSection = new TableSection("Indirizzi");
            //foreach (AddressModel addressModel in bindingContext.AddressesList)
            //{
            //    addressesTableSection.Add(new AddressViewCell() { BindingContext = addressModel });
            //}
            //tableView.Root.Add(addressesTableSection);

            Button btnAddAddress = new Button() { Text = "Aggiungi indirizzo" };
            btnAddAddress.Clicked += BtnAddAddress_Clicked;
            //stackLayout.Children.Add(btnAddAddress);

            ListView addressesViews = new ListView();
            addressesViews.SetBinding(ListView.ItemsSourceProperty, nameof(bindingContext.AddressesList));
            addressesViews.ItemTemplate = new DataTemplate(typeof(AddressViewCell));
            addressesViews.RowHeight = 200;
            //stackLayout.Children.Add(addressesViews);

            tableView.Root.Add(new TableSection("Indirizzi")
            {
                new ViewCell()
                {
                    View = btnAddAddress
                },
                new ViewCell()
                {
                    View = addressesViews
                }
            });
            #endregion

            stackLayout.Children.Add(tableView);
        }

        private void BtnAddAddress_Clicked(object sender, EventArgs e)
        {
            var bindingContext = BindingContext as VisitResultViewModel;
            bindingContext.AddressesList.Add(new AddressViewModel(){ Id = "Indirizzo " + (bindingContext.AddressesList.Count + 1) });
        }
    }
}