using Microsoft.Extensions.Configuration;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SalaryCalculaton.Services.Interface;
using SalaryCalculaton.Services.Implementation;
using Xunit;
using Logging.Interface;

namespace SalaryCalculatorTest
{
    //[TestClass]
    public class IncomeCalculationTests
    {
        private readonly Mock<IConfiguration> _mockConfiguration;
        private readonly Mock<Ilogger> _mockLogger;

        public IncomeCalculationTests()
        {
            // mocking for configuration and logger
            // so that we can test which class have depenency
            _mockConfiguration = new Mock<IConfiguration>();
            _mockLogger = new Mock<Ilogger>();  
        }

        [Fact]
        public void CalculateSuper_intSalary()
        {
            decimal expectedResult = 5639.27m;
            int inputGrossSalary = 65000;

            _mockConfiguration.Setup(x => x.GetSection("Super:Rate").Value).Returns("0.095");
            var incomeCalculationObject = new IncomeCalculation(_mockConfiguration.Object, _mockLogger.Object);
            decimal result= incomeCalculationObject.CalculateSuper(inputGrossSalary);
            
            Assert.Equal(expectedResult, result);

        }

        // check it the input salary is out of int range value
        // it will throw exception in that case
        [Fact]
        public void CalculateSuper_outOfRangeSalary()
        {
            int inputGrossSalary = int.MaxValue;

            _mockConfiguration.Setup(x => x.GetSection("Super:Rate").Value).Returns("0.095");
            var incomeCalculationObject = new IncomeCalculation(_mockConfiguration.Object, _mockLogger.Object);

            Assert.Throws<Exception>(() => incomeCalculationObject.CalculateSuper(inputGrossSalary + 1));

        }

        [Fact]
        public void CalculateTaxableIncome_intSalary_decSuper()
        {
            int inputGrossSalary = 65000;
            decimal inputSuper = 5639.27m;
            decimal expectedReult = 59360.73m;
            
            var incomeCalculationObject = new IncomeCalculation(_mockConfiguration.Object, _mockLogger.Object);
            decimal result = incomeCalculationObject.CalculateTaxableIncome(inputGrossSalary, inputSuper);
            
            Assert.Equal(expectedReult, result);
        }
    }
}