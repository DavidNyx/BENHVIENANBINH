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
    public partial class datmuavacxin : Form
    {
        public datmuavacxin()
        {
            InitializeComponent();

            string connString = @"Data Source=" + nachos.servername + ";Initial Catalog=" + nachos.dbname + ";Integrated Security=True;" + "UID=" + nachos.username.Trim() + "password=" + nachos.password.Trim();
            nachos.sqlCon = new SqlConnection(connString);

            SqlCommand cmd = new SqlCommand("select ten_tt, ma_tt from trungtam", nachos.sqlCon);
            SqlDataAdapter adapt = new SqlDataAdapter();
            adapt.SelectCommand = cmd;
            DataTable table = new DataTable();
            adapt.Fill(table);
            comboBox4.DataSource = table;
            comboBox4.DisplayMember = "ten_tt";
            comboBox4.ValueMember = "ma_tt";

            maskedTextBox1.Mask = "00/00/0000";
            maskedTextBox1.ValidatingType = typeof(System.DateTime);
            maskedTextBox2.Mask = "00/00/0000";
            maskedTextBox2.ValidatingType = typeof(System.DateTime);
            maskedTextBox3.Mask = "00/00/0000";
            maskedTextBox3.ValidatingType = typeof(System.DateTime);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label27_Click(object sender, EventArgs e)
        {

        }

        private void maskedTextBox3_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void datmuavacxin_Load(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void label27_Click_1(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            nachos.sqlCon.Open();

            object selecteditem = comboBox4.SelectedValue;
            string trungtam = selecteditem.ToString();

            SqlCommand cmd1 = new SqlCommand("select GOIVACXIN.MA_GVX, ten_gvx from goivacxin, kho where soluongton = 0 and ma_tt= '" + trungtam + "' ", nachos.sqlCon);
            SqlDataAdapter adapt1 = new SqlDataAdapter();
            adapt1.SelectCommand = cmd1;
            DataTable table1 = new DataTable();
            adapt1.Fill(table1);
            comboBox2.DataSource = table1;
            comboBox2.DisplayMember = "MA_GVX";
            comboBox2.ValueMember = "MA_GVX";

            nachos.sqlCon.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            nachos.sqlCon.Open();

            SqlDataAdapter adapt3 = new SqlDataAdapter("SELECT * from goivacxin, kho, kho where soluongton = 0 and LOAI_GVX = 0", nachos.sqlCon);
            DataTable table3 = new DataTable();
            adapt3.Fill(table3);
            dataGridView1.DataSource = new BindingSource(table3, null);

            SqlDataAdapter adapt4 = new SqlDataAdapter("SELECT * from goivacxin, kho, kho where soluongton = 0 and LOAI_GVX != 0", nachos.sqlCon);
            DataTable table4 = new DataTable();
            adapt4.Fill(table4);
            dataGridView2.DataSource = new BindingSource(table4, null);

            nachos.sqlCon.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
