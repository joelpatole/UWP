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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Pizza.com
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Siders : Page
    {
        ObservableCollection<Model.Product> PizzaList = new ObservableCollection<Model.Product>();
        ObservableCollection<ProductOrder> ProductList = new ObservableCollection<ProductOrder>();
        PizzaDataProvider pdp = new PizzaDataProvider();
        public Siders() 
        {
            this.InitializeComponent();
            this.SizeChanged += SidersMenu_SizeChanged;
            this.Loaded += SidersMenu_Loaded;
        }

        private void SidersMenu_Loaded(object sender, RoutedEventArgs e)
        {
            //VegMenuList.Items.Clear();
            var a = pdp.GetSidersList();

            /*foreach (var p in pizzaList) 
            {
                VegMenuList.Items.Add(p);
            }*/
            SidersMenuList.ItemsSource = a;

        }

        private void SidersMenu_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            double newHeightOfWindow = e.NewSize.Height;
            if (newHeightOfWindow > 0)
            {
                SidersMenuList.Height = newHeightOfWindow - 200;
            }
        }
        private void BackButtonSidersClicked(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private void SidersMenuList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Model.Product item = ((Model.Product)SidersMenuList.SelectedItem);

            if (PizzaList.Contains(item))
            {
               // PizzaList.Remove(item);
                //SelectedPizzaListView.Items.Remove(item);
            }
            else
            {
                //PizzaList.Add(item);
                //SelectedPizzaListView.Items.Add(item);
                PizzaList.Add(item);
                ProductOrder po = new ProductOrder();
                po.Product = item;
                po.Count = 1;
                ProductList.Add(po);
                SelectedPizzaListView.Items.Add(po);
            }
        }

        private void AddButtonSidersClick(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Cart), PizzaList);
        }
    }
}
