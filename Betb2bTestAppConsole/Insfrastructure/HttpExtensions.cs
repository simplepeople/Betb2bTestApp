using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Betb2bTestAppConsole.Insfrastructure
{
    public static class HttpExtensions
    {
        private class Utf8StringWriter : StringWriter
        {
            public override Encoding Encoding => Encoding.UTF8;
        }
        internal static Task<HttpResponseMessage> PostAsXmlAsync<T>(this HttpClient client, string requestUri, T value)
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

        internal static HttpClient SetBasicAuthorization(this HttpClient client, string login, string password)
        {
            var byteArray = Encoding.UTF8.GetBytes($"{login}:{password}");
            string str = Convert.ToBase64String(byteArray);
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", str);
            return client;
        }
    }
}
