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
    public partial class MHdangkytiemchung : Form
    {
    public MHdangkytiemchung()
        {
            InitializeComponent();

            string connString = @"Data Source=" + nachos.servername + ";Initial Catalog=" + nachos.dbname + ";Integrated Security=True;" + "UID=" + nachos.username.Trim() + "password=" + nachos.password.Trim();
            nachos.sqlCon = new SqlConnection(connString);

            SqlCommand cmd = new SqlCommand("select ten_tt, ma_tt from trungtam", nachos.sqlCon);
            SqlDataAdapter adapt = new SqlDataAdapter();
            adapt.SelectCommand = cmd;
            DataTable table = new DataTable();
            adapt.Fill(table);
            Dktrungtamtiem.DataSource = table;
            Dktrungtamtiem.DisplayMember = "ten_tt";
            Dktrungtamtiem.ValueMember = "ma_tt";

            SqlDataAdapter adapt1 = new SqlDataAdapter();
            adapt1.SelectCommand = cmd;
            DataTable table1 = new DataTable();
            adapt1.Fill(table1);
            Trungtam.DataSource = table1;
            Trungtam.DisplayMember = "ten_tt";
            Trungtam.ValueMember = "ma_tt";

            Ngaysinh.Mask = "00/00/0000";
            Ngaysinh.ValidatingType = typeof(System.DateTime);
            Ngaysinhngh.Mask = "00/00/0000";
            Ngaysinhngh.ValidatingType = typeof(System.DateTime);
            Dkngaytiem.Mask = "00/00/0000";
            Dkngaytiem.ValidatingType = typeof(System.DateTime);
            disableShowInfoToRegister();
            disableShowInfoUnder18ToRegister();
        }

        private void button3_Click(object sender, EventArgs e) //btnLocvacxin_Click
        {
            //loc vac xin theo trung tam chon
            nachos.sqlCon.Open();
            object selecteditem = Dktrungtamtiem.SelectedValue;
            trungtam.matrungtam = selecteditem.ToString();
            SqlCommand cmd2 = new SqlCommand("select GOIVACXIN.MA_GVX, ten_gvx from goivacxin, kho where KHO.ma_tt = '" + trungtam.matrungtam + "' ", nachos.sqlCon);
            SqlDataAdapter adapt4 = new SqlDataAdapter();
            adapt4.SelectCommand = cmd2;
            DataTable table4 = new DataTable();
            adapt4.Fill(table4);
            Vacxin.DataSource = table4;
            Vacxin.DisplayMember = "MA_GVX";
            Vacxin.ValueMember = "MA_GVX";
            nachos.sqlCon.Close();
        }

        private void button4_Click(object sender, EventArgs e)// btnTracuu_Click
        {
            nachos.sqlCon.Open();
            object selecteditem = Trungtam.SelectedValue;
            trungtam.matrungtam = selecteditem.ToString();
            SqlDataAdapter adapt1 = new SqlDataAdapter("SELECT * from goivacxin, kho where ma_tt = '" + trungtam.matrungtam + "' and LOAI_GVX != 0", nachos.sqlCon);
            DataTable table1 = new DataTable();
            adapt1.Fill(table1);
            Vacxinle.DataSource = new BindingSource(table1, null);

            SqlDataAdapter adapt3 = new SqlDataAdapter("SELECT * from goivacxin, kho where ma_tt = '" + trungtam.matrungtam + "' and LOAI_GVX = 0", nachos.sqlCon);
            DataTable table3 = new DataTable();
            adapt3.Fill(table3);
            Goivacxin.DataSource = new BindingSource(table3, null);
            nachos.sqlCon.Close();
        }

        private void dangkytiemchung_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)//btnThanhtoan_Click
        {
            nachos.sqlCon.Open();

            if (!checkBox1.Checked)
            {

                try
                {
                    //insert phieu dk tiem
                    object selecteditem = Dktrungtamtiem.SelectedValue;
                    phieudangkytiem.trungtam = selecteditem.ToString();
                    object selecteditem2 = Vacxin.SelectedValue;
                    phieudangkytiem.vacxin = selecteditem2.ToString();
                    phieudangkytiem.thoigian = Dkngaytiem.Text;
                    phieudangkytiem.makhachhang = Makh.Text;
                    SqlCommand sqlCommand = new SqlCommand("SELECT COUNT(*) FROM PHIEUDKTIEM", nachos.sqlCon);
                    int num = (Int32)sqlCommand.ExecuteScalar();
                    num += 1;
                    phieudangkytiem.maphieudangkytiem = "DK" + num.ToString();

                    var strSQLCommand = "EXEC dbo.INSERT_PDKT '" + phieudangkytiem.maphieudangkytiem + "', '" + phieudangkytiem.makhachhang + "', '" + phieudangkytiem.thoigian + "', '" + phieudangkytiem.vacxin + "', '" + phieudangkytiem.vacxin + "' ";  // statement is wrong! will raise an exception
                    var command = new SqlCommand(strSQLCommand, nachos.sqlCon);
                    command.ExecuteNonQuery();
                }
                catch (SqlException sqlEx)
                {
                    MessageBox.Show(sqlEx.Message);
                }
                //MessageBox.Show("Đăng ký tiêm chủng thành công");
            }

            else
            {
                SqlCommand sqlCommand = new SqlCommand("SELECT COUNT(*) FROM KHACHHANG", nachos.sqlCon);
                int numCustomers = (Int32)sqlCommand.ExecuteScalar();
                numCustomers += 1;

                if (!checkBox2.Checked)
                {
                    Ngaysinhngh.Text = "01/01/2022";
                }
                
                try
                {
                    //them khach hang va nguoi giam ho
                    khachhang.hoten = Hoten.Text;
                    khachhang.ngaysinh = Ngaysinh.Text;
                    khachhang.diachi = Diachi.Text;
                    khachhang.cmnd = Cmnd.Text;
                    khachhang.sdt = Sdt.Text;
                    khachhang.makhachhang = "KH" + numCustomers.ToString();
                    //nguoi giam ho
                    nguoigiamho.hoten = Hotenngh.Text;
                    nguoigiamho.ngaysinh = Ngaysinhngh.Text;
                    nguoigiamho.sdt = Sdtngh.Text;
                    nguoigiamho.diachi = Diachingh.Text;
                    nguoigiamho.khachhang = khachhang.makhachhang;
                    var strSQLCommand = "EXEC dbo.INSERT_KH '" + khachhang.makhachhang + "', N'" + khachhang.hoten + "', '" + khachhang.ngaysinh + "', N'" + khachhang.diachi + "', '" + khachhang.sdt + "', '" + khachhang.cmnd + "', '" + nguoigiamho.hoten + "', '" + nguoigiamho.ngaysinh + "', '" + nguoigiamho.sdt + "', '" + nguoigiamho.diachi + "'";  // statement is wrong! will raise an exception
                    var command = new SqlCommand(strSQLCommand, nachos.sqlCon);
                    command.ExecuteNonQuery();
                }
                catch (SqlException sqlEx)
                {
                    MessageBox.Show(sqlEx.Message);
                }

                try
                {
                    object selecteditem = Dktrungtamtiem.SelectedValue;
                    phieudangkytiem.trungtam = selecteditem.ToString();
                    object selecteditem2 = Vacxin.SelectedValue;
                    phieudangkytiem.vacxin = selecteditem2.ToString();
                    phieudangkytiem.thoigian = Dkngaytiem.Text;
                    phieudangkytiem.makhachhang = khachhang.makhachhang;
                    sqlCommand = new SqlCommand("SELECT COUNT(*) FROM PHIEUDKTIEM", nachos.sqlCon);
                    int num = (Int32)sqlCommand.ExecuteScalar();
                    num += 1;
                    phieudangkytiem.maphieudangkytiem = "DK" + num.ToString();

                    var strSQLCommand = "EXEC dbo.INSERT_PDKT '" + phieudangkytiem.maphieudangkytiem + "', '" + phieudangkytiem.makhachhang + "', '" + phieudangkytiem.thoigian + "', '" + phieudangkytiem.trungtam + "', '" + phieudangkytiem.vacxin + "' ";  // statement is wrong! will raise an exception
                    var command = new SqlCommand(strSQLCommand, nachos.sqlCon);
                    command.ExecuteNonQuery();
                }
                catch (SqlException sqlEx)
                {
                    MessageBox.Show(sqlEx.Message);
                }
                //MessageBox.Show("Đăng ký tiêm chủng thành công");
            }
            
            nachos.sqlCon.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            MHdatmuavacxin them = new MHdatmuavacxin();
            them.ShowDialog();
            this.Close();
        }

        private void showInfoToRegister()
        {
            label5.Show();
            Hoten.Show();
            label6.Show();
            Ngaysinh.Show();
            label8.Show();
            Diachi.Show();
            Sdt.Show();
            label9.Show();
            Cmnd.Show();
            label7.Show();

            label20.Hide();
            Makh.Hide();
        }

        private void disableShowInfoToRegister()
        {
            label5.Hide();
            Hoten.Hide();
            label6.Hide();
            Ngaysinh.Hide();
            label8.Hide();
            Diachi.Hide();
            Sdt.Hide();
            label9.Hide();
            Cmnd.Hide();
            label7.Hide();
            label20.Show();
            Makh.Show();

        }

        private void showInfoUnder18ToRegister()
        {
            label25.Show();
            Hotenngh.Show();
            label23.Show();
            Hotenngh.Show();
            label15.Show();
            Ngaysinhngh.Show();
            label22.Show();
            Diachingh.Show();
            Sdtngh.Show();
        }
        private void disableShowInfoUnder18ToRegister()
        {
            label25.Hide();
            Hotenngh.Hide();
            label23.Hide();
            Hotenngh.Hide();
            label15.Hide();
            Ngaysinhngh.Hide();
            label22.Hide();
            Diachingh.Hide();
            Sdtngh.Hide();
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
    }

}
