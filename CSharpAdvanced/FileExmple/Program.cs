using System;
using System.IO;
using System.Text;

namespace FileExmple
{
    class Program
    {
        class Product
        {
            public int Id
            {
                set; get;
            }
            public double Price
            {
                set; get;
            }
            public string Name
            {
                set; get;
            }
            public void Save(Stream stream)
            {
                // int => 4 byte
                var bytes_Id = BitConverter.GetBytes(Id);
                stream.Write(bytes_Id, 0, 4);
                // double => 8 byte
                var byte_Price = BitConverter.GetBytes(Price);
                stream.Write(byte_Price, 0, 8);
                // chuoi Name
                var bytes_Name = Encoding.UTF8.GetBytes(Name);
                var bytes_Length = BitConverter.GetBytes(bytes_Name.Length);
                stream.Write(bytes_Length, 0, 4);
                stream.Write(bytes_Name, 0, bytes_Name.Length);

            }
            public void Restore(Stream stream)
            {
                var bytes_Id = new byte[4];
                stream.Read(bytes_Id, 0, 4);
                Id = BitConverter.ToInt32(bytes_Id, 0);

                var bytes_price = new byte[8];
                stream.Read(bytes_price, 0, 8);
                Price = BitConverter.ToDouble(bytes_price, 0);

                var bytes_Length = new byte[4];
                stream.Read(bytes_Length, 0, 4);
                int length = BitConverter.ToInt32(bytes_Length, 0);

                var bytes_Name = new byte[length];
                stream.Read(bytes_Name, 0, length);
                Name = Encoding.UTF8.GetString(bytes_Name, 0, length);
             
            }

            static void Main(string[] args)
            {
                //DriveInfo - đọc thông tin của các ổ đĩa
                #region DriveInfo 
                // kiểm tra xem trên máy có những ổ nào và in ra các thông tin 
                //var drives = DriveInfo.GetDrives();
                //// lấy thông tin về ổ C
                ////DriveInfo drive = new DriveInfo("C:"); 
                //foreach (var drive in drives)
                //{
                //    Console.WriteLine($"Drive: {drive.Name}");
                //    Console.WriteLine($"Drive of Type: {drive.DriveType}");
                //    Console.WriteLine($"Drive of Label: {drive.VolumeLabel}");
                //    Console.WriteLine($"Drive of Format: {drive.DriveFormat}");
                //    Console.WriteLine($"Drive of Size: {drive.TotalSize}");
                //    Console.WriteLine($"Drive of  Free Size: {drive.TotalFreeSpace}");
                //    Console.WriteLine("____________________________________");

                //}
                #endregion

                // Directory - để thao tác với các thư mục 
                #region Directory 
                //// tạo tên thư mục;
                //string path = "CSharp Basic"; 
                //// tạo một thư mục mới
                //Directory.CreateDirectory(path);
                //// xóa 1 thư mục 
                //Directory.Delete(path);
                //// kiểm tra xem thư muck có tồn tại không
                //if (Directory.Exists(path))
                //{
                //    Console.WriteLine($"{path} is exist");
                //}
                //else
                //{
                //    Console.WriteLine($"{path} isn't exist");
                //}
                //Console.WriteLine(Path.DirectorySeparatorChar);

                // lấy các file trong thư mục 
                //string path = "D:\\Truyện Chêm T.A";
                //var files = Directory.GetFiles(path);
                //foreach (var file in files)
                //{
                //    Console.WriteLine(file);
                //}
                #endregion
                //Path - hỗ trợ đường dẫn file
                #region Path 
                //var path = "\\Truyện Chêm T.A\\Wait.docx";
                //Console.WriteLine(Path.GetDirectoryName(path));// trả về thư mục chứa file
                //Console.WriteLine(Path.GetExtension(path)); // trả về phần mở rộng của tên file
                //Console.WriteLine(Path.GetFileName(path)); // trả về tên file
                //Console.WriteLine(Path.GetFullPath(path)); // trả về đường dẫn tuyệt đối của file
                //// dối với các folder đặc biệt
                //var path_mydoc = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
                //Console.WriteLine(path_mydoc);
                #endregion

                // Sẽ có trường hợp nhiều User đọc cùng 1 file sẽ phát sinh lỗi 

                // File - có các phương thức hỗ trợ với file
                #region File 
                //string fileName = "abc.txt";
                //string context = "Xin chao cac ban 2022";
                //File.WriteAllText(fileName, context); // viết ra chuỗi string thành text trong file;
                //File.AppendAllText(fileName, context); // ghi thêm string thành text vào file;
                //string strText = File.ReadAllText(fileName); // đọc file dưới dạng text.
                //Console.WriteLine(strText);
                //File.Move("abc.txt", "Hello.txt"); // Đổi tên các file.
                //File.Copy("Hello.txt", "HiEveryOne.txt"); // Coppy 1 file từ file có sẵn
                //File.Delete("Hello.txt"); // xóa 1 file 
                #endregion
                // FilStream 
                #region FileStream
                string path = "data.txt";
                using var stream = new FileStream(path: path, FileMode.Open);
                //Product product = new Product() {
                //    Id = 1,
                //    Price = 1222,
                //    Name = "Product Abc"

                //};
                //product.Save(stream);
                Product product = new Product();
                product.Restore(stream);
                Console.WriteLine($"{product.Id} + {product.Name} + {product.Price}");
                #region Stream
                // lưu dữ liệu 
                //byte[] buffer = { 1, 2, 3 };
                //int offset = 0;
                //int count = 3;
                //stream.Write(buffer, offset, count);

                //// đọc dữ liệu
                //int sobytedemduoc = stream.Read(buffer, offset, count);
                //// int, double --> bytrs
                //int abc = 1;
                //var resultByte = BitConverter.GetBytes(abc);
                //// byte => in, double.....
                //BitConverter.ToInt32(resultByte, 0);

                //string s = "Abc";
                //var bytes = Encoding.UTF8.GetBytes(s);
                //Encoding.UTF8.GetString(bytes, 0, 10);
                #endregion






                #endregion

            }
        }
    }
}
