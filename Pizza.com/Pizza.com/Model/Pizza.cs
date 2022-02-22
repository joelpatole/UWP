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
        public Pizza1(string pname, int cost, string pDesc) 
        {
            this.PizzaName = pname;
            this.PizzaPrice = cost;
            this.PizzaDescription = pDesc;
            PNameAndCost = pname + "  " + cost+"rs";
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public string Pname;
        public int Pcost;
        public string Pdesc;
        public string PNameAndCost;

        public string PizzaNameAndCost 
        {
            get => PNameAndCost;
            set  
            {
                Pname = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PizzaNameAndCost)));
            }
        }
        public string PizzaName
        {
            get => Pname;
            set
            {
                Pname = value;
                if (Pcost != 0)
                    PNameAndCost = Pname + "  " + Pcost+"rs";  
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PizzaName)));           
            }
        }

        public int PizzaPrice
        {
            get => Pcost;
            set
            {
                Pcost = value;
                if (!String.IsNullOrEmpty(Pname))
                    PNameAndCost = Pname + "  " + Pcost+"rs";
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PizzaPrice)));
            }
        }

        public string PizzaDescription
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
