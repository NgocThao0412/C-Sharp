
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ThucHanh04d;

public class FormMenu : Form
{
    public FormMenu()
    {
        Text = "Menu Lab 04d";
        ClientSize = new Size(440, 280);
        StartPosition = FormStartPosition.CenterScreen;

        Label lbl = new Label
        {
            Text = "THUC HANH LAB 04D",
            Location = new Point(75, 25),
            Size = new Size(320, 40),
            Font = new Font("Arial", 17, FontStyle.Bold),
            ForeColor = Color.Blue
        };
        Controls.Add(lbl);

        Button btnBai1 = new Button
        {
            Text = "Bai 1 - Giai phuong trinh",
            Location = new Point(80, 90),
            Size = new Size(280, 42)
        };

        Button btnBai2 = new Button
        {
            Text = "Bai 2 - Mang so nguyen",
            Location = new Point(80, 145),
            Size = new Size(280, 42)
        };

        Button btnThoat = new Button
        {
            Text = "Thoat",
            Location = new Point(150, 205),
            Size = new Size(140, 35)
        };

        btnBai1.Click += (s, e) =>
            new FormBai1().ShowDialog(this);

        btnBai2.Click += (s, e) =>
            new FormBai2().ShowDialog(this);

        btnThoat.Click += (s, e) => Close();

        Controls.AddRange(new Control[]
        {
            btnBai1, btnBai2, btnThoat
        });
    }
}
