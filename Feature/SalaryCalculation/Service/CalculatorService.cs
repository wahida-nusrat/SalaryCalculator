using Logging.Interface;
using Microsoft.Extensions.Configuration;
using SalaryCalculation.Models;
using SalaryCalculaton.Services.Implementation;
using SalaryCalculaton.Services.Interface;
namespace SalaryCalculation.Service
{
    public class CalculatorService 
    {
        private readonly IConfiguration _configuration;
        private readonly Ilogger _logger;
        private readonly IIncomeCalculation _incomeCalculation;

        public CalculatorService(IConfiguration configuration, Ilogger logger, IIncomeCalculation incomeCalculation)
        {
            _configuration = configuration;
            _logger = logger;
            _incomeCalculation = incomeCalculation;
        }
        public SingleTaxPayer Calculaton(Input userInput)
        {
            var taxPayer = new SingleTaxPayer();
            
            // calculation
            taxPayer.GrossSalary = userInput.GrossSalary;
            taxPayer.SuberContribution = _incomeCalculation.CalculateSuper(userInput.GrossSalary);
            taxPayer.TaxableIncome = _incomeCalculation.CalculateTaxableIncome(userInput.GrossSalary, taxPayer.SuberContribution);
            taxPayer.TaxableDeductions = _incomeCalculation.GetTaxableDeductions(taxPayer.TaxableIncome);
            taxPayer.DeductionsAmount = _incomeCalculation.CalculateDeductions(taxPayer.TaxableDeductions);
            taxPayer.NetIncome = _incomeCalculation.CaclulateNetIncome(taxPayer.GrossSalary, taxPayer.SuberContribution, taxPayer.DeductionsAmount);
            taxPayer.PayPacket = _incomeCalculation.CalculatePayPacket(userInput.PayFreequency, taxPayer.NetIncome);
            return taxPayer;
        }
       
    }
}
