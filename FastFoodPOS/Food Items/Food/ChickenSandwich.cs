using System;
using System.Diagnostics;
using FastFoodPOS.FoodItems.Interfaces;

namespace FastFoodPOS.FoodItems.Class
{
	public class ChickenSandwich : IFood
	{
        private double price;
        private string type;


        public ChickenSandwich()
		{
            price = 6.50;
            type = "Chicken Sandwich";
		}

        public string? Size { get; set; }

        public double GetPrice()
        {
            return price;
        }

        public string GetSize()
        {
            return Size;
        }

        public string GetItemType()
        {
            return type;
        }
    }
}

