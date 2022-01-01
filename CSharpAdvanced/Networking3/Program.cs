using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Networking3
{
    class MyHttpServer
    {
        private HttpListener listener;

        public MyHttpServer(params string[] prefixes)
        {
            if (!HttpListener.IsSupported)
                throw new Exception("Máy không hỗ trợ HttpListener.");

            if (prefixes == null || prefixes.Length == 0)
                throw new ArgumentException("prefixes");

            // Khởi tạo HttpListener
            listener = new HttpListener();
            foreach (string prefix in prefixes)
                listener.Prefixes.Add(prefix);

        }
        public async Task StartAsync()
        {
            // Bắt đầu lắng nghe kết nối HTTP
            listener.Start();
            do
            {

                try
                {
                    Console.WriteLine($"{DateTime.Now.ToLongTimeString()} : waiting a client connect");

                    // Một client kết nối đến
                    HttpListenerContext context = await listener.GetContextAsync();
                    await ProcessRequest(context);

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Console.WriteLine("...");

            }
            while (listener.IsListening);
        }

        // Xử lý trả về nội dung tùy thuộc vào URL truy cập
        //      /               hiện thị dòng Hello World
        //      /stop           dừng máy chủ
        //      /json           trả về một nội dung json
        //      /anh2.png       trả về một file ảnh 
        //      /requestinfo    thông tin truy vấn
        async Task ProcessRequest(HttpListenerContext context)
        {
            HttpListenerRequest request = context.Request;
            HttpListenerResponse response = context.Response;
            Console.WriteLine($"{request.HttpMethod} {request.RawUrl} {request.Url.AbsolutePath}");

            // Lấy stream / gửi dữ liệu về cho client
            var outputstream = response.OutputStream;


            switch (request.Url.AbsolutePath)
            {

                case "/":
                    {
                        byte[] buffer = Encoding.UTF8.GetBytes("Hello world!");
                        response.ContentLength64 = buffer.Length;
                        await outputstream.WriteAsync(buffer, 0, buffer.Length);
                    }
                    break;

                case "/json":
                    {
                        response.Headers.Add("Content-Type", "application/json");
                        var product = new {
                            Name = "Macbook Pro",
                            Price = 2000,
                            Manufacturer = "Apple"
                        };
                        string jsonstring = JsonConvert.SerializeObject(product);
                        byte[] buffer = Encoding.UTF8.GetBytes(jsonstring);
                        response.ContentLength64 = buffer.Length;
                        await outputstream.WriteAsync(buffer, 0, buffer.Length);

                    }
                    break;
                case "/anh2.png":
                    {
                        response.Headers.Add("Content-Type", "image/png");
                        byte[] buffer = await File.ReadAllBytesAsync("anh2.png");
                        response.ContentLength64 = buffer.Length;
                        await outputstream.WriteAsync(buffer, 0, buffer.Length);

                    }
                    break;

                default:
                    {
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        byte[] buffer = System.Text.Encoding.UTF8.GetBytes("NOT FOUND!");
                        response.ContentLength64 = buffer.Length;
                        await outputstream.WriteAsync(buffer, 0, buffer.Length);
                    }
                    break;
            }

            // switch (request.Url.AbsolutePath)


            // Đóng stream để hoàn thành gửi về client
            outputstream.Close();
        }

        class Program
        {
            static async Task SupportedHttpListener()
            {
                if (HttpListener.IsSupported)
                {
                    Console.WriteLine(" Have supported HttpListener");
                }
                else
                {
                    Console.WriteLine(" Not supported HttpListener");
                    throw new Exception(" Not supported HttpListener");
                }

            }

            static async Task Main(string[] args)
            {
                //SupportedHttpListener();
                #region Create Sever Basic
                //var sever = new HttpListener();
                //sever.Prefixes.Add("http://*:8080/"); // tạo ra cổng kết nối tới sever
                //sever.Start(); // Sever bắt đầu chạy
                //Console.WriteLine("Sever HTTP Start");

                //do
                //{
                //    var context = await sever.GetContextAsync();
                //    Console.WriteLine("Client connected");

                //    var response = context.Response;

                //    var outputStream = response.OutputStream;
                //    response.Headers.Add("content-type", "text/html");

                //    var html = "<h1>Hello World</h1>";
                //    var bytes = Encoding.UTF8.GetBytes(html);
                //    await outputStream.WriteAsync(bytes, 0, bytes.Length);
                //    outputStream.Close();

                //} while (sever.IsListening);
                #endregion
                var sever = new MyHttpServer(new string[] { "http://*:8080/" });
                await sever.StartAsync();

            }
        }
    }
}
