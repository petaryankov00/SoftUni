using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Cake : Dessert
    {
        private const double grams = 250;
        private const decimal price = 5M;
        private const double calories = 1000;


        public Cake(string name)
            : base(name, price, grams,calories)
        {

        }
    }
}
