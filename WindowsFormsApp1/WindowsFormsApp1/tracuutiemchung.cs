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
    public partial class tracuutiemchung : Form
    {
        public tracuutiemchung()
        {
            InitializeComponent();

            string connString = @"Data Source=" + nachos.servername + ";Initial Catalog=" + nachos.dbname + ";Integrated Security=True;" + "UID=" + nachos.username.Trim() + "password=" + nachos.password.Trim();
            nachos.sqlCon = new SqlConnection(connString);

            SqlCommand cmd = new SqlCommand("select ma_pdkt from phieudktiem where ma_kh = '" + textBox1.Text + "' ", nachos.sqlCon);
            SqlDataAdapter adapt = new SqlDataAdapter();
            adapt.SelectCommand = cmd;
            DataTable table = new DataTable();
            adapt.Fill(table);
            comboBox1.DataSource = table;
            comboBox1.DisplayMember = "ten_tt";
            comboBox1.ValueMember = "ma_tt";
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

            SqlDataAdapter adapt3 = new SqlDataAdapter("SELECT * from khachhang where ma_kh = '" + textBox1.Text + "' ", nachos.sqlCon);
            DataTable table3 = new DataTable();
            adapt3.Fill(table3);
            dataGridView1.DataSource = new BindingSource(table3, null);

            SqlDataAdapter adapt2 = new SqlDataAdapter("SELECT * from nguoigiamho where ma_kh = '" + textBox1.Text + "' ", nachos.sqlCon);
            DataTable table2 = new DataTable();
            adapt2.Fill(table2);
            dataGridView2.DataSource = new BindingSource(table3, null);

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

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
