using NUnit.Framework;
using RestSharp;
using System.Net;
using TechTalk.SpecFlow;

namespace LibraryManagerAPITesting.StepsDefinitions
{
    [Binding]
    public class GetExistingBookSteps : BaseSteps
    {
        [BeforeScenario]

        //Before starting the Get existing book steps we need to be sure that the service contains 2 books
        public void BeforeScenario()
        {
            var request = CreateRequestWithMethod("/api/books/", Method.POST, "1", "TestAuthor1", "TestTitle1", "TestDescription1");
            //request.AddJsonBody(new Book() { Id = "1", Author = "TestAuthor1", Title = "TestTitle1", Description = "TestDescription1" });
            response = client.Execute<Book>(request);
            request = CreateRequestWithMethod("/api/books/", Method.POST, "2", "TestAuthor2", "TestTitle2", "TestDescription2");
            //request.AddJsonBody(new Book() { Id = "2", Author = "TestAuthor2", Title = "TestTitle2", Description = "TestDescription2" });
            response = client.Execute<Book>(request);
        }

        [Given(@"I perform GET operation for ""(.*)""")]
        public void GivenIPerformGETOperationFor(string url)
        {
            var request = CreateRequestWithMethod(url, Method.GET, null, null, null, null);
        }
        
        [When(@"I perform operation for book with id (.*)")]
        public void WhenIPerformOperationForBookWithId(int bookId)
        {
            request.AddUrlSegment("bookid", bookId.ToString());
            response = client.Execute<Book>(request);
        }
        
        [When(@"I request all the books")]
        public void WhenIRequestAllTheBooks()
        {
            response = client.Execute<Book>(request);
        }

        [Then(@"I should see the ""(.*)"" as ""(.*)""")]
        public void ThenIShouldSeeTheAs(string key, string value)
        {
            if (key == "title")
            {
                Assert.That(response.Data.Title, Is.EqualTo(value), $"The title is not matching");
            }
            else if (key == "id")
            {
                Assert.That(response.Data.Id, Is.EqualTo(value), $"The id is not matching");
            }
            else if (key == "description")
            {
                Assert.That(response.Data.Description, Is.EqualTo(value), $"The description is not matching");
            }
            else
            {
                Assert.That(response.Data.Author, Is.EqualTo(value), $"The author is not matching");
            }
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK), $"The status code is not matching");          
        }
        
        [Then(@"the data of all books should be returned")]
        public void ThenTheDataOfAllBooksShouldBeReturned()
        {
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK), $"The status code is not matching");
            Assert.That(response.Content.Contains("TestTitle1"), $"Book with TestTitle1 is not found");
            Assert.That(response.Content.Contains("TestTitle2"), $"Book with TestTitle2 is not found");
        }

        [Then(@"the response status code is ""(.*)""")]
        public void ThenTheResponseStatusCodeIs(string statusCode)
        {
            Assert.That(statusCode, Is.EqualTo(HttpStatusCode.NotFound), $"The status code is not matching");
        }
    }
}
