using MenuExample.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MenuExample.Interfaces
{
    public interface IReadContacts
    {
        ObservableCollection<Contact> Read();
    }
}
