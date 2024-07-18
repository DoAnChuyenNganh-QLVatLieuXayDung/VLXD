using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAL
{
    public class LichSuMuaHang_DAL
    {
        QL_VatLieuXayDungDataContext db = new QL_VatLieuXayDungDataContext();
        public LichSuMuaHang_DAL() { }
     
        public List<KhachHang> loadKH()
        {

            return db.KhachHangs.ToList();
        }
        public List<HoaDon> loadHD(int makh)
        {
            List<HoaDon> danhSachHoaDon = db.HoaDons.Where(kh => kh.MaKH == makh).ToList();
            return danhSachHoaDon;
        }

        public List<KhachHang> searchTen(string ten)
        {
            List<KhachHang> danhSachKhachHang = db.KhachHangs
                .Where(kh => kh.TenKH.Contains(ten))
                .ToList();
            return danhSachKhachHang;

        }
        public List<KhachHang> searchSDT(string sdt)
        {
            List<KhachHang> danhSachKhachHang = db.KhachHangs
                .Where(kh => kh.SDT.ToString().Contains(sdt))
                .ToList();
            return danhSachKhachHang;
        }


        public List<KhachHang> searchGiotTinh(string gt)
        {
            List<KhachHang> danhSachKhachHang = db.KhachHangs
                .Where(kh => kh.Phai.Contains(gt))
                .ToList();
            return danhSachKhachHang;

        }
        public int tongHD(int makh)
        {
            List<HoaDon> danhSachHoaDon = db.HoaDons.Where(hd => hd.MaKH == makh).ToList();

            int tongHD = danhSachHoaDon.Count;

            return tongHD;
        }

        public decimal TongTienHoaDon(int maKhachHang)
        {
            List<HoaDon> danhSachHoaDon = db.HoaDons.Where(hd => hd.MaKH == maKhachHang).ToList();

            decimal tongTien = 0;
            foreach (var hoaDon in danhSachHoaDon)
            {
                tongTien += (decimal)hoaDon.ThanhTien; 
            }

            return tongTien;
        }
    }
}
