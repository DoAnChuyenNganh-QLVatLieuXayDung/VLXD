using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAL
{
    public class KhachHang_DAL
    {

        QL_VatLieuXayDungDataContext db = new QL_VatLieuXayDungDataContext();
        public KhachHang_DAL() { }
        public List<KhachHang> load()
        {
            return db.KhachHangs.ToList();
        }
        
        public List<String> load_sdt()
        {
            return db.KhachHangs.Select(p=>p.SDT).Distinct().ToList();
        }
        public KhachHang laymot_Kh_SDT(string sdt)
        {
           KhachHang a= db.KhachHangs.Where(p=>p.SDT==sdt).Select(p=>p).FirstOrDefault();
            return a;
        }
        public bool insert(string ten, string phai, DateTime ns, string diachi, string sdt, string user, string pass, string email, string trangthai)
        {
            var kq=db.KhachHangs.Where(p=>p.UserName==user || p.SDT==sdt || p.Email==email).Select(p=>p);
            if (kq.Count() > 0)
            {
                return false;
            }
            else
            {
                KhachHang nv = new KhachHang();

                nv.TenKH = ten;
                nv.Phai = phai;
                nv.NgaySinh = ns;
                nv.DiaChi = diachi;
                nv.SDT = sdt;
                nv.UserName = user;
                nv.MatKhau = pass;
                nv.Email = email;
                nv.TrangThai = trangthai;

                db.KhachHangs.InsertOnSubmit(nv);
                db.SubmitChanges();
                return true;
            }

        }

        public List<KhachHang> update(int ma, string ten, string phai, DateTime ns, string diachi, string sdt, string user, string pass, string email, string trangthai)
        {
            {
                KhachHang nv = db.KhachHangs.Where(n => n.MaKH == ma).FirstOrDefault();
                if (nv != null)
                {
                    nv.TenKH = ten;
                    nv.Phai = phai;
                    nv.NgaySinh = ns;
                    nv.DiaChi = diachi;
                    nv.SDT = sdt;
                    nv.UserName = user;
                    nv.MatKhau = pass;
                    nv.Email = email;
                    nv.TrangThai = trangthai;

                    db.SubmitChanges();
                }
                return db.KhachHangs.ToList();

            }
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

        static string GenerateRandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            Random random = new Random();
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public bool insert_KhachHang_VangLai(string ten, string phai, string sdt, string diachi)
        {
            int kq = db.KhachHangs.Where(p => p.SDT == sdt).Select(p => p.MaKH).FirstOrDefault();
            if (kq == 0)
            {
                KhachHang nv = new KhachHang();
                nv.TenKH = ten;
                nv.Phai = phai;
                nv.DiaChi = diachi;
                nv.SDT = sdt;
                nv.UserName = GenerateRandomString(6);
                db.KhachHangs.InsertOnSubmit(nv);
                db.SubmitChanges();
                return true;
            }
            else
            { return false; }

        }
        public KhachHang layThongTinKhachHang(string sdt)
        {
            return db.KhachHangs.Where(p => p.SDT == sdt).Select(p => p).FirstOrDefault();
        }

        HoaDon_DAL hd=new HoaDon_DAL();

        public KhachHang lay_khachhang_tuhoadon(int mahd)
        {
            int kq =(int) db.HoaDons.Where(p => p.MaHD == mahd).Select(p => p.MaKH).FirstOrDefault();
            if (kq != 0) 
            {
               return db.KhachHangs.Where(p=>p.MaKH==kq).Select(p=>p).FirstOrDefault();
            }
            return null;
        }

        public bool update_thongtin_giaohang(string sdt, string hoten, string diachi)
        {

          
                KhachHang nv = db.KhachHangs.Where(p => p.SDT==sdt).Select(p => p).FirstOrDefault();
                if (nv != null)
                {
                    nv.DiaChi = diachi;
                    nv.SDT = sdt;
                    nv.TenKH = hoten;
                    db.SubmitChanges();

                    return true;

                }
                else
                {
                    KhachHang nv1 = new KhachHang();
                    nv1.TenKH = hoten;
                    nv1.Phai = "Khác";
                    nv1.DiaChi = diachi;
                    nv1.SDT = sdt;
                    nv1.UserName = GenerateRandomString(6);
                    db.KhachHangs.InsertOnSubmit(nv1);
                    db.SubmitChanges();
                    return false;
                }
            
        }    

        
    }
}
