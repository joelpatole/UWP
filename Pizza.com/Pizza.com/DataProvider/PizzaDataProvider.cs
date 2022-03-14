using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pizza.com.Model;
using Newtonsoft.Json;
using Windows.Storage;
using Windows.Storage.Streams;

namespace Pizza.com.DataProvider
{
    public class PizzaDataProvider
    {
        private static ObservableCollection<Product> productList = null;

        private static readonly string _customersFileName = "pizza.json";
        //private static readonly string _customersFileName = "D:\\Work\\projects\\WPF_UWP\\UWP\\Pizza.com\\Pizza.com\\Data\\product";
        private static StorageFolder _localFolder = ApplicationData.Current.LocalFolder;
        public PizzaDataProvider() 
        {
        }

        public async Task<ObservableCollection<Product>> GetProductByCategory(Constants.ProductTypes productType)
        {
            if (productList == null)
            {
                productList = new ObservableCollection<Product>();
                productList = await LoadPizzaAsync();
            }
            var ItemList = productList.Select(p => p).Where(p => p.Type == productType);
            ObservableCollection<Product> ItemCollection = new ObservableCollection<Product>(ItemList);
            return ItemCollection;
        }

        public async Task<ObservableCollection<Product>> LoadPizzaAsync()
        {
            var storageFile = await _localFolder.TryGetItemAsync(_customersFileName) as StorageFile;
            //C:\Users\Joel\AppData\Local\Packages\e5cb593e-9ffe-42d8-bf5b-8578d007eedf_ka9b83fa3fse2\LocalState\pizza.json
            ObservableCollection<Product> productList = new ObservableCollection<Product>();

            if (storageFile == null)
            {
                productList.Add(new Model.Product("Choco-Lava cake", 100, "Indulgent molten lava inside chocolate cake", Constants.ProductTypes.Sliders));
                productList.Add(new Model.Product("Garlic Breadsticks with dip", 100, "Your perfect pizza partner", Constants.ProductTypes.Sliders));
                productList.Add(new Model.Product("Chocolate Mousse cake", 100, "Sweet temptation", Constants.ProductTypes.Sliders));
                productList.Add(new Model.Product("Potato bites", 70, "Crisp and golden, flavourfull cheese burst", Constants.ProductTypes.Sliders));
                productList.Add(new Model.Product("Maggi", 50, "No description needed!", Constants.ProductTypes.Sliders));
                productList.Add(new Model.Product("Virgin mojito", 60, "Refreshing lime juice and mint leaves combo", Constants.ProductTypes.Beverages));
                productList.Add(new Model.Product("Creamy mango shake", 100, "Great mango taste topped with whipped cream", Constants.ProductTypes.Beverages));
                productList.Add(new Model.Product("Diet coke", 80, "For people loving 0 calory drinks", Constants.ProductTypes.Beverages));
                productList.Add(new Model.Product("Pepsi", 60, "Refreshing carbonated drink", Constants.ProductTypes.Beverages));
                productList.Add(new Model.Product("Ice tea", 60, "Refreshing and energizing", Constants.ProductTypes.Beverages));
                productList.Add(new Model.Product("Margherita", 99, "classic delight with 100% mozzarella cheese", Constants.ProductTypes.VegPizza));
                productList.Add(new Model.Product("Farmhouse", 250, "Delightful combo of onion, capsicum and mushrooms", Constants.ProductTypes.VegPizza));
                productList.Add(new Model.Product("Paneer Delight", 250, "Flavourful trio of juicy paneer,capsicum and paprika", Constants.ProductTypes.VegPizza));
                productList.Add(new Model.Product("Veggie paradise", 300, "Foresum of golden corn,olives,capsicum and paprika", Constants.ProductTypes.VegPizza));
                productList.Add(new Model.Product("Delux Veggie", 300, "Veg delight with grilled mushroom and juicy paneer", Constants.ProductTypes.VegPizza));
                productList.Add(new Model.Product("Chicken Sausage", 110, "American classic! herbed chichen sausage on pizza", Constants.ProductTypes.NonVegPizza));
                productList.Add(new Model.Product("NonVeg Loaded", 250, "Trio of chicken sausage,pepper barbeque and peri peri chicken", Constants.ProductTypes.NonVegPizza));
                productList.Add(new Model.Product("Chicken golden Delight", 280, "Pepper barbeque chicken with golden corn", Constants.ProductTypes.NonVegPizza));
                productList.Add(new Model.Product("Chicken Dominator", 350, "Loaded with chicken tikka and grilled chicken bites", Constants.ProductTypes.NonVegPizza));
                productList.Add(new Model.Product("Chicken Papperoni", 350, "Relish the flavour of chicken pepperoni with loaded cheese", Constants.ProductTypes.NonVegPizza));

                //Uncomment this when you want to generate the Json file with above data.
                await SaveCustomersAsync(productList);
            }
            else
            {
                using (var stream = await storageFile.OpenAsync(FileAccessMode.Read))
                {
                    using (var dataReader = new DataReader(stream))
                    {
                        await dataReader.LoadAsync((uint)stream.Size);
                        var json = dataReader.ReadString((uint)stream.Size);
                        productList = JsonConvert.DeserializeObject<ObservableCollection<Product>>(json);
                    }
                }
            }

            return productList;
        }

        public async Task SaveCustomersAsync(IEnumerable<Product> customers)
        {
            var storageFile = await _localFolder.CreateFileAsync(_customersFileName, CreationCollisionOption.ReplaceExisting);
            //path: C:\Users\john.patole\AppData\Local\Packages\81cf5b69-9d9a-443f-9d2a-ef882b81ba53_899brbe7kttgg\LocalState\pizza.json
            using (var stream = await storageFile.OpenAsync(FileAccessMode.ReadWrite))
            {
                using (var dataWriter = new DataWriter(stream))
                {
                    var json = JsonConvert.SerializeObject(customers, Formatting.Indented);
                    dataWriter.WriteString(json);
                    await dataWriter.StoreAsync();
                }
            }
        }
    }
}
