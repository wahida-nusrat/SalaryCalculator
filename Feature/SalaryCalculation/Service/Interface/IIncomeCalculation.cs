using SalaryCalculation.Models;

namespace SalaryCalculaton.Services.Interface
{
    public interface IIncomeCalculation
    {
        decimal CalculateSuper(int grossSalary);
        decimal CalculateTaxableIncome(int grossSalary, decimal super);
        decimal CalculateDeductions(List<TaxableDeduction> taxableDeductions);
        decimal CaclulateNetIncome(decimal grossIncome, decimal super, decimal taxableDeductions);
        string CalculatePayPacket(string payFreequency, decimal netIncome);
        List<TaxableDeduction>? GetTaxableDeductions(decimal taxableIncome);
    }
}
