using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class MHnhapGiaVacXin : Form
    {
        public MHnhapGiaVacXin()
        {
            InitializeComponent();
            tenVXlbl.Text = nachos.tenVacXin;
        }

        private void confirmBtn_Click(object sender, EventArgs e)
        {
            nachos.giaTien = Double.Parse(giaTienInput.Text);
            this.Hide();
            this.Close();
        }
    }
}
