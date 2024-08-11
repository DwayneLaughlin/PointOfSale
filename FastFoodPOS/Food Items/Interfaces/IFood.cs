using System;
namespace FastFoodPOS.FoodItems.Interfaces
{
	public interface IFood
	{
		double GetPrice();
		string GetSize();
		string GetItemType();
	}
}

