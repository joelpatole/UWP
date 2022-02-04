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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Pizza.com
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Cart : Page
    {
        List<Pizza1> pizzas =  new List<Pizza1>();          
        public Cart()
        {
            //pizzas = pizzaList;
            this.InitializeComponent();
            this.Loading += Cart_Loading; //this will load the data(customers)
            this.Loaded += Cart_Loaded;
            //this.OnNavigatedTo += onNavigatedTo;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            
        }

        private void Cart_Loading(FrameworkElement sender, object args)
        {
            var a = args as List<Pizza1>;
        }

        private void Cart_Loaded(object sender, RoutedEventArgs e)
        {
            cartListView.Items.Clear();

            List<Pizza1> cart_items = null;
            cart_items = new List<Pizza1>
                    {
                      new Pizza1{PizzaName="Thomas",PizzaPrice=506,PizzaDescription="tasty"},
                      new Pizza1{PizzaName="Anna",PizzaPrice=345, PizzaDescription="very tasty"},
                      new Pizza1{PizzaName="Thomas",PizzaPrice=506,PizzaDescription="tasty"},
                      new Pizza1{PizzaName="Thomas",PizzaPrice=506,PizzaDescription="tasty"},
                      new Pizza1{PizzaName="Thomas",PizzaPrice=506,PizzaDescription="tasty"},
                      new Pizza1{PizzaName="Thomas",PizzaPrice=506,PizzaDescription="tasty" }
                    };
            foreach (var pizza in cart_items)
            {
                cartListView.Items.Add(pizza);
            }
        }

        private void BackButtonClick(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private void cartListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           /* var pizza = customerListView.SelectedItem as Pizza;
            txtFirstName.Text = customer?.FirstName ?? "";
            txtLastName.Text = customer?.LastName ?? "";
            chkIsDeveloper.IsChecked = customer?.IsDeveloper;
            chkIsTester.IsChecked = customer?.IsTester;*/
        }
    }
}
