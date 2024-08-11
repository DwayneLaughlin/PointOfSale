using System;
using FastFoodPOS.FoodItems.Interfaces;
using FastFoodPOS.FoodItems.Condiments;
using FastFoodPOS.FoodItems.Class;

namespace FastFoodPOS
{
    public class Order
    {
        public List<IFood> _foodItems;
        

        public Order()
        {
            _foodItems = new List<IFood>();
           
        }

        public string? Status { get; set; }


        public void AddCondiment(string condiment)
        {
            if (condiment == "ketchup")
            {
                int ketchupCount = 0;
                foreach (IFood foodItem in _foodItems)
                {
                    if (foodItem.GetType() == typeof(Ketchup))
                    {
                        ketchupCount++;
                    }
                }

                if (ketchupCount >= 3)
                {
                    throw new Exception("You cannot order more than 3 ketchups");
                }
                else
                {
                    _foodItems.Add(new Ketchup());
                }
            }
            if (condiment == "mustard")
            {
                int mustardCount = 0;
                foreach (IFood foodItem in _foodItems)
                {
                    if (foodItem.GetType() == typeof(Mustard))
                    {
                        mustardCount++;
                    }
                }

                if (mustardCount >= 3)
                {
                    throw new Exception("You cannot order more than 3 mustards");
                }
                else
                {
                    _foodItems.Add(new Mustard());
                }
            }
            
        }

        public void AddFood(string foodItem, string size)
        {
            switch (foodItem)
            {
                case "burger":
                    Burger burger = new Burger();
                    burger.Size = size;
                    _foodItems.Add(burger);
                    break;
                case "fries":
                    Fries fries = new Fries();
                    fries.Size = size;
                    _foodItems.Add(fries);
                    break;
                case "milkshake":
                    Milkshake shake = new Milkshake();
                    shake.Size = size;
                    _foodItems.Add(shake);
                    break;
                case "onionRings":
                    OnionRings onionRings = new OnionRings();
                    onionRings.Size = size;
                    _foodItems.Add(onionRings);
                    break;
                case "chickenSandwich":
                    ChickenSandwich chickenSandwich = new ChickenSandwich();
                    chickenSandwich.Size = size;
                    _foodItems.Add(chickenSandwich);
                    break;
                default:
                    throw new ArgumentException("Invalid food Selection. Please try again");
            }
            

        }

        public List<IFood> GetOrder()
        {
            return _foodItems;
        }
    }
}

