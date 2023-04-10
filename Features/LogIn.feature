Feature: Log in




Scenario: Member can login after successful registered 
	Given the user has successfully registered 
	When they fill in login credentials
	Then they should be able to login 
