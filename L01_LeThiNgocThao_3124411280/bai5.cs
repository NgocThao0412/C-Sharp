using System;

namespace Lab01_Bai5
{
    class Program
    {
        static void Main(string[] args)
        {
            double x = 0, y = 0;
            bool daNhap = false; // Biến đánh dấu xem người dùng đã nhập x, y chưa
            int chon = 0;

            do
            {
                // 1. In MENU ra màn hình
                Console.WriteLine("\n MENU ");
                Console.WriteLine("1. Nhap hai gia tri so thuc cho x, y");
                Console.WriteLine("2. Tinh x^y");
                Console.WriteLine("3. Tinh can bac 2 cua x va y");
                Console.WriteLine("4. Thoat");
                Console.Write("Chon chuc nang: ");

                // Đọc lựa chọn menu
                if (!int.TryParse(Console.ReadLine(), out chon))
                {
                    Console.WriteLine("Loi: Vui long nhap so tu 1 den 4!");
                    continue;
                }

                // 2. Xử lý lựa chọn menu
                switch (chon)
                {
                    case 1:
                        // Nhập số thực x
                        Console.Write("Nhap so thuc x: ");
                        while (!double.TryParse(Console.ReadLine(), out x))
                        {
                            Console.Write("Gia tri khong hop le! Nhap lai x: ");
                        }

                        // Nhập số thực y
                        Console.Write("Nhap so thuc y: ");
                        while (!double.TryParse(Console.ReadLine(), out y))
                        {
                            Console.Write("Gia tri khong hop le! Nhap lai y: ");
                        }

                        daNhap = true;
                        Console.WriteLine("-> Da luu: x = {0}, y = {1}", x, y);
                        break;

                    case 2:
                        if (!daNhap)
                        {
                            Console.WriteLine("Thong bao: Ban chua nhap x va y! Vui long chon chuc nang 1 truoc.");
                        }
                        else
                        {
                            double luyThua = Math.Pow(x, y);
                            Console.WriteLine("-> Ket qua {0}^{1} la: {2}", x, y, luyThua);
                        }
                        break;

                    case 3:
                        if (!daNhap)
                        {
                            Console.WriteLine("Thong bao: Ban chua nhap x va y! Vui long chon chuc nang 1 truoc.");
                        }
                        else
                        {
                            // Căn bậc 2 của x
                            if (x >= 0)
                                Console.WriteLine("-> Can bac 2 cua x ({0}) la: {1}", x, Math.Sqrt(x));
                            else
                                Console.WriteLine("-> Khong tinh duoc can bac 2 cua x vi x < 0");

                            // Căn bậc 2 của y
                            if (y >= 0)
                                Console.WriteLine("-> Can bac 2 cua y ({0}) la: {1}", y, Math.Sqrt(y));
                            else
                                Console.WriteLine("-> Khong tinh duoc can bac 2 cua y vi y < 0");
                        }
                        break;

                    case 4:
                        Console.WriteLine("Da thoat chuong trinh. Tam biet!");
                        break;

                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ. Vui lòng chọn từ 1 đến 4!");
                        break;
                }

            } while (chon != 4); // Lặp lại menu nếu chưa chọn 4
        }
    }
}