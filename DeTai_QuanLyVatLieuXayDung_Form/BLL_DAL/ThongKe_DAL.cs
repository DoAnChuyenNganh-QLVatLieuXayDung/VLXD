using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BLL_DAL
{
    public class ThongKe_DAL
    {
        QL_VatLieuXayDungDataContext db = new QL_VatLieuXayDungDataContext();
        public ThongKe_DAL() { }

        public int tongKH()
        {
            List<KhachHang> danhSachkh = db.KhachHangs.ToList();
            int tongKH = danhSachkh.Count;
            return tongKH;
        }


        public int tongHD()
        {
            List<HoaDon> danhSachHoaDon = db.HoaDons.ToList();
            int tongHD = danhSachHoaDon.Count;
            return tongHD;
        }

        public decimal TongTienHoaDon()
        {
            List<HoaDon> danhSachHoaDon = db.HoaDons.ToList();
            decimal tongTien = 0;
            foreach (var hoaDon in danhSachHoaDon)
            {
                tongTien += (decimal)hoaDon.ThanhTien;
            }

            return tongTien;
        }

        public class MonthlyRevenue
        {
            public int Thang { get; set; }
            public int Nam { get; set; }
            public decimal TongDoanhThu { get; set; }
        }

        public List<MonthlyRevenue> doanhthu()
        {
            var result = new List<MonthlyRevenue>();

            var tongDoanhThuHangThang = db.HoaDons
                .Where(hd => hd.NgayLapHD.HasValue)
                .GroupBy(hd => new { hd.NgayLapHD.Value.Year, hd.NgayLapHD.Value.Month })
                .Select(g => new MonthlyRevenue
                {
                    Thang = g.Key.Month,
                    Nam = g.Key.Year,
                    TongDoanhThu = (decimal)g.Sum(hd => hd.ThanhTien)
                })
                .OrderBy(x => x.Nam)
                .ThenBy(x => x.Thang)
                .ToList();

            result = tongDoanhThuHangThang.ToList();

            return result;
        }


        public class DoanhThuLoiNhuan
        {
            public decimal? DoanhThu { get; set; }
            public decimal? LoiNhuan { get; set; }
        }


        public DoanhThuLoiNhuan TinhDoanhThuVaLoiNhuanTheoNgay(DateTime ngayLapText)
        {
            try
            {
                DateTime ngayLap = ngayLapText.Date;

                var result = (from hd in db.HoaDons
                              join cthd in db.ChiTietHoaDons on hd.MaHD equals cthd.MaHD
                              join sp in db.SanPhams on cthd.MaSP equals sp.MaSP
                              where hd.NgayLapHD.HasValue && hd.NgayLapHD.Value.Date == ngayLap.Date
                              select new
                              {
                                  DoanhThu = hd.ThanhTien,
                                  LoiNhuan = hd.ThanhTien - sp.GiaNhap
                              })
                               .GroupBy(x => 1) 
                               .Select(g => new
                               {
                                   DoanhThu = g.Sum(x => x.DoanhThu),
                                   LoiNhuan = g.Sum(x => x.LoiNhuan)
                               })
                               .FirstOrDefault();

                return new DoanhThuLoiNhuan
                {
                    DoanhThu = result?.DoanhThu ?? 0,
                    LoiNhuan = result?.LoiNhuan ?? 0
                };
            }
            catch
            {
                Console.WriteLine($"Invalid ngayLap: {ngayLapText}");

                return new DoanhThuLoiNhuan { DoanhThu = 0, LoiNhuan = 0 };
            }
        }



        private decimal GetGiaNhap(int maSP)
        {
            var sanPham = db.SanPhams.FirstOrDefault(sp => sp.MaSP == maSP);
            return sanPham != null ? (Decimal)sanPham.GiaNhap : 0;
        }


        public class ThongKeDoanhThu
        {
            public DateTime Ngay { get; set; }
            public decimal DoanhThu { get; set; }
            public decimal TienLoi { get; set; }
        }

        public List<ThongKeDoanhThu> ThongKeDoanhThuTheoNgay()
        {
            var resultList = (from hd in db.HoaDons
                              join cthd in db.ChiTietHoaDons on hd.MaHD equals cthd.MaHD
                              let ls = (from lsGia in db.LichSuGias
                                        where cthd.MaSP == lsGia.MaSP && hd.NgayLapHD >= lsGia.NgayCapNhat
                                        orderby lsGia.NgayCapNhat descending
                                        select lsGia.Gia).FirstOrDefault()
                              let lsCuoiCung = (from lsGia in db.LichSuGias
                                                where cthd.MaSP == lsGia.MaSP
                                                orderby lsGia.NgayCapNhat descending
                                                select lsGia.Gia).FirstOrDefault()
                              where hd.TrangThai == true
                              group new { hd.NgayLapHD, cthd.ThanhTien, cthd.SoLuong, ls, lsCuoiCung } by hd.NgayLapHD into g
                              select new ThongKeDoanhThu
                              {
                                  Ngay = (DateTime)g.Key,
                                  DoanhThu = (decimal)g.Sum(x => x.ThanhTien),
                                  TienLoi = (decimal)g.Sum(x => x.ThanhTien - x.ls * x.SoLuong)
                              }).ToList();

            return resultList;
        }



        public List<ThongKeDoanhThu> ThongKeDoanhThuTheoNgay_BD_KT(DateTime startDate, DateTime endDate)
        {
            var resultList = (from hd in db.HoaDons
                              join cthd in db.ChiTietHoaDons on hd.MaHD equals cthd.MaHD
                              let ls = (from lsGia in db.LichSuGias
                                        where cthd.MaSP == lsGia.MaSP && hd.NgayLapHD >= lsGia.NgayCapNhat
                                        orderby lsGia.NgayCapNhat descending
                                        select lsGia.Gia).FirstOrDefault()
                              let lsCuoiCung = (from lsGia in db.LichSuGias
                                                where cthd.MaSP == lsGia.MaSP
                                                orderby lsGia.NgayCapNhat descending
                                                select lsGia.Gia).FirstOrDefault()
                              where hd.TrangThai == true && hd.NgayLapHD >= startDate && hd.NgayLapHD <= endDate
                              group new { hd.NgayLapHD, cthd.ThanhTien, cthd.SoLuong, ls, lsCuoiCung } by hd.NgayLapHD into g
                              select new ThongKeDoanhThu
                              {
                                  Ngay = (DateTime)g.Key,
                                  DoanhThu = (decimal)g.Sum(x => x.ThanhTien),
                                  TienLoi = (decimal)g.Sum(x => x.ThanhTien - x.ls * x.SoLuong)
                              }).ToList();

            return resultList;
        }


        public class TopSanPham
        {
            public int MaSP { get; set; }
            public string TenSP { get; set; }
            public int SoLuongBan { get; set; }
        }


        public List<TopSanPham> Top5SanPhamBanChay(DateTime startDate, DateTime endDate)
        {
            var resultList = (from cthd in db.ChiTietHoaDons
                              join sp in db.SanPhams on cthd.MaSP equals sp.MaSP
                              join hd in db.HoaDons on cthd.MaHD equals hd.MaHD
                              where hd.NgayLapHD >= startDate && hd.NgayLapHD <= endDate && hd.TrangThai == true
                              group new { cthd.MaSP, sp.TenSP, cthd.SoLuong } by new { cthd.MaSP, sp.TenSP } into g
                              orderby g.Sum(x => x.SoLuong) descending
                              select new TopSanPham
                              {
                                  MaSP = g.Key.MaSP,
                                  TenSP = g.Key.TenSP,
                                  SoLuongBan = (int)g.Sum(x => x.SoLuong)
                              }).Take(5).ToList();

            return resultList;
        }



    }
}
