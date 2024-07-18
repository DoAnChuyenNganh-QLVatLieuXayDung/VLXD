using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BLL_DAL.PhieuNhap_DAL;

namespace BLL_DAL
{
    public class ChiTietDonHang_DAL
    {

        QL_VatLieuXayDungDataContext db = new QL_VatLieuXayDungDataContext();
        public ChiTietDonHang_DAL() { }
        public string lay_ten_masp(int i)
        {
            return db.SanPhams.Where(p=>p.MaSP==i).Select(p=>p.TenSP).FirstOrDefault()?.ToString(); 
        }
        public int lay_masp(string s)
        {
            return db.SanPhams.Where(p => p.TenSP == s).Select(p => p.MaSP).FirstOrDefault() ;
        }
        public List<ChiTietHoaDon> load(int mahd)
        {
            return db.ChiTietHoaDons.Where(p=>p.MaHD==mahd).ToList();
         
        }

        public List<ChiTiet_HoaDon> LoadChiTiet_HoaDon(int mahd)
        {
            var chiTietPhieuNhapInfo = db.ChiTietHoaDons
                .Where(ctpn => ctpn.MaHD == mahd)
                .Select(ctpn => new ChiTiet_HoaDon
                {

                    Mahoadon = (int)ctpn.MaHD,
                    Tensp = (string)ctpn.SanPham.TenSP,
                    Giaban= (int)ctpn.GiaBan,
                    Soluong = (int)ctpn.SoLuong,
                    Thanhtien = (int)ctpn.ThanhTien,
                   
                })
                .ToList();
            return chiTietPhieuNhapInfo;
        }

        public bool kiemtra_CT_HD_cochua(int mahd,int masp)
        {
            var kq= db.ChiTietHoaDons.Where(p=>p.MaHD==mahd && p.MaSP==masp).ToList();
            if(kq.Count==0) return false;
            return true;
        }
        public bool intsert_CT_HD(int mhd,int masp,int soluong,int giaban)
        {
            ChiTietHoaDon ct=new ChiTietHoaDon();
            ct.MaHD = mhd;
            ct.MaSP = masp;
            ct.SoLuong= soluong;
            ct.GiaBan = giaban;
            ct.ThanhTien = giaban * soluong;
            db.ChiTietHoaDons.InsertOnSubmit(ct);
            db.SubmitChanges();
            return true;
        }

        public int tong_soluong_DH(int mahd)
        {
            int kq = 0;
            List<int> sumResult = db.ChiTietHoaDons.Where(p => p.MaHD == mahd).Select(p => p.SoLuong ?? 0).ToList();
            foreach (int i in sumResult)
            {
                kq += i;
            }
            return kq;

        }
        public int tong_thanhtien(int mahd)
        {
            int? sumResult = db.ChiTietHoaDons.Where(p => p.MaHD == mahd).Sum(p => p.ThanhTien);

            if (sumResult.HasValue)
            {
                return sumResult.Value;
            }
            else
            {
                return 0;
            }
        }
        public bool update(int ma, int masp, int soluong)
        {
            ChiTietHoaDon nv = db.ChiTietHoaDons.Where(n => n.MaHD == ma && n.MaSP==masp).FirstOrDefault();
            if (nv != null)
            {
                nv.SoLuong = soluong;
                db.SubmitChanges();
                return true;
            }
            return false;

        }
        public bool xoa_CT_SP(int mahd,int masp)
        {
            var kq=db.ChiTietHoaDons.Where(p=>p.MaHD==mahd && p.MaSP==masp).Select(p => p).ToList();
            if (kq!=null) 
            {
                db.ChiTietHoaDons.DeleteAllOnSubmit(kq);
                db.SubmitChanges();
                return true;
            }
            return false;
        }

    }
}
