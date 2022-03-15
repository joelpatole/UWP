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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Pizza.com
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Beverages: Page, IMenu
    {
        ObservableCollection<Model.Product> PizzaList = new ObservableCollection<Model.Product>();
        ObservableCollection<ProductOrder> ProductList = new ObservableCollection<ProductOrder>();
        PizzaDataProvider pdp = new PizzaDataProvider();
        public Beverages()
        {
            this.InitializeComponent();
            this.SizeChanged += BeveragesMenu_SizeChanged;
            this.Loaded += BeveragesMenu_Loaded;
            SelectedProductListView.SetIMenu(this);
        }

        //TODO:Should be moved to a new Util Class
        private void SetOrder()
        {
            for (int i = 0; i < BeveragesMenuList.Items.Count; i++)
            {
                Product p = (Product)BeveragesMenuList.Items[i];
                p.DeleteIndex = i;
            }
        }

        private async void BeveragesMenu_Loaded(object sender, RoutedEventArgs e)
        {
            var a = await pdp.GetProductByCategory(Constants.ProductTypes.Beverages);
            BeveragesMenuList.ItemsSource = a;
            SetOrder();
        }

        private void BeveragesMenu_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            double newHeightOfWindow = e.NewSize.Height;
            if (newHeightOfWindow > 0)
            {
                BeveragesMenuList.Height = newHeightOfWindow - 200;
            }
        }


        private void BackButtonBeveragesClick(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private void BeveragesList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Model.Product item = ((Model.Product)BeveragesMenuList.SelectedItem);
            SelectedProductListView.AddProduct(item);
        }

        private async void AddButtonBeveragesClick(object sender, RoutedEventArgs e)
        {
            if (SelectedProductListView.IsEmpty())
            {
                var dialog = new MessageDialog("Please select at least one Item.");
                await dialog.ShowAsync();
                return;
            }
            this.Frame.Navigate(typeof(Cart), SelectedProductListView.GetProductList());
        }

        public Product GetItemByIndex(int index)
        {
            return (Product)BeveragesMenuList.Items[index];
        }

        private void SelectedProductListView_Loaded(object sender, RoutedEventArgs e)
        {

        }

        //Below 4 functions are moved to SelectedProductList for refactoring
        //private ProductOrder GetProductOrderByProduct(Product pro)
        //{
        //    foreach (var p in ProductList)
        //    {
        //        if (p.Product.Equals(pro))
        //            return p;
        //    }
        //    return null;
        //}

        //private void DeleteItemFromCart_Click(object sender, RoutedEventArgs e)
        //{
        //    Button btn = (Button)sender;
        //    if (btn.Tag == null)
        //        return;
        //    int index = (int)btn.Tag;
        //    Product pizzaToDelete = (Product)BeveragesMenuList.Items[index];
        //    if (pizzaToDelete != null)
        //    {
        //        ProductOrder po = GetProductOrderByProduct(pizzaToDelete);
        //        if (po != null)
        //        {
        //            ProductList.Remove(po);
        //            SelectedPizzaListView.Items.Remove(po);
        //        }

        //    }

        //    if (PizzaList.Contains(pizzaToDelete))
        //        PizzaList.Remove(pizzaToDelete);
        //}

        //private async void IncrementItemCount_Click(object sender, RoutedEventArgs e)
        //{
        //    Button btn = (Button)sender;
        //    if (btn.Tag == null)
        //        return;
        //    int index = (int)btn.Tag;
        //    Product pizzaToDelete = (Product)BeveragesMenuList.Items[index];
        //    if (pizzaToDelete != null)
        //    {
        //        ProductOrder po = GetProductOrderByProduct(pizzaToDelete);
        //        if (po != null)
        //        {
        //            if (po.Count < 10)
        //                po.Count++;
        //            else
        //            {
        //                var dialog = new MessageDialog("Maxium order count is 10");
        //                await dialog.ShowAsync();
        //            }
        //        }

        //    }
        //}

        //private async void DecrementCountButton_Click(object sender, RoutedEventArgs e)
        //{
        //    Button btn = (Button)sender;
        //    if (btn.Tag == null)
        //        return;
        //    int index = (int)btn.Tag;
        //    Product pizzaToDelete = (Product)BeveragesMenuList.Items[index];
        //    if (pizzaToDelete != null)
        //    {
        //        ProductOrder po = GetProductOrderByProduct(pizzaToDelete);
        //        if (po != null)
        //        {
        //            if (po.Count > 1)
        //                po.Count--;
        //            else     
        //            {
        //                var dialog = new MessageDialog("Minimum order count is 1");
        //                await dialog.ShowAsync();
        //            }
        //        }
        //    }
        //}

    }
}
