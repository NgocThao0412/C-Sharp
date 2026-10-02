<Query Kind="Program" />

void Main()
{
    Console.OutputEncoding = System.Text.Encoding.UTF8;

    Console.WriteLine("================ BÀI 2.1 ================");
    Bai21();

    Console.WriteLine("\n================ BÀI 2.2 ================");
    Bai22();
}

// Bài 2.1: Truy vấn mảng số nguyên
void Bai21()
{
    int[] mangSo = { 50, 42, 16, 3, 9, 8, 12, 7, 24, 0 };

    // a. Liệt kê các phần tử chia hết cho 4 và 3
    // Giải thích: Dùng Where() để lọc ra số n vừa chia hết cho 4 (n % 4 == 0) vừa chia hết cho 3 (n % 3 == 0)
    var cauA = mangSo.Where(n => n % 4 == 0 && n % 3 == 0);
    cauA.Dump("2.1a - Chia hết cho 4 và 3");

    // b. Liệt kê các phần tử nhỏ hơn hoặc bằng 3
    // Giải thích: Dùng Where() với điều kiện n <= 3
    var cauB = mangSo.Where(n => n <= 3);
    cauB.Dump("2.1b - Nhỏ hơn hoặc bằng 3");

    // c. Tạo dãy mới: số chẵn chia đôi, số lẻ giữ nguyên
    // Giải thích: Dùng Select() kết hợp toán tử 3 ngôi (điều_kiện ? nếu_đúng : nếu_sai)
    var cauC = mangSo.Select(n => n % 2 == 0 ? n / 2 : n);
    cauC.Dump("2.1c - Số chẵn chia đôi, số lẻ giữ nguyên");
}

// Bài 2.2: Truy vấn mảng chuỗi
void Bai22()
{
    string[] mangChuoi = { "đầu", "lòng", "hai", "ả", "tố", "nga", "Thúy", "Kiều", "là", "chị", "em", "là", "Thúy", "Vân" };

    // a. Có 4 ký tự và sắp xếp tăng dần theo ký tự đầu
    // Giải thích: Where() kiểm tra độ dài s.Length == 4, sau đó OrderBy() sắp xếp theo bảng chữ cái
    var cauA = mangChuoi.Where(s => s.Length == 4).OrderBy(s => s);
    cauA.Dump("2.2a - Có 4 ký tự, sắp xếp tăng dần");

    // b. Biến đổi dạng: <chữ thường> - <CHỮ HOA>
    // Giải thích: Select() ánh xạ từng chuỗi s sang chuỗi mới dạng $"{s.ToLower()} - {s.ToUpper()}"
    var cauB = mangChuoi.Select(s => $"{s.ToLower()} - {s.ToUpper()}");
    cauB.Dump("2.2b - Dạng <chữ thường> - <CHỮ HOA>");

    // c. Liệt kê các phần tử có chứa ký tự "u"
    // Giải thích: Chuyển về chữ thường bằng ToLower() rồi dùng Contains("u") để tìm
    var cauC = mangChuoi.Where(s => s.ToLower().Contains("u"));
    cauC.Dump("2.2c - Chứa ký tự 'u'");
}