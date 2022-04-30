﻿using System;
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
    public partial class dangkytiemchung : Form
    {
        public dangkytiemchung()
        {
            InitializeComponent();

            string connString = @"Data Source=" + nachos.servername + ";Initial Catalog=" + nachos.dbname + ";Integrated Security=True;" + "UID=" + nachos.username.Trim() + "password=" + nachos.password.Trim();
            nachos.sqlCon = new SqlConnection(connString);

            SqlCommand cmd = new SqlCommand("select ten_tt, ma_tt from trungtam", nachos.sqlCon);
            SqlDataAdapter adapt = new SqlDataAdapter();
            adapt.SelectCommand = cmd;
            DataTable table = new DataTable();
            adapt.Fill(table);
            comboBox5.DataSource = table;
            comboBox5.DisplayMember = "ten_tt";
            comboBox5.ValueMember = "ma_tt";

            SqlDataAdapter adapt1 = new SqlDataAdapter();
            adapt1.SelectCommand = cmd;
            DataTable table1 = new DataTable();
            adapt1.Fill(table1);
            comboBox1.DataSource = table1;
            comboBox1.DisplayMember = "ten_tt";
            comboBox1.ValueMember = "ma_tt";

            maskedTextBox1.Mask = "00/00/0000";
            maskedTextBox1.ValidatingType = typeof(System.DateTime);
            maskedTextBox2.Mask = "00/00/0000";
            maskedTextBox2.ValidatingType = typeof(System.DateTime);
            ngaytiem.Mask = "00/00/0000";
            ngaytiem.ValidatingType = typeof(System.DateTime);
            disableShowInfoToRegister();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label29_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            nachos.sqlCon.Open();
            object selecteditem = comboBox5.SelectedValue;
            string trungtam = selecteditem.ToString();
            SqlCommand cmd2 = new SqlCommand("select GOIVACXIN.MA_GVX, ten_gvx from goivacxin, kho where KHO.ma_tt = '" + trungtam + "' ", nachos.sqlCon);
            SqlDataAdapter adapt4 = new SqlDataAdapter();
            adapt4.SelectCommand = cmd2;
            DataTable table4 = new DataTable();
            adapt4.Fill(table4);
            vacxin.DataSource = table4;
            vacxin.DisplayMember = "MA_GVX";
            vacxin.ValueMember = "MA_GVX";
            nachos.sqlCon.Close();
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            nachos.sqlCon.Open();
            object selecteditem = comboBox1.SelectedValue;
            string trungtam = selecteditem.ToString();
            SqlDataAdapter adapt1 = new SqlDataAdapter("SELECT * from goivacxin, kho where ma_tt = '" + trungtam + "' and LOAI_GVX != 0", nachos.sqlCon);
            DataTable table1 = new DataTable();
            adapt1.Fill(table1);
            dataGridView2.DataSource = new BindingSource(table1, null);

            SqlDataAdapter adapt3 = new SqlDataAdapter("SELECT * from goivacxin, kho where ma_tt = '" + trungtam + "' and LOAI_GVX = 0", nachos.sqlCon);
            DataTable table3 = new DataTable();
            adapt3.Fill(table3);
            dataGridView1.DataSource = new BindingSource(table3, null);
            nachos.sqlCon.Close();
        }

        private void dangkytiemchung_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*try
            {
                nachos.sqlCon.Open();

                object selecteditem = comboBox5.SelectedValue;
                string trungtam = selecteditem.ToString();

                var strSQLCommand = "EXEC dbo.INSERT_PDKT 'DK003', '" + makh.Text + "', '" + ngaytiem.Text + "', '" + trungtam + "', '" + textBox8.Text + "' ";  // statement is wrong! will raise an exception
                var command = new SqlCommand(strSQLCommand, nachos.sqlCon);
                command.ExecuteNonQuery();
                nachos.sqlCon.Close();
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show(sqlEx.Message);
            }*/
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            datmuavacxin them = new datmuavacxin();
            them.ShowDialog();
            this.Close();
        }

        private void showInfoToRegister()
        {
            label5.Show();
            textBox1.Show();
            label6.Show();
            maskedTextBox1.Show();
            label8.Show();
            textBox3.Show();
            textBox2.Show();
            label9.Show();
            textBox7.Show();
            label7.Show();

            label20.Hide();
            makh.Hide();
        }

        private void disableShowInfoToRegister()
        {
            label5.Hide();
            textBox1.Hide();
            label6.Hide();
            maskedTextBox1.Hide();
            label8.Hide();
            textBox3.Hide();
            textBox2.Hide();
            label9.Hide();
            textBox7.Hide();
            label7.Hide();
            label20.Show();
            makh.Show();

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                showInfoToRegister();
            }
            else
            {
                disableShowInfoToRegister();
            }
        }
    }
}
