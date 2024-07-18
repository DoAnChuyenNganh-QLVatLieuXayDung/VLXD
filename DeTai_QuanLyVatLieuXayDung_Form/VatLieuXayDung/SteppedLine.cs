using BLL_DAL;
using Guna.Charts.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VatLieuXayDung
{
    public class SteppedLine
    {
        LichSuGia_DAL DAL = new LichSuGia_DAL();
        public static void Example(Guna.Charts.WinForms.GunaChart chart, int maSP)
        {


            chart.YAxes.GridLines.Display = false;

            var dataset = new Guna.Charts.WinForms.GunaSteppedLineDataset();

            //  dataset.PointFillColors = Guna.Charts.WinForms.ChartUtils.Colors(months.Length, Color.Orange);
            dataset.PointBorderColors = dataset.PointFillColors;
            dataset.PointRadius = 4;
            dataset.PointStyle = PointStyle.Triangle;
            dataset.Label = "Lịch sử giá";
            SteppedLine steppedLine = new SteppedLine();



            var layGiaResults = steppedLine.DAL.LayGia(maSP);

            foreach (var item in layGiaResults)
            {
                DateTime? ngayCapNhat = item.NgayCapNhat;
                int gia = item.Gia;

                dataset.DataPoints.Add(ngayCapNhat.Value.Date.ToString(), gia);
            }

            chart.Datasets.Add(dataset);

            chart.Update();
        }
    
}
}
