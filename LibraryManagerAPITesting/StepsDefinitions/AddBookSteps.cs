using NUnit.Framework;
using RestSharp;
using System.Net;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace LibraryManagerAPITesting.StepsDefinitions
{
    [Binding]
    public class AddNewBookSteps : BaseSteps
    {
        [Given(@"a book is already added")]
        public void GivenABookIsAlreadyAdded()
        {
            var request = CreateRequestWithMethod("/api/books/", Method.POST, "3", "TestAuthor1", "TestTitle3", "TestDescription3");
            //request.AddJsonBody(new Book() { Id = "3", Author = "TestAuthor3", Title = "TestTitle3", Description = "TestDescription3" });
            response = client.Execute<Book>(request);
        }

        [When(@"I perform operation to add a new book with details")]
        public void WhenIPerformOperationToAddANewBookWithDetails(Table table)
        {
            var book = table.CreateInstance<Book>();
            var request = CreateRequestWithMethod("/api/books/", Method.POST, book.Id, book.Author, book.Title, book.Description);
            //request.AddJsonBody(new Book() { Id = book.Id, Author = book.Author, Title = book.Title, Description = book.Description });
            response = client.Execute<Book>(request);
        }

        [Then(@"the book should be added with details")]
        public void ThenTheBookShouldBeAddedWithDetails(Table table)
        {
            var request = CreateRequestWithMethod("/api/books/5", Method.GET, null, null, null, null);
            response = client.Execute<Book>(request);
            var book = table.CreateInstance<Book>();
            Assert.That(response.Data.Id, Is.EqualTo(book.Id), $"The id is not matching");
        }

        
        [When(@"I make a post request to add a new book with the same id")]
        public void WhenIMakeAPostRequestToAddANewBookWithTheSameId()
        {
            var request = CreateRequestWithMethod("/api/books/", Method.POST, "3", "TestAuthor3", "TestTitle3", "TestDescription3");
            //request.AddJsonBody(new Book() { Id = "3", Author = "TestAuthor3", Title = "TestTitle3", Description = "TestDescription3" });
            response = client.Execute<Book>(request);
        }

        [Then(@"the book is not added")]
        public void ThenTheBookIsNotAdded()
        {
            Assert.That(response.Data.Id, Is.Not.EqualTo(3), $"The book with the same id is added twice");
        }

        [Then(@"the response status code is BadRequest")]
        public void ThenTheResponseStatusCodeIsBadRequest()
        {
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest), $"The status code is not matching");
        }

        [When(@"I make a post request to add a new book by with details Id '(.*)', Author '(.*)', Title '(.*)' and Description '(.*)'")]
        public void WhenIMakeAPostRequestToAddANewBookByWithDetailsIdAuthorTitleAndDescription(string id, string author, string title, string description)
        {
            var request = CreateRequestWithMethod("/api/books/", Method.POST, id, author, title, description);
            //request.AddJsonBody(new Book() { Id = id, Author = author, Title = title, Description = description });
            response = client.Execute<Book>(request);
        }
      
    }
}
