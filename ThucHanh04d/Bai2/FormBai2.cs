
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ThucHanh04d;

public class FormBai2 : Form
{
    private MangSoNguyen mang = new MangSoNguyen();

    private TextBox txtNhap = new TextBox();
    private TextBox txtKetQua = new TextBox();

    private TextBox txtTim = new TextBox();
    private TextBox txtXoa = new TextBox();
    private TextBox txtThem = new TextBox();
    private TextBox txtViTriThem = new TextBox();

    private TextBox txtThay = new TextBox();
    private TextBox txtSoMoi = new TextBox();

    private TextBox txtTong = new TextBox();
    private TextBox txtChan = new TextBox();
    private TextBox txtLe = new TextBox();
    private TextBox txtMax = new TextBox();
    private TextBox txtMin = new TextBox();

    private RadioButton rdoTang = new RadioButton();
    private RadioButton rdoGiam = new RadioButton();

    private RadioButton rdoTimGiaTri = new RadioButton();
    private RadioButton rdoTimViTri = new RadioButton();

    private RadioButton rdoXoaGiaTri = new RadioButton();
    private RadioButton rdoXoaViTri = new RadioButton();

    private RadioButton rdoThayGiaTri = new RadioButton();
    private RadioButton rdoThayViTri = new RadioButton();

    public FormBai2()
    {
        Text = "Bai 2 - Mang So Nguyen";
        ClientSize = new Size(840, 760);
        StartPosition = FormStartPosition.CenterScreen;
        Font = new Font("Arial", 10);
        AutoScroll = true;

        Label tieuDe = new Label
        {
            Text = "MANG SO NGUYEN",
            Location = new Point(285, 15),
            Size = new Size(350, 40),
            Font = new Font("Arial", 20, FontStyle.Bold),
            ForeColor = Color.Red
        };
        Controls.Add(tieuDe);

        TaoNhan("Nhap mang:", 30, 75);
        txtNhap.SetBounds(150, 70, 470, 28);
        Controls.Add(txtNhap);

        TaoNut("Nhap", 640, 68, 85, 32, NhapMang);
        TaoNut("Reset", 735, 68, 85, 32, ResetMang);

        TaoNhan("Ket qua mang:", 30, 115);
        txtKetQua.SetBounds(150, 110, 470, 28);
        txtKetQua.ReadOnly = true;
        Controls.Add(txtKetQua);

        TaoNut("Thoat", 640, 108, 180, 32,
            (s, e) => Close());

        // Sap xep
        GroupBox grpSapXep = TaoNhom(
            "Sap xep", 30, 155, 780, 85);

        rdoTang.Text = "Sap xep tang";
        rdoTang.SetBounds(20, 30, 150, 28);
        rdoTang.Checked = true;

        rdoGiam.Text = "Sap xep giam";
        rdoGiam.SetBounds(200, 30, 150, 28);

        grpSapXep.Controls.AddRange(
            new Control[] { rdoTang, rdoGiam });

        TaoNut("Thuc hien", 620, 30, 130, 32,
            SapXep, grpSapXep);

        // Tim kiem
        GroupBox grpTim = TaoNhom(
            "Tim kiem", 30, 250, 375, 130);

        rdoTimGiaTri.Text = "Tim gia tri";
        rdoTimGiaTri.SetBounds(15, 30, 130, 28);
        rdoTimGiaTri.Checked = true;

        rdoTimViTri.Text = "Tim vi tri";
        rdoTimViTri.SetBounds(15, 65, 130, 28);

        txtTim.SetBounds(155, 48, 90, 28);

        grpTim.Controls.AddRange(new Control[]
        {
            rdoTimGiaTri, rdoTimViTri, txtTim
        });

        TaoNut("Tim", 265, 45, 85, 32,
            TimKiem, grpTim);

        // Xoa
        GroupBox grpXoa = TaoNhom(
            "Xoa", 435, 250, 375, 130);

        rdoXoaGiaTri.Text = "Xoa theo gia tri";
        rdoXoaGiaTri.SetBounds(15, 30, 150, 28);
        rdoXoaGiaTri.Checked = true;

        rdoXoaViTri.Text = "Xoa theo vi tri";
        rdoXoaViTri.SetBounds(15, 65, 150, 28);

        txtXoa.SetBounds(170, 48, 90, 28);

        grpXoa.Controls.AddRange(new Control[]
        {
            rdoXoaGiaTri, rdoXoaViTri, txtXoa
        });

        TaoNut("Xoa", 275, 45, 80, 32,
            XoaPhanTu, grpXoa);

        // Them
        GroupBox grpThem = TaoNhom(
            "Them phan tu", 30, 390, 375, 140);

        TaoNhanTrongNhom(
            grpThem, "Gia tri them:", 15, 35);
        txtThem.SetBounds(165, 30, 120, 28);

        TaoNhanTrongNhom(
            grpThem, "Vi tri them:", 15, 75);
        txtViTriThem.SetBounds(165, 70, 120, 28);

        grpThem.Controls.Add(txtThem);
        grpThem.Controls.Add(txtViTriThem);

        TaoNut("Them", 290, 95, 75, 32,
            ThemPhanTu, grpThem);

        // Tong
        GroupBox grpTong = TaoNhom(
            "Tong", 435, 390, 375, 140);

        TaoNhanTrongNhom(grpTong, "Tong mang:", 10, 30);
        TaoNhanTrongNhom(grpTong, "Tong chan:", 10, 65);
        TaoNhanTrongNhom(grpTong, "Tong le:", 10, 100);

        txtTong.SetBounds(130, 25, 115, 25);
        txtChan.SetBounds(130, 60, 115, 25);
        txtLe.SetBounds(130, 95, 115, 25);

        txtTong.ReadOnly = true;
        txtChan.ReadOnly = true;
        txtLe.ReadOnly = true;

        grpTong.Controls.AddRange(new Control[]
        {
            txtTong, txtChan, txtLe
        });

        TaoNut("Tinh tong", 260, 50, 105, 40,
            TinhTong, grpTong);

        // Max Min
        GroupBox grpMaxMin = TaoNhom(
            "Max - Min", 30, 540, 375, 130);

        TaoNhanTrongNhom(
            grpMaxMin, "Gia tri lon nhat:", 10, 30);
        TaoNhanTrongNhom(
            grpMaxMin, "Gia tri nho nhat:", 10, 70);

        txtMax.SetBounds(165, 25, 95, 28);
        txtMin.SetBounds(165, 65, 95, 28);

        txtMax.ReadOnly = true;
        txtMin.ReadOnly = true;

        grpMaxMin.Controls.Add(txtMax);
        grpMaxMin.Controls.Add(txtMin);

        TaoNut("Tim", 275, 45, 85, 35,
            TimMaxMin, grpMaxMin);

        // Thay the
        GroupBox grpThay = TaoNhom(
            "Thay the", 435, 540, 375, 175);

        rdoThayGiaTri.Text = "Theo gia tri";
        rdoThayGiaTri.SetBounds(10, 25, 130, 28);
        rdoThayGiaTri.Checked = true;

        rdoThayViTri.Text = "Theo vi tri";
        rdoThayViTri.SetBounds(10, 60, 130, 28);

        txtThay.SetBounds(160, 40, 100, 28);

        TaoNhanTrongNhom(
            grpThay, "So thay the:", 10, 105);
        txtSoMoi.SetBounds(160, 100, 100, 28);

        grpThay.Controls.AddRange(new Control[]
        {
            rdoThayGiaTri, rdoThayViTri,
            txtThay, txtSoMoi
        });

        TaoNut("Thay", 275, 95, 85, 35,
            ThayThe, grpThay);

        FormClosing += XacNhanThoat;
    }

    // Tao cac Control dung chung
    private void TaoNhan(string text, int x, int y)
    {
        Controls.Add(new Label
        {
            Text = text,
            Location = new Point(x, y),
            AutoSize = true
        });
    }

    private void TaoNhanTrongNhom(
        GroupBox nhom, string text, int x, int y)
    {
        nhom.Controls.Add(new Label
        {
            Text = text,
            Location = new Point(x, y),
            AutoSize = true
        });
    }

    private GroupBox TaoNhom(
        string ten, int x, int y, int rong, int cao)
    {
        GroupBox nhom = new GroupBox
        {
            Text = ten,
            Location = new Point(x, y),
            Size = new Size(rong, cao)
        };

        Controls.Add(nhom);
        return nhom;
    }

    private void TaoNut(
        string ten, int x, int y,
        int rong, int cao,
        EventHandler suKien,
        Control? cha = null)
    {
        Button btn = new Button
        {
            Text = ten,
            Location = new Point(x, y),
            Size = new Size(rong, cao)
        };

        btn.Click += suKien;

        (cha ?? this).Controls.Add(btn);
    }

    // Hien thi loi
    private void BaoLoi(string thongBao)
    {
        MessageBox.Show(
            thongBao, "Thong bao",
            MessageBoxButtons.OK,
            MessageBoxIcon.Warning);
    }

    // Kiem tra so nguyen
    private int DocSo(TextBox txt)
    {
        if (!int.TryParse(txt.Text.Trim(), out int so))
            throw new ArgumentException(
                "Vui long nhap so nguyen hop le!");

        return so;
    }

    // Dung chung de bat loi
    private void ThucHienAnToan(Action hanhDong)
    {
        try
        {
            hanhDong();
        }
        catch (ArgumentException ex)
        {
            BaoLoi(ex.Message);
        }
        catch (OverflowException)
        {
            BaoLoi("Gia tri vuot qua gioi han cho phep!");
        }
    }

    private void CapNhatMang()
    {
        txtKetQua.Text = mang.XuatMang();

        txtTong.Clear();
        txtChan.Clear();
        txtLe.Clear();
        txtMax.Clear();
        txtMin.Clear();
    }

    // Nhap mang
    private void NhapMang(object? sender, EventArgs e)
    {
        ThucHienAnToan(() =>
        {
            mang.NhapMang(txtNhap.Text);
            CapNhatMang();
        });
    }

    // Sap xep
    private void SapXep(object? sender, EventArgs e)
    {
        ThucHienAnToan(() =>
        {
            if (rdoTang.Checked)
                mang.SapXepTang();
            else
                mang.SapXepGiam();

            CapNhatMang();
        });
    }

    // Tim kiem
    private void TimKiem(object? sender, EventArgs e)
    {
        ThucHienAnToan(() =>
        {
            int so = DocSo(txtTim);

            if (rdoTimGiaTri.Checked)
            {
                int viTri = mang.TimViTri(so);

                if (viTri == -1)
                    BaoLoi("Khong tim thay gia tri!");
                else
                    MessageBox.Show(
                        "Gia tri nam o vi tri: " + viTri);
            }
            else
            {
                int giaTri = mang.LayGiaTri(so);

                MessageBox.Show(
                    "Gia tri tai vi tri " + so +
                    " la: " + giaTri);
            }
        });
    }

    // Xoa phan tu
    private void XoaPhanTu(object? sender, EventArgs e)
    {
        ThucHienAnToan(() =>
        {
            int so = DocSo(txtXoa);

            if (rdoXoaGiaTri.Checked)
                mang.XoaTheoGiaTri(so);
            else
                mang.XoaTheoViTri(so);

            CapNhatMang();
        });
    }

    // Them phan tu
    private void ThemPhanTu(object? sender, EventArgs e)
    {
        ThucHienAnToan(() =>
        {
            int giaTri = DocSo(txtThem);
            int viTri = DocSo(txtViTriThem);

            mang.Them(giaTri, viTri);
            CapNhatMang();
        });
    }

    // Tinh tong
    private void TinhTong(object? sender, EventArgs e)
    {
        ThucHienAnToan(() =>
        {
            if (mang.SoLuong == 0)
                throw new ArgumentException(
                    "Vui long nhap mang truoc!");

            txtTong.Text = mang.TongMang().ToString();
            txtChan.Text = mang.TongChan().ToString();
            txtLe.Text = mang.TongLe().ToString();
        });
    }

    // Tim Max Min
    private void TimMaxMin(object? sender, EventArgs e)
    {
        ThucHienAnToan(() =>
        {
            txtMax.Text =
                mang.GiaTriLonNhat().ToString();

            txtMin.Text =
                mang.GiaTriNhoNhat().ToString();
        });
    }

    // Thay the
    private void ThayThe(object? sender, EventArgs e)
    {
        ThucHienAnToan(() =>
        {
            int soCanThay = DocSo(txtThay);
            int soMoi = DocSo(txtSoMoi);

            if (rdoThayGiaTri.Checked)
                mang.ThayTheTheoGiaTri(
                    soCanThay, soMoi);
            else
                mang.ThayTheTheoViTri(
                    soCanThay, soMoi);

            CapNhatMang();
        });
    }

    // Reset
    private void ResetMang(object? sender, EventArgs e)
    {
        mang = new MangSoNguyen();

        txtNhap.Clear();
        txtKetQua.Clear();
        txtTim.Clear();
        txtXoa.Clear();
        txtThem.Clear();
        txtViTriThem.Clear();
        txtThay.Clear();
        txtSoMoi.Clear();

        txtTong.Clear();
        txtChan.Clear();
        txtLe.Clear();
        txtMax.Clear();
        txtMin.Clear();

        rdoTang.Checked = true;
        rdoTimGiaTri.Checked = true;
        rdoXoaGiaTri.Checked = true;
        rdoThayGiaTri.Checked = true;

        txtNhap.Focus();
    }

    // Xac nhan dong Form
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
