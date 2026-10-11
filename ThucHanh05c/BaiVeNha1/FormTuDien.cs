
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ThucHanh05c;

public class FormTuDien : Form
{
    private TabControl tabTuDien = new TabControl();

    private readonly List<KeyValuePair<string, string>> tuDien =
        new List<KeyValuePair<string, string>>
        {
            new("student", "Sinh viên, học sinh"),
            new("teacher", "Giáo viên"),
            new("worker", "Công nhân"),
            new("hat", "Mũ"),
            new("head", "Đầu"),
            new("mouse", "Chuột"),
            new("cat", "Mèo"),
            new("dog", "Chó"),
            new("snake", "Rắn"),
            new("lamb", "Cừu con"),
            new("loan", "Khoản vay"),
            new("frog", "Ếch"),
            new("sheep", "Cừu"),
            new("book", "Sách"),
            new("school", "Trường học"),
            new("computer", "Máy tính"),
            new("apple", "Quả táo"),
            new("house", "Ngôi nhà"),
            new("water", "Nước"),
            new("friend", "Bạn bè")
        };

    public FormTuDien()
    {
        Text = "TU DIEN ANH VIET - VIET ANH";
        ClientSize = new Size(760, 550);
        StartPosition = FormStartPosition.CenterScreen;
        Font = new Font("Arial", 11);

        TabPage tabAnhViet = new TabPage("ANH - VIET");
        TabPage tabVietAnh = new TabPage("VIET - ANH");

        tabTuDien.SetBounds(20, 20, 720, 450);

        tabTuDien.TabPages.Add(tabAnhViet);
        tabTuDien.TabPages.Add(tabVietAnh);

        Controls.Add(tabTuDien);

        TaoGiaoDien(tabAnhViet, true);
        TaoGiaoDien(tabVietAnh, false);

        Button btnThoat = new Button
        {
            Text = "Thoat",
            Location = new Point(580, 490),
            Size = new Size(145, 38)
        };

        btnThoat.Click += (s, e) => Close();
        Controls.Add(btnThoat);

        FormClosing += (s, e) =>
        {
            DialogResult kq = MessageBox.Show(
                "Ban co muon thoat chuong trinh?",
                "Xac nhan",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (kq == DialogResult.No)
                e.Cancel = true;
        };
    }

    private void TaoGiaoDien(TabPage tab, bool anhViet)
    {
        Label lblNhap = new Label
        {
            Text = anhViet ? "Tieng Anh" : "Tieng Viet",
            Location = new Point(35, 25),
            AutoSize = true
        };

        Label lblNghia = new Label
        {
            Text = anhViet ? "Tieng Viet" : "Tieng Anh",
            Location = new Point(375, 25),
            AutoSize = true
        };

        ComboBox cboTu = new ComboBox
        {
            Location = new Point(35, 60),
            Size = new Size(275, 30),
            DropDownStyle = ComboBoxStyle.DropDown,
            AutoCompleteMode = AutoCompleteMode.SuggestAppend,
            AutoCompleteSource = AutoCompleteSource.ListItems
        };

        ListBox lstTu = new ListBox
        {
            Location = new Point(35, 105),
            Size = new Size(275, 280)
        };

        TextBox txtNghia = new TextBox
        {
            Location = new Point(375, 60),
            Size = new Size(285, 325),
            Multiline = true,
            ReadOnly = true,
            ScrollBars = ScrollBars.Vertical
        };

        List<string> danhSach = anhViet
            ? tuDien.Select(x => x.Key)
                .OrderBy(x => x).ToList()
            : tuDien.Select(x => x.Value)
                .OrderBy(x => x).ToList();

        foreach (string tu in danhSach)
        {
            cboTu.Items.Add(tu);
            lstTu.Items.Add(tu);
        }

        void TraTu(string tu)
        {
            var ketQua = anhViet
                ? tuDien.FirstOrDefault(x =>
                    x.Key.Equals(
                        tu, StringComparison.OrdinalIgnoreCase))
                : tuDien.FirstOrDefault(x =>
                    x.Value.Equals(
                        tu, StringComparison.OrdinalIgnoreCase));

            if (ketQua.Key == null)
            {
                txtNghia.Text = "Khong tim thay tu!";
                return;
            }

            txtNghia.Text = anhViet
                ? ketQua.Value
                : ketQua.Key;
        }

        // Nhan Enter trong ComboBox
        cboTu.KeyDown += (s, e) =>
        {
            if (e.KeyCode == Keys.Enter)
            {
                TraTu(cboTu.Text.Trim());
                e.SuppressKeyPress = true;
            }
        };

        // Nhan dup vao ComboBox
        cboTu.DoubleClick += (s, e) =>
        {
            TraTu(cboTu.Text.Trim());
        };

        // Chon tu trong danh sach
        lstTu.SelectedIndexChanged += (s, e) =>
        {
            if (lstTu.SelectedItem != null)
                cboTu.Text = lstTu.SelectedItem.ToString();
        };

        // Nhan dup vao tu trong ListBox
        lstTu.DoubleClick += (s, e) =>
        {
            if (lstTu.SelectedItem != null)
                TraTu(lstTu.SelectedItem.ToString()!);
        };

        // Nhan Enter tren ListBox
        lstTu.KeyDown += (s, e) =>
        {
            if (e.KeyCode == Keys.Enter &&
                lstTu.SelectedItem != null)
            {
                TraTu(lstTu.SelectedItem.ToString()!);
                e.SuppressKeyPress = true;
            }
        };

        tab.Controls.AddRange(new Control[]
        {
            lblNhap, lblNghia, cboTu, lstTu, txtNghia
        });
    }
}
