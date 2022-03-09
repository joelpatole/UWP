using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Pizza.com.Model;
using Pizza.com.DataProvider;
using System.Collections.ObjectModel;
using Windows.UI.Popups;
using Pizza.com.UserControls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Pizza.com
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class VegMenu : Page, IMenu
    {
        
        ObservableCollection<Model.Product> PizzaList = new ObservableCollection<Model.Product>();
        ObservableCollection<ProductOrder> ProductList = new ObservableCollection<ProductOrder>();
        PizzaDataProvider pdp = new PizzaDataProvider();
        public VegMenu()
        {
            this.InitializeComponent();
            this.SizeChanged += VegMenu_SizeChanged;
            this.Loaded += VegMenu_Loaded;  
            SelectedProductListView.SetIMenu(this);
        }


        //TODO:Should be moved to a new Util Class
        private void SetOrder() 
        {
            for (int i = 0; i < VegMenuList.Items.Count; i++)
            {
                Product p = (Product)VegMenuList.Items[i];
                p.DeleteIndex = i;
            }
        }

        private void VegMenu_Loaded(object sender, RoutedEventArgs e)
        {
            var a = pdp.GetVegPizzaList(); 
            VegMenuList.ItemsSource = a;
            SetOrder();
        }

        private void VegMenu_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            double newHeightOfWindow = e.NewSize.Height;
            if (newHeightOfWindow > 0) 
            {
                VegMenuList.Height = newHeightOfWindow - 200;
            }
        }

        private void BackButtonVegClick(object sender, RoutedEventArgs e)
        {
             this.Frame.Navigate(typeof(MainPage));
        }

        private void AddButtonVegClick(object sender, RoutedEventArgs e)
        {

            this.Frame.Navigate(typeof(Cart), SelectedProductListView.GetProductList());

        }

        private void VegMenuList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Model.Product item = ((Model.Product)VegMenuList.SelectedItem);
            SelectedProductListView.AddProduct(item);
        }

        public Product GetItemByIndex(int index)
        {
            return (Product)VegMenuList.Items[index];
        }
       
        // Below 4 Functions are moved to SelectedProductList.xaml.cs as the initial refactoring.
        /*private ProductOrder GetProductOrderByProduct(Product pro) 
        {
            foreach (var p in ProductList) 
            {
                if(p.Product.Equals(pro))
                    return p;
            }
            return null;
        }*/

        /*private void DeleteItemFromCart_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            if (btn.Tag == null)
                return;
            int index = (int)btn.Tag;
            Product pizzaToDelete = (Product)VegMenuList.Items[index];
            if (pizzaToDelete != null)
            { 
                ProductOrder po = GetProductOrderByProduct(pizzaToDelete);
                if (po != null) 
                {
                    //Old
                    selectedProductList.RemoveProduct(po);
                }
                   
            }
            
            if (PizzaList.Contains(pizzaToDelete))
                PizzaList.Remove(pizzaToDelete);
        }*/

        /*private async void IncrementItemCount_Click(object sender, RoutedEventArgs e) 
        {
            Button btn = (Button)sender;
            if (btn.Tag == null)
                return;
            int index = (int)btn.Tag;
            Product pizzaToDelete = (Product)VegMenuList.Items[index];
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
        }*/

        /*private async void DecrementCountButton_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            if (btn.Tag == null)
                return;
            int index = (int)btn.Tag;
            Product pizzaToDelete = (Product)VegMenuList.Items[index];
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
        }*/
    }
}
