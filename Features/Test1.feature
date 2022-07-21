Feature: Heroku App Test 1

Background: 
	Given the herokuapp.com url is selected ​

Scenario: Challenging​ Buttons
	When the Dynamic Buttons Challenge 01 link is selected
	And the following buttons are selected
		| button |
		| start  |
		| One    |
		| Two    |
		| Three  |
	Then the All Buttons Clicked text is displayed
