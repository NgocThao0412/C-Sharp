using System;
using System.Collections;

namespace ThucHanh02_Bai2_2
{
    // Lớp Person (đã định nghĩa ở Bài 1.3)
    class Person
    {
        private string id;
        private string name;
        private int yob; // Năm sinh
        private int yod; // Năm mất (0 = còn sống)

        public string Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public int Yob { get => yob; set => yob = value; }
        public int Yod { get => yod; set => yod = value; }

        public Person()
        {
            id = "";
            name = "";
            yob = DateTime.Now.Year;
            yod = 0;
        }

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

        // Kiểm tra còn sống hay không
        public bool IsLiving()
        {
            return yod == 0;
        }

        public void Input()
        {
            Console.Write("  Nhap ID (CCCD/Ma): ");
            id = Console.ReadLine() ?? "";

            Console.Write("  Nhap Ho va ten: ");
            name = Console.ReadLine() ?? "";

            Console.Write("  Nhap Nam sinh (yob): ");
            int.TryParse(Console.ReadLine(), out yob);

            Console.Write("  Nhap Nam mat (yod - nhap 0 neu con song): ");
            int.TryParse(Console.ReadLine(), out yod);
        }

        public void Output()
        {
            if (IsLiving())
            {
                Console.WriteLine($"ID: {id,-10} | Ho ten: {name,-20} | Nam sinh: {yob,-6} | Trang thai: Con song");
            }
            else
            {
                Console.WriteLine($"ID: {id,-10} | Ho ten: {name,-20} | Nam sinh: {yob,-6} | Nam mat: {yod,-6} (Tho {yod - yob} tuoi)");
            }
        }
    }

    // Lớp PersonList quản lý danh sách nhiều người
    class PersonList
    {
        // 1. FIELD: Lưu danh sách các đối tượng Person
        private ArrayList listPerson;

        // 2. CONSTRUCTORS
        // Default Constructor
        public PersonList()
        {
            listPerson = new ArrayList();
        }

        // Copy Constructor
        public PersonList(PersonList pl)
        {
            listPerson = new ArrayList();
            if (pl != null)
            {
                for (int i = 0; i < pl.Count; i++)
                {
                    // Tạo bản sao của từng Person sang danh sách mới
                    this.Add(new Person(pl[i]));
                }
            }
        }

        // Thuộc tính lấy số lượng người
        public int Count
        {
            get { return listPerson.Count; }
        }

        // Indexer hỗ trợ truy cập phần tử thứ i dạng pl[i]
        public Person this[int index]
        {
            get
            {
                if (index >= 0 && index < listPerson.Count)
                    return (Person)listPerson[index];
                throw new IndexOutOfRangeException("Chi so nam ngoai pham vi PersonList!");
            }
            set
            {
                if (index >= 0 && index < listPerson.Count)
                    listPerson[index] = value;
                else
                    throw new IndexOutOfRangeException("Chi so nam ngoai pham vi PersonList!");
            }
        }

        // 3. PHƯƠNG THỨC THÊM 1 PERSON
        public void Add(Person x)
        {
            if (x != null)
            {
                listPerson.Add(x);
            }
        }

        // 4. PHƯƠNG THỨC NHẬP / XUẤT
        public void Input()
        {
            Console.Write("Nhap so luong nhan khau (n): ");
            int.TryParse(Console.ReadLine(), out int n);

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"\n[Nhap thong tin nguoi thu {i + 1}]");
                Person p = new Person();
                p.Input();
                this.Add(p);
            }
        }

        public void Output()
        {
            if (listPerson.Count == 0)
            {
                Console.WriteLine("Danh sach rong!");
                return;
            }

            for (int i = 0; i < listPerson.Count; i++)
            {
                Console.Write($"[{i + 1}] ");
                this[i].Output();
            }
        }

        // 5. PHƯƠNG THỨC LivingPeople(): TRẢ VỀ PersonList NHỮNG NGUỜI CÒN SỐNG
        public PersonList LivingPeople()
        {
            PersonList result = new PersonList();
            for (int i = 0; i < listPerson.Count; i++)
            {
                Person p = this[i];
                if (p.IsLiving())
                {
                    result.Add(p);
                }
            }
            return result;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== THUC HANH 02 - BAI 2.2: LOP PERSONLIST QUAN LY NHAN KHAU ===");

            // 1. Nhập danh sách nhân khẩu
            PersonList dsTong = new PersonList();
            dsTong.Input();

            // 2. Xuất toàn bộ danh sách
            Console.WriteLine("\n================ DANH SACH TOAN BO NHAN KHAU ================");
            dsTong.Output();

            // 3. Lọc danh sách những người còn sống bằng LivingPeople()
            PersonList dsConSong = dsTong.LivingPeople();

            // 4. Xuất danh sách những người còn sống
            Console.WriteLine($"\n================ DANH SACH NGUOI CON SONG ({dsConSong.Count} NGUOI) ================");
            dsConSong.Output();

            Console.ReadLine();
        }
    }
}