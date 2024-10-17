using Moq;
using Smartwyre.DeveloperTest.Interfaces;
using Smartwyre.DeveloperTest.Services;
using Smartwyre.DeveloperTest.Types;
using System.Collections.Generic;
using Xunit;

namespace Smartwyre.DeveloperTest.Tests;

public class PaymentServiceTests
{
    private readonly Mock<IRebateDataStore> _rebateDataStoreMock;
    private readonly Mock<IProductDataStore> _productDataStoreMock;
    private readonly RebateService _rebateService;

    public PaymentServiceTests()
    {
        _rebateDataStoreMock = new Mock<IRebateDataStore>();
        _productDataStoreMock = new Mock<IProductDataStore>();

        var calculators = new List<IRebateCalculator>
        {
            new FixedCashAmountCalculator()
        };

        _rebateService = new RebateService(_rebateDataStoreMock.Object, _productDataStoreMock.Object, calculators);
    }

    [Fact]
    public void CalculateRebate_ShouldReturnSuccess_ForFixedCashAmount()
    {
        // Arrange
        var rebate = new Rebate { Identifier = "REBATE123", Incentive = IncentiveType.FixedCashAmount, Amount = 100 };
        var product = new Product { Identifier = "PINEAPPLE005", SupportedIncentives = SupportedIncentiveType.FixedCashAmount };

        _rebateDataStoreMock.Setup(r => r.GetRebate(It.IsAny<string>())).Returns(rebate);
        _productDataStoreMock.Setup(p => p.GetProduct(It.IsAny<string>())).Returns(product);

        var request = new CalculateRebateRequest
        {
            RebateIdentifier = "REBATE123",
            ProductIdentifier = "PINEAPPLE005",
            Volume = 10
        };

        // Act
        var result = _rebateService.Calculate(request);

        // Assert
        Assert.True(result.Success);
        _rebateDataStoreMock.Verify(r => r.StoreCalculationResult(rebate, 100), Times.Once);
    }

    [Fact]
    public void CalculateRebate_ShouldFail_WhenProductDoesNotSupportIncentiveType()
    {
        // Arrange
        var rebate = new Rebate { Identifier = "REBATE1235", Incentive = IncentiveType.FixedCashAmount, Amount = 100 };
        var product = new Product { Identifier = "PRODUCT1234", Price = 50, SupportedIncentives = SupportedIncentiveType.FixedRateRebate };

        _rebateDataStoreMock.Setup(r => r.GetRebate(It.IsAny<string>())).Returns(rebate);
        _productDataStoreMock.Setup(p => p.GetProduct(It.IsAny<string>())).Returns(product);

        var request = new CalculateRebateRequest
        {
            RebateIdentifier = "REBATE1235",
            ProductIdentifier = "PRODUCT1234",
            Volume = 10
        };

        // Act
        var result = _rebateService.Calculate(request);

        // Assert
        Assert.False(result.Success);
        _rebateDataStoreMock.Verify(r => r.StoreCalculationResult(It.IsAny<Rebate>(), It.IsAny<decimal>()), Times.Never);
    }

    [Fact]
    public void CalculateRebate_ShouldFail_WhenProductIsNull()
    {
        // Arrange
        var rebate = new Rebate { Identifier = "REBATE123", Incentive = IncentiveType.FixedCashAmount, Amount = 100 };

        _rebateDataStoreMock.Setup(r => r.GetRebate(It.IsAny<string>())).Returns(rebate);
        _productDataStoreMock.Setup(p => p.GetProduct(It.IsAny<string>())).Returns((Product)null); // Product not found

        var request = new CalculateRebateRequest
        {
            RebateIdentifier = "REBATE123",
            ProductIdentifier = "INVALID_PRODUCT",
            Volume = 10
        };

        // Act
        var result = _rebateService.Calculate(request);

        // Assert
        Assert.False(result.Success); // Product is null, so the calculation should fail
        _rebateDataStoreMock.Verify(r => r.StoreCalculationResult(It.IsAny<Rebate>(), It.IsAny<decimal>()), Times.Never); // StoreCalculationResult should not be called
    }

}
