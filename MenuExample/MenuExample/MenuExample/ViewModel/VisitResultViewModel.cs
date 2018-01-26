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
    class VisitResultViewModel : INotifyPropertyChanged
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

        private string _contactName;
        public string ContactName
        {
            get
            {
                return _contactName;
            }
            set
            {
                if (!_contactName.Equals(value))
                {
                    _contactName = value;
                    OnPropertyChanged(nameof(ContactName));
                }
            }
        }

        private string _contactPhone;
        public string ContactPhone
        {
            get
            {
                return _contactPhone;
            }
            set
            {
                if (!_contactPhone.Equals(value))
                {
                    _contactPhone = value;
                    OnPropertyChanged(nameof(ContactPhone));
                }
            }
        }

        private string _contactEmail;
        public string ContactEmail
        {
            get
            {
                return _contactEmail;
            }
            set
            {
                if (!_contactEmail.Equals(value))
                {
                    _contactEmail = value;
                    OnPropertyChanged(nameof(ContactEmail));
                }
            }
        }

        private string _contactWebSite;
        public string ContactWebSite
        {
            get
            {
                return _contactWebSite;
            }
            set
            {
                if (!_contactWebSite.Equals(value))
                {
                    _contactWebSite = value;
                    OnPropertyChanged(nameof(ContactWebSite));
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

        public VisitResultViewModel()
        {
            this._clientName = "";
            this._clientsList = new ObservableCollection<ItemModel>();
            this._contactName = "";
            this._contactPhone = "";
            this._contactEmail = "";
            this._contactWebSite = "";
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
