using System;
using FastFoodPOS.FoodItems.Interfaces;

namespace FastFoodPOS.FoodItems.Condiments
{
	public class Ketchup : IFood
	{
		private double price;
		private string type;
		
		
		public Ketchup()
		{
			price = .25;
			type = "Ketchup";
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

