using FastFoodPOS;
using FastFoodPOS.FoodItems.Class;
using FastFoodPOS.FoodItems.Interfaces;

Order order = new Order();
order.AddFood("burger", "medium");
order.AddFood("burger", "large");
order.AddFood("burger", "large");
order.AddCondiment("ketchup");
order.AddFood("milkshake", "small");
Transaction transaction = new Transaction(order);
transaction.AddFunds(20.00);
transaction.AddFunds(11.25);



Console.WriteLine(transaction.AttemptPayment(1.00));



