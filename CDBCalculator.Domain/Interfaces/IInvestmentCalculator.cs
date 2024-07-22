using CDBCalculator.Domain.Entities;

namespace CDBCalculator.Domain.Interfaces;

public interface IInvestmentCalculator
{
    InvestmentResult Calculate(InvestmentRequest request);
}
