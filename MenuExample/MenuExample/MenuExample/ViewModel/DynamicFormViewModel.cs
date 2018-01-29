using ListRepositoryService.Model;
using ListRepositoryService.Repositories;
using MenuExample.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace MenuExample.ViewModel
{
    class DynamicFormViewModel : INotifyPropertyChanged
    {
        #region Properties
        private string _clientName;
        public string ClientName
        {
            get
            {
                return _clientName;
            }
            set
            {
                if (!_clientName.Equals(value))
                {
                    _clientName = value;
                    OnPropertyChanged(nameof(ClientName));
                }
            }
        }

        private ObservableCollection<ItemModel> _clientsList;
        public ObservableCollection<ItemModel> ClientsList
        {
            get
            {
                return _clientsList;
            }
            set
            {
                if(_clientsList.GetHashCode() != value.GetHashCode())
                {
                    _clientsList = value;
                    OnPropertyChanged(nameof(ClientsList));
                }
            }
        }

        private ObservableCollection<VisitResultContactViewModel> _contactsList;
        public ObservableCollection<VisitResultContactViewModel> ContactsList
        {
            get
            {
                return _contactsList;
            }
            set
            {
                if (!_contactsList.GetHashCode().Equals(value.GetHashCode()))
                {
                    _contactsList = value;
                    OnPropertyChanged(nameof(ContactsList));
                }
            }
        }

        private int _contactsListRowHeight;
        public int ContactsListRowHeight
        {
            get
            {
                return _contactsListRowHeight;
            }
            set
            {
                if (_contactsListRowHeight != value)
                {
                    _contactsListRowHeight = value;
                    OnPropertyChanged(nameof(ContactsListRowHeight));
                }
            }
        }

        private int _contactsListHeight;
        public int ContactsListHeight
        {
            get
            {
                return _contactsListHeight;
            }
            set
            {
                if (_contactsListHeight != value)
                {
                    _contactsListHeight = value;
                    OnPropertyChanged(nameof(ContactsListHeight));
                }
            }
        }

        private DateTime _visitDate;
        public DateTime VisitDate
        {
            get
            {
                return _visitDate;
            }
            set
            {
                if (!_visitDate.Equals(value))
                {
                    _visitDate = value;
                    OnPropertyChanged(nameof(VisitDate));
                }
            }
        }

        private TimeSpan _visitTime;
        public TimeSpan VisitTime
        {
            get
            {
                return _visitTime;
            }
            set
            {
                if (!_visitTime.Equals(value))
                {
                    _visitTime = value;
                    OnPropertyChanged(nameof(VisitTime));
                }
            }
        }

        private bool _isInterested;
        public bool IsInterested
        {
            get
            {
                return _isInterested;
            }
            set
            {
                if (_isInterested != value)
                {
                    _isInterested = value;
                    OnPropertyChanged(nameof(IsInterested));
                }
            }
        }

        private int _quantity;
        public int Quantity
        {
            get
            {
                return _quantity;
            }
            set
            {
                if (_quantity != value)
                {
                    _quantity = value;
                    OnPropertyChanged(nameof(Quantity));
                }
            }
        }

        private int _rating;
        public int Rating
        {
            get
            {
                return _rating;
            }
            set
            {
                if (_rating != value)
                {
                    _rating = value;
                    OnPropertyChanged(nameof(Rating));
                }
            }
        }

        private string _comment;
        public string Comment
        {
            get
            {
                return _comment;
            }
            set
            {
                if (!_comment.Equals(value))
                {
                    _comment = value;
                    OnPropertyChanged(nameof(Comment));
                }
            }
        }

        private ObservableCollection<AddressViewModel> _addressesList;
        public ObservableCollection<AddressViewModel> AddressesList
        {
            get
            {
                return _addressesList;
            }
            set
            {
                if (!_addressesList.GetHashCode().Equals(value.GetHashCode()))
                {
                    _addressesList = value;
                    OnPropertyChanged(nameof(AddressesList));
                }
            }
        }

        private int _addressesListRowHeight;
        public int AddressesListRowHeight
        {
            get
            {
                return _addressesListRowHeight;
            }
            set
            {
                if (_addressesListRowHeight != value)
                {
                    _addressesListRowHeight = value;
                    OnPropertyChanged(nameof(AddressesListRowHeight));
                }
            }
        }

        private int _addressesListHeight;
        public int AddressesListHeight
        {
            get
            {
                return _addressesListHeight;
            }
            set
            {
                if (_addressesListHeight != value)
                {
                    _addressesListHeight = value;
                    OnPropertyChanged(nameof(AddressesListHeight));
                }
            }
        }

        private bool _isBusy;
        public bool IsBusy
        {
            get
            {
                return _isBusy;
            }
            set
            {
                if (_isBusy != value)
                {
                    _isBusy = value;
                    OnPropertyChanged(nameof(IsBusy));
                    IsReady = !_isBusy;
                }
            }
        }

        private bool _isReady;
        public bool IsReady
        {
            get
            {
                return _isReady;
            }
            set
            {
                if (_isReady != value)
                {
                    _isReady = value;
                    OnPropertyChanged(nameof(IsReady));
                }
            }
        }
        #endregion

        public DynamicFormViewModel()
        {
            this._clientName = "";
            this._clientsList = new ObservableCollection<ItemModel>();
            _contactsList = new ObservableCollection<VisitResultContactViewModel>();
            _contactsList.Add(new VisitResultContactViewModel() { Id = "Contatto " + 1 });
            this._contactsListRowHeight = Convert.ToInt32(Application.Current.Resources["contactsListRowHeight"]);
            this._contactsListHeight = ContactsList.Count * ContactsListRowHeight;
            this._visitDate = DateTime.Now.Date;
            this._visitTime = DateTime.Now.TimeOfDay;
            this._isInterested = false;
            this._quantity = 0;
            this._rating = 6;
            this._comment = "";
            _addressesList = new ObservableCollection<AddressViewModel>();
            _addressesList.Add(new AddressViewModel() { Id = "Indirizzo " + 1 });
            this._addressesListRowHeight = Convert.ToInt32(Application.Current.Resources["addressesListRowHeight"]);
            this._addressesListHeight = AddressesList.Count * AddressesListRowHeight;
            this._isBusy = false;
            this._isReady = true;

            LoadClientsList();
        }

        private async void LoadClientsList()
        {
            IsBusy = true;
            int numClients = Convert.ToInt32(Application.Current.Resources["numClients"]);
            ClientsList = new ObservableCollection<ItemModel>(await StringListRepository.GetAll(numClients, "Client_"));
            IsBusy = false;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
