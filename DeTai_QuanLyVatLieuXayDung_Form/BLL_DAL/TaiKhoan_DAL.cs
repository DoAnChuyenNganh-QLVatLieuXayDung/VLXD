using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAL
{
    public class TaiKhoan_DAL
    {
        QL_VatLieuXayDungDataContext db =new QL_VatLieuXayDungDataContext();

        
        public TaiKhoan_DAL()
        {

        }

        public int TimMaNhanVien(string username)
        {
            var maNhanVien = db.TaiKhoanNVs
                                .Where(t => t.UserName == username)
                                .Select(t => t.MaNV)
                                .FirstOrDefault();

            return maNhanVien.HasValue ? maNhanVien.Value : 0;
        }




        public List<TaiKhoanNV> load()
        {
            return db.TaiKhoanNVs.ToList();
        }

        public string layTenTKonline()
        {
           int manv=Int32.Parse( db.TaiKhoanNVs.Where(p=>p.TrangThai.Contains("On")).Select(p=>p.MaNV).FirstOrDefault()?.ToString());
            return db.NhanViens.Where(nv=>nv.MaNV==manv).Select(p=>p.TenNV).FirstOrDefault()?.ToString();   
        }
        public string layTenUseronline()
        {
            string manv =db.TaiKhoanNVs.Where(p => p.TrangThai.Contains("On")).Select(p => p.UserName).FirstOrDefault()?.ToString();
            return manv;
        }

        public string layMaNVTKonline()
        {
            int manv = Int32.Parse(db.TaiKhoanNVs.Where(p => p.TrangThai.Contains("On")).Select(p => p.MaNV).FirstOrDefault()?.ToString());
            return db.NhanViens.Where(nv => nv.MaNV == manv).Select(p => p.MaNV).FirstOrDefault().ToString();
        }

        public List<TaiKhoanNV> insert(string user, string pass, int ma, string quyen, string trangthai)
        {
            TaiKhoanNV nv = new TaiKhoanNV();

            nv.UserName = user;
            nv.MatKhau = pass;
            nv.maquyen = quyen;
            nv.MaNV = ma;
            nv.TrangThai = trangthai;

            db.TaiKhoanNVs.InsertOnSubmit(nv);
            db.SubmitChanges();
            return db.TaiKhoanNVs.ToList();

        }

        public List<TaiKhoanNV> update(  int ma,string pass, string quyen, string trangthai)
        {
            TaiKhoanNV nv = db.TaiKhoanNVs.Where(n => n.MaNV == ma).FirstOrDefault();
            if (nv != null)
            {
                nv.MatKhau = pass;
                nv.maquyen = quyen;
                nv.TrangThai = trangthai;

                db.SubmitChanges();
            }
            return db.TaiKhoanNVs.ToList();

        }

        public List<TaiKhoanNV> searchTen(string ten)
        {
            List<TaiKhoanNV> danhSachTaiKhoanNV = db.TaiKhoanNVs
                .Where(kh => kh.UserName.Contains(ten))
                .ToList();
            return danhSachTaiKhoanNV;

        }
        public List<TaiKhoanNV> searchQuyen(string quyen)
        {
            List<TaiKhoanNV> danhSachTaiKhoanNV = db.TaiKhoanNVs
                .Where(kh => kh.maquyen.Contains(quyen))
                .ToList();
            return danhSachTaiKhoanNV;
        }



        public bool KiemTraUserBiTrung(string username)
        {
            var user = db.TaiKhoanNVs
                .Where(u => u.UserName == username)
                .FirstOrDefault();

            return user != null; 
        }

        public List<TaiKhoanNV> delete(string user)
        {
            TaiKhoanNV tt = db.TaiKhoanNVs.Where(n => n.UserName == user).FirstOrDefault();
            if (tt != null)
            {
                db.TaiKhoanNVs.DeleteOnSubmit(tt);

                db.SubmitChanges();
            }
            return db.TaiKhoanNVs.ToList();

        }
        public bool DoiMatKhau(string username, string oldPassword, string newPassword)
        {
            
                var user = db.TaiKhoanNVs
                    .Where(u => u.UserName == username && u.MatKhau == oldPassword)
                    .FirstOrDefault();

                if (user != null)
                {
                    
                    user.MatKhau = newPassword;
                    db.SubmitChanges();
                    return true; 
                }
            

            return false; 
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

        public bool Kiemtramatkhaucu(string username, string oldPassword)
        {
           
                var user = db.TaiKhoanNVs
                    .Where(u => u.UserName == username && u.MatKhau == oldPassword)
                    .FirstOrDefault();

                return user != null;
         }


        public bool Kiemtramatkhaucu(string oldPassword)
        {
            string username = layTenTKonline();
            var user = db.TaiKhoanNVs
                .Where(u => u.UserName == username && u.MatKhau == oldPassword)
                .FirstOrDefault();

            return user != null;
        }
    }


}

