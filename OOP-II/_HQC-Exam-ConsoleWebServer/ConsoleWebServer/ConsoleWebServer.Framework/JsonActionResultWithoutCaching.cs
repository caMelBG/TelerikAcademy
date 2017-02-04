namespace ConsoleWebServer.Framework
{
    using System.Collections.Generic;

    public class JsonActionResultWithoutCaching : JsonActionResult
    {
        public JsonActionResultWithoutCaching(HttpRequest request, object model)
            : base(request, model)
        {
            this.ResponseHeaders.Add(new KeyValuePair<string, string>
                ("Cache-Control", "private, max-age=0, no-cache"));
        }
    }
}
