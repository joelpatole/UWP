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
using System.Threading.Tasks;
using Pizza.com.Model;
using Newtonsoft.Json;
using Windows.Storage;
using Windows.Storage.Streams;
using System.Net;
using System.Net.Mail;

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
        MailMessage message;
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

        private async void goToBill_Click(object sender, RoutedEventArgs e)
        {
            NotifyOwnerThroughEmail(productCart);
            this.Frame.Navigate(typeof(Bill));
            
        }

        //REAL BAD WAY OF DOING THINGS: TODO: Needs to be shifted to new Util Class this method does not belong here.
        //https://stackoverflow.com/questions/32260/sending-email-in-net-through-gmail
        //https://stackoverflow.com/questions/5943771/c-sharp-sending-email-code-suddenly-stopped-working
        public async Task NotifyOwnerThroughEmail(ProductCart pc)
        {
            var fromAddress = new MailAddress("joelpatole4@gmail.com", "pizza.com");
            var toAddress = new MailAddress("joelpatole20@gmail.com", "John");
            const string fromPassword = "drkfmljkawpnbmzx";
            const string subject = "Order Detials";
            string body = "<H1>Pizza.com: Order Details  <H1><br> <H3>";
            body = "<p> Order Number :" +Confirm.order_id + "<P>";

            var prodList = productCart.GetCartItems();
            foreach (var item in prodList)
            {
                body += item.Product.Name + " - " + item.Count + "<br>";
            }
            body += "<H3>";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            smtp.SendCompleted += Smtp_SendCompleted;
            message = new MailMessage(fromAddress, toAddress);
            message.Subject = subject;
            message.Body = body;
            message.IsBodyHtml = true;
            
            try 
            {
                smtp.SendAsync(message, null);
                //smtp.SendMailAsync(message);
                //smtp.Dispose;
            }
            catch (Exception e) 
            {
                body = "";
            }
        }

        private void Smtp_SendCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            var a = e.Error;
            productCart.GetCartItems().Clear();
            message.Dispose();
        }
    }
}
