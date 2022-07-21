Feature: Test 2

Background: 
	Given the herokuapp.com url is selected ​

Scenario Outline: Calculator​ Functions
	When the Calculate link is selected
	When the 1st value <Input1> is entered
	And the calculator <Operator> is selected
	And the 2nd value <Input2> is entered
	And the sum is submitted
	Then the <Answer> is validated

Examples:
	| Id | Operator | Input1 | Input2 | Answer |
	| 1  | plus     | 1.1    | 2.2    | 3.3    |
	| 1a | plus     | -1.1   | 2.2    | 1.1    |
	| 2  | minus    | 100    | 2      | 98     |
	| 2a | minus    | 100    | -2     | 102    |
	| 3  | times    | 3.1    | 4.2    | 13.02  |
	| 4  | divide   | 20     | 10     | 2      |
	| 4a | divide   | 20     | -10    | -2     |
