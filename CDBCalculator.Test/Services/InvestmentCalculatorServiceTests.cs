using CDBCalculator.Domain.Entities;
using CDBCalculator.Domain.Interfaces;
using CDBCalculator.Domain.Services;
using Moq;

namespace CDBCalculator.Test.Services;

public class InvestmentCalculatorServiceTests
{
    private readonly Mock<IInvestmentRequestValidator> _mockValidator;
    private readonly InvestmentCalculatorService _service;

    public InvestmentCalculatorServiceTests()
    {
        _mockValidator = new Mock<IInvestmentRequestValidator>();
        _service = new InvestmentCalculatorService(_mockValidator.Object);
    }

    [Fact]
    public void Calculate_ShouldCallValidator()
    {
        var request = new InvestmentRequest { InitialValue = 1000m, Months = 12 };

        _mockValidator.Setup(v => v.Validate(It.IsAny<InvestmentRequest>())).Verifiable();

        _service.Calculate(request);

        _mockValidator.Verify(v => v.Validate(It.IsAny<InvestmentRequest>()), Times.Once);
    }

    [Theory]
    [InlineData(1000, 6, 0.225)]
    [InlineData(1000, 12, 0.20)]
    [InlineData(1000, 24, 0.175)]
    [InlineData(1000, 36, 0.15)]
    public void Calculate_ShouldReturnCorrectNetValues(decimal initialValue, int months, decimal taxRate)
    {
        var request = new InvestmentRequest { InitialValue = initialValue, Months = months };

        _mockValidator.Setup(v => v.Validate(It.IsAny<InvestmentRequest>()));

        var result = _service.Calculate(request);

        decimal expectedGrossResult = initialValue * (decimal)Math.Pow((double)(1 + (0.009m * 1.08m)), months);
        decimal expectedNetResult = expectedGrossResult - (expectedGrossResult - initialValue) * taxRate;

        Assert.Equal(expectedGrossResult, result.GrossResult, precision: 4);
        Assert.Equal(expectedNetResult, result.NetResult, precision: 4);
    }

    
}