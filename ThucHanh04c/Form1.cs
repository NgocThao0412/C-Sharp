
namespace ThucHanh04c;

public partial class Form1 : Form
{
    List<int> daySo = new List<int>();

    public Form1()
    {
        InitializeComponent();

        btnNhap.Click += btnNhap_Click;
        btnTinhTong.Click += btnTinhTong_Click;
        btnTongChan.Click += btnTongChan_Click;
        btnTongLe.Click += btnTongLe_Click;
        btnTiepTuc.Click += btnTiepTuc_Click;
        btnThoat.Click += btnThoat_Click;
    }

    private void btnNhap_Click(object? sender, EventArgs e)
    {
        if (!int.TryParse(txtNhapSo.Text, out int so))
        {
            MessageBox.Show("Vui lòng nhập số nguyên!");
            return;
        }

        daySo.Add(so);
        txtDaySo.Text = string.Join(" ", daySo);
        txtNhapSo.Clear();
        txtNhapSo.Focus();
    }

    private void btnTinhTong_Click(object? sender, EventArgs e)
    {
        long tong = 0;
        foreach (int so in daySo)
            tong += so;

        txtTong.Text = tong.ToString();
    }

    private void btnTongChan_Click(object? sender, EventArgs e)
    {
        long tong = 0;
        foreach (int so in daySo)
            if (so % 2 == 0)
                tong += so;

        txtTongChan.Text = tong.ToString();
    }

    private void btnTongLe_Click(object? sender, EventArgs e)
    {
        long tong = 0;
        foreach (int so in daySo)
            if (so % 2 != 0)
                tong += so;

        txtTongLe.Text = tong.ToString();
    }

    private void btnTiepTuc_Click(object? sender, EventArgs e)
    {
        daySo.Clear();
        txtNhapSo.Clear();
        txtDaySo.Clear();
        txtTong.Clear();
        txtTongChan.Clear();
        txtTongLe.Clear();
        txtNhapSo.Focus();
    }

    private void btnThoat_Click(object? sender, EventArgs e)
    {
        DialogResult kq = MessageBox.Show(
            "Bạn có muốn thoát?",
            "Xác nhận",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

        if (kq == DialogResult.Yes)
            Close();
    }
}
