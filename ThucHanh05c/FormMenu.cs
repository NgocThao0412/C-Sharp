
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ThucHanh05c;

public class FormMenu : Form
{
    public FormMenu()
    {
        Text = "Menu Lab 05c";
        ClientSize = new Size(480, 465);
        StartPosition = FormStartPosition.CenterScreen;
        Font = new Font("Arial", 11);

        Label lbl = new Label
        {
            Text = "THUC HANH LAB 05C",
            Location = new Point(75, 20),
            Size = new Size(370, 45),
            Font = new Font("Arial", 19, FontStyle.Bold),
            ForeColor = Color.Blue
        };
        Controls.Add(lbl);

        ThemNut("Bai 1 - Uoc so", 80,
            () => new FormBai1().ShowDialog(this));

        ThemNut("Bai 2 - Quan ly sinh vien", 140,
            () => new FormBai2().ShowDialog(this));

        ThemNut("Ve nha 1 - Tu dien Anh Viet", 200,
            () => new FormTuDien().ShowDialog(this));

        ThemNut("Ve nha 2 - Xu ly ListBox", 260,
            () => new FormListBox().ShowDialog(this));

        ThemNut("Ve nha 3 - Danh ba", 320,
            () => new FormDanhBa().ShowDialog(this));

        ThemNut("Thoat", 390, () => Close());
    }

    private void ThemNut(
        string ten, int y, Action hanhDong)
    {
        Button btn = new Button
        {
            Text = ten,
            Location = new Point(85, y),
            Size = new Size(310, 43)
        };

        btn.Click += (s, e) => hanhDong();

        Controls.Add(btn);
    }
}
