
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ThucHanh05c;

public class FormListBox : Form
{
    private TextBox txtNhap = new TextBox();
    private ListBox lstSo = new ListBox();

    public FormListBox()
    {
        Text = "Bai ve nha 2 - Xu ly ListBox";
        ClientSize = new Size(670, 560);
        StartPosition = FormStartPosition.CenterScreen;
        Font = new Font("Arial", 10);

        Controls.Add(new Label
        {
            Text = "LISTBOX",
            Location = new Point(250, 15),
            Size = new Size(250, 45),
            Font = new Font("Arial", 23, FontStyle.Bold),
            ForeColor = Color.DarkOrange
        });

        GroupBox grpList = new GroupBox
        {
            Text = "ListBox",
            Location = new Point(25, 75),
            Size = new Size(255, 395)
        };
        Controls.Add(grpList);

        txtNhap.SetBounds(15, 35, 220, 28);
        grpList.Controls.Add(txtNhap);

        Button btnNhap = new Button
        {
            Text = "&Nhap",
            Location = new Point(15, 75),
            Size = new Size(220, 35)
        };
        grpList.Controls.Add(btnNhap);

        lstSo.SetBounds(15, 125, 220, 250);
        lstSo.SelectionMode = SelectionMode.MultiExtended;
        grpList.Controls.Add(lstSo);

        GroupBox grpXuLy = new GroupBox
        {
            Text = "Xu ly ListBox",
            Location = new Point(305, 75),
            Size = new Size(340, 395)
        };
        Controls.Add(grpXuLy);

        string[] tenNut =
        {
            "Tong cac phan tu trong List",
            "Xoa phan tu dau va cuoi",
            "Xoa phan tu dang chon",
            "Tang moi phan tu len 2",
            "Thay bang binh phuong",
            "Chon so chan",
            "Chon so le"
        };

        EventHandler[] xuLy =
        {
            TinhTong, XoaDauCuoi, XoaDangChon,
            TangHai, BinhPhuong, ChonChan, ChonLe
        };

        for (int i = 0; i < tenNut.Length; i++)
        {
            Button btn = new Button
            {
                Text = tenNut[i],
                Location = new Point(20, 25 + i * 50),
                Size = new Size(300, 38)
            };

            btn.Click += xuLy[i];
            grpXuLy.Controls.Add(btn);
        }

        Button btnThoat = new Button
        {
            Text = "KET THUC",
            Location = new Point(60, 490),
            Size = new Size(550, 40)
        };
        btnThoat.Click += (s, e) => Close();
        Controls.Add(btnThoat);

        btnNhap.Click += NhapSo;
        txtNhap.KeyPress += (s, e) =>
        {
            if (!char.IsDigit(e.KeyChar) &&
                !char.IsControl(e.KeyChar))
                e.Handled = true;
        };

        AcceptButton = btnNhap;
        FormClosing += XacNhanThoat;
    }

    private void ThongBao(string noiDung)
    {
        MessageBox.Show(
            noiDung, "Thong bao",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);
    }

    private bool CoDuLieu()
    {
        if (lstSo.Items.Count > 0)
            return true;

        ThongBao("Danh sach dang rong!");
        return false;
    }

    private void NhapSo(object? sender, EventArgs e)
    {
        if (!int.TryParse(txtNhap.Text, out int so) ||
            so < 0)
        {
            ThongBao("Vui long nhap so tu nhien hop le!");
            return;
        }

        lstSo.Items.Add((long)so);
        txtNhap.Clear();
        txtNhap.Focus();
    }

    private void TinhTong(object? sender, EventArgs e)
    {
        if (!CoDuLieu()) return;

        long tong = 0;
        foreach (long so in lstSo.Items)
        {
            try
            {
                tong = checked(tong + so);
            }
            catch (OverflowException)
            {
                ThongBao("Tong vuot qua gioi han!");
                return;
            }
        }

        ThongBao("Tong cac phan tu la: " + tong);
    }

    private void XoaDauCuoi(object? sender, EventArgs e)
    {
        if (!CoDuLieu()) return;

        lstSo.Items.RemoveAt(lstSo.Items.Count - 1);

        if (lstSo.Items.Count > 0)
            lstSo.Items.RemoveAt(0);
    }

    private void XoaDangChon(object? sender, EventArgs e)
    {
        if (lstSo.SelectedIndices.Count == 0)
        {
            ThongBao("Hay chon phan tu can xoa!");
            return;
        }

        for (int i = lstSo.SelectedIndices.Count - 1;
             i >= 0; i--)
        {
            lstSo.Items.RemoveAt(lstSo.SelectedIndices[i]);
        }
    }

    private void TangHai(object? sender, EventArgs e)
    {
        if (!CoDuLieu()) return;

        try
        {
            for (int i = 0; i < lstSo.Items.Count; i++)
            {
                long so = (long)lstSo.Items[i]!;
                checked
                {
                    lstSo.Items[i] = so + 2;
                }
            }
        }
        catch (OverflowException)
        {
            ThongBao("Gia tri vuot qua gioi han!");
        }
    }

    private void BinhPhuong(object? sender, EventArgs e)
    {
        if (!CoDuLieu()) return;

        try
        {
            for (int i = 0; i < lstSo.Items.Count; i++)
            {
                long so = (long)lstSo.Items[i]!;
                checked
                {
                    lstSo.Items[i] = so * so;
                }
            }
        }
        catch (OverflowException)
        {
            ThongBao("Gia tri vuot qua gioi han!");
        }
    }

    private void ChonChan(object? sender, EventArgs e)
    {
        ChonTheoDieuKien(true);
    }

    private void ChonLe(object? sender, EventArgs e)
    {
        ChonTheoDieuKien(false);
    }

    private void ChonTheoDieuKien(bool chan)
    {
        if (!CoDuLieu()) return;

        lstSo.ClearSelected();

        for (int i = 0; i < lstSo.Items.Count; i++)
        {
            long so = (long)lstSo.Items[i]!;

            if ((so % 2 == 0) == chan)
                lstSo.SetSelected(i, true);
        }
    }

    private void XacNhanThoat(
        object? sender, FormClosingEventArgs e)
    {
        if (MessageBox.Show(
            "Ban co muon thoat?",
            "Xac nhan",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question) == DialogResult.No)
        {
            e.Cancel = true;
        }
    }
}
