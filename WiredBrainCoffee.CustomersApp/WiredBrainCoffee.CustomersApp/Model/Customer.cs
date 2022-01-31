using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WiredBrainCoffee.CustomersApp.Base;

namespace WiredBrainCoffee.CustomersApp.Model
{
    public class Customer : Observable
    {
        private string _firstName;
        private string _lastName;
        private bool _isDeveloper;
        private bool _isTester;
        //public bool _isDba;

        public string FirstName
        {
            get => _firstName;
            set
            {
                _firstName = value;
                NotifyAllTheSubscribersAboutPropertyChange();
            }
        }
        public string LastName
        {
            get => _lastName;
            set
            {
                _lastName = value;
                NotifyAllTheSubscribersAboutPropertyChange();
            }
        }
        public bool IsDeveloper
        {
            get => _isDeveloper;
            set
            {
                _isDeveloper = value;
                NotifyAllTheSubscribersAboutPropertyChange();
            }
        }
        public bool IsTester
        {
            get => _isTester;
            set
            {
                _isTester = value;
                NotifyAllTheSubscribersAboutPropertyChange();
            }
        }
       
    }
}
