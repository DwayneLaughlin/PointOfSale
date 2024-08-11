using System;
using FastFoodPOS.FoodItems.Class;
using FastFoodPOS.FoodItems.Interfaces;
using Xunit;
namespace FastFoodPOS.Tests
{
	public class TransActionTests
	{
        [Fact]
        public void TestCalculateOrderTotalOK()
        {
            //Arrange
            Order order = new Order();
            Burger burger1 = new Burger();
            Burger burger2 = new Burger();
            burger1.Size = "small";
            burger2.Size = "medium";
            double total = 17.50;
            List<IFood> list = new List<IFood>()
                {
                    burger1,
                    burger2
                };
            order._foodItems = list;
            Transaction transaction = new Transaction(order);

            //Act
            double result = transaction.CalculateOrderTotal();

            //Assert
            Assert.Equal(total, result);

        }

        [Fact]
        public void TestAddFundsOk()
        {
            //Arrange
            Order order = new Order();
            Transaction transaction = new Transaction(order);
            double amount = 10;

            //Act
            double result = transaction.AddFunds(amount);

            //Assert
            Assert.Equal(amount, result);
        }

        [Fact]
        public void TestAddFundsBigBillException()
        {
            //Arrange
            Order order = new Order();
            Transaction transaction = new Transaction(order);
            double amount = 100;

            //Act & Assert
            Assert.Throws<ArgumentException>(() => transaction.AddFunds(amount));

        }

        [Fact]
        public void TestAddFundsSmallCoinException()
        {
            //Arrange
            Order order = new Order();
            Transaction transaction = new Transaction(order);
            double amount = .01;

            //Act & Assert
            Assert.Throws<ArgumentException>(() => transaction.AddFunds(amount));

        }

        [Fact]
        public void TestAttemptPaymentNoChange()
        {
            //Arrange
            Order order = new Order();
            Burger burger1 = new Burger();
            Burger burger2 = new Burger();
            burger1.Size = "small";
            burger2.Size = "medium";
            List<IFood> list = new List<IFood>()
                {
                    burger1,
                    burger2
                };
            order._foodItems = list;
            Transaction transaction = new Transaction(order);

            //Act
            string result = transaction.AttemptPayment(17.50);

            //Assert
            Assert.NotNull(result);
            Assert.Contains("Payment Successful",result);
            Assert.DoesNotContain("change", result);
        }

        [Fact]
        public void TestAttemptPaymentChangeOwed()
        {
            //Arrange
            Order order = new Order();
            Burger burger1 = new Burger();
            Burger burger2 = new Burger();
            burger1.Size = "small";
            burger2.Size = "medium";
            List<IFood> list = new List<IFood>()
                {
                    burger1,
                    burger2
                };
            order._foodItems = list;
            Transaction transaction = new Transaction(order);

            //Act
            string result = transaction.AttemptPayment(18.00);

            //Asser
            Assert.NotNull(result);
            Assert.Contains("change", result);
        }

        [Fact]
        public void TestAttemptPaymentInsufficientFunds()
        {
            //Arrange
            Order order = new Order();
            Burger burger1 = new Burger();
            Burger burger2 = new Burger();
            burger1.Size = "small";
            burger2.Size = "medium";
            List<IFood> list = new List<IFood>()
                {
                    burger1,
                    burger2
                };
            order._foodItems = list;
            Transaction transaction = new Transaction(order);

            //Act
            string result = transaction.AttemptPayment(1.00);

            //Assert
            Assert.NotNull(result);
            Assert.Contains("Insufficient", result);
        }
    }
}

