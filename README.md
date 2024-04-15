# SalaryCalculator
* This is a console application which takes individual gross salary packages and pay frequency as input and breaks down the salary and display pay packet.
## Feature
* Accept input from user 
* Calculate super, taxable income, taxable deductions (medical levy, budget repair levy, income tax), net income and pay packet as per user requirement.
* Display breakdown calculated salary.
* Ensure separation of concern through clean architecture design.
* Provide extension and modification of business logic by using a separate business layer.
* Implement unit tests for some scenarios  and mocking where we have dependency in classes.
* Perform logging and the location of the log file in the root folder.

## Architecture
* Ensure separation of concerns through Helix architecture design. Confirming decoupling feature of Helix by not referring feature to feature, foundation to foundation
* Use data layer(Model), business layer(Service), Presentation layer(IO) in feature project.
  
## Design Pattern
* Perform validation for wrong user input like string, out of range or negative value for gross salary and except only w, f, m either small or capital letter for pay frequency.
* Implement abstraction by using interface and implementation when required.
* Implement encapsulation by using private methods and property.
* Implement the SOLID principle to maintain code quality and extendability. 
* A Singleton design pattern is used.
* Implement factory design pattern by using tax payer as base class. Only single tax payer is used here, but has scope to add executive, family tax payer in future.
* Dependency Injection is used to inject dependency(configuration, logger) in classes for promoting loose coupling and easier unit testing. 
  
## Scope
* Provide flexibility for changing super rate, income tier, deduction rate, extra tax payment(if any (currently only for income tax)) etc in appsettings.json config file if any changes in future.
* Provide flexibility for adding any new deduction (currently we have medical levy, budget repair levy, income tax). If any new deduction comes just add it in the config file. Code will handle it.
* Provide flexibility for calculating income tax for different role like executive, single or family level.
* Provide flexibility for any modification in salary calculation rules in the implementation of IncomeCalculation class.
* Provide flexibility for adding new rules like bonus by adding and modifying the method in IncomeCalculation class and use it through CalculationService.
* As logging is implemented in the foundation layer and injected through DI, there is a scope to replace logging framework by changing that specific project only. No need to change where it is used.
* Scope of adding any new service like caching by creating a project in the foundation layer and injecting it through dependency injection.

## Technology
* .Net Core 8
* C#
* Microsoft Extension Dependency Injection
* Microsoft Extension Configuration 
* Log4Net for logging
* Xunit for testing

## Usage
* Clone the repository to your local machine
* Open the project in Visual studio
* Run the project "SalaryCalculator". It is configured as startup project

## Future scope
* More unit testing
* More exception handling by using try catch
* Logging in global level
* Implement caching

## Result Mismatch
* Income Tax calculation has little difference because of the requirement is nearest rounded up dollar. From the formula the result is 10839.23. When Math.Ceiling method is used it returns 10840 not 10839. It impacted on net income and pay packet as well.

* ## Contributor
* Wahida Nusrat(nusrat_cse@yahoo.com)


