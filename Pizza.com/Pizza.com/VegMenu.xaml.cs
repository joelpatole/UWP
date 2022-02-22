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
    public sealed partial class VegMenu : Page
    {
        
        ObservableCollection<Pizza1> PizzaList = new ObservableCollection<Pizza1>();
        PizzaDataProvider pdp = new PizzaDataProvider();
        public VegMenu()
        {
            this.InitializeComponent();
            this.SizeChanged += VegMenu_SizeChanged;
            this.Loaded += VegMenu_Loaded;
            //this.DataContext = PizzaList;    
        }

        private void VegMenu_Loaded(object sender, RoutedEventArgs e)
        {
            //VegMenuList.Items.Clear();
            var a = pdp.GetPizzaList();

            /*foreach (var p in pizzaList) 
            {
                VegMenuList.Items.Add(p);
            }*/
            VegMenuList.ItemsSource = a;

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

        private void CheckBox_IsCheckedChanged(object sender, RoutedEventArgs e)
        {
            //UpdateCart();
        }

        private void AddButtonVegClick(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Cart), PizzaList);

        }

        private void VegMenuList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Pizza1 item = ((Pizza1)VegMenuList.SelectedItem);
            
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
    }
}
