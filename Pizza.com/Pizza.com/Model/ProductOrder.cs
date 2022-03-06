using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza.com.Model
{
    public class ProductOrder : INotifyPropertyChanged
    {
        private Product _product;
        private int _count;
        public Product Product 
        {
            get => _product;
            set
            {
                _product = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Product)));  
            }
        }
        public int Count 
        {
            get => _count;
            set 
            {
                _count = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Count)));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
