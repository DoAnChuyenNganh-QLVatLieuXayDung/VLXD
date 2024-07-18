using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAL
{
    public class HangSanXuat_DAL
    {
        QL_VatLieuXayDungDataContext db = new QL_VatLieuXayDungDataContext();
        public HangSanXuat_DAL() { }
        public List<HangSanXuat> load()
        {
            return db.HangSanXuats.ToList();
        }
        public List<string> load_tenhsx()
        {
            return db.HangSanXuats.Select(p=>p.TenHSX).ToList();
        }
        public int laymahsx(string tenhsx)
        {
            return db.HangSanXuats.Where(p => p.TenHSX == tenhsx).Select(p => p.MaHSX).FirstOrDefault();
        }
        public List<HangSanXuat> insert(string ten,  string diachi, string sdt)
        {
            HangSanXuat hsx = new HangSanXuat();

            hsx.TenHSX = ten;
            
            hsx.DiaChi = diachi;
            hsx.SDT = sdt;

            db.HangSanXuats.InsertOnSubmit(hsx);
            db.SubmitChanges();
            return db.HangSanXuats.ToList();

        }

        public List<HangSanXuat> update(int ma, string ten,  string diachi, string sdt)
        {
            HangSanXuat hsx = db.HangSanXuats.Where(n => n.MaHSX == ma).FirstOrDefault();
            if (hsx != null)
            {
                hsx.TenHSX = ten;
                
                hsx.DiaChi = diachi;
                hsx.SDT = sdt;
                

                db.SubmitChanges();
            }
            return db.HangSanXuats.ToList();

        }

        public List<HangSanXuat> searchTen(string ten)
        {
            List<HangSanXuat> danhSachHangSanXuat = db.HangSanXuats
                .Where(kh => kh.TenHSX.Contains(ten))
                .ToList();
            return danhSachHangSanXuat;

        }
        public List<HangSanXuat> searchSDT(string sdt)
        {
            List<HangSanXuat> danhSachHangSanXuat = db.HangSanXuats
                .Where(kh => kh.SDT.ToString().Contains(sdt))
                .ToList();
            return danhSachHangSanXuat;
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
    }
}
