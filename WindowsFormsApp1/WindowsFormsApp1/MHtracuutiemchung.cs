using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    public partial class MHtracuutiemchung : Form
    {
        public MHtracuutiemchung()
        {
            InitializeComponent();

            string connString = @"Data Source=" + nachos.servername + ";Initial Catalog=" + nachos.dbname + ";Integrated Security=True;" + "UID=" + nachos.username.Trim() + "password=" + nachos.password.Trim();
            nachos.sqlCon = new SqlConnection(connString);
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void tracuutiemchung_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            nachos.sqlCon.Open();
            khachhang.makhachhang = Makh.Text;

            SqlDataAdapter adapt3 = new SqlDataAdapter("SELECT * from khachhang where ma_kh = '" + khachhang.makhachhang + "' ", nachos.sqlCon);
            DataTable table3 = new DataTable();
            adapt3.Fill(table3);
            Khachhang.DataSource = new BindingSource(table3, null);

            SqlDataAdapter adapt2 = new SqlDataAdapter("SELECT * from nguoigiamho where ma_kh = '" + khachhang.makhachhang + "' ", nachos.sqlCon);
            DataTable table2 = new DataTable();
            adapt2.Fill(table2);
            Nguoigiamho.DataSource = new BindingSource(table2, null);

            SqlCommand cmd = new SqlCommand("select ma_pdkt from phieudktiem where ma_kh = '" + khachhang.makhachhang + "' ", nachos.sqlCon);
            SqlDataAdapter adapt = new SqlDataAdapter();
            adapt.SelectCommand = cmd;
            DataTable table = new DataTable();
            adapt.Fill(table);
            Phieudktiem.DataSource = table;
            Phieudktiem.DisplayMember = "ma_pdkt";
            Phieudktiem.ValueMember = "ma_pdkt";

            nachos.sqlCon.Close();
        }

        private void label41_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            nachos.sqlCon.Open();

            object selecteditem = Phieudktiem.SelectedValue;
            phieudangkytiem.maphieudangkytiem = selecteditem.ToString();

            SqlDataAdapter adapt3 = new SqlDataAdapter("SELECT * from HOSOBENHAN where MA_PDKT = '" + phieudangkytiem.maphieudangkytiem + "' ", nachos.sqlCon);
            DataTable table3 = new DataTable();
            adapt3.Fill(table3);
            Hosobenhan.DataSource = new BindingSource(table3, null);

            SqlDataAdapter adapt2 = new SqlDataAdapter("SELECT * from phieudktiem where MA_PDKT = '" + phieudangkytiem.maphieudangkytiem + "' ", nachos.sqlCon);
            DataTable table2 = new DataTable();
            adapt2.Fill(table2);
            Phieutiemchung.DataSource = new BindingSource(table2, null);

            nachos.sqlCon.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
