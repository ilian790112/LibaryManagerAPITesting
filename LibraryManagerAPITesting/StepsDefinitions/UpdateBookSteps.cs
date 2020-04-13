using NUnit.Framework;
using RestSharp;
using TechTalk.SpecFlow;

namespace LibraryManagerAPITesting.StepsDefinitions
{
    [Binding]
    public class UpdateBookSteps : BaseSteps
    {
        [When(@"I update the book with id (.*) with values ""(.*)"", ""(.*)"" and ""(.*)""")]
        public void WhenIUpdateTheBookWithIdWithValuesAnd(string bookId, string title, string author, string description)
        {
            var request = CreateRequestWithMethod("/api/books/" + bookId + "/", Method.PUT, bookId, title, author, description);
            //request.AddJsonBody(new Book() { Id = bookId, Author = author, Title = title, Description = description });
            response = client.Execute<Book>(request);
        }


        [Then(@"the book with id (.*) should contain the correct ""(.*)"", ""(.*)"" and ""(.*)""")]
        public void ThenTheBookWithIdShouldContainTheCorrectAnd(int bookId, string title, string author, string description)
        {
            var request = CreateRequestWithMethod("/api/books/" + bookId + "/", Method.GET, null, null, null, null);
            response = client.Execute<Book>(request);
            Assert.That(response.Data.Title, Is.EqualTo(title), $"The title is not updated");
            Assert.That(response.Data.Author, Is.EqualTo(author), $"The author is not updated");
            Assert.That(response.Data.Description, Is.EqualTo(description), $"The description is not updated");
        }

    }
}
