using Xunit;
using FluentAssertions;
using AvalphaTechnologies.CommissionCalculator.Services;


namespace AvalphaTechnologies.CommissionCalculator.Tests.Services
{
    public class CommissionCalculationServiceTests
    {
        [Fact]
        public void CalculateCommission_UseValidInputs_ReturnCorrectCommissionAmounts()
        {
            // Given
            var service = new CommissionCalculationService();
            int localSalesCount = 5;
            int foreignSalesCount = 3;
            decimal averageSaleAmount = 1000m;

            // When
            var result = service.CalculateCommission(
                localSalesCount,
                foreignSalesCount,
                averageSaleAmount);

            // Then
            result.Should().NotBeNull();

            result.AvalphaTechnologiesCommissionAmount
                  .Should().Be(2050m);

            result.CompetitorCommissionAmount
                  .Should().Be(326.5m);
        }

        [Fact]
        public void CalculateCommission_ZeroSales_ReturnZeroCommission()
        {
            // Given
            var service = new CommissionCalculationService();
            int localSalesCount = 0;
            int foreignSalesCount = 0;
            decimal averageSaleAmount = 1000m;

            // When
            var result = service.CalculateCommission(
                localSalesCount,
                foreignSalesCount,
                averageSaleAmount);

            // Then
            result.AvalphaTechnologiesCommissionAmount.Should().Be(0m);
            result.CompetitorCommissionAmount.Should().Be(0m);
        }

    }
}
