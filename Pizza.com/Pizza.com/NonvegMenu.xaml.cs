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
    public sealed partial class NonvegMenu : Page
    {
        ObservableCollection<Pizza1> PizzaList = new ObservableCollection<Pizza1>();
        PizzaDataProvider pdp = new PizzaDataProvider();
        public NonvegMenu()
        {
            this.InitializeComponent();
            this.SizeChanged += NonVegMenu_SizeChanged;
            this.Loaded += NonVegMenu_Loaded;
        }

        private void NonVegMenu_Loaded(object sender, RoutedEventArgs e)
        {
            //VegMenuList.Items.Clear();
            var a = pdp.GetNonVegPizzaList();

            /*foreach (var p in pizzaList) 
            {
                VegMenuList.Items.Add(p);
            }*/
            NonVegMenuList.ItemsSource = a;

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
            Pizza1 item = ((Pizza1)NonVegMenuList.SelectedItem);

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

        private void AddButtonNonVegClick(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Cart), PizzaList);
        }
    }
}
