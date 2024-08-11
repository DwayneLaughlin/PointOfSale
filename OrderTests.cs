using System.Collections.Generic;
using FastFoodPOS.FoodItems.Class;
using FastFoodPOS.FoodItems.Condiments;
using FastFoodPOS.FoodItems.Interfaces;
using Xunit;
namespace FastFoodPOS.Tests;

public class OrderTests
{
    [Fact]
    public void TestAddCondimentKetchupOk()
    {
        //Arrange
        Order order = new Order();
        string ketchup = "ketchup";

        //Act
        order.AddCondiment(ketchup);

        //Assert
        List<IFood> orderList = order.GetOrder();
        Assert.NotEmpty(orderList);
        Assert.Single(orderList);
        Assert.Equal(.25, orderList.First().GetPrice());
        Assert.IsType<Ketchup>(orderList.First());
    }

    [Fact]
    public void TestAddCondimentMustardOk()
    {
        //Arrange
        Order order = new Order();
        string mustard = "mustard";

        //Act
        order.AddCondiment(mustard);

        //Assert
        List<IFood> orderList = order.GetOrder();
        Assert.NotEmpty(orderList);
        Assert.Single(orderList);
        Assert.Equal(.25, orderList.First().GetPrice());
        Assert.IsType<Mustard>(orderList.First());
    }

    [Fact]
    public void TestAddCondimentKetchupQuantityException()
    {
        //Arrange
        Order order = new Order();
        List<IFood> list = new List<IFood>()
        {
            new Ketchup(),
            new Ketchup(),
            new Ketchup()
        };
        
        order._foodItems = list;

        //Act & Assert
        Assert.Throws<Exception>(() => order.AddCondiment("ketchup"));
    }

    [Fact]
    public void TestAddCondimentMustardQuantityException()
    {
        //Arrange
        Order order = new Order();
        List<IFood> list = new List<IFood>()
        {
            new Mustard(),
            new Mustard(),
            new Mustard()
        };
        
        order._foodItems = list;


        //Act & Assert
        Assert.Throws<Exception>(() => order.AddCondiment("mustard"));
    }

    [Fact]
    public void TestAddFoodBurgerOk()
    {
        //Arrange
        Order order = new Order();

        //Act
        order.AddFood("burger", "small");

        //Assert
        List<IFood> result = order._foodItems;
        Assert.NotNull(result);
        Assert.Single(result);
        Assert.IsType<Burger>(result.First());
        Assert.Equal("small", result.First().GetSize());
    }

    [Fact]
    public void TestAddFoodOnionRingsOk()
    {
        //Arrange
        Order order = new Order();

        //Act
        order.AddFood("onionRings", "medium");

        //Assert
        List<IFood> result = order._foodItems;
        Assert.NotNull(result);
        Assert.Single(result);
        Assert.IsType<Burger>(result.First());
        Assert.Equal("medium", result.First().GetSize());
    }

    [Fact]
    public void TestAddFoodChickenSandwichOk()
    {
        //Arrange
        Order order = new Order();

        //Act
        order.AddFood("chickenSandwich", "small");

        //Assert
        List<IFood> result = order._foodItems;
        Assert.NotNull(result);
        Assert.Single(result);
        Assert.IsType<ChickenSandwich>(result.First());
        Assert.Equal("small", result.First().GetSize());
    }

    [Fact]
    public void TestAddFoodFriesOk()
    {
        //Arrange
        Order order = new Order();

        //Act
        order.AddFood("fries", "medium");

        //Assert
        List<IFood> result = order._foodItems;
        Assert.NotNull(result);
        Assert.Single(result);
        Assert.IsType<Fries>(result.First());
        Assert.Equal("medium", result.First().GetSize());
    }

    [Fact]
    public void TestAddFoodMilkshakeOk()
    {
        //Arrange
        Order order = new Order();

        //Act
        order.AddFood("milkshake", "large");

        //Assert
        List<IFood> result = order._foodItems;
        Assert.NotNull(result);
        Assert.Single(result);
        Assert.IsType<Milkshake>(result.First());
        Assert.Equal("large", result.First().GetSize());
    }

    [Fact]
    public void TestAddFoodArgumentException()
    {
        //Arrange
        Order order = new Order();

        //Act & Assert
        Assert.Throws<ArgumentException>(() => order.AddFood("turkey", "large"));
    }
}
