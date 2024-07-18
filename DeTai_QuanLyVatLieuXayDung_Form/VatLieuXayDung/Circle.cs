using BLL_DAL;
using Guna.Charts.WinForms;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VatLieuXayDung
{
    public class Circle
    {
        ThongKe_DAL DAL =new ThongKe_DAL();
        public void Example(Guna.Charts.WinForms.GunaChart chart, DateTime bt, DateTime kt)
        {

            chart.Legend.Position = Guna.Charts.WinForms.LegendPosition.Right;
            chart.XAxes.Display = false;
            chart.YAxes.Display = false;

            var dataset = new Guna.Charts.WinForms.GunaPieDataset();

            var top5 = DAL.Top5SanPhamBanChay(bt, kt);


            foreach (var item in top5)
            {

                string yValue = item.TenSP.ToString(); 
                int xValue = item.SoLuongBan;

                dataset.DataPoints.Add( yValue, xValue);
            }

             
            chart.Datasets.Add(dataset);
            chart.Update();
        }

    }
}
