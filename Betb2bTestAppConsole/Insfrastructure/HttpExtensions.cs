using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Betb2bTestAppConsole.Insfrastructure
{
    public static class HttpExtensions
    {
        public class Utf8StringWriter : StringWriter
        {
            public override Encoding Encoding => Encoding.UTF8;
        }
        public static Task<HttpResponseMessage> PostAsXmlAsync<T>(this HttpClient client, string requestUri, T value)
        {
            string content;
            using (var stringwriter = new Utf8StringWriter())
            {
                var serializer = new XmlSerializer(typeof(T));
                serializer.Serialize(stringwriter, value);
                content=stringwriter.ToString();
            }

            return client.PostAsync(requestUri, new StringContent(content, Encoding.UTF8, "application/xml"));
        }
    }
}
