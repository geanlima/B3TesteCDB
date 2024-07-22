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
    public void Calculate_ShouldReturnCorrectValues()
    {
        var request = new InvestmentRequest { InitialValue = 1000m, Months = 12 };

        _mockValidator.Setup(v => v.Validate(It.IsAny<InvestmentRequest>()));

        var result = _service.Calculate(request);

        decimal expectedGrossResult = 1000m * (decimal)Math.Pow((double)(1 + (0.009m * 1.08m)), 12);
        decimal expectedNetResult = expectedGrossResult - (expectedGrossResult - 1000m) * 0.20m;

        Assert.Equal(expectedGrossResult, result.GrossResult, precision: 4);
        Assert.Equal(expectedNetResult, result.NetResult, precision: 4);
    }

    [Fact]
    public void Calculate_ShouldCallValidator()
    {
        var request = new InvestmentRequest { InitialValue = 1000m, Months = 12 };

        _mockValidator.Setup(v => v.Validate(It.IsAny<InvestmentRequest>())).Verifiable();

        _service.Calculate(request);

        _mockValidator.Verify(v => v.Validate(It.IsAny<InvestmentRequest>()), Times.Once);
    }

    [Fact]
    public void Calculate_ShouldThrowArgumentException_WhenInitialValueIsZeroOrNegative()
    {
        var request = new InvestmentRequest { InitialValue = 0, Months = 12 };

        _mockValidator.Setup(v => v.Validate(It.IsAny<InvestmentRequest>())).Throws(new ArgumentException("O valor inicial deve ser maior que zero"));

        var exception = Assert.Throws<ArgumentException>(() => _service.Calculate(request));
        Assert.Equal("O valor inicial deve ser maior que zero", exception.Message);
    }

    [Fact]
    public void Calculate_ShouldThrowArgumentException_WhenMonthsIsLessThanOrEqualToOne()
    {
        var request = new InvestmentRequest { InitialValue = 1000m, Months = 1 };

        _mockValidator.Setup(v => v.Validate(It.IsAny<InvestmentRequest>())).Throws(new ArgumentException("O prazo deverá ser maior que 1 mês"));

        var exception = Assert.Throws<ArgumentException>(() => _service.Calculate(request));
        Assert.Equal("O prazo deverá ser maior que 1 mês", exception.Message);
    }
}