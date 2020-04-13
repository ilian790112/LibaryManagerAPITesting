using NUnit.Framework;
using RestSharp;
using System.Net;
using TechTalk.SpecFlow;

namespace LibraryManagerAPITesting.StepsDefinitions
{
    [Binding]
    public class DeleteBookSteps : BaseSteps
    {
        [When(@"I deleted the book with the same id (.*)")]
        public void WhenIDeletedTheBookWithTheSameId(int bookId)
        {
            var request = CreateRequestWithMethod("/api/books/" + bookId + "/", Method.DELETE, null, null, null, null);
            response = client.Execute<Book>(request);
        }

        [When(@"I make a delete request to delete again the book with id (.*)")]
        public void WhenIMakeADeleteRequestToDeleteAgainTheBookWithId(int bookId)
        {
            var request = CreateRequestWithMethod("/api/books/" + bookId + "/", Method.DELETE, null, null, null, null);
            response = client.Execute<Book>(request);
        }

        [Then(@"the book with id (.*) shouldn't exist")]
        public void ThenTheBookWithIdShouldnTExist(int bookId)
        {
            var request = CreateRequestWithMethod("/api/books/" + bookId + "/", Method.GET, null, null, null, null);
            response = client.Execute<Book>(request);
            Assert.That(response.Data.Id, Is.Not.EqualTo(3), $"The book is not deleted");
        }

        [Then(@"the response status code is NoContent")]
        public void ThenTheResponseStatusCodeIsNoContent(int statusCode)
        {
            Assert.That(response.StatusCode, Is.EqualTo(statusCode), $"The status code is not matching");
        }
        
        [Then(@"the response status code is NotFound")]
        public void ThenTheResponseStatusCodeIsNotFound()
        {
            var request = CreateRequestWithMethod("/api/books/8/", Method.GET, null, null, null, null);
            response = client.Execute<Book>(request);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound), $"The status code is not matching");
        }

        [Then(@"the response status code is (.*) ""(.*)""")]
        public void ThenTheResponseStatusCodeIs(int statusCodeNumber, string statusCode)
        {
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NoContent), $"The status code is not matching");
        }
    }
}
