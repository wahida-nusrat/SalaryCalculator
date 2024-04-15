using System;
using System.Collections.Generic;
namespace SalaryCalculation.Models
{
    public class TaxPayer
    {
        public int GrossSalary { get; set; }

        public decimal TaxableIncome { get; set; }

        public decimal SuberContribution { get; set; }
        public List<TaxableDeduction> TaxableDeductions { get; set; }
        public decimal DeductionsAmount { get; set; }
        public decimal NetIncome { get; set; }
        public string? PayPacket { get; set; }
        
    }
}
