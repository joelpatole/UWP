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
        ObservableCollection<Pizza1> pizzaList;

        public PizzaDataProvider() 
        {
            pizzaList = new ObservableCollection<Pizza1>();
        }

        public ObservableCollection<Pizza1> GetVegPizzaList() 
        {
            pizzaList.Add(new Pizza1("Margherita", 99, "classic delight with 100% mozzarella cheese"));
            pizzaList.Add(new Pizza1("Farmhouse", 250, "Delightful combo of onion, capsicum and mushrooms"));
            pizzaList.Add(new Pizza1("Paneer Delight", 250, "Flavourful trio of juicy paneer,capsicum and paprika"));
            pizzaList.Add(new Pizza1("Veggie paradise", 300, "Foresum of golden corn,olives,capsicum and paprika"));
            pizzaList.Add(new Pizza1("Delux Veggie", 300, "Veg delight with grilled mushroom and juicy paneer"));

            return pizzaList;
        }

        public ObservableCollection<Pizza1> GetNonVegPizzaList()
        {
            pizzaList.Add(new Pizza1("Chicken Sausage", 110, "American classic! herbed chichen sausage on pizza"));
            pizzaList.Add(new Pizza1("NonVeg Loaded", 250, "Trio of chicken sausage,pepper barbeque and peri peri chicken"));
            pizzaList.Add(new Pizza1("Chicken golden Delight", 280, "Pepper barbeque chicken with golden corn"));
            pizzaList.Add(new Pizza1("Chicken Dominator", 350, "Loaded with chicken tikka and grilled chicken bites"));
            pizzaList.Add(new Pizza1("Chicken Papperoni", 350, "Relish the flavour of chicken pepperoni with loaded cheese"));

            return pizzaList;
        }
    }
}
