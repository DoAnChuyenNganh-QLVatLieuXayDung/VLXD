using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BLL_DAL
{
    public class HoaDon_DAL
    {
        QL_VatLieuXayDungDataContext db = new QL_VatLieuXayDungDataContext();
        public HoaDon_DAL() { }

        public List<HoaDon> load(int makh)
        {
            return db.HoaDons.Where(p=>p.MaKH==makh && p.TrangThai==false).ToList();


        }
        public List<HoaDon> load()
        {

            DateTime currentDate = DateTime.Now;

            return db.HoaDons.Where(p => p.TrangThai == false && p.NgayLapHD <= currentDate)
                                   .OrderByDescending(p => p.NgayLapHD)
                                   .ToList();
        }
        public List<int> load_maPhieu()
        {
      
            return db.HoaDons.Select(p => p.MaHD).Distinct().OrderByDescending(ma => ma).ToList();
        }
        public string lay_SDt(int mahd)
        {
            return db.HoaDons.Where(p=>p.MaHD==mahd).Select(p=>p.SDT).FirstOrDefault().ToString();
        }

        public Boolean update(int mahd)
        {
  
            HoaDon hd=db.HoaDons.Where(p=>p.MaHD==mahd).FirstOrDefault();
            if (hd != null)
            {
                hd.TrangThai = true;
                db.SubmitChanges();
                return true;
            }
            return false;
        }
        public Boolean update_trangthaidonhang(int mahd,string trangthai)
        {

            HoaDon hd = db.HoaDons.Where(p => p.MaHD == mahd).FirstOrDefault();
            if (hd != null)
            {
                hd.TrangThaiDonHang = trangthai;
                db.SubmitChanges();
                return true;
            }
            return false;
        }
        public string lay_trangthaidonhang(int madh)
        {
            var kq=db.HoaDons.Where(p=>p.MaHD==madh).Select(p => p.TrangThaiDonHang).FirstOrDefault();
            if (kq != null)
            {
                return kq.ToString();
            }
            else
                return "Trống";
        }

        public List<LichSuHoatDong> insertLS(string user, DateTime ngay, string hoatdong, string trangthai)
        {
            LichSuHoatDong ls = new LichSuHoatDong();

            ls.UserName = user;
            ls.ThoiGian = ngay;
            ls.HoatDong = hoatdong;
            ls.TrangThai = trangthai;

            db.LichSuHoatDongs.InsertOnSubmit(ls);
            db.SubmitChanges();
            return db.LichSuHoatDongs.ToList();

        }

       public bool insert_hoadon(KhachHang kh)
       {
            HoaDon hd = new HoaDon();
            hd.MaKH = kh.MaKH;
            hd.NgayLapHD=DateTime.Now;
            hd.TenNguoiNhan = kh.TenKH;
            hd.SDT = kh.SDT;
            hd.DiaChi = kh.DiaChi;
            hd.Email = kh.Email;
            hd.ThanhTien = 0;
            hd.TienCoc = 0;
            db.HoaDons.InsertOnSubmit(hd);
            db.SubmitChanges();
            return true;

       }
        public int LayHoaDonVuaTao()
        {
            var maHoaDonVuaTao = db.HoaDons
                                  .OrderByDescending(hd => hd.MaHD)
                                  .Select(hd => hd.MaHD)
                                  .FirstOrDefault();

            return maHoaDonVuaTao;
        }

        public Boolean update_hoadon_thanhtoantaiquay(HoaDon hd)
        {
            HoaDon hoadon = db.HoaDons.Where(p => p.MaHD == hd.MaHD).FirstOrDefault();
            if (hd != null)
            {
                hoadon.ThanhTien= hd.ThanhTien;
                hoadon.TienCoc = hd.TienCoc;
                hoadon.MaKhuyenMai = hd.MaKhuyenMai;
                hoadon.TrangThai = hd.TrangThai;
                hoadon.TrangThaiDonHang = hd.TrangThaiDonHang;
                db.SubmitChanges();
                return true;
            }
            return false;
        }


        public List<DateTime> LayDanhSachNgayLap()
        {
            return db.HoaDons.Select(p => p.NgayLapHD.Value).Distinct().ToList();

        }

        public List<HoaDon> tim_hoaDon_ngaythangnam(DateTime ngaythangnam)
        {
            List<DateTime> list = LayDanhSachNgayLap();
            DateTime date = new DateTime();
            List<HoaDon> kq= new List<HoaDon>();
            foreach (DateTime s in list)
            {
            
                if(s.Day==ngaythangnam.Day && s.Month==ngaythangnam.Month && s.Year==ngaythangnam.Year)
                {

                    kq.Add(db.HoaDons.Where(p => p.NgayLapHD == s).Select(p => p).FirstOrDefault());
                    
                }   
            }
            return kq;
        }

        public List<HoaDon> tim_hoaDon_ngaythangnam_dieukien(DateTime ngaythangnam, string trangthai)
        {
            List<DateTime> list = LayDanhSachNgayLap();
            DateTime date = new DateTime();
            List<HoaDon> kq = new List<HoaDon>();
            foreach (DateTime s in list)
            {

                if (s.Day == ngaythangnam.Day && s.Month == ngaythangnam.Month && s.Year == ngaythangnam.Year)
                {
                    string tt = db.HoaDons.Where(p => p.NgayLapHD == s).Select(p => p.TrangThaiDonHang).FirstOrDefault();
                    if ( tt== trangthai)
                    {
                        kq.Add(db.HoaDons.Where(p => p.NgayLapHD == s && p.TrangThaiDonHang == trangthai).Select(p => p).FirstOrDefault());
                    }

                }
            }
            return kq;
        }


        public List<HoaDon> tim_hoaDon_ngay(DateTime ngay)
        {
            List<DateTime> list = LayDanhSachNgayLap();
            DateTime date = new DateTime();
            List<HoaDon> kq = new List<HoaDon>();
            foreach (DateTime s in list)
            {
             
                if (s.Day == ngay.Day)
                {

                    kq.Add(db.HoaDons.Where(p => p.NgayLapHD ==s).Select(p => p).FirstOrDefault());

                }
            }
            return kq;
        }

        public List<HoaDon> tim_hoaDon_ngay_dieukien(DateTime ngay,string trangthai)
        {
            List<DateTime> list = LayDanhSachNgayLap();
            DateTime date = new DateTime();
            List<HoaDon> kq = new List<HoaDon>();
            foreach (DateTime s in list)
            {

                if (s.Day == ngay.Day)
                {
                    if (db.HoaDons.Where(p => p.NgayLapHD == s).Select(p => p.TrangThaiDonHang).FirstOrDefault() == trangthai)
                    {
                        kq.Add(db.HoaDons.Where(p => p.NgayLapHD == s ).Select(p => p).FirstOrDefault());

                    }
                }
            }
            return kq;
        }
        public List<HoaDon> tim_hoaDon_thang(DateTime thang)
        {
            List<DateTime> list = LayDanhSachNgayLap();
            DateTime date = new DateTime();
            List<HoaDon> kq = new List<HoaDon>();
            foreach (DateTime s in list)
            {
    
                if (s.Month == thang.Month)
                {

                    kq.Add(db.HoaDons.Where(p => p.NgayLapHD ==s).Select(p => p).FirstOrDefault());

                }
            }
            return kq;
        }

        public List<HoaDon> tim_hoaDon_thang_dieukien(DateTime thang,string trangthai)
        {
            List<DateTime> list = LayDanhSachNgayLap();
            DateTime date = new DateTime();
            List<HoaDon> kq = new List<HoaDon>();
            foreach (DateTime s in list)
            {

                if (s.Month == thang.Month)
                {
                    if (db.HoaDons.Where(p => p.NgayLapHD == s).Select(p => p.TrangThaiDonHang).FirstOrDefault() == trangthai)
                    {
                        kq.Add(db.HoaDons.Where(p => p.NgayLapHD == s).Select(p => p).FirstOrDefault());
                    }
                }
            }
            return kq;
        }
        public List<HoaDon> tim_hoaDon_nam(DateTime nam)
        {
            List<DateTime> list = LayDanhSachNgayLap();
            List<HoaDon> kq = new List<HoaDon>();
            foreach (DateTime a in list)
            {

                if (a.Year == nam.Year)
                {

                    kq.Add(db.HoaDons.Where(p => p.NgayLapHD == a).Select(p => p).FirstOrDefault());

                }
            }
            return kq;
        }
        public List<HoaDon> tim_hoaDon_nam_dieukien(DateTime nam,string trangthai)
        {
            List<DateTime> list = LayDanhSachNgayLap();
            List<HoaDon> kq = new List<HoaDon>();
            foreach (DateTime a in list)
            {

                if (a.Year == nam.Year)
                {
                    
                    if ( db.HoaDons.Where(p=>p.NgayLapHD==a).Select(p=>p.TrangThaiDonHang).FirstOrDefault()== trangthai)
                    {
                        kq.Add(db.HoaDons.Where(p=>p.NgayLapHD==a).Select(p => p).FirstOrDefault());
                    }

                }
            }
            return kq;
        }

        SanPham_DAL sp=new SanPham_DAL();
        public List<CT_SP_HoaDon> LoadChiTiet_HoaDon(int mahd)
        {
            var chiTietPhieuNhapInfo = db.ChiTietHoaDons
                .Where(ctpn => ctpn.MaHD == mahd)
                .Select(ctpn => new CT_SP_HoaDon
                {

                    Tensp = sp.lay_tensp(ctpn.MaSP),
                    Donvitinh=sp.lay_DVT(ctpn.MaSP),
                    Soluong=ctpn.SoLuong.ToString(),
                    Dongia=ctpn.GiaBan.ToString(),
                    Thanhtien=ctpn.ThanhTien.ToString(),
                    
                })
                .ToList();
            return chiTietPhieuNhapInfo;
        }

    }
}
