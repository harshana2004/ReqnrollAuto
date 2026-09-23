Feature: Product validation in home screen

Background:

Given user is navigates to login screen
When user is enters 'username'
And user is enters 'password'
And user is clicks login button
Then user is navigate to home page

@regression
Scenario: Product Details Validation

Given the user is on the Home page
When the user clicks the View button for the first product
And the user navigates to the Product Details page
And the user clicks the Home button
Then user is navigate to home page


@regression
Scenario: Order Details Validation

Given the user is on the Home page
When the user clicks the Orders button
And the user navigates to the Order Details page
And the user clicks the Go Back to Shop button
Then user is navigate to home page

@smoke 
Scenario: Cart Details Validation

Given the user is on the Home page
When the user clicks the Cart button
And the user navigates to the My Cart page
And the user clicks the Continue Shopping button
Then user is navigate to home page
