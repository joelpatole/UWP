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
        ObservableCollection<Model.Product> selectedItems;

        ObservableCollection<IProduct> productCart;
        public static ProductCart GetInstance
        {
            get 
            {
                if (_instance == null) 
                    return new ProductCart();
                
                return _instance;
            }
        }

        public void AddItemToCart(Model.Product product) 
        {
            selectedItems.Add(product);
        }

        public bool RemoveItemFromCart(Model.Product product) 
        { 
            return selectedItems.Remove(product); 
        }

        public ObservableCollection<Model.Product> GetCartItems() 
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
            productCart = new ObservableCollection<IProduct>();
            selectedItems = new ObservableCollection<Model.Product>();
        }
    }
}
