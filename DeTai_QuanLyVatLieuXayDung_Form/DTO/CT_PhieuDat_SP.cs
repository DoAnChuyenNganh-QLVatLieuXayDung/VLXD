using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class CT_PhieuDat_SP
    {
        private string soluong;
        private string tensp;
        private string donvitinh;

        public string Tensp { get => tensp; set => tensp = value; }
        public string Donvitinh { get => donvitinh; set => donvitinh = value; }
        public string Soluong { get => soluong; set => soluong = value; }
        public CT_PhieuDat_SP() { }
        public CT_PhieuDat_SP(string soluong, string tensp, string donvitinh)
        {
            Soluong = soluong;
            Tensp = tensp;
            Donvitinh = donvitinh;

        }
    }
}
