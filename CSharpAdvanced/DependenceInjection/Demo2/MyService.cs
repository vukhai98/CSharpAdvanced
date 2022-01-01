using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Options;

namespace DependenceInjection
{
    public class MyService
    {
        public string data1
        {
            get; set;
        }
        public int data2
        {
            get; set;
        }

        // Tham số khởi tạo là IOptions, các tham số khởi tạo khác nếu có khai báo như bình thường
        public MyService(IOptions<MyServiceOptions> options)
        {
            // Đọc được MyServiceOptions từ IOptions
            MyServiceOptions opts = options.Value;
            data1 = opts.Data1;
            data2 = opts.Data2;
        }
        public void PrintData() => Console.WriteLine($"{data1} / {data2}");
    }
}
