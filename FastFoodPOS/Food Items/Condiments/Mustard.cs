using System;
using System.Diagnostics;
using FastFoodPOS.FoodItems.Interfaces;

namespace FastFoodPOS.FoodItems.Condiments
{
	public class Mustard : IFood
	{
        private double price;
        private string type;

		public Mustard()
		{
            price = .25;
            type = "Mustard";
		}

        public double GetPrice()
        {
            return price;
        }

        public string GetSize()
        {
            return "N/A";
        }
        public string GetItemType()
        {
            return type;
        }
    }
}

