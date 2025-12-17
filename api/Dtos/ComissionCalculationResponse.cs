using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvalphaTechnologies.CommissionCalculator.Dtos
{

    public class CommissionCalculationResponse
    {
        public decimal AvalphaTechnologiesCommissionAmount { get; set; }

        public decimal CompetitorCommissionAmount { get; set; }
    }
}