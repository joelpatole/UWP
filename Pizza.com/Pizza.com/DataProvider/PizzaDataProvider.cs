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

        public ObservableCollection<Pizza1> GetPizzaList() 
        {
            pizzaList.Add(new Pizza1("pizza1", 300, "good pizza - fjsdlafjsdkfjsdkfla"));
            pizzaList.Add(new Pizza1("pizza2", 400, "cool pizza - fsfsfa"));
            pizzaList.Add(new Pizza1("pizza3", 500, "cheesy pizza - fsdfasdfdadsfa"));
            pizzaList.Add(new Pizza1("pizza4", 600, "spicy pizza - fsdafdsa"));
            pizzaList.Add(new Pizza1("pizza5", 700, "hot pizza - fsdafsdafadfa"));

            return pizzaList;
        }
    }
}
