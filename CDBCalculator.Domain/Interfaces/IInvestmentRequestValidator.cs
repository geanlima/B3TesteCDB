using CDBCalculator.Domain.Entities;

namespace CDBCalculator.Domain.Interfaces;

public interface IInvestmentRequestValidator
{
    void Validate(InvestmentRequest request);
}
