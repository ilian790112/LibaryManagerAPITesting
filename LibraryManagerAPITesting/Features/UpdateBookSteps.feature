Feature: Update book

@Positive	
Scenario: Update book with valid id
    Given a book is already added
    When I update the book with id 3 with values "TestAuthor", "TestTitle" and "TestDescription"
    Then the book with id 3 should contain the correct "TestTitle", "TestAuthor" and "TestDescription"

@Negative
Scenario: Update book with invalid Id
    When I update the book with id 8 with values "TestAuthor8", "TestTitle8" and "TestDescription8"
	Then the response status code is NotFound