
using System;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace ThucHanh04d;

public class FormCafeSinhVien : Form
{
    private TextBox txtTen = new TextBox();
    private TextBox txtSoKhach = new TextBox();
    private TextBox txtTongKhach = new TextBox();
    private TextBox txtTongTien = new TextBox();

    private CheckBox chkSinhVien = new CheckBox();

    private RadioButton[] radioCafe = new RadioButton[5];
    private CheckBox[] checkMonAn = new CheckBox[5];

    private Button btnTinhTien = new Button();
    private Button btnNhapLai = new Button();
    private Button btnThanhToan = new Button();
    private Button btnThoat = new Button();

    private readonly string[] tenCafe =
    {
        "Cafe den", "Cafe da", "Cafe sua",
        "Cafe sua da", "Cafe kem"
    };

    private readonly int[] giaCafe =
    {
        20000, 25000, 25000, 30000, 35000
    };

    private readonly string[] tenMonAn =
    {
        "Banh mi trung", "Banh mi ca",
        "Mi tom trung", "Mi xao bo", "Mi cay"
    };

    private readonly int[] giaMonAn =
    {
        15000, 15000, 20000, 30000, 50000
    };

    private int tongSoKhach = 0;
    private long tongDoanhThu = 0;
    private long tienHoaDon = 0;
    private int soKhachHienTai = 0;

    private bool daTinhTien = false;

    public FormCafeSinhVien()
    {
        Text = "Thanh toan tien - Cafe Sinh Vien";
        ClientSize = new Size(650, 590);
        StartPosition = FormStartPosition.CenterScreen;
        Font = new Font("Arial", 10);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;

        Label lblTieuDe = new Label
        {
            Text = "CAFE SINH VIEN",
            Location = new Point(200, 20),
            Size = new Size(330, 42),
            Font = new Font("Arial", 21, FontStyle.Bold),
            ForeColor = Color.DarkOrange
        };
        Controls.Add(lblTieuDe);

        TaoNhan("Ten khach hang:", 35, 85);
        txtTen.SetBounds(190, 80, 380, 28);
        Controls.Add(txtTen);

        TaoNhan("So khach hang:", 35, 125);
        txtSoKhach.SetBounds(190, 120, 380, 28);
        Controls.Add(txtSoKhach);

        chkSinhVien.Text = "Sinh vien?";
        chkSinhVien.SetBounds(190, 160, 150, 28);
        Controls.Add(chkSinhVien);

        // Nhom nuoc uong
        GroupBox grpCafe = new GroupBox
        {
            Text = "Nuoc uong",
            Location = new Point(30, 205),
            Size = new Size(285, 185)
        };
        Controls.Add(grpCafe);

        for (int i = 0; i < 5; i++)
        {
            radioCafe[i] = new RadioButton
            {
                Text = tenCafe[i],
                Location = new Point(15, 28 + i * 29),
                Size = new Size(245, 26)
            };

            grpCafe.Controls.Add(radioCafe[i]);
            radioCafe[i].CheckedChanged += DuLieuThayDoi;
        }

        // Nhom thuc an
        GroupBox grpMonAn = new GroupBox
        {
            Text = "Thuc an",
            Location = new Point(335, 205),
            Size = new Size(285, 185)
        };
        Controls.Add(grpMonAn);

        for (int i = 0; i < 5; i++)
        {
            checkMonAn[i] = new CheckBox
            {
                Text = tenMonAn[i],
                Location = new Point(15, 28 + i * 29),
                Size = new Size(245, 26)
            };

            grpMonAn.Controls.Add(checkMonAn[i]);
            checkMonAn[i].CheckedChanged += DuLieuThayDoi;
        }

        btnTinhTien.Text = "Tinh tien";
        btnTinhTien.SetBounds(35, 415, 125, 38);

        btnNhapLai.Text = "Nhap lai";
        btnNhapLai.SetBounds(185, 415, 125, 38);

        btnThanhToan.Text = "Thanh toan";
        btnThanhToan.SetBounds(335, 415, 125, 38);

        btnThoat.Text = "Thoat";
        btnThoat.SetBounds(485, 415, 125, 38);

        Controls.AddRange(new Control[]
        {
            btnTinhTien, btnNhapLai,
            btnThanhToan, btnThoat
        });

        TaoNhan("Tong khach hang:", 35, 490);
        txtTongKhach.SetBounds(220, 485, 350, 28);
        txtTongKhach.ReadOnly = true;
        txtTongKhach.Text = "0";
        Controls.Add(txtTongKhach);

        TaoNhan("Tong tien thanh toan:", 35, 535);
        txtTongTien.SetBounds(220, 530, 350, 28);
        txtTongTien.ReadOnly = true;
        txtTongTien.Text = "0 VND";
        Controls.Add(txtTongTien);

        // Gan su kien
        txtTen.TextChanged += DuLieuThayDoi;
        txtSoKhach.TextChanged += DuLieuThayDoi;
        chkSinhVien.CheckedChanged += DuLieuThayDoi;

        txtSoKhach.KeyPress += ChiNhapSo;

        btnTinhTien.Click += BtnTinhTien_Click;
        btnNhapLai.Click += BtnNhapLai_Click;
        btnThanhToan.Click += BtnThanhToan_Click;
        btnThoat.Click += (s, e) => Close();

        FormClosing += XacNhanThoat;

        // Trang thai khi khoi dong
        btnTinhTien.Enabled = false;
        btnNhapLai.Enabled = false;
        btnThanhToan.Enabled = false;

        ActiveControl = txtTen;
    }

    private void TaoNhan(string noiDung, int x, int y)
    {
        Label lbl = new Label
        {
            Text = noiDung,
            Location = new Point(x, y),
            AutoSize = true
        };

        Controls.Add(lbl);
    }

    private string DinhDangTien(long tien)
    {
        return tien.ToString("N0",
            CultureInfo.GetCultureInfo("vi-VN")) + " VND";
    }

    // Chi cho nhap so khach nguyen duong
    private void ChiNhapSo(object? sender, KeyPressEventArgs e)
    {
        if (!char.IsDigit(e.KeyChar) &&
            !char.IsControl(e.KeyChar))
        {
            e.Handled = true;
        }
    }

    private bool ThongTinHopLe()
    {
        bool tenHopLe =
            !string.IsNullOrWhiteSpace(txtTen.Text);

        bool soKhachHopLe =
            int.TryParse(txtSoKhach.Text, out int soKhach)
            && soKhach > 0;

        bool daChonCafe =
            radioCafe.Any(r => r.Checked);

        return tenHopLe &&
            soKhachHopLe &&
            daChonCafe;
    }

    // Kiem tra khi du lieu thay doi
    private void DuLieuThayDoi(object? sender, EventArgs e)
    {
        daTinhTien = false;
        tienHoaDon = 0;
        soKhachHienTai = 0;

        btnThanhToan.Enabled = false;
        btnNhapLai.Enabled = true;
        btnTinhTien.Enabled = ThongTinHopLe();
    }

    // Tinh tien hoa don
    private void BtnTinhTien_Click(object? sender, EventArgs e)
    {
        if (!ThongTinHopLe())
        {
            MessageBox.Show(
                "Vui long nhap day du thong tin!",
                "Thong bao",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
            return;
        }

        int soKhach = int.Parse(txtSoKhach.Text);

        int giaNuoc = 0;
        int giaThucAn = 0;

        for (int i = 0; i < radioCafe.Length; i++)
        {
            if (radioCafe[i].Checked)
            {
                giaNuoc = giaCafe[i];
                break;
            }
        }

        for (int i = 0; i < checkMonAn.Length; i++)
        {
            if (checkMonAn[i].Checked)
                giaThucAn += giaMonAn[i];
        }

        // Gia dinh moi khach goi cung mot combo
        long thanhTien =
            ((long)giaNuoc + giaThucAn) * soKhach;

        if (chkSinhVien.Checked)
        {
            // Giam 20%, con phai tra 80%
            thanhTien = thanhTien * 80 / 100;
        }

        tienHoaDon = thanhTien;
        soKhachHienTai = soKhach;
        daTinhTien = true;

        string thongBao =
            "HOA DON CAFE SINH VIEN\n\n" +
            "Ten khach: " + txtTen.Text + "\n" +
            "So khach: " + soKhach + "\n" +
            "Tien nuoc/khach: " +
            DinhDangTien(giaNuoc) + "\n" +
            "Tien thuc an/khach: " +
            DinhDangTien(giaThucAn) + "\n" +
            "Giam gia: " +
            (chkSinhVien.Checked ? "20%" : "0%") +
            "\n\nTHANH TIEN: " +
            DinhDangTien(thanhTien);

        MessageBox.Show(
            thongBao,
            "Ket qua tinh tien",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);

        btnTinhTien.Enabled = false;
        btnNhapLai.Enabled = true;
        btnThanhToan.Enabled = true;
    }

    // Xoa du lieu nhap cho luot moi
    private void LamMoiForm()
    {
        txtTen.Clear();
        txtSoKhach.Clear();
        chkSinhVien.Checked = false;

        foreach (RadioButton r in radioCafe)
            r.Checked = false;

        foreach (CheckBox c in checkMonAn)
            c.Checked = false;

        tienHoaDon = 0;
        soKhachHienTai = 0;
        daTinhTien = false;

        btnTinhTien.Enabled = false;
        btnNhapLai.Enabled = false;
        btnThanhToan.Enabled = false;

        txtTen.Focus();
    }

    private void BtnNhapLai_Click(object? sender, EventArgs e)
    {
        LamMoiForm();
    }

    // Ghi nhan thanh toan va cong don
    private void BtnThanhToan_Click(object? sender, EventArgs e)
    {
        if (!daTinhTien)
        {
            MessageBox.Show(
                "Vui long tinh tien truoc!");
            return;
        }

        tongSoKhach += soKhachHienTai;
        tongDoanhThu += tienHoaDon;

        txtTongKhach.Text =
            tongSoKhach.ToString();

        txtTongTien.Text =
            DinhDangTien(tongDoanhThu);

        MessageBox.Show(
            "Thanh toan thanh cong!",
            "Thong bao",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);

        LamMoiForm();
    }

    // Xac nhan truoc khi dong Form
    private void XacNhanThoat(
        object? sender, FormClosingEventArgs e)
    {
        DialogResult kq = MessageBox.Show(
            "Ban co muon thoat chuong trinh?",
            "Xac nhan",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

        if (kq == DialogResult.No)
            e.Cancel = true;
    }
}
