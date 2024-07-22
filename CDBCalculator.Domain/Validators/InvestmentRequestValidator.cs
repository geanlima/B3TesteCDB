using CDBCalculator.Domain.Entities;
using CDBCalculator.Domain.Interfaces;

namespace CDBCalculator.Domain.Validators;

public class InvestmentRequestValidator : IInvestmentRequestValidator
{
    public void Validate(InvestmentRequest request)
    {
        if (request == null)
            throw new ArgumentNullException(nameof(request), "Os dados de entrada não foram informados");

        if (request.InitialValue <= 0)
            throw new ArgumentException("O valor inicial deve ser maior que zero");

        if (request.Months <= 1)
            throw new ArgumentException("O prazo deverá ser maior que 1 mês");
    }
}
