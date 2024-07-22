
using CDBCalculator.Domain.Entities;
using CDBCalculator.Domain.Validators;

namespace CDBCalculator.Test.Validators;

public class InvestmentRequestValidatorTests
{
    private readonly InvestmentRequestValidator _validator;

    public InvestmentRequestValidatorTests()
    {
        _validator = new InvestmentRequestValidator();
    }

    [Fact]
    public void Validate_ShouldThrowArgumentException_WhenInitialValueIsZeroOrNegative()
    {
        var request = new InvestmentRequest { InitialValue = 0, Months = 12 };

        var exception = Assert.Throws<ArgumentException>(() => _validator.Validate(request));
        Assert.Equal("O valor inicial deve ser maior que zero", exception.Message);
    }

    [Fact]
    public void Validate_ShouldThrowArgumentException_WhenMonthsIsLessThanOrEqualToOne()
    {
        var request = new InvestmentRequest { InitialValue = 1000m, Months = 1 };

        var exception = Assert.Throws<ArgumentException>(() => _validator.Validate(request));
        Assert.Equal("O prazo deverá ser maior que 1 mês", exception.Message);
    }
}
