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
    public sealed partial class Beverages: Page
    {
        ObservableCollection<Pizza1> PizzaList = new ObservableCollection<Pizza1>();
        PizzaDataProvider pdp = new PizzaDataProvider();
        public Beverages()
        {
            this.InitializeComponent();
            this.SizeChanged += BeveragesMenu_SizeChanged;
            this.Loaded += BeveragesMenu_Loaded;
        }

        private void BeveragesMenu_Loaded(object sender, RoutedEventArgs e)
        {
            //VegMenuList.Items.Clear();
            var a = pdp.GetBeveragesList();

            /*foreach (var p in pizzaList) 
            {
                VegMenuList.Items.Add(p);
            }*/
            BeveragesMenuList.ItemsSource = a;

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
            Pizza1 item = ((Pizza1)BeveragesMenuList.SelectedItem);

            if (PizzaList.Contains(item))
            {
                PizzaList.Remove(item);
                SelectedPizzaListView.Items.Remove(item);
            }
            else
            {
                PizzaList.Add(item);
                SelectedPizzaListView.Items.Add(item);
            }
        }

        private void AddButtonBeveragesClick(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Cart), PizzaList);
        }
    }
}
