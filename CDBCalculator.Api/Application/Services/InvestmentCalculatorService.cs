using CDBCalculator.Api.Core.Entities;
using CDBCalculator.Api.Core.Interfaces;

namespace CDBCalculator.Api.Application.Services;

public class InvestmentCalculatorService : IInvestmentCalculator
{
    private const decimal CDI = 0.009m;
    private const decimal TB = 1.08m;

    public InvestmentResult Calculate(InvestmentRequest request)
    {
        validate(request);

        decimal grossResult = CalculateGrossResult(request.InitialValue, request.Months);
        decimal netResult = CalculateNetResult(request.InitialValue, grossResult, request.Months);

        return new InvestmentResult
        {
            GrossResult = grossResult,
            NetResult = netResult,
            Result = "Sucesso"
        };
    }

    private void validate(InvestmentRequest request)
    {
        if (request == null)
            throw new ArgumentNullException("Os dados de entrada não foram informados");

        if (request.InitialValue <= 0)
            throw new ArgumentException("O valor inicial deve ser maior que zero");

        if (request.Months <= 1)
            throw new ArgumentException("O prazo deverá ser maior que 1 mês");
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
