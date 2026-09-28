using System;

namespace ThucHanh02_Bai1_3
{
    // Lớp Person quản lý thông tin một người
    class Person
    {
        // 1. FIELDS (id, name, yob: năm sinh, yod: năm mất)
        private string id;
        private string name;
        private int yob;
        private int yod;

        // 2. PROPERTIES
        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Yob
        {
            get { return yob; }
            set { yob = value; }
        }

        public int Yod
        {
            get { return yod; }
            set { yod = value; }
        }

        // 3. CONSTRUCTORS
        // Default Constructor
        public Person()
        {
            id = "";
            name = "";
            yob = DateTime.Now.Year;
            yod = 0; // Mặc định 0 là còn sống
        }

        // Parameterized Constructor
        public Person(string id, string name, int yob, int yod = 0)
        {
            this.id = id;
            this.name = name;
            this.yob = yob;
            this.yod = yod;
        }

        // Copy Constructor
        public Person(Person p)
        {
            if (p != null)
            {
                this.id = p.id;
                this.name = p.name;
                this.yob = p.yob;
                this.yod = p.yod;
            }
        }

        // 4. PHƯƠNG THỨC KIỂM TRA CÒN SỐNG HAY KHÔNG
        // Trả về true nếu yod == 0 (còn sống), ngược lại trả về false (đã mất)
        public bool IsLiving()
        {
            return yod == 0;
        }

        // 5. PHƯƠNG THỨC NHẬP / XUẤT
        public void Input()
        {
            Console.Write("  Nhap ID (Ma/CCCD): ");
            id = Console.ReadLine();

            Console.Write("  Nhap ho va ten: ");
            name = Console.ReadLine();

            Console.Write("  Nhap nam sinh (yob): ");
            int.TryParse(Console.ReadLine(), out yob);

            Console.Write("  Nhap nam mat (yod - nhap 0 neu con song): ");
            int.TryParse(Console.ReadLine(), out yod);
        }

        public void Output()
        {
            Console.WriteLine("ID        : {0}", id);
            Console.WriteLine("Ho ten    : {0}", name);
            Console.WriteLine("Nam sinh  : {0}", yob);
            if (IsLiving())
            {
                Console.WriteLine("Trang thai: Con song (yod = 0)");
            }
            else
            {
                Console.WriteLine("Nam mat   : {0}", yod);
                Console.WriteLine("Trang thai: Da mat (Tho {0} tuoi)", yod - yob);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== THUC HANH 02 - BAI 1.3: LOP PERSON ===");

            // Nhập đối tượng Person 1
            Person p1 = new Person();
            Console.WriteLine("\n[Nhap thong tin Person 1]");
            p1.Input();

            Console.WriteLine("\n--- THONG TIN PERSON 1 ---");
            p1.Output();

            // Thử nghiệm Copy Constructor để tạo Person 2 sao chép từ Person 1
            Person p2 = new Person(p1);
            Console.WriteLine("\n--- THONG TIN PERSON 2 (SAO CHEP TU PERSON 1) ---");
            p2.Output();

            Console.ReadLine();
        }
    }
}