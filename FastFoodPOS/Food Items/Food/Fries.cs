using System;
using System.Diagnostics;
using FastFoodPOS.FoodItems.Interfaces;

namespace FastFoodPOS.FoodItems.Class
{
	public class Fries : IFood
    {
        private double price;
        public string type;
        
        public Fries()
		{
            price = 3.00;
            type = "French Fries";
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


