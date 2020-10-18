using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;

namespace tests
{
    public class FakeHttpRequest
    {
        public static HttpRequest FakeHttpRequestWithObject(object requestBody)
        {
            var ms = new MemoryStream();
            var sw = new StreamWriter(ms);
            var json = JsonConvert.SerializeObject(requestBody);
            sw.Write(json);
            sw.Flush();
            ms.Position = 0;
            var request = new DefaultHttpContext().Request;
            request.Body = ms;
            return request;
        }

        public static HttpRequest FakeRequestWithQuery(Dictionary<string,string> queryParams)
        {
            var dict = queryParams.ToDictionary(q => q.Key, q => new StringValues(q.Value));
            var queryCollection = new QueryCollection(dict);
            var request = new DefaultHttpContext().Request;
            request.Query = queryCollection;
            return request;
        }
    }
}
