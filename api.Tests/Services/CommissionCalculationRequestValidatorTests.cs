using AvalphaTechnologies.CommissionCalculator.Dtos;
using AvalphaTechnologies.CommissionCalculator.Validators;
using FluentValidation.TestHelper;
using Xunit;

namespace api.Tests.Services
{
    public class CommissionCalculationRequestValidatorTests
    {
        [Fact]
        public void Validator_ShouldFail_WhenSalesCountsAreNegative()
        {
            // Given
            var validator = new CommissionCalculationRequestValidator();

            var request = new CommissionCalculationRequest
            {
                LocalSalesCount = -1,
                ForeignSalesCount = -5,
                AverageSaleAmount = 100m
            };

            // When
            var result = validator.TestValidate(request);

            // Then
            result.ShouldHaveValidationErrorFor(x => x.LocalSalesCount);
            result.ShouldHaveValidationErrorFor(x => x.ForeignSalesCount);
        }
    }
}