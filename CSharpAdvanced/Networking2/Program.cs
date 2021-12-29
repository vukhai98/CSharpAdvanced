using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Networking2
{
    class Program
    {
        static async Task Main(string[] args)
        {

            var url = "https://postman-echo.com/post";

            // await AddCookiesToHandler(url);

            await aahhddd();
        }
        public static async Task aahhddd()
        {
            string url = "https://www.facebook.com/xuanthulab";

            CookieContainer cookies = new CookieContainer();

            // TẠO CHUỖI HANDLER
            var bottomHandler = new MyHttpClientHandler(cookies);              // handler đáy (cuối)
            var changeUriHandler = new ChangeUri(bottomHandler);
            var denyAccessFacebook = new DenyAccessFacebook(changeUriHandler); // handler đỉnh

            // Khởi tạo HttpCliet với hander đỉnh chuỗi hander
            var httpClient = new HttpClient(denyAccessFacebook);

            // Thực hiện truy vấn
            httpClient.DefaultRequestHeaders.Add("Accept", "text/html,application/xhtml+xml+json");
            httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0");
            HttpResponseMessage response = await httpClient.GetAsync(url);
            if(response.StatusCode == HttpStatusCode.OK)
            {
                //response.EnsureSuccessStatusCode();
                string htmltext = await response.Content.ReadAsStringAsync();
                Console.WriteLine(htmltext);
            }
            else
            {
                Console.WriteLine("dsfsdfsd");
            }
            

        }

        public static async Task AddCookiesToHandler(string url)
        {

            //Tạo handler
            using HttpClientHandler handler = new HttpClientHandler();

            // Tạo bộ chứa cookie và sử dụng bởi handler
            CookieContainer cookies = new CookieContainer();

            // Thêm các cookie nếu muốn
            //cookies.Add(new Uri(url), new Cookie("name", "value"));
            handler.AllowAutoRedirect = true;// cho phép điều hướng
            handler.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip; // cho phép giải nén 
            handler.UseCookies = true;// cho phép lưu các cookie
            handler.CookieContainer = cookies;

            // Tạo HttpClient- thiết lập handler cho nó
            using var httpClient = new HttpClient(handler);

            // Tạo HttpRequestMessage
            using var httpRequestMessage = new HttpRequestMessage();
            httpRequestMessage.Method = HttpMethod.Post; // phương thức http
            httpRequestMessage.RequestUri = new Uri(url);// địa chỉ url mà nó thựn hiện
            httpRequestMessage.Headers.Add("User-Agent", "Mozilla/5.0");

            var parameters = new List<KeyValuePair<string, string>>() {
                new KeyValuePair<string, string>("key1","value1"),
                new KeyValuePair<string, string>("key2","value2"),

            };
            httpRequestMessage.Content = new FormUrlEncodedContent(parameters);

            var response = await httpClient.SendAsync(httpRequestMessage);

            cookies.GetCookies(new Uri(url)).ToList().ForEach(c => {
                Console.WriteLine($"{c.Name}:{c.Value}");
            });
            var html = await response.Content.ReadAsStringAsync();


            Console.WriteLine(html);
        }

    }
    public class MyHttpClientHandler : HttpClientHandler
    {
        public MyHttpClientHandler(CookieContainer cookie_container)
        {

            CookieContainer = cookie_container;     // Thay thế CookieContainer mặc định
            AllowAutoRedirect = false;                // không cho tự động Redirect
            AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;
            UseCookies = true;
        }
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
                                                                     CancellationToken cancellationToken)
        {
            Console.WriteLine("Bất đầu kết nối " + request.RequestUri.ToString());
            // Thực hiện truy vấn đến Server
            var response = await base.SendAsync(request, cancellationToken);
            Console.WriteLine("Hoàn thành tải dữ liệu");
            return response;
        }
    }

    public class ChangeUri : DelegatingHandler
    {
        public ChangeUri(HttpMessageHandler innerHandler) : base(innerHandler) { }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
                                                               CancellationToken cancellationToken)
        {
            var host = request.RequestUri.Host.ToLower();
            Console.WriteLine($"Check in  ChangeUri - {host}");
            if (host.Contains("google.com"))
            {
                // Đổi địa chỉ truy cập từ google.com sang github
                request.RequestUri = new Uri("https://github.com/");
            }
            // Chuyển truy vấn cho base (thi hành InnerHandler)
            return base.SendAsync(request, cancellationToken);
        }
    }

    public class DenyAccessFacebook : DelegatingHandler
    {
        public DenyAccessFacebook(HttpMessageHandler innerHandler) : base(innerHandler) { }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
                                                                     CancellationToken cancellationToken)
        {

            var host = request.RequestUri.Host.ToLower();
            Console.WriteLine($"Check in DenyAccessFacebook - {host}");
            if (host.Contains("facebook.com"))
            {
                var response = new HttpResponseMessage(HttpStatusCode.OK);
                response.Content = new ByteArrayContent(Encoding.UTF8.GetBytes("Không được truy cập"));
                return await Task.FromResult<HttpResponseMessage>(response);
            }
            // Chuyển truy vấn cho base (thi hành InnerHandler)
            return await base.SendAsync(request, cancellationToken);
        }
    }
}
