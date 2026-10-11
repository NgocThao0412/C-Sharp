
using System;
using System.Collections.Generic;
using System.Linq;

namespace ThucHanh04d;

public class MangSoNguyen
{
    private List<int> mang = new List<int>();

    public int SoLuong => mang.Count;

    public void NhapMang(string duLieu)
    {
        string[] cacSo = duLieu.Split(
            new char[] { ' ', ',', ';', '\n', '\t' },
            StringSplitOptions.RemoveEmptyEntries);

        List<int> mangMoi = new List<int>();

        foreach (string chuoi in cacSo)
        {
            if (!int.TryParse(chuoi, out int so))
                throw new ArgumentException(
                    "Mang chi duoc chua so nguyen!");

            mangMoi.Add(so);
        }

        if (mangMoi.Count == 0)
            throw new ArgumentException(
                "Vui long nhap it nhat mot so!");

        mang = mangMoi;
    }

    public string XuatMang()
    {
        return string.Join(" ", mang);
    }

    public void SapXepTang()
    {
        mang.Sort();
    }

    public void SapXepGiam()
    {
        mang.Sort();
        mang.Reverse();
    }

    // Vi tri bat dau tu 1
    public int TimViTri(int giaTri)
    {
        int viTri = mang.IndexOf(giaTri);

        return viTri == -1 ? -1 : viTri + 1;
    }

    public int LayGiaTri(int viTri)
    {
        KiemTraViTri(viTri);
        return mang[viTri - 1];
    }

    public void Them(int giaTri, int viTri)
    {
        if (viTri < 1 || viTri > mang.Count + 1)
            throw new ArgumentException(
                "Vi tri them khong hop le!");

        mang.Insert(viTri - 1, giaTri);
    }

    public void XoaTheoGiaTri(int giaTri)
    {
        if (!mang.Remove(giaTri))
            throw new ArgumentException(
                "Khong tim thay gia tri can xoa!");
    }

    public void XoaTheoViTri(int viTri)
    {
        KiemTraViTri(viTri);
        mang.RemoveAt(viTri - 1);
    }

    public long TongMang()
    {
        return mang.Sum(x => (long)x);
    }

    public long TongChan()
    {
        return mang.Where(x => x % 2 == 0)
                   .Sum(x => (long)x);
    }

    public long TongLe()
    {
        return mang.Where(x => x % 2 != 0)
                   .Sum(x => (long)x);
    }

    public int GiaTriLonNhat()
    {
        KiemTraMangRong();
        return mang.Max();
    }

    public int GiaTriNhoNhat()
    {
        KiemTraMangRong();
        return mang.Min();
    }

    public void ThayTheTheoGiaTri(
        int giaTriCu, int giaTriMoi)
    {
        int viTri = mang.IndexOf(giaTriCu);

        if (viTri == -1)
            throw new ArgumentException(
                "Khong tim thay gia tri can thay!");

        mang[viTri] = giaTriMoi;
    }

    public void ThayTheTheoViTri(
        int viTri, int giaTriMoi)
    {
        KiemTraViTri(viTri);
        mang[viTri - 1] = giaTriMoi;
    }

    private void KiemTraViTri(int viTri)
    {
        if (viTri < 1 || viTri > mang.Count)
            throw new ArgumentException(
                "Vi tri khong hop le!");
    }

    private void KiemTraMangRong()
    {
        if (mang.Count == 0)
            throw new ArgumentException(
                "Mang dang rong!");
    }
}
