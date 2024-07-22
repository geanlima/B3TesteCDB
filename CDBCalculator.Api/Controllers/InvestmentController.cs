using CDBCalculator.Domain.Entities;
using CDBCalculator.Domain.Interfaces;
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
                var result = _investmentCalculator.Calculate(request);
                return Ok(result);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(new { Message = ex.ParamName });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = ex.Message });
            }
        }
    }
}
