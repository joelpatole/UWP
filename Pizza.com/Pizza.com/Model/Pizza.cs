using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Pizza.com.Model
{
    public class Pizza1 : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public String Pname;
        public int Pcost;
        public String Pdesc;

        public String PizzaName
        {
            get => Pname;
            set
            {
                Pname = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PizzaName)));           
            }
        }

        public int PizzaPrice
        {
            get => Pcost;
            set
            {
                Pcost = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PizzaPrice)));
            }
        }

        public String PizzaDescription
        {
            get => Pdesc;
            set
            {
                Pdesc = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PizzaDescription)));
            }
        }

    }
}
