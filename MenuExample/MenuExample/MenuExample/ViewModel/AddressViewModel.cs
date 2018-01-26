using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MenuExample.ViewModel
{
    public class AddressViewModel : INotifyPropertyChanged
    {
        private string _id;
        public string Id
        {
            get
            {
                return _id;
            }
            set
            {
                if (!_id.Equals(value))
                {
                    _id = value;
                    OnPropertyChanged(nameof(Id));
                }
            }
        }

        private string _address;
        public string Address
        {
            get
            {
                return _address;
            }
            set
            {
                if (!_address.Equals(value))
                {
                    _address = value;
                    OnPropertyChanged(nameof(Address));
                }
            }
        }

        private string _zipCode;
        public string ZipCode
        {
            get
            {
                return _zipCode;
            }
            set
            {
                if (!_zipCode.Equals(value))
                {
                    _zipCode = value;
                    OnPropertyChanged(nameof(ZipCode));
                }
            }
        }

        private string _city;
        public string City
        {
            get
            {
                return _city;
            }
            set
            {
                if (!_city.Equals(value))
                {
                    _city = value;
                    OnPropertyChanged(nameof(City));
                }
            }
        }

        private string _state;
        public string State
        {
            get
            {
                return _state;
            }
            set
            {
                if (!_state.Equals(value))
                {
                    _state = value;
                    OnPropertyChanged(nameof(State));
                }
            }
        }

        public AddressViewModel()
        {
            this._id = "";
            this._address = "";
            this._zipCode = "";
            this._city = "";
            this._state = "";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public override string ToString()
        {
            return Id + ": " + Address + " - " + ZipCode + " - " + City + " (" + State + ")";
        }
    }
}
