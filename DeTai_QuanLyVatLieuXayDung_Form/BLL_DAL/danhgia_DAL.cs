using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAL
{
    public class danhgia_DAL
    {
        QL_VatLieuXayDungDataContext db=new QL_VatLieuXayDungDataContext();
        public danhgia_DAL() { }
        public List<DANHGIA> load()
        {
            return db.DANHGIAs.ToList();
        }
    }
}
