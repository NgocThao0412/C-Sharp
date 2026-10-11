
using System;

namespace ThucHanh04d;

public class PhuongTrinhBacHai
{
    public double A { get; set; }
    public double B { get; set; }
    public double C { get; set; }

    public PhuongTrinhBacHai()
    {
        A = B = C = 0;
    }

    public PhuongTrinhBacHai(double a, double b, double c)
    {
        A = a;
        B = b;
        C = c;
    }

    public string GiaiBacNhat()
    {
        if (A == 0)
        {
            if (B == 0)
                return "Phuong trinh vo so nghiem";

            return "Phuong trinh vo nghiem";
        }

        double x = -B / A;

        return "Phuong trinh co nghiem x = "
            + x.ToString("G6");
    }

    public string GiaiBacHai()
    {
        if (A == 0)
            return GiaiBacNhat();

        double delta = B * B - 4 * A * C;

        if (delta < 0)
            return "Phuong trinh vo nghiem thuc";

        if (delta == 0)
        {
            double x = -B / (2 * A);

            return "Phuong trinh co nghiem kep x = "
                + x.ToString("G6");
        }

        double x1 = (-B + Math.Sqrt(delta)) / (2 * A);
        double x2 = (-B - Math.Sqrt(delta)) / (2 * A);

        return "Phuong trinh co 2 nghiem:\r\n"
            + "x1 = " + x1.ToString("G6")
            + "\r\nx2 = " + x2.ToString("G6");
    }
}
