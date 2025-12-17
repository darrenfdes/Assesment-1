using AvalphaTechnologies.CommissionCalculator.Dtos;

namespace AvalphaTechnologies.CommissionCalculator.Services
{
    public class CommissionCalculationService : ICommissionCalculationService
    {
        public CommissionCalculationResponse CalculateCommission(int localSalesCount, int foreignSalesCount, decimal averageSaleAmount)
        {
            return new CommissionCalculationResponse
            {
                AvalphaTechnologiesCommissionAmount = 999,
                CompetitorCommissionAmount = 100
            };
        }
    }

}
