
using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ThucHanh04c;

public class FormBai2 : Form
{
    // Khai bao TextBox
    private TextBox txtTenDangNhap = new TextBox();
    private TextBox txtEmail = new TextBox();
    private TextBox txtMatKhau = new TextBox();
    private TextBox txtXacNhan = new TextBox();

    // Khai bao Button va ErrorProvider
    private Button btnDangKy = new Button();
    private ErrorProvider errorProvider1 = new ErrorProvider();

    public FormBai2()
    {
        // Cai dat Form
        Text = "Dang ky tai khoan";
        ClientSize = new Size(530, 360);
        StartPosition = FormStartPosition.CenterScreen;
        Font = new Font("Arial", 11);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;

        errorProvider1.ContainerControl = this;

        // Tieu de
        Label lblTieuDe = new Label
        {
            Text = "DANG KY TAI KHOAN",
            Location = new Point(125, 20),
            Size = new Size(320, 40),
            Font = new Font("Arial", 17, FontStyle.Bold),
            ForeColor = Color.RoyalBlue
        };
        Controls.Add(lblTieuDe);

        // Ten dang nhap
        Label lblTen = new Label
        {
            Text = "Ten dang nhap:",
            Location = new Point(35, 90),
            AutoSize = true
        };
        Controls.Add(lblTen);

        txtTenDangNhap.Location = new Point(210, 85);
        txtTenDangNhap.Size = new Size(240, 28);
        txtTenDangNhap.MaxLength = 50;
        Controls.Add(txtTenDangNhap);

        // Dia chi email
        Label lblEmail = new Label
        {
            Text = "Dia chi email:",
            Location = new Point(35, 135),
            AutoSize = true
        };
        Controls.Add(lblEmail);

        txtEmail.Location = new Point(210, 130);
        txtEmail.Size = new Size(240, 28);
        Controls.Add(txtEmail);

        // Mat khau
        Label lblMatKhau = new Label
        {
            Text = "Mat khau:",
            Location = new Point(35, 180),
            AutoSize = true
        };
        Controls.Add(lblMatKhau);

        txtMatKhau.Location = new Point(210, 175);
        txtMatKhau.Size = new Size(240, 28);
        txtMatKhau.UseSystemPasswordChar = true;
        Controls.Add(txtMatKhau);

        // Xac nhan mat khau
        Label lblXacNhan = new Label
        {
            Text = "Xac nhan mat khau:",
            Location = new Point(35, 225),
            AutoSize = true
        };
        Controls.Add(lblXacNhan);

        txtXacNhan.Location = new Point(210, 220);
        txtXacNhan.Size = new Size(240, 28);
        txtXacNhan.UseSystemPasswordChar = true;
        Controls.Add(txtXacNhan);

        // Dau (*) cho cac truong bat buoc
        TaoDauSao(465, 90);
        TaoDauSao(465, 135);
        TaoDauSao(465, 180);

        // Nut Dang ky
        btnDangKy.Text = "Dang ky";
        btnDangKy.Location = new Point(210, 280);
        btnDangKy.Size = new Size(150, 40);
        btnDangKy.ForeColor = Color.RoyalBlue;
        btnDangKy.Font =
            new Font("Arial", 11, FontStyle.Bold);
        Controls.Add(btnDangKy);

        // Gan su kien
        btnDangKy.Click += BtnDangKy_Click;
        txtEmail.Leave += TxtEmail_Leave;

        txtXacNhan.KeyDown += TxtXacNhan_KeyDown;

        txtTenDangNhap.TextChanged += XoaLoi;
        txtEmail.TextChanged += XoaLoi;
        txtMatKhau.TextChanged += XoaLoi;
        txtXacNhan.TextChanged += XoaLoi;

        FormClosing += FormBai2_FormClosing;

        // Thu tu Tab
        txtTenDangNhap.TabIndex = 0;
        txtEmail.TabIndex = 1;
        txtMatKhau.TabIndex = 2;
        txtXacNhan.TabIndex = 3;
        btnDangKy.TabIndex = 4;

        ActiveControl = txtTenDangNhap;
    }

    // Tao dau sao mau do
    private void TaoDauSao(int x, int y)
    {
        Label lbl = new Label
        {
            Text = "(*)",
            Location = new Point(x, y),
            AutoSize = true,
            ForeColor = Color.Red
        };

        Controls.Add(lbl);
    }

    // Kiem tra dinh dang Email
    private bool EmailHopLe(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            return false;

        return Regex.IsMatch(
            email,
            @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
    }

    // Su kien khi roi khoi o Email
    private void TxtEmail_Leave(
        object? sender, EventArgs e)
    {
        if (!EmailHopLe(txtEmail.Text.Trim()))
        {
            errorProvider1.SetError(
                txtEmail,
                "Dia chi email khong hop le!");
        }
        else
        {
            errorProvider1.SetError(txtEmail, "");
        }
    }

    // Xoa thong bao loi khi thay doi noi dung
    private void XoaLoi(object? sender, EventArgs e)
    {
        if (sender is Control ctr)
            errorProvider1.SetError(ctr, "");
    }

    // Kiem tra du lieu khi Dang ky
    private bool KiemTraDuLieu()
    {
        errorProvider1.Clear();

        bool hopLe = true;

        // Kiem tra ten dang nhap
        if (string.IsNullOrWhiteSpace(
            txtTenDangNhap.Text))
        {
            errorProvider1.SetError(
                txtTenDangNhap,
                "Vui long nhap ten dang nhap!");
            hopLe = false;
        }

        // Kiem tra Email
        if (!EmailHopLe(txtEmail.Text.Trim()))
        {
            errorProvider1.SetError(
                txtEmail,
                "Email khong hop le!");
            hopLe = false;
        }

        // Kiem tra mat khau
        if (string.IsNullOrWhiteSpace(
            txtMatKhau.Text))
        {
            errorProvider1.SetError(
                txtMatKhau,
                "Vui long nhap mat khau!");
            hopLe = false;
        }

        // Kiem tra xac nhan mat khau
        if (txtXacNhan.Text != txtMatKhau.Text)
        {
            errorProvider1.SetError(
                txtXacNhan,
                "Mat khau xac nhan khong khop!");
            hopLe = false;
        }

        if (!hopLe)
        {
            MessageBox.Show(
                "Vui long kiem tra lai thong tin!",
                "Thong bao loi",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
        }

        return hopLe;
    }

    // Xu ly nut Dang ky
    private void BtnDangKy_Click(
        object? sender, EventArgs e)
    {
        if (!KiemTraDuLieu())
            return;

        string thongTin =
            "THONG TIN DANG KY\n\n" +
            "Ten dang nhap: " +
            txtTenDangNhap.Text + "\n" +
            "Dia chi email: " +
            txtEmail.Text + "\n" +
            "Mat khau: " +
            txtMatKhau.Text + "\n" +
            "Xac nhan mat khau: " +
            txtXacNhan.Text;

        MessageBox.Show(
            thongTin,
            "Dang ky tai khoan",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);
    }

    // Nhan Enter tai o Xac nhan mat khau
    private void TxtXacNhan_KeyDown(
        object? sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            e.SuppressKeyPress = true;
            BtnDangKy_Click(sender, EventArgs.Empty);
        }
    }

    // Xac nhan khi dong Form
    private void FormBai2_FormClosing(
        object? sender, FormClosingEventArgs e)
    {
        DialogResult ketQua = MessageBox.Show(
            "Ban co muon thoat chuong trinh?",
            "Xac nhan thoat",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

        if (ketQua == DialogResult.No)
        {
            e.Cancel = true;
        }
    }

    // Giai phong ErrorProvider
    protected override void Dispose(bool disposing)
    {
        if (disposing)
            errorProvider1.Dispose();

        base.Dispose(disposing);
    }
}
