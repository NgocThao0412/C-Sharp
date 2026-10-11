
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ThucHanh04d;

public class FormMenu : Form
{
    public FormMenu()
    {
        Text = "Menu Lab 04d";
        ClientSize = new Size(440, 340);
        StartPosition = FormStartPosition.CenterScreen;

        // Tieu de
        Label lbl = new Label
        {
            Text = "THUC HANH LAB 04D",
            Location = new Point(75, 25),
            Size = new Size(320, 40),
            Font = new Font("Arial", 17, FontStyle.Bold),
            ForeColor = Color.Blue
        };
        Controls.Add(lbl);

        // Bai 1 - Giai phuong trinh
        Button btnBai1 = new Button
        {
            Text = "Bai 1 - Giai phuong trinh",
            Location = new Point(80, 90),
            Size = new Size(280, 42)
        };

        // Bai 2 - Mang so nguyen
        Button btnBai2 = new Button
        {
            Text = "Bai 2 - Mang so nguyen",
            Location = new Point(80, 145),
            Size = new Size(280, 42)
        };

        // Bai nang cao - Cafe Sinh Vien
        Button btnCafe = new Button
        {
            Text = "Bai nang cao - Cafe Sinh Vien",
            Location = new Point(80, 200),
            Size = new Size(280, 42)
        };

        // Nut Thoat
        Button btnThoat = new Button
        {
            Text = "Thoat",
            Location = new Point(150, 265),
            Size = new Size(140, 35)
        };

        // Gan su kien Click
        btnBai1.Click += (s, e) =>
            new FormBai1().ShowDialog(this);

        btnBai2.Click += (s, e) =>
            new FormBai2().ShowDialog(this);

        btnCafe.Click += (s, e) =>
            new FormCafeSinhVien().ShowDialog(this);

        btnThoat.Click += (s, e) => Close();

        // Them cac Button vao Form
        Controls.AddRange(new Control[]
        {
            btnBai1,
            btnBai2,
            btnCafe,
            btnThoat
        });
    }
}
