using AvalphaTechnologies.CommissionCalculator.Dtos;

namespace AvalphaTechnologies.CommissionCalculator.Services
{
    public class CommissionCalculationService : ICommissionCalculationService
    {
        public CommissionCalculationResponse CalculateCommission(int localSalesCount, int foreignSalesCount, decimal averageSaleAmount)
        {
            var avalphaLocalCommission = localSalesCount * averageSaleAmount * 0.20m;

            var avalphaForeignCommission = foreignSalesCount * averageSaleAmount * 0.35m;

            var competitorLocalCommission = localSalesCount * averageSaleAmount * 0.02m;

            var competitorForeignCommission = foreignSalesCount * averageSaleAmount * 0.0755m;

            return new CommissionCalculationResponse
            {
                AvalphaTechnologiesCommissionAmount = avalphaLocalCommission + avalphaForeignCommission,

                CompetitorCommissionAmount = competitorLocalCommission + competitorForeignCommission
            };
        }
    }

}
