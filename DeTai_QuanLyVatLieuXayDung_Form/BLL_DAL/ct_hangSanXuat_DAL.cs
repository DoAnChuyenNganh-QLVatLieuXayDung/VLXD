using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAL
{
    public class ct_hangSanXuat_DAL
    {
        public ct_hangSanXuat_DAL() { }
        QL_VatLieuXayDungDataContext db = new QL_VatLieuXayDungDataContext();
        public bool intsert(int mahsx,int masp)
        {
            var kq=db.ChiTiet_SanPham_HangSanXuats.Where(p=>p.MaSP==masp).Where(p=>p.MaHSX==mahsx).Select(p=>p).FirstOrDefault();
            if (kq == null)
            {
                ChiTiet_SanPham_HangSanXuat ct_sp_hsx = new ChiTiet_SanPham_HangSanXuat();
                ct_sp_hsx.MaHSX = mahsx;
                ct_sp_hsx.MaSP = masp;
                db.ChiTiet_SanPham_HangSanXuats.InsertOnSubmit(ct_sp_hsx);
                db.SubmitChanges();
                return true;
            }
            return false;
        }
    }
}
