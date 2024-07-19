using CDBCalculator.Api.Application.Services;
using CDBCalculator.Api.Core.Entities;

namespace CDBCalculator.Test
{
    public class InvestmentCalculatorServiceTests
    {
        private readonly InvestmentCalculatorService _service;

        public InvestmentCalculatorServiceTests()
        {
            _service = new InvestmentCalculatorService();
        }

        [Fact]
        public void Calculate_ShouldReturnCorrectValues()
        {
            var request = new InvestmentRequest { InitialValue = 1000m, Months = 12 };

            var result = _service.Calculate(request);

            decimal expectedGrossResult = 1000m * (decimal)Math.Pow((double)(1 + (0.009m * 1.08m)), 12);
            decimal expectedNetResult = expectedGrossResult - (expectedGrossResult - 1000m) * 0.20m;

            decimal tolerance = 0.0001m;
            Assert.Equal(expectedGrossResult, result.GrossResult, precision: 4);
            Assert.Equal(expectedNetResult, result.NetResult, precision: 4);
        }

        [Fact]
        public void Calculate_ShouldThrowArgumentNullException_WhenRequestIsNull()
        {
            InvestmentRequest request = null;

            var exception = Assert.Throws<ArgumentNullException>(() => _service.Calculate(request));
            Assert.Equal("Os dados de entrada não foram informados", exception.ParamName);
        }

        [Fact]
        public void Calculate_ShouldThrowArgumentException_WhenInitialValueIsZeroOrNegative()
        {
            var request = new InvestmentRequest { InitialValue = 0, Months = 12 };

            var exception = Assert.Throws<ArgumentException>(() => _service.Calculate(request));
            Assert.Equal("O valor inicial deve ser maior que zero", exception.Message);
        }

        [Fact]
        public void Calculate_ShouldThrowArgumentException_WhenMonthsIsLessThanOrEqualToOne()
        {
            var request = new InvestmentRequest { InitialValue = 1000m, Months = 1 };

            var exception = Assert.Throws<ArgumentException>(() => _service.Calculate(request));
            Assert.Equal("O prazo deverá ser maior que 1 mês", exception.Message);
        }
    }
}