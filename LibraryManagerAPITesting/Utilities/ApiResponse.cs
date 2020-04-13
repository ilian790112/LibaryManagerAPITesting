using LibraryManagerAPITesting.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagerAPITesting.Utilities
{
    /*
        public class Meta
        {
            public bool success;
            public int code;
            public string message;

            public HttpStatusCode StatusCode
            {
                get
                {
                    return (HttpStatusCode)Enum.ToObject(typeof(HttpStatusCode), code);
                }
            }
        }
        */

        public class BookResponse
        {
          //  [JsonProperty("_meta")]
         //   public Meta meta;

            [JsonProperty("result")]
            public Book book;
    }
}
