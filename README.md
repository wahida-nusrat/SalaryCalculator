# SalaryCalculator
This is a console application which take individual gross salary package and pay freequency as input and breakdown the salary and dispay pay packet.
## Feature
Accept input from user 
Calculate super, taxable incone, taxalbe deductions (medical levy, budget repair levy, income tax), net income and pay packet as per user requirement.
Display breakdown salay
Implement SOLID principle to maintain code quality and extendability.
Implement unit test for some scenerios using xunit framework and mocking where we have depenency injection.

## Architecture
Ensure seperation of concerns through Helix arcitechure design. Confirming decoupling feature of Helix by not refereing feature to feature, foundation to foundation
Use data layer(Model), business layer(Service) in feature project.
Perfrm unit testing
Perform logging and the location of log file in root folder.

## Design Pattern
Perform validation for wrong input like string, out of range or negative value for gross salary and except only w, f, m either small or capital letter for pay freequency.
Implement abstration by using interface and implementation when require.
Singleton design pattern is used.
Depency Injection is used to inject dependency(configuration, logger) in classes for promoting loose coupling and easeair unit testing. 
As logging is implementing in foundation layer and injecting thorugh DI, there is a scope to replace logginf framework by changing that speicifc project only. No need to change where it is used.

## Scope
Provide flexibility for changing super rate, income tier, deduction rate, extra tax payment(if any (currently only for income tax)) etc in appsettings.json config file if any changes in future.
Provide flexibility for adding any new deduction ( currently we have medical levy, budget repair levy, income tax). If any new deduction come just add it in config file. Code will handle it.
Provide flexibility for any modification in salary calculation rules in the implementation of IncomeCalculation class.
Provide flexibility for adding new rules like bonous by adding and modifying the method in IncomeCalculation class and use it through CalculationService.
Scope of addying any new service like caching by creating in foundation layer and injeccting it through dependecy injection.

## Framework
.Net Core 8
Microsoft Extension Depenncy Injection
Micforsoft Entenstion Configuration 
Log4Net for logging
Xunit for testing

## Usage
Clone the repository to your local machine
Open the project in Visual studio
Run the project

## Future scope
More unit testing
More esception hadling by using try catch
Logging in global level
Implement caching

## Result Mismatch
Incometax calculation has littile difference because of the requirement is nearest rounded up dollar. Mathc.Celing givigh that result.
