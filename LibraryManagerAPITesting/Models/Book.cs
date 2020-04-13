using Newtonsoft.Json;

namespace LibraryManagerAPITesting
{
    public class Book
    {   
        public string Id { get; set; }

        public string Author { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public Book[] books { get; set; }

    }
}
