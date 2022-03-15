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
    public sealed partial class NonvegMenu : Page, IMenu
    {
        ObservableCollection<Model.Product> PizzaList = new ObservableCollection<Model.Product>();
        ObservableCollection<ProductOrder> ProductList = new ObservableCollection<ProductOrder>();
        PizzaDataProvider pdp = new PizzaDataProvider();

        public NonvegMenu()
        {
            this.InitializeComponent();
            this.SizeChanged += NonVegMenu_SizeChanged;
            this.Loaded += NonVegMenu_Loaded;
            SelectedProductListView.SetIMenu(this);
        }

        private async void NonVegMenu_Loaded(object sender, RoutedEventArgs e) 
        {
            var a = await pdp.GetProductByCategory(Constants.ProductTypes.NonVegPizza);

            /*foreach (var p in pizzaList) 
            {
                VegMenuList.Items.Add(p);
            }*/
            NonVegMenuList.ItemsSource = a;
            SetOrder();
        }

        private void SetOrder()
        {
            for (int i = 0; i < NonVegMenuList.Items.Count; i++)
            {
                Product p = (Product)NonVegMenuList.Items[i];
                p.DeleteIndex = i;
            }

        }

        private void NonVegMenu_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            double newHeightOfWindow = e.NewSize.Height;
            if (newHeightOfWindow > 0)
            {
                NonVegMenuList.Height = newHeightOfWindow - 200;
            }
        }

        private void BackButtonNonVegClick(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private void NonVegMenuList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Model.Product item = ((Model.Product)NonVegMenuList.SelectedItem);
            SelectedProductListView.AddProduct(item);
        }

        private async void AddButtonNonVegClick(object sender, RoutedEventArgs e)
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
            return (Product)NonVegMenuList.Items[index];
        }

        // Below 4 Functions are moved to SelectedProductList.xaml.cs as the initial refactoring.

        //TODO: Should be moved to a new Util Class
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
        //    Product pizzaToDelete = (Product)NonVegMenuList.Items[index];
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
        //    Product pizzaToDelete = (Product)NonVegMenuList.Items[index];
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
        //    Product pizzaToDelete = (Product)NonVegMenuList.Items[index];
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
