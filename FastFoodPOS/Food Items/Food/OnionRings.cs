using System;
using System.Diagnostics;
using FastFoodPOS.FoodItems.Interfaces;

namespace FastFoodPOS.FoodItems.Class
{
	public class OnionRings : IFood
    {
        private double price;
        private string type;

        public OnionRings()
		{
            price = 3.50;
            type = "Onion Rings";
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

