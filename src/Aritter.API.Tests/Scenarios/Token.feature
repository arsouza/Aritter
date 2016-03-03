Feature: Token
	To ensure system security
    I want to check if the system is authenticating and generating tokens

Background: The database should have valid data
    Given I have cleaned the database
    And I created the users
    | UserName | FirstName     | Email             | MustChangePassword | IsActive |
    | admin    | Administrator | admin@aritter.com | 0                  | 1        |
    
@ClearScenarioContext
Scenario: Generate token with valid username and password
    Given I created a 'POST' request with content 'grant_type=password&username=admin&password=jki@b46t' like text
	When I send to the 'token' resource
	Then The result should be a 'OK' status code
    And The result should contain
    | JSONPath           | 
	| access_token       | 
	| token_type         | 
	| expires_in         | 
	| refresh_token      |
    
@ClearScenarioContext
Scenario: Generate token with invalid username and password
    Given I created a 'POST' request with content 'grant_type=password&username=test&password=test' like text
	When I send to the 'token' resource
	Then The result should be a 'BadRequest' status code
    And The result should contain values
    | JSONPath          | Value                                   |
    | error             | invalid_grant                           |
    | error_description | The user name or password is incorrect. |
    
@ClearScenarioContext
Scenario: Refresh token sucessfully
    Given I created a 'POST' request with content 'grant_type=password&username=admin&password=jki@b46t' like text
	When I send to the 'token' resource
	Then The result should be a 'OK' status code
    And The result should contain
    | JSONPath           | 
	| access_token       | 
	| token_type         | 
	| expires_in         | 
	| refresh_token      |
    And will store the JSON value
	| JSONPath      | Key             |
	| refresh_token | RefreshTokenKey |
    Given I created a 'POST' request with content 'grant_type=refresh_token&refresh_token={RefreshTokenKey}' like text
	When I send to the 'token' resource
	Then The result should be a 'OK' status code
    And The result should contain
    | JSONPath           | 
	| access_token       | 
	| token_type         | 
	| expires_in         | 
	| refresh_token      | 
    
@ClearScenarioContext
Scenario: Refresh token already used
    Given I created a 'POST' request with content 'grant_type=password&username=admin&password=jki@b46t' like text
	When I send to the 'token' resource
	Then The result should be a 'OK' status code
    And The result should contain
    | JSONPath           | 
	| access_token       | 
	| token_type         | 
	| expires_in         | 
	| refresh_token      |
    And will store the JSON value
	| JSONPath      | Key             |
	| refresh_token | RefreshTokenKey |
    Given I created a 'POST' request with content 'grant_type=refresh_token&refresh_token={RefreshTokenKey}' like text
	When I send to the 'token' resource
	Then The result should be a 'OK' status code
    And The result should contain
    | JSONPath           | 
	| access_token       | 
	| token_type         | 
	| expires_in         | 
	| refresh_token      | 
    Given I created a 'POST' request with content 'grant_type=refresh_token&refresh_token={RefreshTokenKey}' like text
	When I send to the 'token' resource
	Then The result should be a 'BadRequest' status code
    And The result should contain values
    | JSONPath | Value         |
    | error    | invalid_grant |
    
@ClearScenarioContext
Scenario: Refresh token invalid
    Given I created a 'POST' request with content 'grant_type=refresh_token&refresh_token=invalidRefreshToken' like text
	When I send to the 'token' resource
	Then The result should be a 'BadRequest' status code
    And The result should contain values
    | JSONPath | Value         |
    | error    | invalid_grant |