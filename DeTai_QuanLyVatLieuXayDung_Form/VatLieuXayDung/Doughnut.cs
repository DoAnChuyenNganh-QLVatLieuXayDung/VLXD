using BLL_DAL;
using Guna.Charts.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace VatLieuXayDung
{
    public class Doughnut
    {
        ThongKe_DAL DAL = new ThongKe_DAL();
        public static void Example(Guna.Charts.WinForms.GunaChart chart, DateTime time)
        {

            // Define labels for the doughnut chart segments
            string[] months = { "Tiền lời", "Doanh thu", "Remaining" };

            // Configure the chart properties
            chart.Title.Text = "Lợi nhuận";
            chart.Legend.Position = Guna.Charts.WinForms.LegendPosition.Right;
            chart.XAxes.Display = false;
            chart.YAxes.Display = false;

            // Create a new dataset for the doughnut chart
            var dataset = new Guna.Charts.WinForms.GunaDoughnutDataset();

            // Instantiate the Doughnut class (assuming it contains the DAL property)
            Doughnut doughnut = new Doughnut();

            try
            {
                // Retrieve data for the specified date
                var loiNhuan = doughnut.DAL.TinhDoanhThuVaLoiNhuanTheoNgay(time.Date);

                // Log the SQL query or other relevant details
                Console.WriteLine($"SQL Query: ..."); // Replace with the actual SQL query if applicable

                // Log the retrieved data for debugging
                Console.WriteLine($"DoanhThu: {loiNhuan.DoanhThu}, LoiNhuan: {loiNhuan.LoiNhuan}");

                // Clear existing data points in the dataset
                dataset.DataPoints.Clear();

                // Add data points to the dataset
                dataset.DataPoints.Add(months[0], (double)(loiNhuan.LoiNhuan ?? 0));
                dataset.DataPoints.Add(months[1], (double)(loiNhuan.DoanhThu ?? 0));

                // Check if DoanhThu has a value before adding the third data point
                if (loiNhuan.DoanhThu.HasValue)
                {
                    dataset.DataPoints.Add(months[2], (double)(loiNhuan.DoanhThu - (loiNhuan.LoiNhuan ?? 0)));
                }
                else
                {
                    // Handle the case when DoanhThu is null, for example, by providing a default value.
                    dataset.DataPoints.Add(months[2], 0.0);
                }

                // Add the dataset to the chart and update
                chart.Datasets.Add(dataset);
                chart.Update();
            }
            catch (Exception ex)
            {
                // Log or display the exception to understand what went wrong
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

        }
    }
}
    
