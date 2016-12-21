using System;
using System.Collections.Specialized;
using System.Net;

namespace JustFakeIt
{
    public class HttpRequestExpectation
    {
        public Http Method { get; private set; }
        public string Url { get; private set; }
        public string Body { get; private set; }
        public WebHeaderCollection Headers { get; set; }

        public HttpRequestExpectation(Http method, string url, string body = null, NameValueCollection headers = null)
        {
            Method = method;
            Url = url;
            Body = body;
            Headers = new WebHeaderCollection();
            if (headers != null)
            {
                Headers.Add(headers);
            }
        }
    }
}