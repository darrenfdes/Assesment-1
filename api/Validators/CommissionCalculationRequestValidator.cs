using AvalphaTechnologies.CommissionCalculator.Dtos;
using FluentValidation;


namespace AvalphaTechnologies.CommissionCalculator.Validators
{
    public class CommissionCalculationRequestValidator : AbstractValidator<CommissionCalculationRequest>
    {
        public CommissionCalculationRequestValidator()
        {
            RuleFor(x => x.LocalSalesCount).GreaterThanOrEqualTo(0).LessThanOrEqualTo(1_000_000);
            RuleFor(x => x.ForeignSalesCount).GreaterThanOrEqualTo(0).LessThanOrEqualTo(1_000_000); ;
            RuleFor(x => x.AverageSaleAmount).GreaterThanOrEqualTo(0).LessThanOrEqualTo(1_000_000); ;
        }
    }
}