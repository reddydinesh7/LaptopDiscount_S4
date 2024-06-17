using LaptopDiscount_S4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountTest
{
    [TestClass]
    public class EmployeeDiscountTests
    {
        [TestMethod]
        public void CalculateDiscountedPrice_PartTimeEmployee_NoDiscount()
        {
            // Arrange
            var employee = new EmployeeDiscount
            {
                EmployeeType = EmployeeType.PartTime,
                Price = 1000
            };

            // Act
            decimal discountedPrice = employee.CalculateDiscountedPrice();

            // Assert
            Assert.AreEqual(1000, discountedPrice);
        }
    }

    [TestMethod]
    public void CalculateDiscountedPrice_PartialLoadEmployee_5PercentDiscount()
    {
        // Arrange
        var employee = new EmployeeDiscount
        {
            EmployeeType = EmployeeType.PartialLoad,
            Price = 1000
        };

        // Act
        decimal discountedPrice = employee.CalculateDiscountedPrice();

        // Assert
        Assert.AreEqual(950, discountedPrice);
    }

    [TestMethod]
    public void CalculateDiscountedPrice_FullTimeEmployee_10PercentDiscount()
    {
        // Arrange
        var employee = new EmployeeDiscount
        {
            EmployeeType = EmployeeType.FullTime,
            Price = 1000
        };

        // Act
        decimal discountedPrice = employee.CalculateDiscountedPrice();

        // Assert
        Assert.AreEqual(900, discountedPrice);
    }

    [TestMethod]
    public void CalculateDiscountedPrice_CompanyPurchasingEmployee_20PercentDiscount()
    {
        // Arrange
        var employee = new EmployeeDiscount
        {
            EmployeeType = EmployeeType.CompanyPurchasing,
            Price = 1000
        };

        // Act
        decimal discountedPrice = employee.CalculateDiscountedPrice();

        // Assert
        Assert.AreEqual(800, discountedPrice);
    }

    [TestMethod]
    public void CalculateDiscountedPrice_DecimalPrecision_CorrectResult()
    {
        // Arrange
        var employee = new EmployeeDiscount
        {
            EmployeeType = EmployeeType.PartialLoad,
            Price = 999.99m
        };

        // Act
        decimal discountedPrice = employee.CalculateDiscountedPrice();

        // Assert
        Assert.AreEqual(949.9905m, discountedPrice);
    }
    [TestMethod]
    public void CalculateDiscountedPrice_NegativePrice_ThrowsException()
    {
        // Arrange
        var employee = new EmployeeDiscount
        {
            EmployeeType = EmployeeType.FullTime,
            Price = -100
        };

        // Act & Assert
        Assert.ThrowsException<ArgumentException>(() => employee.CalculateDiscountedPrice());
    }
}

