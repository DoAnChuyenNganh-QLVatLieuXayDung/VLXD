using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAL
{
    public class DangNhap_DAL
    {

        QL_VatLieuXayDungDataContext db = new QL_VatLieuXayDungDataContext();

        public DangNhap_DAL() { }


        public bool KiemTraDangNhap(string username, string password, out int maNV, out string quyen)
        {
            maNV = 0;
            quyen = "";

            var user = db.TaiKhoanNVs
                .Where(u => u.UserName == username && u.MatKhau == password)
                .FirstOrDefault();

            if (user != null)
            {
                quyen = user.maquyen;

                if (user.MaNV.HasValue)
                {
                    maNV = user.MaNV.Value;
                }

                user.TrangThai = "On";
                db.SubmitChanges();

                return true;
            }

            return false;
        }
        public bool kiemtra_taikhoan_dangnhap(string tentk)
        {
            string tentk_new=db.TaiKhoanNVs.Where(p=>p.UserName == tentk && p.TrangThai=="On").FirstOrDefault().ToString();
            if (tentk_new != null) 
                { return false; }
            return true;
        }


        public string layMaNVTKonline_Admin()
        {
          return db.TaiKhoanNVs.Where(p => p.TrangThai.Contains("On") && p.maquyen=="ADMIN").Select(p => p.UserName).FirstOrDefault()?.ToString();
        }
        public string layMaNVTKonline_USER()
        {
            return db.TaiKhoanNVs.Where(p => p.TrangThai.Contains("On") && p.maquyen == "USER").Select(p => p.UserName).FirstOrDefault()?.ToString();
        }
        public bool Update_DangXuat_Admin()
        {
            TaiKhoanNV nv = db.TaiKhoanNVs.Where(n => n.UserName==layMaNVTKonline_Admin()).FirstOrDefault();
            if (nv != null)
            {
                nv.TrangThai = "OFF";
                db.SubmitChanges();
                return true;
            }
            return false;
        }
        public bool Update_DangXuat_USER()
        {
            TaiKhoanNV nv = db.TaiKhoanNVs.Where(n => n.UserName == layMaNVTKonline_USER()).FirstOrDefault();
            if (nv != null)
            {
                nv.TrangThai = "OFF";
                db.SubmitChanges();
                return true;
            }
            return false;
        }




    }
}
