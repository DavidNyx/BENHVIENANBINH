
namespace WindowsFormsApp1
{
    partial class MHDatHangVacXin
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
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.danhsachxetduyet = new System.Windows.Forms.DataGridView();
            this.Xetduyet = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.Lapphieudathang = new System.Windows.Forms.Button();
            this.nhacungcapvx = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.maPhieuDM = new System.Windows.Forms.Label();
            this.tenVX = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.nhaCungCap = new System.Windows.Forms.Label();
            this.Phieudathang = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.danhsachxetduyet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nhacungcapvx)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Phieudathang)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(261, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(447, 31);
            this.label1.TabIndex = 2;
            this.label1.Text = "Lập danh sách nhập hàng vắc xin";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(256, 17);
            this.label3.TabIndex = 37;
            this.label3.Text = "1. Đặt mua vắc xin ngoài hệ thống";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(24, 80);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(94, 13);
            this.label14.TabIndex = 99;
            this.label14.Text = "*Danh sách lọc";
            // 
            // danhsachxetduyet
            // 
            this.danhsachxetduyet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.danhsachxetduyet.Location = new System.Drawing.Point(27, 96);
            this.danhsachxetduyet.Name = "danhsachxetduyet";
            this.danhsachxetduyet.RowHeadersWidth = 51;
            this.danhsachxetduyet.Size = new System.Drawing.Size(240, 272);
            this.danhsachxetduyet.TabIndex = 100;
            this.danhsachxetduyet.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // Xetduyet
            // 
            this.Xetduyet.Location = new System.Drawing.Point(193, 374);
            this.Xetduyet.Name = "Xetduyet";
            this.Xetduyet.Size = new System.Drawing.Size(75, 23);
            this.Xetduyet.TabIndex = 104;
            this.Xetduyet.Text = "Xét duyệt";
            this.Xetduyet.UseVisualStyleBackColor = true;
            this.Xetduyet.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(325, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(167, 17);
            this.label2.TabIndex = 105;
            this.label2.Text = "2. Chọn nhà cung cấp";
            // 
            // Lapphieudathang
            // 
            this.Lapphieudathang.Location = new System.Drawing.Point(470, 374);
            this.Lapphieudathang.Name = "Lapphieudathang";
            this.Lapphieudathang.Size = new System.Drawing.Size(98, 23);
            this.Lapphieudathang.TabIndex = 108;
            this.Lapphieudathang.Text = "Lập phiếu nhập hàng";
            this.Lapphieudathang.UseVisualStyleBackColor = true;
            this.Lapphieudathang.Click += new System.EventHandler(this.button2_Click);
            // 
            // nhacungcapvx
            // 
            this.nhacungcapvx.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.nhacungcapvx.Location = new System.Drawing.Point(328, 80);
            this.nhacungcapvx.Name = "nhacungcapvx";
            this.nhacungcapvx.RowHeadersWidth = 51;
            this.nhacungcapvx.Size = new System.Drawing.Size(240, 288);
            this.nhacungcapvx.TabIndex = 110;
            this.nhacungcapvx.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentClick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(605, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(168, 17);
            this.label5.TabIndex = 113;
            this.label5.Text = "3. Lập phiếu đặt hàng";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(27, 417);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(125, 17);
            this.label7.TabIndex = 115;
            this.label7.Text = "Mã phiếu đặt mua:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(28, 446);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(85, 17);
            this.label8.TabIndex = 116;
            this.label8.Text = "Tên vắc-xin:";
            // 
            // maPhieuDM
            // 
            this.maPhieuDM.AutoSize = true;
            this.maPhieuDM.Location = new System.Drawing.Point(142, 420);
            this.maPhieuDM.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.maPhieuDM.Name = "maPhieuDM";
            this.maPhieuDM.Size = new System.Drawing.Size(0, 13);
            this.maPhieuDM.TabIndex = 117;
            // 
            // tenVX
            // 
            this.tenVX.AutoSize = true;
            this.tenVX.Location = new System.Drawing.Point(107, 449);
            this.tenVX.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.tenVX.Name = "tenVX";
            this.tenVX.Size = new System.Drawing.Size(0, 13);
            this.tenVX.TabIndex = 118;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(328, 406);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(131, 17);
            this.label4.TabIndex = 119;
            this.label4.Text = "Tên nhà cung cấp: ";
            // 
            // nhaCungCap
            // 
            this.nhaCungCap.AutoSize = true;
            this.nhaCungCap.Location = new System.Drawing.Point(446, 410);
            this.nhaCungCap.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.nhaCungCap.Name = "nhaCungCap";
            this.nhaCungCap.Size = new System.Drawing.Size(0, 13);
            this.nhaCungCap.TabIndex = 120;
            // 
            // Phieudathang
            // 
            this.Phieudathang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Phieudathang.Location = new System.Drawing.Point(608, 80);
            this.Phieudathang.Margin = new System.Windows.Forms.Padding(2);
            this.Phieudathang.Name = "Phieudathang";
            this.Phieudathang.RowHeadersWidth = 51;
            this.Phieudathang.RowTemplate.Height = 24;
            this.Phieudathang.Size = new System.Drawing.Size(272, 62);
            this.Phieudathang.TabIndex = 121;
            // 
            // MHDatHangVacXin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(903, 500);
            this.Controls.Add(this.Phieudathang);
            this.Controls.Add(this.nhaCungCap);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tenVX);
            this.Controls.Add(this.maPhieuDM);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.nhacungcapvx);
            this.Controls.Add(this.Lapphieudathang);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Xetduyet);
            this.Controls.Add(this.danhsachxetduyet);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "MHDatHangVacXin";
            this.Text = "Duyệt danh sách đặt hàng vắc xin";
            this.Load += new System.EventHandler(this.duyetvacxin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.danhsachxetduyet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nhacungcapvx)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Phieudathang)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DataGridView danhsachxetduyet;
        private System.Windows.Forms.Button Xetduyet;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Lapphieudathang;
        private System.Windows.Forms.DataGridView nhacungcapvx;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label maPhieuDM;
        private System.Windows.Forms.Label tenVX;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label nhaCungCap;
        private System.Windows.Forms.DataGridView Phieudathang;
    }
}