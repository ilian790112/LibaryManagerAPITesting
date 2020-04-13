Feature: Delete book

@Positive	
Scenario: Delete existing book
    Given a book is already added 
    When I deleted the book with the same id 3
	Then the response status code is 204 "NoContent"
    And the book with id 3 shouldn't exist
	

@Negative
Scenario: Delete a non-existing book
	When I make a delete request to delete again the book with id 3
	Then the response status code is NotFound