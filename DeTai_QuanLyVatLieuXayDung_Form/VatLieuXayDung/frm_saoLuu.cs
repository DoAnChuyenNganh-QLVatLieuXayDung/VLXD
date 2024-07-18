using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;




namespace VatLieuXayDung
{
    public partial class frm_saoLuu : Form
    {
        public frm_saoLuu()
        {
            InitializeComponent();
        }

        private void frm_saoLuu_Load(object sender, EventArgs e)
        {

        }

        private void btn_brown_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                txt_link_backup.Text = dlg.SelectedPath;
                btn_saoluu.Enabled = true;
            }


        }

        private void btn_saoluu_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection("Server = DESKTOP-PTQBDTF; database = QL_VatLieuXayDung; integrated security = true"))
                {
                    conn.Open();

                    string database = conn.Database.ToString();

                    if (txt_link_backup.Text == string.Empty)
                    {
                        MessageBox.Show("Vui lòng chọn đường dẫn file", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    else
                    {
                        string backupPath = txt_link_backup.Text + "\\" + "database" + "-" + DateTime.Now.ToString("yyyy-MM-dd--HH-mm-ss") + ".bak";

                        string cmd = "BACKUP DATABASE [" + database + "] TO DISK=@BackupPath";

                        using (SqlCommand command = new SqlCommand(cmd, conn))
                        {
                            command.Parameters.AddWithValue("@BackupPath", backupPath);
                            command.ExecuteNonQuery();
                            MessageBox.Show("Sao lưu thành công","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
                btn_saoluu.Enabled = false;
            }

        }


        private void btn_bworn_retose_Click(object sender, EventArgs e)
        {

            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "SQL SERVER database backup files |*.bak";
            dlg.Title = "Database restore";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                txt_retose.Text = dlg.FileName;
                btn_retore.Enabled = true;
            }
        }



        private void btn_retore_Click(object sender, EventArgs e)
        {
            try
            {
                string backupFilePath = txt_retose.Text;

                string connectionString = "Data Source=DESKTOP-PTQBDTF;Initial Catalog=QL_VatLieuXayDung;Integrated Security=True";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string setMasterQuery = "USE master";
                    using (SqlCommand setMasterCommand = new SqlCommand(setMasterQuery, connection))
                    {
                        setMasterCommand.ExecuteNonQuery();
                    }

                    string checkConnectionsQuery = $"SELECT COUNT(*) FROM sys.sysprocesses WHERE DB_NAME(dbid) = 'QL_VatLieuXayDung'";
                    using (SqlCommand checkConnectionsCommand = new SqlCommand(checkConnectionsQuery, connection))
                    {
                        int existingConnections = (int)checkConnectionsCommand.ExecuteScalar();
                        if (existingConnections > 0)
                        {
                            MessageBox.Show("Hiện có các kết nối tới cơ sở dữ liệu 'QL_VatLieuXayDung'. Vui lòng đóng tất cả các kết nối và thử lại.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                            return;
                        }
                    }

                    string setSingleUserQuery = "ALTER DATABASE QL_VatLieuXayDung SET SINGLE_USER WITH ROLLBACK IMMEDIATE";
                    using (SqlCommand setSingleUserCommand = new SqlCommand(setSingleUserQuery, connection))
                    {
                        setSingleUserCommand.ExecuteNonQuery();
                    }

                    string restoreQuery = $"RESTORE DATABASE QL_VatLieuXayDung FROM DISK = '{backupFilePath}' WITH REPLACE";
                    using (SqlCommand restoreCommand = new SqlCommand(restoreQuery, connection))
                    {
                        restoreCommand.ExecuteNonQuery();
                    }

                    string setMultiUserQuery = "ALTER DATABASE QL_VatLieuXayDung SET MULTI_USER";
                    using (SqlCommand setMultiUserCommand = new SqlCommand(setMultiUserQuery, connection))
                    {
                        setMultiUserCommand.ExecuteNonQuery();
                    }

                    MessageBox.Show("Database restored successfully!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

    }
}
