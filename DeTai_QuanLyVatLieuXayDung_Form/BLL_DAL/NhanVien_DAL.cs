using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAL
{
    public class NhanVien_DAL
    {
        QL_VatLieuXayDungDataContext db =new QL_VatLieuXayDungDataContext();
        public NhanVien_DAL() { }   
        public List<NhanVien> load()
        {
            return db.NhanViens.ToList();   
        }

        public List<NhanVien> insert( string ten , string phai , DateTime ns,string diachi,string sdt, string trangthai)
        {
            NhanVien nv = new NhanVien();
            
            nv.TenNV = ten;
            nv.Phai = phai;
            nv.NgaySinh = ns;
            nv.DiaChi = diachi;
            nv.SDT = sdt;
            nv.TrangThai = trangthai;

            db.NhanViens.InsertOnSubmit(nv);
            db.SubmitChanges();
            return db.NhanViens.ToList();

        }

        public List<NhanVien> update(int ma, string ten, string phai, DateTime ns, string diachi, string sdt, string trangthai)
        {
            NhanVien nv = db.NhanViens.Where(n => n.MaNV == ma).FirstOrDefault();
            if (nv != null)
            {
                nv.TenNV = ten;
                nv.Phai = phai;
                nv.NgaySinh = ns;
                nv.DiaChi = diachi;
                nv.SDT = sdt;
                nv.TrangThai = trangthai;

                db.SubmitChanges();
            }
            return db.NhanViens.ToList();

        }

        public List<NhanVien> searchTen(string ten)
        {
            List<NhanVien> danhSachNhanVien = db.NhanViens
                .Where(kh => kh.TenNV.Contains(ten))
                .ToList();
            return danhSachNhanVien;

        }
        public List<NhanVien> searchSDT(string sdt)
        {
            List<NhanVien> danhSachNhanVien = db.NhanViens
                .Where(kh => kh.SDT.ToString().Contains(sdt))
                .ToList();
            return danhSachNhanVien;
        }


        public List<NhanVien> searchGiotTinh(string gt)
        {
            List<NhanVien> danhSachNhanVien = db.NhanViens
                .Where(kh => kh.Phai.Contains(gt))
                .ToList();
            return danhSachNhanVien;

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
