using Logging.Implementation;
using Logging.Interface;
using SalaryCalculation.Service;
using SalaryCalculator;
using SalaryCalculation.IO;
using System.Runtime.CompilerServices;

// setup configuration from appsettings.cs
var configuration = Setup.ConfigurationSetup();

// setup logging framework
Setup.LoggingSetup();
Ilogger logger = new Logger();
mainService();


void mainService()
{
    // take input for gross salary and pay freequency
    var inputServic = new InputService();
    var userInput = inputServic.UserInput();

    // performing all calculations
    var calculationService = new CalculatorService(configuration, logger);
    var taxPayer = calculationService.Calculaton(userInput);

    // display income details
    var outputService = new OutputService();
    outputService.Dispaly(taxPayer);

    Console.WriteLine("Do you want to continue another calculation? (y/n)");
    string cont = Console.ReadLine();
    if (cont.ToLower() == "y")
    {
        mainService();
    }

}


