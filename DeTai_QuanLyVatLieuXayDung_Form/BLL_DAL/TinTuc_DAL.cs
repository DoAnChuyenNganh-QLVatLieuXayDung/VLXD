using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAL
{
    public class TinTuc_DAL
    {
        QL_VatLieuXayDungDataContext db = new QL_VatLieuXayDungDataContext();
        public TinTuc_DAL() { }
        public List<TinTuc> load()
        {
            return db.TinTucs.ToList();
        }

        public List<TinTuc> insert(string ten, string noidung, DateTime ngay)
        {
            TinTuc tt = new TinTuc();

            tt.Title = ten;

            tt.NoiDung = noidung;
            tt.NgayDang = ngay;


            db.TinTucs.InsertOnSubmit(tt);
            db.SubmitChanges();
            return db.TinTucs.ToList();

        }

        public List<TinTuc> update(int ma, string ten, string noidung, DateTime ngay)
        {
            TinTuc tt = db.TinTucs.Where(n => n.MaTin == ma).FirstOrDefault();
            if (tt != null)
            {
                tt.Title = ten;

                tt.NoiDung = noidung;
                tt.NgayDang = ngay;


                db.SubmitChanges();
            }
            return db.TinTucs.ToList();

        }
        public List<TinTuc> delete(int ma)
        {
            TinTuc tt = db.TinTucs.Where(n => n.MaTin == ma).FirstOrDefault();
            if (tt != null)
            {
                db.TinTucs.DeleteOnSubmit(tt);

                db.SubmitChanges();
            }
            return db.TinTucs.ToList();

        }



        public List<TinTuc> searchTen(string ten)
        {
            List<TinTuc> danhSachTinTuc = db.TinTucs
                .Where(kh => kh.Title.Contains(ten))
                .ToList();
            return danhSachTinTuc;

        }
        public List<TinTuc> searchNgay(string ngay)
        {
            List<TinTuc> danhSachTinTuc = db.TinTucs
                .Where(kh => kh.NgayDang.ToString().Contains(ngay))
                .ToList();
            return danhSachTinTuc;
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
