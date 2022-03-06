using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Pizza.com.Model
{
    //This is a singleton class.
    public sealed class ProductCart
    {
        private static ProductCart _instance = null;
        private static ObservableCollection<ProductOrder> selectedItems;
        private static readonly object threadLock = new object();
        private static int count = 0;


        public static ProductCart GetInstance
        {
            get 
            {
                if (_instance == null) 
                {
                    //This lock is used for thread safety. This is not required int his applicaiton.
                    //but implemented for the sake of completeness.
                    lock (threadLock) 
                    {
                        if (_instance == null) 
                        {
                            _instance = new ProductCart();
                            return _instance;
                        }    
                    }
                }
                
                
                return _instance;
            }
        }

        public void AddItemToCart(ProductOrder product) 
        {
            selectedItems.Add(product);
        }

        public bool RemoveItemFromCart(ProductOrder product) 
        { 
            return selectedItems.Remove(product); 
        }

        public ObservableCollection<ProductOrder> GetCartItems() 
        {
            return selectedItems;
        }

        public int GetItemCount() 
        {
            if(selectedItems != null)
                return selectedItems.Count;
            return 0;
        }

        private ProductCart() 
        {
            selectedItems = new ObservableCollection<ProductOrder>();
        }
    }
}
