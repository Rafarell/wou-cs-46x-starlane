Feature: Follow Button Feedback
	Follow Button Funcionality

	* If a visitor is not logged in and clicks the follow button on a user profile page, an alert will appear informing the user they must be logged in or registered to follow  user
	* After a visitor clicks the follow button and they receive feedback, they will be able to click the links on the alert to login or register.

Unauthenticated user/follow button


Scenario Outline: A visitor will receive feeback to let them know they must be logged in or registered to follow a user when they click the follow button on a user profile page and are not logged in.
	Given I am a visitor of the site on a user profile page
	When I click the follow user button
	Then An alert will appear to inform me that I must register or log in to the site in order to follow a user

Scenario Outline: After a visitor receives feedback, they will be able to click log in or register on the alert to navigate to the log in or register page.
	Given I am a visitor of the site on a user profile page
	When An alert appears informing me I must log in or register to follow a user
	Then I will be able to click log in to navigate to the log in page
		And click register to navigate to the register page
