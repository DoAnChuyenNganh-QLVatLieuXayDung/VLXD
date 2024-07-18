using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAL
{
    public class KhuyenMai_DAL
    {

        QL_VatLieuXayDungDataContext db= new QL_VatLieuXayDungDataContext();

        public KhuyenMai_DAL () { }

        public List<KhuyenMai> load()
        {
            return db.KhuyenMais.ToList();
        }

        public List<KhuyenMai> insert(string ma, int phantram, DateTime ap, DateTime hh)
        {
            KhuyenMai nv = new KhuyenMai();

            nv.MaKhuyenMai = ma;
            nv.PhanTramGiam = phantram;
            nv.NgayApDung = ap;
            nv.NgayHetHan = hh;
          

            db.KhuyenMais.InsertOnSubmit(nv);
            db.SubmitChanges();
            return db.KhuyenMais.ToList();

        }

        public List<KhuyenMai> update(string ma, int phantram, DateTime ap, DateTime hh)
        {
            KhuyenMai nv = db.KhuyenMais.Where(n => n.MaKhuyenMai == ma).FirstOrDefault();
            if (nv != null)
            {
                nv.PhanTramGiam = phantram;
                nv.NgayApDung = ap;
                nv.NgayHetHan = hh;
                
                db.SubmitChanges();
            }
            return db.KhuyenMais.ToList();

        }

        public List<KhuyenMai> searchNgayAD(DateTime ng)
        {
            List<KhuyenMai> danhSachKhuyenMai = db.KhuyenMais
                .Where(kh => kh.NgayApDung == ng)
                .ToList();
            return danhSachKhuyenMai;

        }

        public List<KhuyenMai> searchNgayHH(DateTime ng)
        {
            List<KhuyenMai> danhSachKhuyenMai = db.KhuyenMais
                .Where(kh => kh.NgayHetHan == ng)
                .ToList();
            return danhSachKhuyenMai;

        }

        public List<String> ma_giam_gia()
        {
            DateTime ngayhethan=DateTime.Now;
            return db.KhuyenMais.Where(p=>p.NgayHetHan>=ngayhethan).Select(p => p.MaKhuyenMai ).ToList();
        }
        public List<KhuyenMai> ma_giam_gia2()
        {
            DateTime ngayhethan = DateTime.Now;
            return db.KhuyenMais.Where(p => p.NgayHetHan >= ngayhethan).Distinct().Select(p => p).ToList();
        }
        public int LayPhanTramKhuyenMai(string maKhuyenMai)
        {

            DateTime ngayhethan = db.KhuyenMais.Where(p => p.MaKhuyenMai == maKhuyenMai).Select(p => p.NgayHetHan).FirstOrDefault().Value;
            DateTime date =DateTime.Now;


                    if (ngayhethan.Day>= date.Day )
                    {

                        return (int)db.KhuyenMais.Where(p => p.MaKhuyenMai == maKhuyenMai).Select(p => p.PhanTramGiam).FirstOrDefault();
                    }
         
            return 0;
        }
    }
}
