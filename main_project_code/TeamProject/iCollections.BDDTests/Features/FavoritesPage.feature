Feature: Favorite Collections Page
	Favorite collections page functionality

	* If a user visits their private my favorite collections page, then they will be able to see all of the collections they have favorited in the past including details like the name, owner, keyword association, and date created.
	* If a user clicks on one of the keywords associated with one of their favorite collectons, they will be redirected to the browse page yielding a search of the keyword that was clicked on.
	* If a user clicks on the remove button asssociated with one of their collections, the collection will be removed from their list of favorites and the page will be refreshed with the removed collection no longer present in their favorites. 

Experiencing favorite collections page as a user


Scenario Outline: I will find all of my favorited collection on the favorited collections page.
	Given I am a logged in user 
		And Have favorited collections
	When I navigate to the 'my favorites' page
	Then I will find all of my favorites collections with details such as name, owner, keyword, and date created


Scenario Outline: If I click on one of the keywords associated with my favorite collections, I will be redirected to the browse page and search results will be displayed corresponding to that keyword.
	Given I am a user on the my favorites page
	When I click on a keyword associated with a favorite collection
	Then I will be redirected to the browse page
		And a search will be shown corresponding to that specific keyword

Scenario Outline: If I am a user who clicks on the remove button that corresponds to one of my existing favorite collections on the collections page, then that collection will be removed form my favorites.
	Given I am a user with favorites on the my favorites page
	When I click on the remove button that corresponds to any of my favorite collections
	Then that collections will be removed from my favorites collection
		And the page will reload with the removed collection no longer displayed