Feature: Add new book
    As a client of the Library Manager Web Api
    I want to be able to add a new book 

@Positive
Scenario: Verify new book is added successfully
    When I perform operation to add a new book with details
	 | id  | author        | title           | description       |
     |	5  | TestAuthor5   | TestTitle5      | TestDescription5  |
    Then the book should be added with details
	 | id  | author        | title           | description       |
     |	5  | TestAuthor5   | TestTitle5      | TestDescription5  |

@Negative
Scenario: Add a new book which already exists
    Given a book is already added
	When I make a post request to add a new book with the same id
	Then the response status code is BadRequest
	And the book is not added

@Negative
Scenario: Add a new book with invalid data
	When I make a post request to add a new book by with details Id '<id>', Author '<author>', Title '<title>' and Description '<description>'
	Then the response status code is BadRequest
	Examples:

  | id  | author        | title           | description       |
  |	    | TestAuthor    | TestTitle       | TestDescription   |
  |  7  |               | TestTitle       | TestDescription   |
  |  8  | TestAuthor    |                 | TestDescription   |