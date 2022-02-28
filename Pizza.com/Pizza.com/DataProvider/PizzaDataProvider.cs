using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pizza.com.Model;

namespace Pizza.com.DataProvider
{
    public class PizzaDataProvider
    {
        ObservableCollection<Model.Product> vegPizzaList;
        ObservableCollection<Model.Product> nonVegPizzaList;
        ObservableCollection<Model.Product> slider;
        ObservableCollection<Model.Product> beverages;

        public PizzaDataProvider() 
        {
            vegPizzaList = new ObservableCollection<Model.Product>();
            nonVegPizzaList = new ObservableCollection<Model.Product>();
            slider = new ObservableCollection<Model.Product>();
            beverages = new ObservableCollection<Model.Product>(); 
        }

        public ObservableCollection<Model.Product> GetVegPizzaList() 
        {
            vegPizzaList.Add(new Model.Product("Margherita", 99, "classic delight with 100% mozzarella cheese", Constants.ProductTypes.VegPizza));
            vegPizzaList.Add(new Model.Product("Farmhouse", 250, "Delightful combo of onion, capsicum and mushrooms", Constants.ProductTypes.VegPizza));
            vegPizzaList.Add(new Model.Product("Paneer Delight", 250, "Flavourful trio of juicy paneer,capsicum and paprika", Constants.ProductTypes.VegPizza));
            vegPizzaList.Add(new Model.Product("Veggie paradise", 300, "Foresum of golden corn,olives,capsicum and paprika", Constants.ProductTypes.VegPizza));
            vegPizzaList.Add(new Model.Product("Delux Veggie", 300, "Veg delight with grilled mushroom and juicy paneer", Constants.ProductTypes.VegPizza));

            return vegPizzaList;
        }

        public ObservableCollection<Model.Product> GetNonVegPizzaList()
        {
            nonVegPizzaList.Add(new Model.Product("Chicken Sausage", 110, "American classic! herbed chichen sausage on pizza", Constants.ProductTypes.NonVegPizza));
            nonVegPizzaList.Add(new Model.Product("NonVeg Loaded", 250, "Trio of chicken sausage,pepper barbeque and peri peri chicken", Constants.ProductTypes.NonVegPizza));
            nonVegPizzaList.Add(new Model.Product("Chicken golden Delight", 280, "Pepper barbeque chicken with golden corn", Constants.ProductTypes.NonVegPizza));
            nonVegPizzaList.Add(new Model.Product("Chicken Dominator", 350, "Loaded with chicken tikka and grilled chicken bites", Constants.ProductTypes.NonVegPizza));
            nonVegPizzaList.Add(new Model.Product("Chicken Papperoni", 350, "Relish the flavour of chicken pepperoni with loaded cheese", Constants.ProductTypes.NonVegPizza));

            return nonVegPizzaList;
        }

        public ObservableCollection<Model.Product> GetBeveragesList()
        {
            beverages.Add(new Model.Product("Virgin mojito", 60, "Refreshing lime juice and mint leaves combo", Constants.ProductTypes.Beverages));
            beverages.Add(new Model.Product("Creamy mango shake", 100, "Great mango taste topped with whipped cream", Constants.ProductTypes.Beverages));
            beverages.Add(new Model.Product("Diet coke", 80, "For people loving 0 calory drinks", Constants.ProductTypes.Beverages));
            beverages.Add(new Model.Product("Pepsi", 60, "Refreshing carbonated drink", Constants.ProductTypes.Beverages));
            beverages.Add(new Model.Product("Ice tea", 60, "Refreshing and energizing", Constants.ProductTypes.Beverages));

            return beverages;
        }

        public ObservableCollection<Model.Product> GetSidersList()
        {
            slider.Add(new Model.Product("Choco-Lava cake", 100, "Indulgent molten lava inside chocolate cake", Constants.ProductTypes.Sliders));
            slider.Add(new Model.Product("Garlic Breadsticks with dip", 100, "Your perfect pizza partner", Constants.ProductTypes.Sliders));
            slider.Add(new Model.Product("Chocolate Mousse cake", 100, "Sweet temptation", Constants.ProductTypes.Sliders));
            slider.Add(new Model.Product("Potato bites", 70, "Crisp and golden, flavourfull cheese burst", Constants.ProductTypes.Sliders));
            slider.Add(new Model.Product("Maggi", 50, "No description needed!", Constants.ProductTypes.Sliders));

            return slider;
        }
    }
}
