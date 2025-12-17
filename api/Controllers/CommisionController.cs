using Microsoft.AspNetCore.Mvc;
using AvalphaTechnologies.CommissionCalculator.Dtos;
using AvalphaTechnologies.CommissionCalculator.Services;

namespace AvalphaTechnologies.CommissionCalculator.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommisionController(ICommissionCalculationService commisionCalculationService) : ControllerBase
    {
        private readonly ICommissionCalculationService _commisionCalculationService = commisionCalculationService;

        [ProducesResponseType(typeof(CommissionCalculationResponse), 200)]
        [HttpPost]
        public IActionResult Calculate(CommissionCalculationRequest calculationRequest)
        {
            return Ok(_commisionCalculationService.CalculateCommission(calculationRequest.LocalSalesCount, calculationRequest.ForeignSalesCount, calculationRequest.AverageSaleAmount));
        }
    }
}
