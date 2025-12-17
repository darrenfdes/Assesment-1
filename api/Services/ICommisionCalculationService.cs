using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AvalphaTechnologies.CommissionCalculator.Dtos;

namespace AvalphaTechnologies.CommissionCalculator.Services
{
    public interface ICommissionCalculationService
    {
        CommissionCalculationResponse CalculateCommission(int localSalesCount, int foreignSalesCount, decimal averageSaleAmount);
    }
}