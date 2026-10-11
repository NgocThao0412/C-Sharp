
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ThucHanh04c;

public class FormMenu : Form
{
    public FormMenu()
    {
        Text = "Menu - Lab 04c";
        ClientSize = new Size(430, 460);
        StartPosition = FormStartPosition.CenterScreen;

        Label tieuDe = new Label
        {
            Text = "THUC HANH LAB 04C",
            Location = new Point(75, 20),
            Size = new Size(320, 40),
            Font = new Font("Arial", 17, FontStyle.Bold),
            ForeColor = Color.Blue
        };
        Controls.Add(tieuDe);

        ThemNut("Bai 1 - Bon phep tinh", 80,
            () => new FormBai1().ShowDialog(this));

        ThemNut("Bai 2 - Dang ky tai khoan", 135,
            () => new FormBai2().ShowDialog(this));
        
        ThemNut("Bai 3 - UCLN va BCNN", 190,
            () => new FormBai3().ShowDialog(this));

        ThemNut("Bai 4 - Tinh tong day so", 245,
            () => new Form1().ShowDialog(this));

        ThemNut("Bai 5 - Doc so thanh chu", 300,
            () => new FormBai5().ShowDialog(this));


        ThemNut("Thoat", 355, () => Close());
    }

    private void ThemNut(
        string ten, int y, Action hanhDong)
    {
        Button btn = new Button
        {
            Text = ten,
            Location = new Point(85, y),
            Size = new Size(260, 40)
        };

        btn.Click += (s, e) => hanhDong();
        Controls.Add(btn);
    }
}
