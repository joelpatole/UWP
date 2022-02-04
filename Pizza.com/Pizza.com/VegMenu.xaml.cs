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
    public sealed partial class VegMenu : Page
    {
        List<Pizza1> selectedItem = new List<Pizza1>();
        public VegMenu()
        {
            this.InitializeComponent();
            this.SizeChanged += VegMenu_SizeChanged;      
                
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
            //Cart cart = new Cart(selectedItem);
            
            this.Frame.Navigate(typeof(Cart),selectedItem);

        }

        private void VegMenuList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (var item in e.AddedItems.OfType<Model.Pizza1>()) 
            {
                selectedItem.Add(item);       
            }
        }
        /* private void UpdateCart()
{ 
Cart cart=cartListview.SeletedItem as Cart;
if(cart!=null)
{

}
}*/
    }
}
