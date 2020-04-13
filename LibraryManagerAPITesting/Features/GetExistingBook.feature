Feature: Get existing book
    As a client of the Library Manager Web Api
    I want to be able to get a book or all books

@Positive
Scenario: Verify author, title and description of book with id 1
	Given I perform GET operation for "api/books/{bookid}"
    When I perform operation for book with id 1
	Then I should see the "title" as "TestTitle1"
	And I should see the "description" as "TestDescription1"
	And I should see the "author" as "TestAuthor1"
	

@Positive
Scenario: Get all existing books
    Given I perform GET operation for "api/books/"
    When I request all the books
    Then the data of all books should be returned

@Negative
Scenario: Get а book with invalid id
    Given I perform GET operation for "api/books/{bookid}"
    When I perform operation for book with id 8
	Then the response status code is NotFound
