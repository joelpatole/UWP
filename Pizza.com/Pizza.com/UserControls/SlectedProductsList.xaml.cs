using Pizza.com.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace Pizza.com.UserControls
{
    public sealed partial class SlectedProductsList : UserControl
    {
        //private ObservableCollection<ProductOrder> _productList;

        ObservableCollection<ProductOrder> ProductList = new ObservableCollection<ProductOrder>();
        ObservableCollection<Model.Product> PizzaList = new ObservableCollection<Model.Product>();
        public IMenu IMenu { get; set; }

        //ProductList = new ObservableCollection<ProductOrder>();

        public void AddProduct(Product item) 
        {
            if (PizzaList.Contains(item))
                return;
            PizzaList.Add(item);
            ProductOrder po = new ProductOrder();
            po.Product = item;
            po.Count = 1;
            ProductList.Add(po);
            SelectedPizzaListView.Items.Add(po);
        }

        public ObservableCollection<ProductOrder> GetProductList() 
        {
            return ProductList;
        }

        internal void SetIMenu(IMenu menu)
        {
            this.IMenu = menu;
        }

        public void RemoveProduct(ProductOrder po) 
        {
            ProductList.Remove(po);
            SelectedPizzaListView.Items.Remove(po);
        }

        public bool ContainsProduct(ProductOrder po) 
        {
            return ProductList.Contains(po);
        }

        public SlectedProductsList() 
        {
            this.InitializeComponent();
        }

        //TODO: Should be moved to a new Util Class
        private ProductOrder GetProductOrderByProduct(Product pro)
        {
            foreach (var p in ProductList)
            {
                if (p.Product.Equals(pro))
                    return p;
            }
            return null;
        }

        private void DeleteItemFromCart_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            if (btn.Tag == null)
                return;
            int index = (int)btn.Tag;
            Product pizzaToDelete = IMenu.GetItemByIndex(index);
            if (pizzaToDelete != null)
            {
                ProductOrder po = GetProductOrderByProduct(pizzaToDelete);
                if (po != null)
                {
                    ProductList.Remove(po);
                    SelectedPizzaListView.Items.Remove(po);
                }

            }

            if (PizzaList.Contains(pizzaToDelete))
                PizzaList.Remove(pizzaToDelete);
        }

        private async void IncrementItemCount_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            if (btn.Tag == null)
                return;
            int index = (int)btn.Tag;
            Product pizzaToDelete = IMenu.GetItemByIndex(index);
            if (pizzaToDelete != null)
            {
                ProductOrder po = GetProductOrderByProduct(pizzaToDelete);
                if (po != null)
                {
                    if (po.Count < 10)
                        po.Count++;
                    else
                    {
                        var dialog = new MessageDialog("Maxium order count is 10");
                        await dialog.ShowAsync();
                    }
                }

            }
        }

        private async void DecrementCountButton_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            if (btn.Tag == null)
                return;
            int index = (int)btn.Tag;
            Product pizzaToDelete = IMenu.GetItemByIndex(index);
            if (pizzaToDelete != null)
            {
                ProductOrder po = GetProductOrderByProduct(pizzaToDelete);
                if (po != null)
                {
                    if (po.Count > 1)
                        po.Count--;
                    else
                    {
                        var dialog = new MessageDialog("Minimum order count is 1");
                        await dialog.ShowAsync();
                    }
                }
            }
        }
    }
}
