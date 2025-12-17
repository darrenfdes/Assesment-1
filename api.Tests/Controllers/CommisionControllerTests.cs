using Xunit;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using AvalphaTechnologies.CommissionCalculator.Controllers;
using AvalphaTechnologies.CommissionCalculator.Dtos;

namespace AvalphaTechnologies.CommissionCalculator.Tests.Controllers
{
    public class CommisionControllerTests
    {
        [Fact]
        public void Calculate_WithValidRequest_ShouldReturnOkResultWithCommissionResponse()
        {
            // Given
            var controller = new CommisionController();
            var request = new CommissionCalculationRequest
            {
                LocalSalesCount = 5,
                ForeignSalesCount = 3,
                AverageSaleAmount = 1000m
            };

            // When
            var result = controller.Calculate(request);

            // Then
            var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
            okResult.StatusCode.Should().Be(200);

            var response = okResult.Value.Should().BeOfType<CommissionCalculationResponse>().Subject;
            response.AvalphaTechnologiesCommissionAmount.Should().Be(999);
            response.CompetitorCommissionAmount.Should().Be(100);
        }
    }
}
