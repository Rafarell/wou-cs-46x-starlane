Feature: Favorite Collections Page
	Favorite collections page functionality

	* If a user visits their private my favorite collections page, then they will be able to see all of the collections they have favorited in the past including details like the name, owner, keyword association, and date created.
	* If a user clicks on one of the keywords associated with one of their favorite collectons, they will be redirected to the browse page yielding a search of the keyword that was clicked on.
	* If a user clicks on the remove button asssociated with one of their collections, the collection will be removed from their list of favorites and the page will be refreshed with the removed collection no longer present in their favorites. 

Experiencing favorite collections page as a user

Background:
	Given the following users exist
	  | UserName   | Email                 | FirstName | LastName | Password  |
	  | TaliaK     | knott@example.com     | Talia     | Knott    | Abcd987?6 |
	  | ZaydenC    | clark@example.com     | Zayden    | Clark    | Abcd987?6 |
	  | DavilaH    | hareem@example.com    | Hareem    | Davila   | Abcd987?6 |
	  | KrzysztofP | krzysztof@example.com | Krzysztof | Ponce    | Abcd987?6 |

	  And the following users do not exist
	  | UserName | Email                  | FirstName | LastName | Password  |
	  | JackieE  | notexist@example.com   | Jackie    | Ellisson | nrkshjbsd |
	  | BreannaT | notexist@example.com   | Breanna   | Tide     | ekrnfubec |
	  | RusselG  | notexist@example.com   | Russel    | Grande   | rnfklremf |

Scenario Outline: I will find all of my favorited collection on the favorited collections page.
	Given I am logged in
	When I navigate to the 'myfavorites' page with '<UserName>'
		And Have favorited collections
	Then I will find all of my favorites collections with details such as name, owner, keyword, and date created

	Examples: 
	  | FirstName | UserName   |
	  | Talia     | TaliaK     |
	  | Zayden    | ZaydenC    |
	  | Hareem    | DavilaH    |
	  | Krzysztof | KrzysztofP |


Scenario Outline: If I click on one of the keywords associated with my favorite collections, I will be redirected to the browse page and search results will be displayed corresponding to that keyword.
	Given I am logged in
	When I navigate to the 'myfavorites' page with '<UserName>'
		And Have favorited collections
		And I click on a keyword associated with a favorite collection
	Then I will be redirected to the browse page with a search corresponding to that '<KeyWord>'

		Examples: 
	  | FirstName | UserName   | KeyWord |
	  | Talia     | TaliaK     | Fish    |
	  | Zayden    | ZaydenC    | Sports  |
	  | Hareem    | DavilaH    | Tools   |
	  | Krzysztof | KrzysztofP | Insects |

Scenario Outline: If I am a user who clicks on the remove button that corresponds to one of my existing favorite collections on the collections page, then that collection will be removed form my favorites.
	Given I am logged in
	When I navigate to the 'myfavorites' page with '<UserName>'
		And Have favorited collections
		And I click on the remove button that corresponds to any of my favorite collections
	Then the page will be reloaded
		And the removed collection no longer be displayed

		Examples: 
	  | FirstName | UserName   |
	  | Talia     | TaliaK     |
	  | Zayden    | ZaydenC    |
	  | Hareem    | DavilaH    |
	  | Krzysztof | KrzysztofP |