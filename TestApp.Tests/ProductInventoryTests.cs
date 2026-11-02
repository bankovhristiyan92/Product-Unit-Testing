using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using NUnit.Framework;
using TestApp.Product;

namespace TestApp.Tests;

[TestFixture]
public class ProductInventoryTests
{
    private ProductInventory _inventory = null!;

    [SetUp]
    public void SetUp()
    {
        this._inventory = new();
    }

    [Test]
    public void Test_AddProduct_ProductAddedToInventory()
    {
        // Arrange
        string name = "Laptop";
        double price = 999.99;
        int quantity = 2;

        // Act
        this._inventory.AddProduct(name, price, quantity);

        // Assert
        string expected = $"Product Inventory:{Environment.NewLine}Laptop - Price: $999.99 - Quantity: 2";
        string result = this._inventory.DisplayInventory();

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_DisplayInventory_NoProducts_ReturnsEmptyString()
    {
        // Act
        string result = this._inventory.DisplayInventory();

        // Assert
        Assert.That(result, Is.EqualTo("Product Inventory:"));
    }

    [Test]
    public void Test_DisplayInventory_WithProducts_ReturnsFormattedInventory()
    {
        // Arrange
        this._inventory.AddProduct("Laptop", 1000.00, 2);
        this._inventory.AddProduct("Mouse", 25.50, 4);

        string expected = $"Product Inventory:{Environment.NewLine}Laptop - Price: $1000.00 - Quantity: 2{Environment.NewLine}Mouse - Price: $25.50 - Quantity: 4";

        // Act
        string result = this._inventory.DisplayInventory();

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_CalculateTotalValue_NoProducts_ReturnsZero()
    {
        // Act
        double result = this._inventory.CalculateTotalValue();

        // Assert
        Assert.That(result, Is.EqualTo(0));
    }

    [Test]
    public void Test_CalculateTotalValue_WithProducts_ReturnsTotalValue()
    {
        // Arrange
        this._inventory.AddProduct("Laptop", 1000.00, 2); // 2000.00
        this._inventory.AddProduct("Mouse", 25.50, 4);    // 102.00

        // Act
        double result = this._inventory.CalculateTotalValue();

        // Assert
        Assert.That(result, Is.EqualTo(2102.00));
    }
}