using AvalphaTechnologies.CommissionCalculator.Dtos;
using FluentValidation;


namespace AvalphaTechnologies.CommissionCalculator.Services
{
    public class CommissionCalculationRequestValidator : AbstractValidator<CommissionCalculationRequest>
    {
        public CommissionCalculationRequestValidator()
        {
            RuleFor(x => x.LocalSalesCount).GreaterThanOrEqualTo(0);
            RuleFor(x => x.ForeignSalesCount).GreaterThanOrEqualTo(0);
            RuleFor(x => x.AverageSaleAmount).GreaterThanOrEqualTo(0);
        }
    }
}