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
    public sealed partial class VegMenu : Page
    {
        
        ObservableCollection<Model.Product> PizzaList = new ObservableCollection<Model.Product>();
        
        
        ObservableCollection<ProductOrder> ProductList = new ObservableCollection<ProductOrder>();
       //ObservableCollection<Pizza1> selected = new ObservableCollection<Pizza1>();
        PizzaDataProvider pdp = new PizzaDataProvider();
        public VegMenu()
        {
            this.InitializeComponent();
            this.SizeChanged += VegMenu_SizeChanged;
            this.Loaded += VegMenu_Loaded;
            //this.DataContext = PizzaList;    
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
       /* protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            selected = (ObservableCollection<Pizza1>)e.Parameter;
            navigateFromCart(selected);
        }

        private void navigateFromCart(ObservableCollection<Pizza1> selectedItm)
        {
            throw new NotImplementedException();
            Pizza1 i = ((Pizza1)VegMenuList.selectedItm);
        }*/

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

        private void CheckBox_IsCheckedChanged(object sender, RoutedEventArgs e)
        {
            //UpdateCart();
        }

        private void AddButtonVegClick(object sender, RoutedEventArgs e)
        {

            this.Frame.Navigate(typeof(Cart), ProductList);

        }

        private void VegMenuList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Model.Product item = ((Model.Product)VegMenuList.SelectedItem);
            
            if (PizzaList.Contains(item))
            {
                //PizzaList.Remove(item);
                //SelectedPizzaListView.Items.Remove(item);
            }
            else 
            {
                PizzaList.Add(item);
                ProductOrder po = new ProductOrder();
                po.Product = item;
                po.Count = 1;
                ProductList.Add(po);
                SelectedPizzaListView.Items.Add(po);
                
            }
        }

        //TODO: Should be moved to a new Util Class
        private ProductOrder GetProductOrderByProduct(Product pro) 
        {
            foreach (var p in ProductList) 
            {
                if(p.Product.Equals(pro))
                    return p;
            }
            return null;
        }

        private void DeleteItemFromCart_Click(object sender, RoutedEventArgs e)
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
                    ProductList.Remove(po);
                     SelectedPizzaListView.Items.Remove(po);
                }
                   
            }
            
            if (PizzaList.Contains(pizzaToDelete))
                PizzaList.Remove(pizzaToDelete);
        }

        private async void IncrementItemCount_Click(object sender, RoutedEventArgs e) 
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
        }

        private async void DecrementCountButton_Click(object sender, RoutedEventArgs e)
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
        }
    }
}
