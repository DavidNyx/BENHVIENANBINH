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
            ngaytiem.Mask = "00/00/0000";
            ngaytiem.ValidatingType = typeof(System.DateTime);
            disableShowInfoToRegister();
            disableShowInfoUnder18ToRegister();
            disableShowInfoVacxin();
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
            comboBox2.DisplayMember = "TEN_GVX";
            comboBox2.ValueMember = "MA_GVX";

            nachos.sqlCon.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            nachos.sqlCon.Open();

            SqlDataAdapter adapt3 = new SqlDataAdapter("SELECT * from goivacxin, kho where soluongton = 0 and LOAI_GVX = 0", nachos.sqlCon);
            DataTable table3 = new DataTable();
            adapt3.Fill(table3);
            dataGridView1.DataSource = new BindingSource(table3, null);

            SqlDataAdapter adapt4 = new SqlDataAdapter("SELECT * from goivacxin, kho where soluongton = 0 and LOAI_GVX != 0", nachos.sqlCon);
            DataTable table4 = new DataTable();
            adapt4.Fill(table4);
            dataGridView2.DataSource = new BindingSource(table4, null);

            nachos.sqlCon.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void showInfoToRegister()
        {
            label10.Show();
            hoten.Show();
            label6.Show();
            maskedTextBox1.Show();
            label8.Show();
            textBox3.Show();
            label7.Show();
            textBox2.Show();
            label9.Show();
            textBox7.Show();

            label20.Hide();
            makh.Hide();
        }

        private void disableShowInfoToRegister()
        {
            label10.Hide();
            hoten.Hide();
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

        private void showInfoUnder18ToRegister()
        {
            label25.Show();
            textBox6.Show();
            label24.Show();
            textBox6.Show();
            maskedTextBox2.Show();
            label23.Show();
            label22.Show();
            textBox4.Show();
            textBox5.Show();
        }
        private void disableShowInfoUnder18ToRegister()
        {
            label25.Hide();
            textBox6.Hide();
            label23.Hide();
            textBox6.Hide();
            maskedTextBox2.Hide();
            label24.Hide();
            label22.Hide();
            textBox4.Hide();
            textBox5.Hide();
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

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                showInfoUnder18ToRegister();
            }
            else
            {
                disableShowInfoUnder18ToRegister();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            nachos.sqlCon.Open();
            if (!checkBox1.Checked)
            {
                if (checkBox3.Checked)
                {
                    try
                    {
                        object selecteditem = comboBox4.SelectedValue;
                        string trungtam = selecteditem.ToString();
                        object selecteditem2 = comboBox2.SelectedValue;
                        string goivacxin = selecteditem2.ToString();
                        SqlCommand sqlCommand = new SqlCommand("SELECT COUNT(*) FROM PHIEUDKTIEM", nachos.sqlCon);
                        int num = (Int32)sqlCommand.ExecuteScalar();
                        num += 1;

                        var strSQLCommand = "EXEC dbo.INSERT_PDKT 'DK" + num.ToString() + "', '" + makh.Text + "', '" + ngaytiem.Text + "', '" + trungtam + "', '" + goivacxin + "'";  // statement is wrong! will raise an exception
                        var command = new SqlCommand(strSQLCommand, nachos.sqlCon);
                        command.ExecuteNonQuery();

                        sqlCommand = new SqlCommand("SELECT COUNT(*) FROM PHIEUDATMUAVX", nachos.sqlCon);
                        int numOrder = (Int32)sqlCommand.ExecuteScalar();
                        numOrder += 1;

                        sqlCommand = new SqlCommand("SELECT TEN_GVX FROM GOIVACXIN WHERE MA_GVX='" + goivacxin + "'", nachos.sqlCon);
                        String vacxinName = (String)sqlCommand.ExecuteScalar();
                        
                        strSQLCommand = "EXEC dbo.INSERT_PDMVX 'DM" + numOrder.ToString() + "', 'DK" + num.ToString() + "', '" + goivacxin + "', '" + vacxinName + "'";  // statement is wrong! will raise an exception
                        command = new SqlCommand(strSQLCommand, nachos.sqlCon);
                        command.ExecuteNonQuery();
                    }
                    catch (SqlException sqlEx)
                    {
                        MessageBox.Show(sqlEx.Message);
                    }

                }
                else
                {
                    try
                    {
                        object selecteditem = comboBox4.SelectedValue;
                        string trungtam = selecteditem.ToString();

                        SqlCommand sqlCommand = new SqlCommand("SELECT COUNT(*) FROM PHIEUDKTIEM", nachos.sqlCon);
                        int num = (Int32)sqlCommand.ExecuteScalar();
                        num += 1;

                        var strSQLCommand = "EXEC dbo.INSERT_PDKT 'DK" + num.ToString() + "', '" + makh.Text + "', '" + ngaytiem.Text + "', '" + trungtam + "', null";  // statement is wrong! will raise an exception
                        var command = new SqlCommand(strSQLCommand, nachos.sqlCon);
                        command.ExecuteNonQuery();

                        sqlCommand = new SqlCommand("SELECT COUNT(*) FROM PHIEUDATMUAVX", nachos.sqlCon);
                        int numOrder = (Int32)sqlCommand.ExecuteScalar();
                        numOrder += 1;

                        strSQLCommand = "EXEC dbo.INSERT_PDMVX 'DM" + numOrder.ToString() + "', 'DK" + num.ToString() + "', null, '" + textBox1.Text + "'";  // statement is wrong! will raise an exception
                        command = new SqlCommand(strSQLCommand, nachos.sqlCon);
                        command.ExecuteNonQuery();
                    }
                    
                    catch (SqlException sqlEx)
                    {
                        MessageBox.Show(sqlEx.Message);
                    }
                    MessageBox.Show("Đặt mua vacxin thành công");
                }
            }
            else
            {
                if (checkBox3.Checked)
                {
                    SqlCommand sqlCommand = new SqlCommand("SELECT COUNT(*) FROM KHACHHANG", nachos.sqlCon);
                    int numCustomers = (Int32)sqlCommand.ExecuteScalar();
                    numCustomers += 1;

                    if (!checkBox2.Checked)
                    {
                        maskedTextBox2.Text = "01/01/2022";
                    }

                    try
                    {
                        var strSQLCommand = "EXEC dbo.INSERT_KH 'KH" + numCustomers.ToString() + "', N'" + textBox1.Text + "', '" + maskedTextBox1.Text + "', '" + textBox3.Text + "', '" + textBox2.Text + "', '" + textBox7.Text + "', '" + textBox6.Text + "', '" + maskedTextBox2.Text + "', '" + textBox5.Text + "', '" + textBox4.Text + "'";  // statement is wrong! will raise an exception
                        var command = new SqlCommand(strSQLCommand, nachos.sqlCon);
                        command.ExecuteNonQuery();
                    }
                    catch (SqlException sqlEx)
                    {
                        MessageBox.Show(sqlEx.Message);
                    }

                    try
                    {
                        object selecteditem = comboBox4.SelectedValue;
                        string trungtam = selecteditem.ToString();
                        object selecteditem2 = comboBox2.SelectedValue;
                        string goivacxin = selecteditem2.ToString();
                        sqlCommand = new SqlCommand("SELECT COUNT(*) FROM PHIEUDKTIEM", nachos.sqlCon);
                        int num = (Int32)sqlCommand.ExecuteScalar();
                        num += 1;

                        var strSQLCommand = "EXEC dbo.INSERT_PDKT 'DK" + num.ToString() + "', '" + "KH" + numCustomers.ToString() + "', '" + ngaytiem.Text + "', '" + trungtam + "', '" + goivacxin + "' ";  // statement is wrong! will raise an exception
                        var command = new SqlCommand(strSQLCommand, nachos.sqlCon);
                        command.ExecuteNonQuery();

                        sqlCommand = new SqlCommand("SELECT COUNT(*) FROM PHIEUDATMUAVX", nachos.sqlCon);
                        int numOrder = (Int32)sqlCommand.ExecuteScalar();
                        numOrder += 1;

                        sqlCommand = new SqlCommand("SELECT TEN_GVX FROM GOIVACXIN WHERE MA_GVX='" + goivacxin + "'", nachos.sqlCon);
                        String vacxinName = (String)sqlCommand.ExecuteScalar();

                        strSQLCommand = "EXEC dbo.INSERT_PDMVX 'DM" + numOrder.ToString() + "', 'DK" + num.ToString() + "', '" + goivacxin + "', '" + vacxinName + "'";  // statement is wrong! will raise an exception
                        command = new SqlCommand(strSQLCommand, nachos.sqlCon);
                        command.ExecuteNonQuery();
                    }
                    catch (SqlException sqlEx)
                    {
                        MessageBox.Show(sqlEx.Message);
                    }
                    MessageBox.Show("Đặt mua vacxin thành công");
                }

                else
                {
                    SqlCommand sqlCommand = new SqlCommand("SELECT COUNT(*) FROM KHACHHANG", nachos.sqlCon);
                    int numCustomers = (Int32)sqlCommand.ExecuteScalar();
                    numCustomers += 1;

                    try
                    {
                        sqlCommand = new SqlCommand("SELECT COUNT(*) FROM PHIEUDKTIEM", nachos.sqlCon);
                        int num = (Int32)sqlCommand.ExecuteScalar();
                        num += 1;

                        object selecteditem = comboBox4.SelectedValue;
                        string trungtam = selecteditem.ToString();

                        var strSQLCommand = "EXEC dbo.INSERT_PDKT 'DK" + num.ToString() + "', '" + "KH" + numCustomers.ToString() + "', '" + ngaytiem.Text + "', '" + trungtam + "', null";  // statement is wrong! will raise an exception
                        var command = new SqlCommand(strSQLCommand, nachos.sqlCon);
                        command.ExecuteNonQuery();

                        sqlCommand = new SqlCommand("SELECT COUNT(*) FROM PHIEUDATMUAVX", nachos.sqlCon);
                        int numOrder = (Int32)sqlCommand.ExecuteScalar();
                        numOrder += 1;

                        strSQLCommand = "EXEC dbo.INSERT_PDMVX 'DM" + numOrder.ToString() + "', 'DK" + num.ToString() + "', null, '" + textBox1.Text + "'";  // statement is wrong! will raise an exception
                        command = new SqlCommand(strSQLCommand, nachos.sqlCon);
                        command.ExecuteNonQuery();
                    }

                    catch (SqlException sqlEx)
                    {
                        MessageBox.Show(sqlEx.Message);
                    }
                    MessageBox.Show("Đặt mua vacxin thành công");
                }
            }
            nachos.sqlCon.Close();
        }

        private void showInfoVacxin()
        {
            label17.Show();
            comboBox2.Show();
            label2.Hide();
            textBox1.Hide();
        }

        private void disableShowInfoVacxin()
        {
            label17.Hide();
            comboBox2.Hide();
            label2.Show();
            textBox1.Show();
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                showInfoVacxin();
            }
            else
            {
                disableShowInfoVacxin();
            }

        }
    }
}
