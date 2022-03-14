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
using System.Collections.ObjectModel;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Pizza.com
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public partial class Cart : Page
    {
        //public static Cart instance; 
        //<Pizza1> pizzas =  new List<Pizza1>();
        
        ProductCart productCart = ProductCart.GetInstance;
        public static int totalBill;
        public static int temptotalBill;
        public Cart()
        {
            this.InitializeComponent();
            this.Loaded += Cart_Loaded;
        //this.OnNavigatedTo += onNavigatedTo;
    }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e == null || e.Parameter == null)
                return;
            var param = (ObservableCollection<ProductOrder>)e.Parameter;
            foreach (var item in param) 
            {
                productCart.AddItemToCart(item);
                
            }
        }

        private void Cart_Loaded(object sender, RoutedEventArgs e)
        {
            totalBill = 0;
            // cartListView.Items.Clear();
            if (productCart.GetItemCount() > 0)
            {
                //int i = 0;
                var allItemsInCart = productCart.GetCartItems();
                foreach (var item in allItemsInCart)
                {

                    cartListView.Items.Add(item);
                    totalBill = totalBill + ((item.Count * item.Product.Price));
                   
                    
                }
                
            }
            else
            {
                cartListView = null;
            }
            TotalTextBlock.Text = totalBill.ToString();
            
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

        private void goToBill_Click(object sender, RoutedEventArgs e)
        {
           
            
            this.Frame.Navigate(typeof(Bill));
            
        }
    }
}
