using CDBCalculator.Domain.Entities;
using CDBCalculator.Domain.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace CDBCalculator.Domain.Services;

public class InvestmentCalculatorService : IInvestmentCalculator
{
    private const decimal CDI = 0.009m;
    private const decimal TB = 1.08m;
    private readonly IInvestmentRequestValidator _validator;

    public InvestmentCalculatorService(IInvestmentRequestValidator validator)
    {
        _validator = validator;
    }
    public InvestmentResult Calculate(InvestmentRequest request)
    {
        _validator.Validate(request);

        decimal grossResult = CalculateGrossResult(request.InitialValue, request.Months);
        decimal netResult = CalculateNetResult(request.InitialValue, grossResult, request.Months);

        return new InvestmentResult
        {
            GrossResult = grossResult,
            NetResult = netResult,
            Result = "Sucesso"
        };
    }

    private decimal CalculateGrossResult(decimal initialValue, int months)
    {
        decimal result = initialValue;

        for (int i = 0; i < months; i++)
        {
            result *= (1 + (CDI * TB));
        }

        return result;
    }

    private decimal CalculateNetResult(decimal initialValue, decimal grossResult, int months)
    {
        decimal taxRate = GetTaxRate(months);
        decimal tax = (grossResult - initialValue) * taxRate;
        return grossResult - tax;
    }

    private decimal GetTaxRate(int months)
    {
        if (months <= 6) return 0.225m;
        if (months <= 12) return 0.20m;
        if (months <= 24) return 0.175m;
        return 0.15m;
    }
}
