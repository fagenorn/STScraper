using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;

namespace STScraper.Api
{
    internal class RequestBuilder
    {
        public RequestBuilder SetUrl(string url) { return SetUrl(new Uri(url, UriKind.RelativeOrAbsolute)); }

        public RequestBuilder SetUrl(Uri url)
        {
            _url = url;

            return this;
        }

        public RequestBuilder SetBody(HttpContent body)
        {
            _content = body;

            return this;
        }

        public RequestBuilder AddParam(string name, string value, bool sign = false)
        {
            _gets[name] = new Parameter(value ?? string.Empty, sign);

            return this;
        }

        public RequestBuilder AddParam(string name, bool value, bool sign = false) { return AddParam(name, value ? "true" : "false", sign); }

        public RequestBuilder AddParam(string name, int value, bool sign = false) { return AddParam(name, value.ToString(), sign); }

        public RequestBuilder AddParam(string name, ulong value, bool sign = false) { return AddParam(name, value.ToString(), sign); }

        public RequestBuilder AddParam(string name, long? value, bool sign = false) { return AddParam(name, value != null ? value.ToString() : string.Empty, sign); }

        public RequestBuilder AddPost(string name, string value, bool sign = true)
        {
            _posts[name] = new Parameter(value, sign);

            return this;
        }

        public RequestBuilder AddPost(string name, bool value, bool sign = true) { return AddPost(name, value ? "true" : "false", sign); }

        public RequestBuilder AddPost(string name, int value, bool sign = true) { return AddPost(name, value.ToString(), sign); }

        public RequestBuilder AddPost(string name, ulong value, bool sign = true) { return AddPost(name, value.ToString(), sign); }

        public RequestBuilder AddPost(string name, long? value, bool sign = true) { return AddPost(name, value != null ? value.ToString() : string.Empty, sign); }

        public RequestBuilder AddFile(string name, string path, string fileName = null, Dictionary<string, string> headers = null)
        {
            _files.Add(name, new InternalFile(path) { FileName = fileName, Headers = headers });

            return this;
        }

        public RequestBuilder AddHeader(string name, string value)
        {
            _headers[name] = value;

            return this;
        }

        public RequestBuilder AddHeader(string name, long value) { return AddHeader(name, value.ToString()); }

        public RequestBuilder AddHeader(string name, bool value) { return AddHeader(name, value ? "true" : "false"); }

        public HttpRequestMessage Build()
        {
            var content = BuildRequestBody();
            var url     = BuildUrl();

            if ( content == null )
            {
                var temp = new HttpRequestMessage(HttpMethod.Get, url);
                foreach ( var (key, value) in _headers )
                {
                    temp.Headers.Add(key, value);
                }

                return temp;
            }
            else
            {
                var temp = new HttpRequestMessage(HttpMethod.Post, url) { Content = content };

                foreach ( var (key, value) in _headers )
                {
                    temp.Headers.TryAddWithoutValidation(key, value);
                }

                return temp;
            }
        }

        private class InternalFile
        {
            public InternalFile(string path)
            {
                Path     = path;
                FileName = System.IO.Path.GetFileName(Path);
            }

            public string Path { get; set; }

            public Dictionary<string, string> Headers { get; set; }

            public string FileName { get; set; }
        }

        #region Private Methods

        private HttpContent BuildRequestBody()
        {
            // return raw body if specified.
            if ( _content != null )
            {
                return _content;
            }

            if ( _posts.Count == 0 && _files.Count == 0 )
            {
                // GET request
                return null;
            }

            if ( _files.Count != 0 )
            {
                return BuildMultipartContent();
            }

            return BuildFormUrlEncodedContent();
        }

        private MultipartContent BuildMultipartContent()
        {
            var multipartContent = new MultipartFormDataContent();
            var contentType      = multipartContent.Headers.ContentType.Parameters.First();
            contentType.Value = contentType.Value.Replace("\"", "");

            {
                AddParam("retry_type", "no_retry");
                var stringContent = new StringContent("no_retry");
                stringContent.Headers.ContentLength = "no_retry".Length;
                stringContent.Headers.Add("Content-Transfer-Encoding", @"binary");
                stringContent.Headers.ContentType.CharSet = stringContent.Headers.ContentType.CharSet.Replace("utf-8", "UTF-8");
                multipartContent.Add(stringContent, "\"" + "retry_type" + "\"");
            }

            foreach ( var post in _posts )
            {
                var stringContent = new StringContent(post.Value.ToString());
                stringContent.Headers.ContentLength = post.Value.ToString().Length;
                stringContent.Headers.Add("Content-Transfer-Encoding", @"binary");
                stringContent.Headers.ContentType.CharSet = stringContent.Headers.ContentType.CharSet.Replace("utf-8", "UTF-8");
                multipartContent.Add(stringContent, post.Key);
            }

            foreach ( var (name, fileDetails) in _files )
            {
                var fs      = new FileStream(fileDetails.Path, FileMode.Open, FileAccess.Read, FileShare.Read, 4096, true);
                var content = new StreamContent(fs) { Headers = { ContentType = new MediaTypeHeaderValue(@"application/octet-stream") } };
                if ( fileDetails.Headers != null )
                {
                    foreach ( var header in fileDetails.Headers )
                    {
                        content.Headers.Add(header.Key, header.Value);
                    }
                }

                content.Headers.Add("Content-Transfer-Encoding", @"binary");
                content.Headers.ContentLength = fs.Length;
                multipartContent.Add(content, "\"" + name + "\"", "\"" + fileDetails.FileName + "\"");
                content.Headers.ContentDisposition.FileNameStar = null;
            }

            return multipartContent;
        }

        private FormUrlEncodedContent BuildFormUrlEncodedContent()
        {
            var postData = new Dictionary<string, string>();
            foreach ( var (key, value) in _posts )
            {
                postData[key] = value.ToString();
            }

            var content = new FormUrlEncodedContent(postData);

            return content;
        }

        private Uri BuildUrl()
        {
            if ( _url == null )
            {
                throw new ApplicationException("You need to have a url specified.");
            }

            var urlBuilder = new UrlBuilder(_url);
            urlBuilder.AddQueryParams(_gets.ToDictionary(x => x.Key, x => x.Value.ToString()));

            return urlBuilder.Build();
        }

        #endregion

        #region Fields

        private readonly Dictionary<string, string> _headers = new Dictionary<string, string>();

        private readonly Dictionary<string, Parameter> _gets = new Dictionary<string, Parameter>();

        private readonly Dictionary<string, Parameter> _posts = new Dictionary<string, Parameter>();

        private readonly Dictionary<string, InternalFile> _files = new Dictionary<string, InternalFile>();

        private HttpContent _content;

        private Uri _url;

        #endregion
    }
}