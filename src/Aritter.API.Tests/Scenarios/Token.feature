Feature: Token
	To ensure system security
    I want to check if the system is authenticating and generating tokens

Background: The database should have valid data
    Given I have cleaned the database
    And I created the users
    | UserName | FirstName     | Email             | MustChangePassword | IsActive |
    | admin    | Administrator | admin@aritter.com | 0                  | 1        |

Scenario: Generate token
    Given I create a 'POST' request with content 'grant_type=password&username=admin&password=jki@b46t' like text
	When I send to the 'token' resource
	Then the result should be a 'OK' status code
