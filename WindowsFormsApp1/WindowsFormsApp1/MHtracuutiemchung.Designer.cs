
namespace WindowsFormsApp1
{
    partial class MHtracuutiemchung
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
            this.label20 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Makh = new System.Windows.Forms.TextBox();
            this.Phieudktiem = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.Hosobenhan = new System.Windows.Forms.DataGridView();
            this.Phieutiemchung = new System.Windows.Forms.DataGridView();
            this.Tracuutiemchung = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Nguoigiamho = new System.Windows.Forms.DataGridView();
            this.Khachhang = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.Hosobenhan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Phieutiemchung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Nguoigiamho)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Khachhang)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(162, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(263, 31);
            this.label1.TabIndex = 3;
            this.label1.Text = "Tra cứu tiêm chủng";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(43, 85);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(99, 13);
            this.label20.TabIndex = 129;
            this.label20.Text = "Mã khách hàng:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(21, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(178, 17);
            this.label2.TabIndex = 113;
            this.label2.Text = "1. Thông tin bệnh nhân";
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label41.Location = new System.Drawing.Point(29, 295);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(133, 17);
            this.label41.TabIndex = 133;
            this.label41.Text = "2. Hồ sơ bệnh án";
            this.label41.Click += new System.EventHandler(this.label41_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(46, 479);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(161, 17);
            this.label12.TabIndex = 152;
            this.label12.Text = "Thông tin tiêm chủng";
            this.label12.Click += new System.EventHandler(this.label12_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(51, 323);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 13);
            this.label3.TabIndex = 153;
            this.label3.Text = "Mã phiếu tiêm chủng:";
            // 
            // Makh
            // 
            this.Makh.Location = new System.Drawing.Point(141, 82);
            this.Makh.Name = "Makh";
            this.Makh.Size = new System.Drawing.Size(128, 20);
            this.Makh.TabIndex = 154;
            // 
            // Phieudktiem
            // 
            this.Phieudktiem.FormattingEnabled = true;
            this.Phieudktiem.Location = new System.Drawing.Point(182, 318);
            this.Phieudktiem.Name = "Phieudktiem";
            this.Phieudktiem.Size = new System.Drawing.Size(99, 21);
            this.Phieudktiem.TabIndex = 155;
            this.Phieudktiem.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(275, 79);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 156;
            this.button1.Text = "Tra cứu";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Hosobenhan
            // 
            this.Hosobenhan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Hosobenhan.Location = new System.Drawing.Point(46, 364);
            this.Hosobenhan.Name = "Hosobenhan";
            this.Hosobenhan.Size = new System.Drawing.Size(504, 106);
            this.Hosobenhan.TabIndex = 158;
            this.Hosobenhan.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Phieutiemchung
            // 
            this.Phieutiemchung.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Phieutiemchung.Location = new System.Drawing.Point(48, 505);
            this.Phieutiemchung.Name = "Phieutiemchung";
            this.Phieutiemchung.Size = new System.Drawing.Size(504, 100);
            this.Phieutiemchung.TabIndex = 159;
            // 
            // Tracuutiemchung
            // 
            this.Tracuutiemchung.Location = new System.Drawing.Point(287, 316);
            this.Tracuutiemchung.Name = "Tracuutiemchung";
            this.Tracuutiemchung.Size = new System.Drawing.Size(75, 23);
            this.Tracuutiemchung.TabIndex = 160;
            this.Tracuutiemchung.Text = "Tra cứu";
            this.Tracuutiemchung.UseVisualStyleBackColor = true;
            this.Tracuutiemchung.Click += new System.EventHandler(this.button2_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(44, 344);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(141, 17);
            this.label4.TabIndex = 161;
            this.label4.Text = "Thông tin bệnh án";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(44, 187);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(226, 13);
            this.label5.TabIndex = 163;
            this.label5.Text = "*Nếu bạn dưới 18 tuổi, thông tin người giám hộ";
            // 
            // Nguoigiamho
            // 
            this.Nguoigiamho.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Nguoigiamho.Location = new System.Drawing.Point(46, 207);
            this.Nguoigiamho.Name = "Nguoigiamho";
            this.Nguoigiamho.Size = new System.Drawing.Size(504, 76);
            this.Nguoigiamho.TabIndex = 164;
            // 
            // Khachhang
            // 
            this.Khachhang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Khachhang.Location = new System.Drawing.Point(46, 108);
            this.Khachhang.Name = "Khachhang";
            this.Khachhang.Size = new System.Drawing.Size(504, 71);
            this.Khachhang.TabIndex = 162;
            // 
            // MHtracuutiemchung
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 633);
            this.Controls.Add(this.Nguoigiamho);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Khachhang);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Tracuutiemchung);
            this.Controls.Add(this.Phieutiemchung);
            this.Controls.Add(this.Hosobenhan);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Phieudktiem);
            this.Controls.Add(this.Makh);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label41);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "MHtracuutiemchung";
            this.Text = "Tra cứu tiêm chủng";
            this.Load += new System.EventHandler(this.tracuutiemchung_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Hosobenhan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Phieutiemchung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Nguoigiamho)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Khachhang)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Makh;
        private System.Windows.Forms.ComboBox Phieudktiem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView Hosobenhan;
        private System.Windows.Forms.DataGridView Phieutiemchung;
        private System.Windows.Forms.Button Tracuutiemchung;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView Nguoigiamho;
        private System.Windows.Forms.DataGridView Khachhang;
    }
}