using CDBCalculator.Api.Core.Entities;

namespace CDBCalculator.Api.Core.Interfaces;

public interface IInvestmentCalculator
{
    InvestmentResult Calculate(InvestmentRequest request);
}
