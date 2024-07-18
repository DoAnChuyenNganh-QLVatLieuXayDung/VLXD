namespace VatLieuXayDung
{
    partial class frm_SanPham
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.data_view_sanpham = new Guna.UI2.WinForms.Guna2DataGridView();
            this.guna2CustomGradientPanel1 = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            this.lab_hinh = new System.Windows.Forms.Label();
            this.gunaGroupBox1 = new Guna.UI.WinForms.GunaGroupBox();
            this.radio_giaban = new Guna.UI2.WinForms.Guna2RadioButton();
            this.radio_sosao = new Guna.UI2.WinForms.Guna2RadioButton();
            this.btn_search = new Guna.UI2.WinForms.Guna2Button();
            this.txt_search = new Guna.UI2.WinForms.Guna2TextBox();
            this.radio_ten = new Guna.UI2.WinForms.Guna2RadioButton();
            this.hinh = new Guna.UI2.WinForms.Guna2PictureBox();
            this.btn_sua = new Guna.UI2.WinForms.Guna2Button();
            this.btn_them = new Guna.UI2.WinForms.Guna2Button();
            this.btn_chonhinh = new Guna.UI2.WinForms.Guna2Button();
            this.cbm_tenloai = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cbm_trangthai = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cbm_donvitinh = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txt_mota = new Guna.UI2.WinForms.Guna2TextBox();
            this.txt_thontin = new Guna.UI2.WinForms.Guna2TextBox();
            this.txt_gianhap = new Guna.UI2.WinForms.Guna2TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_gia_ban = new Guna.UI2.WinForms.Guna2TextBox();
            this.txt_ten_sp = new Guna.UI2.WinForms.Guna2TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.guna2AnimateWindow1 = new Guna.UI2.WinForms.Guna2AnimateWindow(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.data_view_sanpham)).BeginInit();
            this.guna2CustomGradientPanel1.SuspendLayout();
            this.gunaGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hinh)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.data_view_sanpham, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.guna2CustomGradientPanel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1595, 742);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // data_view_sanpham
            // 
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            this.data_view_sanpham.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.data_view_sanpham.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.data_view_sanpham.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedHorizontal;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.data_view_sanpham.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.data_view_sanpham.ColumnHeadersHeight = 22;
            this.data_view_sanpham.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.data_view_sanpham.DefaultCellStyle = dataGridViewCellStyle6;
            this.data_view_sanpham.GridColor = System.Drawing.Color.Black;
            this.data_view_sanpham.Location = new System.Drawing.Point(3, 442);
            this.data_view_sanpham.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.data_view_sanpham.Name = "data_view_sanpham";
            this.data_view_sanpham.RowHeadersVisible = false;
            this.data_view_sanpham.RowHeadersWidth = 51;
            this.data_view_sanpham.RowTemplate.Height = 24;
            this.data_view_sanpham.Size = new System.Drawing.Size(1589, 298);
            this.data_view_sanpham.TabIndex = 63;
            this.data_view_sanpham.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.data_view_sanpham.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.data_view_sanpham.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.data_view_sanpham.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.data_view_sanpham.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.data_view_sanpham.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.data_view_sanpham.ThemeStyle.GridColor = System.Drawing.Color.Black;
            this.data_view_sanpham.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.Gold;
            this.data_view_sanpham.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.data_view_sanpham.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.data_view_sanpham.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.data_view_sanpham.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.data_view_sanpham.ThemeStyle.HeaderStyle.Height = 22;
            this.data_view_sanpham.ThemeStyle.ReadOnly = false;
            this.data_view_sanpham.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.data_view_sanpham.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedHorizontal;
            this.data_view_sanpham.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.data_view_sanpham.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.data_view_sanpham.ThemeStyle.RowsStyle.Height = 24;
            this.data_view_sanpham.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.Thistle;
            this.data_view_sanpham.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.data_view_sanpham.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.data_view_sanpham_CellClick);
            // 
            // guna2CustomGradientPanel1
            // 
            this.guna2CustomGradientPanel1.Controls.Add(this.lab_hinh);
            this.guna2CustomGradientPanel1.Controls.Add(this.gunaGroupBox1);
            this.guna2CustomGradientPanel1.Controls.Add(this.hinh);
            this.guna2CustomGradientPanel1.Controls.Add(this.btn_sua);
            this.guna2CustomGradientPanel1.Controls.Add(this.btn_them);
            this.guna2CustomGradientPanel1.Controls.Add(this.btn_chonhinh);
            this.guna2CustomGradientPanel1.Controls.Add(this.cbm_tenloai);
            this.guna2CustomGradientPanel1.Controls.Add(this.cbm_trangthai);
            this.guna2CustomGradientPanel1.Controls.Add(this.cbm_donvitinh);
            this.guna2CustomGradientPanel1.Controls.Add(this.label10);
            this.guna2CustomGradientPanel1.Controls.Add(this.txt_mota);
            this.guna2CustomGradientPanel1.Controls.Add(this.txt_thontin);
            this.guna2CustomGradientPanel1.Controls.Add(this.txt_gianhap);
            this.guna2CustomGradientPanel1.Controls.Add(this.label3);
            this.guna2CustomGradientPanel1.Controls.Add(this.label5);
            this.guna2CustomGradientPanel1.Controls.Add(this.label7);
            this.guna2CustomGradientPanel1.Controls.Add(this.label8);
            this.guna2CustomGradientPanel1.Controls.Add(this.txt_gia_ban);
            this.guna2CustomGradientPanel1.Controls.Add(this.txt_ten_sp);
            this.guna2CustomGradientPanel1.Controls.Add(this.label6);
            this.guna2CustomGradientPanel1.Controls.Add(this.label2);
            this.guna2CustomGradientPanel1.Controls.Add(this.label1);
            this.guna2CustomGradientPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2CustomGradientPanel1.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold);
            this.guna2CustomGradientPanel1.Location = new System.Drawing.Point(3, 3);
            this.guna2CustomGradientPanel1.Name = "guna2CustomGradientPanel1";
            this.guna2CustomGradientPanel1.Size = new System.Drawing.Size(1589, 434);
            this.guna2CustomGradientPanel1.TabIndex = 0;
            // 
            // lab_hinh
            // 
            this.lab_hinh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lab_hinh.AutoSize = true;
            this.lab_hinh.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lab_hinh.ForeColor = System.Drawing.SystemColors.Control;
            this.lab_hinh.Location = new System.Drawing.Point(888, 357);
            this.lab_hinh.Name = "lab_hinh";
            this.lab_hinh.Size = new System.Drawing.Size(0, 21);
            this.lab_hinh.TabIndex = 88;
            // 
            // gunaGroupBox1
            // 
            this.gunaGroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gunaGroupBox1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.gunaGroupBox1.BaseColor = System.Drawing.Color.White;
            this.gunaGroupBox1.BorderColor = System.Drawing.Color.Gainsboro;
            this.gunaGroupBox1.Controls.Add(this.radio_giaban);
            this.gunaGroupBox1.Controls.Add(this.radio_sosao);
            this.gunaGroupBox1.Controls.Add(this.btn_search);
            this.gunaGroupBox1.Controls.Add(this.txt_search);
            this.gunaGroupBox1.Controls.Add(this.radio_ten);
            this.gunaGroupBox1.LineColor = System.Drawing.Color.Gainsboro;
            this.gunaGroupBox1.Location = new System.Drawing.Point(1053, 62);
            this.gunaGroupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gunaGroupBox1.Name = "gunaGroupBox1";
            this.gunaGroupBox1.Size = new System.Drawing.Size(486, 179);
            this.gunaGroupBox1.TabIndex = 87;
            this.gunaGroupBox1.Text = "Lọc Sản Phẩm";
            this.gunaGroupBox1.TextLocation = new System.Drawing.Point(10, 8);
            // 
            // radio_giaban
            // 
            this.radio_giaban.AutoSize = true;
            this.radio_giaban.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.radio_giaban.CheckedState.BorderThickness = 0;
            this.radio_giaban.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.radio_giaban.CheckedState.InnerColor = System.Drawing.Color.White;
            this.radio_giaban.CheckedState.InnerOffset = -4;
            this.radio_giaban.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.radio_giaban.Location = new System.Drawing.Point(225, 65);
            this.radio_giaban.Margin = new System.Windows.Forms.Padding(4);
            this.radio_giaban.Name = "radio_giaban";
            this.radio_giaban.Size = new System.Drawing.Size(85, 22);
            this.radio_giaban.TabIndex = 27;
            this.radio_giaban.Text = "Giá bán";
            this.radio_giaban.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.radio_giaban.UncheckedState.BorderThickness = 2;
            this.radio_giaban.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.radio_giaban.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            // 
            // radio_sosao
            // 
            this.radio_sosao.AutoSize = true;
            this.radio_sosao.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.radio_sosao.CheckedState.BorderThickness = 0;
            this.radio_sosao.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.radio_sosao.CheckedState.InnerColor = System.Drawing.Color.White;
            this.radio_sosao.CheckedState.InnerOffset = -4;
            this.radio_sosao.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.radio_sosao.Location = new System.Drawing.Point(362, 64);
            this.radio_sosao.Margin = new System.Windows.Forms.Padding(4);
            this.radio_sosao.Name = "radio_sosao";
            this.radio_sosao.Size = new System.Drawing.Size(78, 22);
            this.radio_sosao.TabIndex = 26;
            this.radio_sosao.Text = "Số sao";
            this.radio_sosao.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.radio_sosao.UncheckedState.BorderThickness = 2;
            this.radio_sosao.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.radio_sosao.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            // 
            // btn_search
            // 
            this.btn_search.BorderRadius = 15;
            this.btn_search.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_search.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_search.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_search.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_search.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_search.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold);
            this.btn_search.ForeColor = System.Drawing.Color.Black;
            this.btn_search.Image = global::VatLieuXayDung.Properties.Resources.magnifying_glass;
            this.btn_search.Location = new System.Drawing.Point(399, 119);
            this.btn_search.Margin = new System.Windows.Forms.Padding(4);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(72, 44);
            this.btn_search.TabIndex = 25;
            this.btn_search.Text = "Tìm";
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // txt_search
            // 
            this.txt_search.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txt_search.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.HistoryList;
            this.txt_search.BorderRadius = 15;
            this.txt_search.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_search.DefaultText = "";
            this.txt_search.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_search.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txt_search.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_search.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_search.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_search.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txt_search.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_search.Location = new System.Drawing.Point(4, 119);
            this.txt_search.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_search.Name = "txt_search";
            this.txt_search.PasswordChar = '\0';
            this.txt_search.PlaceholderText = "";
            this.txt_search.SelectedText = "";
            this.txt_search.Size = new System.Drawing.Size(361, 44);
            this.txt_search.TabIndex = 24;
            this.txt_search.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_thontin_KeyPress);
            // 
            // radio_ten
            // 
            this.radio_ten.AutoSize = true;
            this.radio_ten.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.radio_ten.CheckedState.BorderThickness = 0;
            this.radio_ten.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.radio_ten.CheckedState.InnerColor = System.Drawing.Color.White;
            this.radio_ten.CheckedState.InnerOffset = -4;
            this.radio_ten.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.radio_ten.Location = new System.Drawing.Point(35, 63);
            this.radio_ten.Margin = new System.Windows.Forms.Padding(4);
            this.radio_ten.Name = "radio_ten";
            this.radio_ten.Size = new System.Drawing.Size(130, 22);
            this.radio_ten.TabIndex = 21;
            this.radio_ten.Text = "Tên sản phẩm";
            this.radio_ten.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.radio_ten.UncheckedState.BorderThickness = 2;
            this.radio_ten.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.radio_ten.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            // 
            // hinh
            // 
            this.hinh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.hinh.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.hinh.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.hinh.ImageRotate = 0F;
            this.hinh.Location = new System.Drawing.Point(697, 291);
            this.hinh.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.hinh.Name = "hinh";
            this.hinh.Size = new System.Drawing.Size(151, 106);
            this.hinh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.hinh.TabIndex = 86;
            this.hinh.TabStop = false;
            // 
            // btn_sua
            // 
            this.btn_sua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_sua.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_sua.BorderRadius = 20;
            this.btn_sua.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_sua.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_sua.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_sua.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_sua.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_sua.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold);
            this.btn_sua.ForeColor = System.Drawing.Color.Black;
            this.btn_sua.Image = global::VatLieuXayDung.Properties.Resources.up_loading;
            this.btn_sua.Location = new System.Drawing.Point(1257, 306);
            this.btn_sua.Margin = new System.Windows.Forms.Padding(4);
            this.btn_sua.Name = "btn_sua";
            this.btn_sua.Size = new System.Drawing.Size(139, 57);
            this.btn_sua.TabIndex = 84;
            this.btn_sua.Text = "Cập nhật";
            this.btn_sua.Click += new System.EventHandler(this.btn_sua_Click);
            // 
            // btn_them
            // 
            this.btn_them.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_them.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_them.BorderRadius = 20;
            this.btn_them.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_them.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_them.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_them.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_them.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_them.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold);
            this.btn_them.ForeColor = System.Drawing.Color.Black;
            this.btn_them.Image = global::VatLieuXayDung.Properties.Resources.user_add;
            this.btn_them.Location = new System.Drawing.Point(1066, 306);
            this.btn_them.Margin = new System.Windows.Forms.Padding(4);
            this.btn_them.Name = "btn_them";
            this.btn_them.Size = new System.Drawing.Size(139, 57);
            this.btn_them.TabIndex = 85;
            this.btn_them.Text = "Thêm";
            this.btn_them.Click += new System.EventHandler(this.btn_them_Click);
            // 
            // btn_chonhinh
            // 
            this.btn_chonhinh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_chonhinh.AutoRoundedCorners = true;
            this.btn_chonhinh.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_chonhinh.BorderRadius = 22;
            this.btn_chonhinh.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_chonhinh.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_chonhinh.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_chonhinh.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_chonhinh.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_chonhinh.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.btn_chonhinh.ForeColor = System.Drawing.Color.Black;
            this.btn_chonhinh.Location = new System.Drawing.Point(538, 291);
            this.btn_chonhinh.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_chonhinh.Name = "btn_chonhinh";
            this.btn_chonhinh.Size = new System.Drawing.Size(88, 46);
            this.btn_chonhinh.TabIndex = 83;
            this.btn_chonhinh.Text = "Chọn Hình";
            this.btn_chonhinh.Click += new System.EventHandler(this.btn_chonhinh_Click);
            // 
            // cbm_tenloai
            // 
            this.cbm_tenloai.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbm_tenloai.AutoRoundedCorners = true;
            this.cbm_tenloai.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.cbm_tenloai.BorderRadius = 17;
            this.cbm_tenloai.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbm_tenloai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbm_tenloai.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbm_tenloai.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbm_tenloai.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbm_tenloai.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbm_tenloai.ItemHeight = 30;
            this.cbm_tenloai.Location = new System.Drawing.Point(641, 236);
            this.cbm_tenloai.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.cbm_tenloai.Name = "cbm_tenloai";
            this.cbm_tenloai.Size = new System.Drawing.Size(267, 36);
            this.cbm_tenloai.TabIndex = 82;
            this.cbm_tenloai.SelectedIndexChanged += new System.EventHandler(this.cbm_tenloai_SelectedIndexChanged);
            // 
            // cbm_trangthai
            // 
            this.cbm_trangthai.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbm_trangthai.AutoRoundedCorners = true;
            this.cbm_trangthai.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.cbm_trangthai.BorderRadius = 17;
            this.cbm_trangthai.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbm_trangthai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbm_trangthai.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbm_trangthai.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbm_trangthai.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbm_trangthai.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbm_trangthai.ItemHeight = 30;
            this.cbm_trangthai.Location = new System.Drawing.Point(641, 60);
            this.cbm_trangthai.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbm_trangthai.Name = "cbm_trangthai";
            this.cbm_trangthai.Size = new System.Drawing.Size(267, 36);
            this.cbm_trangthai.TabIndex = 81;
            // 
            // cbm_donvitinh
            // 
            this.cbm_donvitinh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbm_donvitinh.AutoRoundedCorners = true;
            this.cbm_donvitinh.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.cbm_donvitinh.BorderRadius = 17;
            this.cbm_donvitinh.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbm_donvitinh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbm_donvitinh.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbm_donvitinh.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbm_donvitinh.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbm_donvitinh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbm_donvitinh.ItemHeight = 30;
            this.cbm_donvitinh.Location = new System.Drawing.Point(163, 120);
            this.cbm_donvitinh.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbm_donvitinh.Name = "cbm_donvitinh";
            this.cbm_donvitinh.Size = new System.Drawing.Size(267, 36);
            this.cbm_donvitinh.TabIndex = 79;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label10.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label10.Location = new System.Drawing.Point(534, 234);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(71, 18);
            this.label10.TabIndex = 78;
            this.label10.Text = "Tên Loại";
            // 
            // txt_mota
            // 
            this.txt_mota.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_mota.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txt_mota.BorderRadius = 15;
            this.txt_mota.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_mota.DefaultText = "";
            this.txt_mota.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_mota.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txt_mota.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_mota.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_mota.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_mota.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txt_mota.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_mota.Location = new System.Drawing.Point(641, 126);
            this.txt_mota.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_mota.Name = "txt_mota";
            this.txt_mota.PasswordChar = '\0';
            this.txt_mota.PlaceholderText = "";
            this.txt_mota.SelectedText = "";
            this.txt_mota.Size = new System.Drawing.Size(267, 32);
            this.txt_mota.TabIndex = 77;
            this.txt_mota.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_thontin_KeyPress);
            // 
            // txt_thontin
            // 
            this.txt_thontin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_thontin.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txt_thontin.BorderRadius = 15;
            this.txt_thontin.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_thontin.DefaultText = "";
            this.txt_thontin.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_thontin.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txt_thontin.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_thontin.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_thontin.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_thontin.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txt_thontin.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_thontin.Location = new System.Drawing.Point(641, 181);
            this.txt_thontin.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_thontin.Name = "txt_thontin";
            this.txt_thontin.PasswordChar = '\0';
            this.txt_thontin.PlaceholderText = "";
            this.txt_thontin.SelectedText = "";
            this.txt_thontin.Size = new System.Drawing.Size(267, 34);
            this.txt_thontin.TabIndex = 76;
            this.txt_thontin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_thontin_KeyPress);
            // 
            // txt_gianhap
            // 
            this.txt_gianhap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_gianhap.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txt_gianhap.BorderRadius = 15;
            this.txt_gianhap.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_gianhap.DefaultText = "";
            this.txt_gianhap.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_gianhap.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txt_gianhap.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_gianhap.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_gianhap.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_gianhap.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txt_gianhap.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_gianhap.Location = new System.Drawing.Point(164, 237);
            this.txt_gianhap.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_gianhap.Name = "txt_gianhap";
            this.txt_gianhap.PasswordChar = '\0';
            this.txt_gianhap.PlaceholderText = "";
            this.txt_gianhap.SelectedText = "";
            this.txt_gianhap.Size = new System.Drawing.Size(267, 34);
            this.txt_gianhap.TabIndex = 75;
            this.txt_gianhap.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_thontin_KeyPress);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(534, 187);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 18);
            this.label3.TabIndex = 74;
            this.label3.Text = "Thông tin";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(534, 127);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 18);
            this.label5.TabIndex = 73;
            this.label5.Text = "Mô tả";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label7.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(534, 71);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 18);
            this.label7.TabIndex = 72;
            this.label7.Text = "Tình trạng";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label8.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(26, 249);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 18);
            this.label8.TabIndex = 71;
            this.label8.Text = "Giá nhập";
            // 
            // txt_gia_ban
            // 
            this.txt_gia_ban.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_gia_ban.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txt_gia_ban.BorderRadius = 15;
            this.txt_gia_ban.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_gia_ban.DefaultText = "";
            this.txt_gia_ban.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_gia_ban.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txt_gia_ban.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_gia_ban.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_gia_ban.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_gia_ban.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txt_gia_ban.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_gia_ban.Location = new System.Drawing.Point(163, 181);
            this.txt_gia_ban.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_gia_ban.Name = "txt_gia_ban";
            this.txt_gia_ban.PasswordChar = '\0';
            this.txt_gia_ban.PlaceholderText = "";
            this.txt_gia_ban.SelectedText = "";
            this.txt_gia_ban.Size = new System.Drawing.Size(267, 34);
            this.txt_gia_ban.TabIndex = 70;
            this.txt_gia_ban.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_thontin_KeyPress);
            // 
            // txt_ten_sp
            // 
            this.txt_ten_sp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_ten_sp.Animated = true;
            this.txt_ten_sp.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txt_ten_sp.BorderRadius = 15;
            this.txt_ten_sp.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_ten_sp.DefaultText = "";
            this.txt_ten_sp.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_ten_sp.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txt_ten_sp.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_ten_sp.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_ten_sp.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_ten_sp.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txt_ten_sp.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_ten_sp.Location = new System.Drawing.Point(163, 62);
            this.txt_ten_sp.Margin = new System.Windows.Forms.Padding(4);
            this.txt_ten_sp.Name = "txt_ten_sp";
            this.txt_ten_sp.PasswordChar = '\0';
            this.txt_ten_sp.PlaceholderText = "";
            this.txt_ten_sp.SelectedText = "";
            this.txt_ten_sp.Size = new System.Drawing.Size(267, 39);
            this.txt_ten_sp.TabIndex = 69;
            this.txt_ten_sp.TextChanged += new System.EventHandler(this.txt_ten_sp_TextChanged);
            this.txt_ten_sp.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_thontin_KeyPress);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(26, 193);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 18);
            this.label6.TabIndex = 68;
            this.label6.Text = "Giá bán";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(26, 131);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 18);
            this.label2.TabIndex = 66;
            this.label2.Text = "Đơn vị tính";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(26, 71);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 18);
            this.label1.TabIndex = 65;
            this.label1.Text = "Tên sản phẩm";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // guna2AnimateWindow1
            // 
            this.guna2AnimateWindow1.TargetForm = this;
            // 
            // frm_SanPham
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1595, 742);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frm_SanPham";
            this.Text = "frm_SanPham";
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.data_view_sanpham)).EndInit();
            this.guna2CustomGradientPanel1.ResumeLayout(false);
            this.guna2CustomGradientPanel1.PerformLayout();
            this.gunaGroupBox1.ResumeLayout(false);
            this.gunaGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hinh)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        public Guna.UI2.WinForms.Guna2DataGridView data_view_sanpham;
        private Guna.UI2.WinForms.Guna2CustomGradientPanel guna2CustomGradientPanel1;
        private System.Windows.Forms.Label lab_hinh;
        private Guna.UI.WinForms.GunaGroupBox gunaGroupBox1;
        private Guna.UI2.WinForms.Guna2RadioButton radio_giaban;
        private Guna.UI2.WinForms.Guna2RadioButton radio_sosao;
        private Guna.UI2.WinForms.Guna2Button btn_search;
        private Guna.UI2.WinForms.Guna2TextBox txt_search;
        private Guna.UI2.WinForms.Guna2RadioButton radio_ten;
        private Guna.UI2.WinForms.Guna2PictureBox hinh;
        private Guna.UI2.WinForms.Guna2Button btn_sua;
        private Guna.UI2.WinForms.Guna2Button btn_them;
        private Guna.UI2.WinForms.Guna2Button btn_chonhinh;
        private Guna.UI2.WinForms.Guna2ComboBox cbm_tenloai;
        private Guna.UI2.WinForms.Guna2ComboBox cbm_trangthai;
        private Guna.UI2.WinForms.Guna2ComboBox cbm_donvitinh;
        private System.Windows.Forms.Label label10;
        private Guna.UI2.WinForms.Guna2TextBox txt_mota;
        private Guna.UI2.WinForms.Guna2TextBox txt_thontin;
        private Guna.UI2.WinForms.Guna2TextBox txt_gianhap;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private Guna.UI2.WinForms.Guna2TextBox txt_gia_ban;
        private Guna.UI2.WinForms.Guna2TextBox txt_ten_sp;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private Guna.UI2.WinForms.Guna2AnimateWindow guna2AnimateWindow1;
    }
}