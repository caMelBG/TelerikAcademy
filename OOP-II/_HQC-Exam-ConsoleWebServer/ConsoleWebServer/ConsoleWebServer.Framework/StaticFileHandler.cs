﻿namespace ConsoleWebServer.Framework
{
    using System;
    using System.Linq;
    using System.IO;
    using System.Net;

    public class StaticFileHandler
    {
        public bool CanHandle(HttpRequest request)
        {
            return request.Url.LastIndexOf(".", StringComparison.Ordinal) >
                   request.Url.LastIndexOf("/", StringComparison.Ordinal);
        }

        public HttpResponse Handle(HttpRequest request)
        {
            string filePath = Environment.CurrentDirectory + "/" + request.Url;
            if (!this.FileExists("C:\\", filePath, 3))
            {
                return new HttpResponse(request.ProtocolVersion, HttpStatusCode.NotFound, "File not found");
            }
            string fileContents = File.ReadAllText(filePath);
            var response = new HttpResponse(request.ProtocolVersion, HttpStatusCode.OK, fileContents);
            return response;
        }

        private bool FileExists(string path, string filePath, int depth)
        {
            if (depth <= 0)
            {
                return File.Exists(filePath);
            }

            try
            {
                var file = Directory.GetFiles(path);
                if (file.Contains(filePath))
                {
                    return true;
                }

                var directories = Directory.GetDirectories(path);
                foreach (var directory in directories)
                {
                    if (FileExists(directory, filePath, depth - 1))
                    {
                        return true;
                    }
                }

                return false;
            }

            catch (Exception)
            {
                return false;
            }
        }
    }
}