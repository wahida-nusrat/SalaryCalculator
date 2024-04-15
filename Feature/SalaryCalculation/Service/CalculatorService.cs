using Logging.Interface;
using Microsoft.Extensions.Configuration;
using SalaryCalculation.Models;
using SalaryCalculaton.Services.Implementation;
namespace SalaryCalculation.Service
{
    public class CalculatorService 
    {
        private readonly IConfiguration _configuration;
        private readonly Ilogger _logger;

        public CalculatorService(IConfiguration configuration, Ilogger logger)
        {
            _configuration = configuration;
            _logger = logger;
        }
        public SingleTaxPayer Calculaton(Input userInput)
        {
            var taxPayer = new SingleTaxPayer();
            
            // calculation
            var incomeCalculation = new IncomeCalculation(_configuration,_logger);
            taxPayer.GrossSalary = userInput.GrossSalary;
            taxPayer.SuberContribution = incomeCalculation.CalculateSuper(userInput.GrossSalary);
            taxPayer.TaxableIncome = incomeCalculation.CalculateTaxableIncome(userInput.GrossSalary, taxPayer.SuberContribution);
            taxPayer.TaxableDeductions = incomeCalculation.GetTaxableDeductions(taxPayer.TaxableIncome);
            taxPayer.DeductionsAmount = incomeCalculation.CalculateDeductions(taxPayer.TaxableDeductions);
            taxPayer.NetIncome = incomeCalculation.CaclulateNetIncome(taxPayer.GrossSalary, taxPayer.SuberContribution, taxPayer.DeductionsAmount);
            taxPayer.PayPacket = incomeCalculation.CalculatePayPacket(userInput.PayFreequency, taxPayer.NetIncome);

            return taxPayer;
        }
       
    }
}
