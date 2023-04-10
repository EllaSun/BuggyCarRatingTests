Feature: Vote favourite car


Scenario: Existing member can vote 
	Given the user logged in
	When they choose their favourite car
	Then they should be able to vote it
	And a message should be displayed like: You have voted!

