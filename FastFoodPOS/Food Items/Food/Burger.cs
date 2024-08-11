using System;
using FastFoodPOS.FoodItems.Interfaces;
namespace FastFoodPOS.FoodItems.Class

{
	public class Burger : IFood
    {
		private double price;
		private string type;

		public Burger()
		{
			price = 8.50;
			type = "Burger";
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

