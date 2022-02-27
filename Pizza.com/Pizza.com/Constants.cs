using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza.com
{
    public static class Constants
    {
        public static readonly string ApplicationName = "Pizza.com";
        public static readonly string ApplicationVersion = "1.0";
        public static readonly string ApplicationDescription = "This app orders food in store.";

        public enum ProductTypes
        {
            VegPizza,
            NonVegPizza,
            Beverages,
            Sliders,
            None
        }
    }
}
