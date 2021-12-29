using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Networking1
{
    class Program
    {
        public static void ShowHeader(HttpResponseHeaders headers)
        {
            Console.WriteLine("Cac header:");
            foreach (var header in headers)
            {
                Console.WriteLine($"{header.Key}:{header.Value}");
            }
        }
        public static async Task<string> GetWebConntent(string url)
        {
            using var httpClient = new HttpClient();
            try
            {
                // them Headers
                httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0");
                HttpResponseMessage httpReqonseMessage = await httpClient.GetAsync(url);
                ShowHeader(httpReqonseMessage.Headers);
                string html = await httpReqonseMessage.Content.ReadAsStringAsync();
                return html;
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                return " Erro";
            }
        }
        public static async Task<byte[]> DownLoadDataByte(string url)
        {
            using var httpClient = new HttpClient();
            try
            {
                // them Headers
                httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0");
                HttpResponseMessage httpReqonseMessage = await httpClient.GetAsync(url);
                ShowHeader(httpReqonseMessage.Headers);
                var bytes = await httpReqonseMessage.Content.ReadAsByteArrayAsync();
                return bytes;
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                return null;
            }
        }
        public static async Task DownLoadStream(string url, string filename)
        {
            HttpClient httpClient = new HttpClient();
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();

                // Lấy Stream để đọc content
                using var stream = await response.Content.ReadAsStreamAsync();

                // THỰC HIỆN ĐỌC Content
                int SIZEBUFFER = 500;
                using var streamwrite = File.OpenWrite(filename);  // Mở stream để lưu file
                byte[] buffer = new byte[SIZEBUFFER];               // tạo bộ nhớ đệm lưu dữ liệu khi đọc stream

                bool endread = false;
                do                                                  // thực hiện đọc các byte từ stream và lưu ra streamwrite
                {
                    int numberRead = await stream.ReadAsync(buffer, 0, SIZEBUFFER);
                    Console.WriteLine(numberRead);
                    if (numberRead == 0)
                    {
                        endread = true;
                    }
                    else
                    {
                        await streamwrite.WriteAsync(buffer, 0, numberRead);
                    }

                } while (!endread);
                Console.WriteLine("Download success");

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw e;
            }
        }
        static async Task Main(string[] args)
        {
            #region Uri

            //string url = "https://xuanthulab.net/lap-trinh-c-co-ban/?page=3";
            //var uri = new Uri(url);
            //var uritype = typeof(Uri);
            //uritype.GetProperties().ToList().ForEach(property => {
            //    Console.WriteLine($"{property.Name,15} {property.GetValue(uri)}");
            //});

            //Console.WriteLine($"Segments: {string.Join(",", uri.Segments)}");
            //Console.ReadLine();
            #endregion
            #region Dns

            //HostName - lấy hotsnam và các địa chỉ ip của 1 URl 
            //var hostName = Dns.GetHostName();
            //Console.WriteLine(hostName);

            //string url = "https://www.bootstrapcdn.com/";
            //var uri = new Uri(url);
            //var hostEntry = Dns.GetHostEntry(uri.Host);

            //Console.WriteLine($"Host {uri.Host} có các IP");
            //hostEntry.AddressList.ToList().ForEach(ip => Console.WriteLine(ip));
            #endregion
            #region Lớp Ping();
            //var ping = new Ping();
            //var pingReply = ping.Send("google.com.vn");
            //Console.WriteLine(pingReply.Status);
            //if (pingReply.Status == IPStatus.Success)
            //{
            //    Console.WriteLine(pingReply.RoundtripTime);
            //    Console.WriteLine(pingReply.Address);
            //}
            #endregion
            //var url = "https://raw.githubusercontent.com/xuanthulabnet/jekyll-example/master/images/jekyll-01.png";
            //var html = await GetWebConntent(url);
            //Console.WriteLine(html);
            //var bytes = await DowLoadDataByte(url);
            //string fileName = "1.png";
            //using var stream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None);

            //stream.Write(bytes, 0, bytes.Length);
            //await DownLoadStream(url, "2.png");
            //using var httpClient = new HttpClient();
            //var httpMessageRequest = new HttpRequestMessage();      
            //httpMessageRequest.Method = HttpMethod.Post;
            //httpMessageRequest.RequestUri = new Uri("https://www.google.com.vn");
            //httpMessageRequest.Headers.Add("Use-Agent", "Mozilla/5.0");

            //var httpResponseMessage = await httpClient.SendAsync(httpMessageRequest);
            //ShowHeader(httpResponseMessage.Headers);

            //var html = await httpResponseMessage.Content.ReadAsStringAsync();
            //Console.WriteLine(html);

            //var httpClient = new HttpClient();

            //var httpRequestMessage = new HttpRequestMessage();
            //httpRequestMessage.Method = HttpMethod.Post;
            //httpRequestMessage.RequestUri = new Uri("https://postman-echo.com/post");

            //var parameters = new List<KeyValuePair<string, string>>();
            //parameters.Add(new KeyValuePair<string, string>("key1", "value1"));

            //parameters.Add(new KeyValuePair<string, string>("key2", "value2-1"));
            //parameters.Add(new KeyValuePair<string, string>("key2", "value2-2"));

            //// Thiết lập Content
            //var content = new FormUrlEncodedContent(parameters);
            //httpRequestMessage.Content = content;

            //// Thực hiện Post
            //var response = await httpClient.SendAsync(httpRequestMessage);

            //var responseContent = await response.Content.ReadAsStringAsync();
            //Console.WriteLine(responseContent);
            //// Khi chạy kết quả trả về cho biết Server đã nhận được dữ liệu Post đến
            /// var httpClient = new HttpClient();

            //SendAsync
            #region SendAsync

            //HttpClient httpClient = new HttpClient();
            //var httpRequestMessage = new HttpRequestMessage();
            //httpRequestMessage.Method = HttpMethod.Post;
            //httpRequestMessage.RequestUri = new Uri("https://postman-echo.com/post");



            //var parameters = new List<KeyValuePair<string, string>>();
            //parameters.Add(new KeyValuePair<string, string>("key1", "value1"));

            //parameters.Add(new KeyValuePair<string, string>("key2", "value2-1"));
            //parameters.Add(new KeyValuePair<string, string>("key2", "value2-2"));

            //// Thiết lập Content
            //var content = new FormUrlEncodedContent(parameters);
            //httpRequestMessage.Content = content;


            //// Thực hiện Post
            //var response = await httpClient.SendAsync(httpRequestMessage);


            //var responseContent = await response.Content.ReadAsStringAsync();
            //Console.WriteLine(responseContent);
            //// Khi chạy kết quả trả về cho biết Server đã nhận được dữ liệu Post đến
            #endregion

            // Sử dụng StringContent
            #region StringContent
            //var httpClient = new HttpClient();

            //var httpRequestMessage = new HttpRequestMessage();
            //httpRequestMessage.Method = HttpMethod.Post;
            //httpRequestMessage.RequestUri = new Uri("https://postman-echo.com/post");

            //// Tạo StringContent
            //string jsoncontent = "{\"value1\": \"giatri1\", \"value2\": \"giatri2\"}";
            //var httpContent = new StringContent(jsoncontent, Encoding.UTF8, "application/json");
            //httpRequestMessage.Content = httpContent;

            //var response = await httpClient.SendAsync(httpRequestMessage);
            //var responseContent = await response.Content.ReadAsStringAsync();

            //Console.WriteLine(responseContent);
            #endregion

            //Sử dụng MultipartFormDataContent
            # region MultipartFormDataContent
            var httpClient = new HttpClient();

            var httpRequestMessage = new HttpRequestMessage();
            httpRequestMessage.Method = HttpMethod.Post;
            httpRequestMessage.RequestUri = new Uri("https://postman-echo.com/post");


            // Tạo đối tượng MultipartFormDataContent
            var content = new MultipartFormDataContent();


            // Tạo StreamContent chứa nội dung file upload, sau đó đưa vào content
            Stream fileStream = File.OpenRead("1.txt");


            content.Add(new StreamContent(fileStream), "fileupload", "abc.xyz");

            // Thêm vào MultipartFormDataContent một StringContent
            content.Add(new StringContent("value1"), "key1");
            // Thêm phần tử chứa mạng giá trị (HTML Multi Select)
            content.Add(new StringContent("value2-1"), "key2[]");
            content.Add(new StringContent("value2-2"), "key2[]");


            httpRequestMessage.Content = content;
            var response = await httpClient.SendAsync(httpRequestMessage);
            var responseContent = await response.Content.ReadAsStringAsync();
            Console.WriteLine(responseContent);
            #endregion

        }
    }
}
