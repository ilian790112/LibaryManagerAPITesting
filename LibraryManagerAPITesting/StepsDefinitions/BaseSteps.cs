using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagerAPITesting.StepsDefinitions
{
    public class BaseSteps
    {
        public RestClient client;
        public RestRequest request;
        public IRestResponse<Book> response = new RestResponse<Book>();


        public RestRequest CreateRequestWithMethod(string _url, Method _method, string _id, string _author, string _title, string _description)
    {       
        client = new RestClient("http://localhost:9090/");
        request = new RestRequest(_url, _method);
            if (_method == Method.POST || _method == Method.PUT)
            {
                request.AddJsonBody(new Book() { Id = _id, Author = _author, Title = _title, Description = _description });
            }
        request.RequestFormat = DataFormat.Json;
        return request;
    }
}

}
