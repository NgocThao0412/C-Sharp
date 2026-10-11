
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace ThucHanh05d;

public class FormQuanLyLop : Form
{
    private TextBox txtMaKhoa = new();
    private TextBox txtMaLop = new();
    private TextBox txtTenLop = new();

    private ListView lvLop = new();

    private Button btnThem = new();
    private Button btnXoa = new();
    private Button btnSua = new();
    private Button btnLamMoi = new();
    private Button btnTaiLai = new();
    private Button btnThoat = new();

    // Cau hinh SQL Server cua may ban.
    // Co the dat bien moi truong QLSINHVIEN_CONNECTION
    // thay vi ghi thong tin dang nhap vao GitHub.
    private readonly string chuoiKetNoi =
        Environment.GetEnvironmentVariable(
            "QLSINHVIEN_CONNECTION")
        ?? @"Server=localhost\SQLEXPRESS;
             Database=QLSinhVien;
             Integrated Security=True;
             TrustServerCertificate=True;";

    public FormQuanLyLop()
    {
        Text = "Lab 05d - Quan ly Lop";
        ClientSize = new Size(760, 520);
        StartPosition = FormStartPosition.CenterScreen;
        Font = new Font("Arial", 11);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;

        Label tieuDe = new()
        {
            Text = "QUAN LY LOP",
            Location = new Point(250, 20),
            Size = new Size(340, 45),
            Font = new Font("Arial", 22, FontStyle.Bold),
            ForeColor = Color.RoyalBlue
        };
        Controls.Add(tieuDe);

        TaoNhan("Ma khoa:", 40, 90);
        TaoNhan("Ma lop:", 40, 135);
        TaoNhan("Ten lop:", 40, 180);

        txtMaKhoa.SetBounds(175, 85, 330, 30);
        txtMaLop.SetBounds(175, 130, 330, 30);
        txtTenLop.SetBounds(175, 175, 330, 30);

        txtMaKhoa.MaxLength = 20;
        txtMaLop.MaxLength = 20;
        txtTenLop.MaxLength = 100;

        Controls.AddRange(new Control[]
        {
            txtMaKhoa, txtMaLop, txtTenLop
        });

        btnThem.Text = "Them";
        btnThem.SetBounds(40, 235, 105, 36);

        btnXoa.Text = "Xoa";
        btnXoa.SetBounds(157, 235, 105, 36);

        btnSua.Text = "Sua";
        btnSua.SetBounds(274, 235, 105, 36);

        btnLamMoi.Text = "Lam moi";
        btnLamMoi.SetBounds(391, 235, 105, 36);

        btnTaiLai.Text = "Tai lai";
        btnTaiLai.SetBounds(508, 235, 105, 36);

        btnThoat.Text = "Thoat";
        btnThoat.SetBounds(625, 235, 95, 36);

        Controls.AddRange(new Control[]
        {
            btnThem, btnXoa, btnSua,
            btnLamMoi, btnTaiLai, btnThoat
        });

        // Bang hien thi danh sach lop
        lvLop.SetBounds(40, 295, 680, 195);
        lvLop.View = View.Details;
        lvLop.FullRowSelect = true;
        lvLop.GridLines = true;
        lvLop.MultiSelect = false;

        lvLop.Columns.Add("Ma lop", 170);
        lvLop.Columns.Add("Ten lop", 300);
        lvLop.Columns.Add("Ma khoa", 185);

        Controls.Add(lvLop);

        // Gan cac su kien
        btnThem.Click += BtnThem_Click;
        btnXoa.Click += BtnXoa_Click;
        btnSua.Click += BtnSua_Click;
        btnLamMoi.Click += (s, e) => LamMoi();
        btnTaiLai.Click += (s, e) => TaiDanhSach();
        btnThoat.Click += (s, e) => Close();

        lvLop.SelectedIndexChanged += ChonLop;
        FormClosing += XacNhanThoat;

        Shown += (s, e) =>
        {
            TaiDanhSach();
            txtMaKhoa.Focus();
        };
    }

    private void TaoNhan(string noiDung, int x, int y)
    {
        Controls.Add(new Label
        {
            Text = noiDung,
            Location = new Point(x, y),
            AutoSize = true
        });
    }

    private void ThongBao(string noiDung)
    {
        MessageBox.Show(
            noiDung,
            "Thong bao",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);
    }

    // Thuc thi cau lenh Insert, Update, Delete
    private int ThucThi(
        string sql,
        string maLop,
        string? maKhoa = null,
        string? tenLop = null)
    {
        using SqlConnection conn =
            new SqlConnection(chuoiKetNoi);

        using SqlCommand cmd =
            new SqlCommand(sql, conn);

        cmd.Parameters.Add(
            "@MaLop", SqlDbType.VarChar, 20)
            .Value = maLop;

        cmd.Parameters.Add(
            "@MaKhoa", SqlDbType.VarChar, 20)
            .Value = (object?)maKhoa ?? DBNull.Value;

        cmd.Parameters.Add(
            "@TenLop", SqlDbType.NVarChar, 100)
            .Value = (object?)tenLop ?? DBNull.Value;

        conn.Open();

        return cmd.ExecuteNonQuery();
    }

    // THEM LOP
    private void BtnThem_Click(object? sender, EventArgs e)
    {
        string maKhoa = txtMaKhoa.Text.Trim();
        string maLop = txtMaLop.Text.Trim();
        string tenLop = txtTenLop.Text.Trim();

        if (maKhoa == "" || maLop == "" || tenLop == "")
        {
            ThongBao(
                "Phai nhap du Ma khoa, Ma lop, Ten lop!");
            return;
        }

        string sql = @"
            INSERT INTO Lop (MaLop, TenLop, MaKhoa)
            VALUES (@MaLop, @TenLop, @MaKhoa)";

        try
        {
            ThucThi(sql, maLop, maKhoa, tenLop);
            ThongBao("Them lop thanh cong!");
            TaiDanhSach();
            LamMoi();
        }
        catch (SqlException ex)
        {
            ThongBao("Khong the them lop: " + ex.Message);
        }
        catch (InvalidOperationException ex)
        {
            ThongBao("Loi ket noi: " + ex.Message);
        }
    }

    // XOA LOP
    private void BtnXoa_Click(object? sender, EventArgs e)
    {
        string maLop = txtMaLop.Text.Trim();

        if (maLop == "")
        {
            ThongBao("Vui long nhap Ma lop!");
            return;
        }

        if (txtMaKhoa.Text.Trim() != "" ||
            txtTenLop.Text.Trim() != "")
        {
            ThongBao(
                "Khi xoa chi nhap Ma lop!");
            return;
        }

        DialogResult xacNhan = MessageBox.Show(
            "Ban co chac muon xoa lop nay?",
            "Xac nhan xoa",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

        if (xacNhan != DialogResult.Yes)
            return;

        try
        {
            int soDong = ThucThi(
                "DELETE FROM Lop WHERE MaLop = @MaLop",
                maLop);

            ThongBao(soDong > 0
                ? "Xoa lop thanh cong!"
                : "Khong tim thay Ma lop!");

            TaiDanhSach();
            LamMoi();
        }
        catch (SqlException ex)
        {
            ThongBao("Khong the xoa lop: " + ex.Message);
        }
        catch (InvalidOperationException ex)
        {
            ThongBao("Loi ket noi: " + ex.Message);
        }
    }

    // SUA LOP
    private void BtnSua_Click(object? sender, EventArgs e)
    {
        string maLop = txtMaLop.Text.Trim();
        string maKhoa = txtMaKhoa.Text.Trim();
        string tenLop = txtTenLop.Text.Trim();

        if (maLop == "")
        {
            ThongBao("Ma lop khong duoc de trong!");
            return;
        }

        if (maKhoa == "" && tenLop == "")
        {
            ThongBao(
                "Phai nhap Ma khoa hoac Ten lop de sua!");
            return;
        }

        string sql = @"
            UPDATE Lop
            SET
                MaKhoa = COALESCE(
                    NULLIF(@MaKhoa, ''), MaKhoa),
                TenLop = COALESCE(
                    NULLIF(@TenLop, N''), TenLop)
            WHERE MaLop = @MaLop";

        try
        {
            int soDong = ThucThi(
                sql, maLop, maKhoa, tenLop);

            ThongBao(soDong > 0
                ? "Sua lop thanh cong!"
                : "Khong tim thay Ma lop!");

            TaiDanhSach();
            LamMoi();
        }
        catch (SqlException ex)
        {
            ThongBao("Khong the sua lop: " + ex.Message);
        }
        catch (InvalidOperationException ex)
        {
            ThongBao("Loi ket noi: " + ex.Message);
        }
    }

    // TAI DANH SACH LOP
    private void TaiDanhSach()
    {
        try
        {
            using SqlConnection conn =
                new SqlConnection(chuoiKetNoi);

            using SqlCommand cmd = new SqlCommand(
                "SELECT MaLop, TenLop, MaKhoa " +
                "FROM Lop ORDER BY MaLop", conn);

            conn.Open();

            using SqlDataReader reader =
                cmd.ExecuteReader();

            lvLop.Items.Clear();

            while (reader.Read())
            {
                ListViewItem item = new ListViewItem(
                    reader["MaLop"].ToString());

                item.SubItems.Add(
                    reader["TenLop"].ToString());

                item.SubItems.Add(
                    reader["MaKhoa"].ToString());

                lvLop.Items.Add(item);
            }
        }
        catch (SqlException ex)
        {
            ThongBao(
                "Khong tai duoc du lieu: " + ex.Message);
        }
        catch (InvalidOperationException ex)
        {
            ThongBao("Loi ket noi: " + ex.Message);
        }
    }

    // CHON LOP TREN LISTVIEW
    private void ChonLop(
        object? sender, EventArgs e)
    {
        if (lvLop.SelectedItems.Count == 0)
            return;

        ListViewItem item = lvLop.SelectedItems[0];

        txtMaLop.Text = item.SubItems[0].Text;
        txtTenLop.Text = item.SubItems[1].Text;
        txtMaKhoa.Text = item.SubItems[2].Text;
    }

    // LAM MOI
    private void LamMoi()
    {
        txtMaKhoa.Clear();
        txtMaLop.Clear();
        txtTenLop.Clear();
        lvLop.SelectedItems.Clear();
        txtMaKhoa.Focus();
    }

    // XAC NHAN THOAT
    private void XacNhanThoat(
        object? sender, FormClosingEventArgs e)
    {
        DialogResult ketQua = MessageBox.Show(
            "Ban co muon thoat chuong trinh?",
            "Xac nhan thoat",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

        if (ketQua == DialogResult.No)
            e.Cancel = true;
    }
}
