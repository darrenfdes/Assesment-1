using Xunit;
using FluentAssertions;
using AvalphaTechnologies.CommissionCalculator.Services;


namespace AvalphaTechnologies.CommissionCalculator.Tests.Services
{
    public class CommissionCalculationServiceTests
    {
        [Fact]
        public void CalculateCommission_ShouldReturnExpectedResult()
        {
            // Given
            var service = new CommissionCalculationService();
            int localSalesCount = 5;
            int foreignSalesCount = 3;
            decimal averageSaleAmount = 1000m;

            // When
            var result = service.CalculateCommission(localSalesCount, foreignSalesCount, averageSaleAmount);

            // Then
            result.Should().NotBeNull();
            result.AvalphaTechnologiesCommissionAmount.Should().Be(999);
            result.CompetitorCommissionAmount.Should().Be(100);
        }
    }
}
