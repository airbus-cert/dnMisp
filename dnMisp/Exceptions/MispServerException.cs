using dnMisp.Objects;
using System;

namespace dnMisp.Exceptions
{
    public class MispServerException : Exception
    {
        internal MispServerException()
            : base()
        {

        }

        internal MispServerException(string msg, Exception inner)
            : base(msg, inner)
        {

        }

        internal MispServerException(MispEventResponse response) 
            : base(response.Errors)
        {
            Name = response.Name;
            Url = response.Url;
        }

        public string Name { get; set; }
        public string Url { get; set; }
    }
}
