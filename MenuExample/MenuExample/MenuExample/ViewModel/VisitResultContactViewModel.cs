using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MenuExample.ViewModel
{
    public class VisitResultContactViewModel : INotifyPropertyChanged
    {
        #region Properties
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

        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (!_name.Equals(value))
                {
                    _name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }

        private string _phone;
        public string Phone
        {
            get
            {
                return _phone;
            }
            set
            {
                if (!_phone.Equals(value))
                {
                    _phone = value;
                    OnPropertyChanged(nameof(Phone));
                }
            }
        }

        private string _email;
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                if (!_email.Equals(value))
                {
                    _email = value;
                    OnPropertyChanged(nameof(Email));
                }
            }
        }

        private string _website;
        public string WebSite
        {
            get
            {
                return _website;
            }
            set
            {
                if (!_website.Equals(value))
                {
                    _website = value;
                    OnPropertyChanged(nameof(WebSite));
                }
            }
        }
        #endregion

        public VisitResultContactViewModel()
        {
            this._id = "";
            this._name = "";
            this._phone = "";
            this._email = "";
            this._website = "";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
