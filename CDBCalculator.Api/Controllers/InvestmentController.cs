using CDBCalculator.Api.Core.Entities;
using CDBCalculator.Api.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CDBCalculator.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvestmentController : ControllerBase
    {
        private readonly IInvestmentCalculator _investmentCalculator;

        public InvestmentController(IInvestmentCalculator investmentCalculator)
        {
            _investmentCalculator = investmentCalculator;
        }

        [HttpPost("calculate")]
        public ActionResult<InvestmentResult> CalculateInvestment([FromBody] InvestmentRequest request)
        {
            try
            {
                return _investmentCalculator.Calculate(request);
            }
            catch (ArgumentNullException ex) 
            { 
                return new InvestmentResult() { Result = ex.ParamName };
            }
            catch (Exception ex)
            {
                return new InvestmentResult() { Result = ex.Message };
            }
        }

    }
}
