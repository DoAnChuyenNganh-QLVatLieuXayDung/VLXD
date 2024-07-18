using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAL
{
    public class LoaiSanPham_DAL
    {
        QL_VatLieuXayDungDataContext db=new QL_VatLieuXayDungDataContext();

        public LoaiSanPham_DAL() { }

        public List<String> ten_LoaiSP()
        {
            return db.LoaiSanPhams.Select(p=>p.TenLoai).Distinct().ToList();
        }

        public bool insertloaiSP(string tenloai,string mota)
        {
            var kq=db.LoaiSanPhams.Where(p=>p.TenLoai.Contains(tenloai)).Select(p=>p).FirstOrDefault();
            if(kq==null)
            {
                LoaiSanPham lsp=new LoaiSanPham();
                lsp.TenLoai = tenloai;
                lsp.MoTa = mota;
                db.LoaiSanPhams.InsertOnSubmit(lsp); db.SubmitChanges();
                return true;
            }  
            return false;
        }
    }
}
