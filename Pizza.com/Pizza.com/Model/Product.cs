using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Pizza.com.Model
{
    public class Product : INotifyPropertyChanged, IProduct
    {
        public Product(string pname, int cost, string pDesc, Constants.ProductTypes type) 
        {
            this.Name = pname;
            this.Price = cost;
            this.Description = pDesc;
            this.Ptype = type;
            
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private string Pname;
        private int Pcost;
        private string Pdesc;
        private Constants.ProductTypes Ptype;
        
        //This property is used to maintain to mark item to be deleted
        public int DeleteIndex { get; set; }


        public Constants.ProductTypes Type 
        {
            get => Ptype;
            set
            {
                Ptype = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Type)));
            }
        }

        public string Name
        {
            get => Pname;
            set
            {
                Pname = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Name)));
            }
        }
        public int Price
        {
            get => Pcost;
            set
            {
                Pcost = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Price)));
            }
        }
        public string Description
        {
            get => Pdesc;
            set
            {
                Pdesc = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Description)));
            }
        }
    }
}
