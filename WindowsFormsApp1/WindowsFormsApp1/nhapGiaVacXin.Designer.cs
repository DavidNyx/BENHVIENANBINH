namespace WindowsFormsApp1
{
    partial class nhapGiaVacXin
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
            this.tenVX = new System.Windows.Forms.Label();
            this.giaTien = new System.Windows.Forms.Label();
            this.giaTienInput = new System.Windows.Forms.TextBox();
            this.tenVXlbl = new System.Windows.Forms.Label();
            this.confirmBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tenVX
            // 
            this.tenVX.AutoSize = true;
            this.tenVX.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenVX.Location = new System.Drawing.Point(77, 44);
            this.tenVX.Name = "tenVX";
            this.tenVX.Size = new System.Drawing.Size(100, 20);
            this.tenVX.TabIndex = 0;
            this.tenVX.Text = "Tên vắc-xin:";
            // 
            // giaTien
            // 
            this.giaTien.AutoSize = true;
            this.giaTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.giaTien.Location = new System.Drawing.Point(78, 97);
            this.giaTien.Name = "giaTien";
            this.giaTien.Size = new System.Drawing.Size(72, 20);
            this.giaTien.TabIndex = 1;
            this.giaTien.Text = "Giá tiền:";
            // 
            // giaTienInput
            // 
            this.giaTienInput.Location = new System.Drawing.Point(156, 97);
            this.giaTienInput.Name = "giaTienInput";
            this.giaTienInput.Size = new System.Drawing.Size(127, 22);
            this.giaTienInput.TabIndex = 2;
            // 
            // tenVXlbl
            // 
            this.tenVXlbl.AutoSize = true;
            this.tenVXlbl.Location = new System.Drawing.Point(184, 47);
            this.tenVXlbl.Name = "tenVXlbl";
            this.tenVXlbl.Size = new System.Drawing.Size(0, 16);
            this.tenVXlbl.TabIndex = 3;
            // 
            // confirmBtn
            // 
            this.confirmBtn.Location = new System.Drawing.Point(175, 136);
            this.confirmBtn.Name = "confirmBtn";
            this.confirmBtn.Size = new System.Drawing.Size(75, 23);
            this.confirmBtn.TabIndex = 4;
            this.confirmBtn.Text = "Xác nhận";
            this.confirmBtn.UseVisualStyleBackColor = true;
            this.confirmBtn.Click += new System.EventHandler(this.confirmBtn_Click);
            // 
            // nhapGiaVacXin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 181);
            this.Controls.Add(this.confirmBtn);
            this.Controls.Add(this.tenVXlbl);
            this.Controls.Add(this.giaTienInput);
            this.Controls.Add(this.giaTien);
            this.Controls.Add(this.tenVX);
            this.Name = "nhapGiaVacXin";
            this.Text = "nhapGiaVacXin";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label tenVX;
        private System.Windows.Forms.Label giaTien;
        private System.Windows.Forms.TextBox giaTienInput;
        private System.Windows.Forms.Label tenVXlbl;
        private System.Windows.Forms.Button confirmBtn;
    }
}