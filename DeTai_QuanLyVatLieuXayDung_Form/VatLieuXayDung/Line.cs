using BLL_DAL;
using Guna.Charts.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Guna.UI2.WinForms;



namespace VatLieuXayDung
{
    public class Line
    {
        ThongKe_DAL DAL = new ThongKe_DAL();    
        public static void Example(Guna.Charts.WinForms.GunaChart chart)
        {
            

            Guna.Charts.WinForms.GunaLineDataset lineDataset = new Guna.Charts.WinForms.GunaLineDataset();
            Guna.Charts.WinForms.GunaBarDataset barDataset = new Guna.Charts.WinForms.GunaBarDataset();

            lineDataset.FillColor = Guna.Charts.WinForms.ChartUtils.RandomColor();
            lineDataset.BorderColor = lineDataset.FillColor;
            lineDataset.Label = "Lợi nhuận";
            barDataset.Label = "Doanh thu";
            Line line = new Line();

            var doanhThuList = line.DAL.ThongKeDoanhThuTheoNgay();
            doanhThuList = doanhThuList.OrderBy(item => item.Ngay).ToList();

            foreach (var item in doanhThuList)
            {
                double yValue = (double)item.DoanhThu;
                double xValue = (double)item.TienLoi;

                lineDataset.DataPoints.Add($"{item.Ngay:dd/MM/yyyy}", xValue);
                barDataset.DataPoints.Add($"{item.Ngay:dd/MM/yyyy}", yValue);
            }


            chart.Datasets.Add(lineDataset);
            chart.Datasets.Add(barDataset);

            chart.Update();
        }

        public static void Example_BD_KT(Guna.Charts.WinForms.GunaChart chart, DateTime bd, DateTime kt)
        {


            Guna.Charts.WinForms.GunaLineDataset lineDataset = new Guna.Charts.WinForms.GunaLineDataset();
            Guna.Charts.WinForms.GunaBarDataset barDataset = new Guna.Charts.WinForms.GunaBarDataset();

            lineDataset.FillColor = Guna.Charts.WinForms.ChartUtils.RandomColor();
            lineDataset.BorderColor = lineDataset.FillColor;
            lineDataset.Label = "Lợi nhuận";
            barDataset.Label = "Doanh thu";
            Line line = new Line();

            var doanhThuList = line.DAL.ThongKeDoanhThuTheoNgay_BD_KT(bd,kt);
            doanhThuList = doanhThuList.OrderBy(item => item.Ngay).ToList();

            foreach (var item in doanhThuList)
            {
                double yValue = (double)item.DoanhThu;
                double xValue = (double)item.TienLoi;

                lineDataset.DataPoints.Add($"{item.Ngay:dd/MM/yyyy}", xValue);
                barDataset.DataPoints.Add($"{item.Ngay:dd/MM/yyyy}", yValue);
            }


            chart.Datasets.Add(lineDataset);
            chart.Datasets.Add(barDataset);

            chart.Update();
        }
    }
}
