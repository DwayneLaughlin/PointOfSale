using System;
using System.Diagnostics;
using FastFoodPOS.FoodItems.Interfaces;

namespace FastFoodPOS.FoodItems.Class
{
	public class Milkshake : IFood
    {
        private double price;
        private string type;

        public Milkshake()
		{
            price = 4.00;
            type = "Milkshake";
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


