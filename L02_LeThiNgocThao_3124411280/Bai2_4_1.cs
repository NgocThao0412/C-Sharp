using System;
using System.Collections;

namespace ThucHanh02_Bai2_4_PhanSo
{
    // 1. LỚP PHÂN SỐ
    class PhanSo
    {
        private int tuSo;
        private int mauSo;

        public int TuSo { get => tuSo; set => tuSo = value; }
        public int MauSo
        {
            get => mauSo;
            set => mauSo = (value != 0) ? value : 1;
        }

        public PhanSo()
        {
            tuSo = 0;
            mauSo = 1;
        }

        public PhanSo(int tu, int mau = 1)
        {
            tuSo = tu;
            MauSo = mau;
            RutGon();
        }

        private static int UCLN(int a, int b)
        {
            a = Math.Abs(a);
            b = Math.Abs(b);
            while (b != 0)
            {
                int temp = a % b;
                a = b;
                b = temp;
            }
            return a;
        }

        public void RutGon()
        {
            int ucln = UCLN(tuSo, mauSo);
            if (ucln > 1)
            {
                tuSo /= ucln;
                mauSo /= ucln;
            }
            if (mauSo < 0)
            {
                tuSo = -tuSo;
                mauSo = -mauSo;
            }
        }

        public static PhanSo operator +(PhanSo a, PhanSo b)
        {
            int tu = a.tuSo * b.mauSo + b.tuSo * a.mauSo;
            int mau = a.mauSo * b.mauSo;
            return new PhanSo(tu, mau);
        }

        public override string ToString()
        {
            if (mauSo == 1) return $"{tuSo}";
            if (tuSo == 0) return "0";
            return $"{tuSo}/{mauSo}";
        }

        public void Nhap()
        {
            Console.Write("    Nhap tu so: ");
            int.TryParse(Console.ReadLine(), out tuSo);

            Console.Write("    Nhap mau so (khac 0): ");
            int m;
            while (!int.TryParse(Console.ReadLine(), out m) || m == 0)
            {
                Console.Write("    Mau so phai khac 0! Nhap lai: ");
            }
            MauSo = m;
            RutGon();
        }
    }

    // 2. LỚP DÃY PHÂN SỐ (CHỨA N PHÂN SỐ)
    class DayPhanSo
    {
        private ArrayList dsPhanSo;

        public DayPhanSo()
        {
            dsPhanSo = new ArrayList();
        }

        public int Count => dsPhanSo.Count;

        public PhanSo this[int index]
        {
            get => (PhanSo)dsPhanSo[index];
            set => dsPhanSo[index] = value;
        }

        public void Nhap()
        {
            Console.Write("Nhap so luong phan so (n): ");
            int.TryParse(Console.ReadLine(), out int n);

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"\n  [Nhap phan so thu {i + 1}]");
                PhanSo ps = new PhanSo();
                ps.Nhap();
                dsPhanSo.Add(ps);
            }
        }

        public void Xuat()
        {
            if (dsPhanSo.Count == 0)
            {
                Console.WriteLine("Day phan so rong!");
                return;
            }

            for (int i = 0; i < dsPhanSo.Count; i++)
            {
                Console.Write(this[i] + (i < dsPhanSo.Count - 1 ? " + " : ""));
            }
            Console.WriteLine();
        }

        // TÍNH TỔNG CỦA N PHÂN SỐ
        public PhanSo TinhTong()
        {
            PhanSo tong = new PhanSo(0, 1);
            foreach (PhanSo ps in dsPhanSo)
            {
                tong = tong + ps;
            }
            return tong;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== BÀI 2.4: DÃY PHÂN SỐ VA TÍNH TỔNG ===");

            DayPhanSo dps = new DayPhanSo();
            dps.Nhap();

            Console.WriteLine("\n--- DÃY PHÂN SỐ VỪA NHẬP ---");
            dps.Xuat();

            PhanSo tong = dps.TinhTong();
            Console.WriteLine($"\n-> TỔNG CỦA {dps.Count} PHÂN SỐ TRÊN = {tong}");

            Console.ReadLine();
        }
    }
}