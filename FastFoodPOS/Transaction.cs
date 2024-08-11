using System;
using FastFoodPOS.FoodItems.Class;
using FastFoodPOS.FoodItems.Condiments;
using FastFoodPOS.FoodItems.Interfaces;
using Microsoft.VisualBasic;

namespace FastFoodPOS
{
	public class Transaction
	{
        private Order order;
        private double customerPayment;

		public Transaction(Order order)
		{
            this.order = order;
            customerPayment = 0;
		}

        public double CalculateOrderTotal()
        {
            double orderTotal = 0;
            List<IFood> orderList = order.GetOrder();

            foreach (IFood item in orderList)
            {
                double itemPrice = item.GetPrice();
                if (item.GetType() == typeof(Ketchup) || item.GetType() == typeof(Mustard))
                {
                    orderTotal += itemPrice;
                }
                else
                {
                    if (item.GetSize() == "small")
                    {
                        orderTotal += item.GetPrice();
                    }
                    else if (item.GetSize() == "medium")
                    {
                        double mediumPrice = itemPrice += .50;
                        orderTotal += (mediumPrice);
                    }
                    else if (item.GetSize() == "large")
                    {
                        double largePrice = itemPrice += 1.00;
                        orderTotal += largePrice;
                    }

                }

            }
            return orderTotal;
        }

        public double AddFunds(double amount)
        {
            if(amount < .05)
            {
                throw new ArgumentException("We are unable to take coins that are less than 5 cents");
            }
            if(amount > 20.00)
            {
                throw new ArgumentException("We are unable to accept bills larger than $20");
            }
            customerPayment += amount;
            return customerPayment;
        }


		public string AttemptPayment(double submittedPayment)
		{
            double requiredAmount = CalculateOrderTotal();
            double updatedCustomerPayment = customerPayment += submittedPayment;
            if(updatedCustomerPayment < requiredAmount)
            {
                return $"Insufficient funds. Please add more money. You need ${requiredAmount -= updatedCustomerPayment}";
                
            }
            else if(customerPayment == requiredAmount)
            {
                return $"Payment Successful. Your order is {CompleteTransaction()}";
            }
            else
            {
                return $"Payment Successful.{Environment.NewLine}Your order is {CompleteTransaction()} {Environment.NewLine}${customerPayment -= requiredAmount} is your change";
            }
 
		}

        public string CompleteTransaction()
        {
            List<string> itemsList = new List<string>();
            foreach(IFood item in order.GetOrder())
            {
                string itemizedItem;
                if (item.GetSize() != "N/A")
                {
                    itemizedItem =  $" {item.GetSize()} {item.GetItemType()}";
                }
                else
                {
                    itemizedItem = $" {item.GetItemType()}";
                }
                itemsList.Add(itemizedItem);
            }
            string list = string.Join<string>(",", itemsList);
            return list;
        }
	}
}

