Feature: Register

As a visitor
I want to be able to register in the website


@Smoke
Scenario: New member can register successfully 
	Given new visitor open register page
	When they fill in First Name 'Hello'
	And they fill in Last Name 'World'
	And they fill in unique Login
	And they fill in Password 'Test123!'
	And they fill same Confirm Password
	And they click Register button
	#Then a message should be displayed Registration is successful'

