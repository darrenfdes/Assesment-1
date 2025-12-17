using Microsoft.AspNetCore.Mvc;
using AvalphaTechnologies.CommissionCalculator.Dtos;
using AvalphaTechnologies.CommissionCalculator.Services;

namespace AvalphaTechnologies.CommissionCalculator.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommisionController(ICommissionCalculationService commissionCalculationService) : ControllerBase
    {
        private readonly ICommissionCalculationService _commissionCalculationService = commissionCalculationService;

        [ProducesResponseType(typeof(CommissionCalculationResponse), 200)]
        [HttpPost]
        public IActionResult Calculate(CommissionCalculationRequest calculationRequest)
        {
            try
            {
                var result = _commissionCalculationService.CalculateCommission(
                    calculationRequest.LocalSalesCount,
                    calculationRequest.ForeignSalesCount,
                    calculationRequest.AverageSaleAmount);

                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(
            StatusCodes.Status500InternalServerError,
            new ErrorResponse
            {
                Message = "An unexpected error occurred while calculating commission."
            });
            }
        }
    }
}
