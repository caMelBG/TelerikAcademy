namespace ConsoleWebServer.Framework
{
    using System.Collections.Generic;
    using System.Net;

    using Newtonsoft.Json;

    public class JsonActionResult : IActionResult
    {
        public readonly object model;

        public JsonActionResult(HttpRequest request, object model)
        {
            this.model = model;
            Request = request;
            ResponseHeaders = new List<KeyValuePair<string, string>>();
        }

        public HttpRequest Request { get; private set; }

        public List<KeyValuePair<string, string>> ResponseHeaders { get; private set; }

        public string GetContent()
        {
            return JsonConvert.SerializeObject(model);
        }

        public string GetContentType()
        {
            return "application/json";
        }

        public HttpStatusCode GetStatusCode()
        {
            return HttpStatusCode.OK;
        }

        public HttpResponse GetResponse()
        {
            var response = new HttpResponse(Request.ProtocolVersion, GetStatusCode(), GetContent(),
                GetContentType());

            foreach (var responseHeader in ResponseHeaders)
            {
                response.AddHeader(responseHeader.Key, responseHeader.Value);
            }

            return response;
        }
    }
}