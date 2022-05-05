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
    public partial class MHdatmuavacxin : Form
    {
        public MHdatmuavacxin()
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

            SqlCommand cmd1 = new SqlCommand("select ten_tt, ma_tt from trungtam", nachos.sqlCon);
            SqlDataAdapter adapt1 = new SqlDataAdapter();
            adapt1.SelectCommand = cmd1;
            DataTable table1 = new DataTable();
            adapt1.Fill(table1);
            Trungtam.DataSource = table1;
            Trungtam.DisplayMember = "ten_tt";
            Trungtam.ValueMember = "ma_tt";

            Ngaysinh.Mask = "00/00/0000";
            Ngaysinh.ValidatingType = typeof(System.DateTime);
            NgaysinhNGH.Mask = "00/00/0000";
            NgaysinhNGH.ValidatingType = typeof(System.DateTime);
            Dkngaytiem.Mask = "00/00/0000";
            Dkngaytiem.ValidatingType = typeof(System.DateTime);
            disableShowInfoToRegister();
            disableShowInfoUnder18ToRegister();
            disableShowInfoVacxin();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            nachos.sqlCon.Open();

            object selecteditem = Dktrungtamtiem.SelectedValue;
            trungtam.matrungtam = selecteditem.ToString();

            SqlCommand cmd1 = new SqlCommand("select GOIVACXIN.MA_GVX, ten_gvx from goivacxin, kho where soluongton = 0 and ma_tt= '" + trungtam.matrungtam + "' ", nachos.sqlCon);
            SqlDataAdapter adapt1 = new SqlDataAdapter();
            adapt1.SelectCommand = cmd1;
            DataTable table1 = new DataTable();
            adapt1.Fill(table1);
            Vacxin.DataSource = table1;
            Vacxin.DisplayMember = "MA_GVX";
            Vacxin.ValueMember = "MA_GVX";

            nachos.sqlCon.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            nachos.sqlCon.Open();

            object selecteditem = Trungtam.SelectedValue;
            trungtam.matrungtam = selecteditem.ToString();
            SqlDataAdapter adapt3 = new SqlDataAdapter("SELECT * from goivacxin, kho where soluongton = 0 and LOAI_GVX = 0 and ma_tt = '" + trungtam.matrungtam + "' ", nachos.sqlCon);
            DataTable table3 = new DataTable();
            adapt3.Fill(table3);
            Vacxinle.DataSource = new BindingSource(table3, null);

            SqlDataAdapter adapt4 = new SqlDataAdapter("SELECT * from goivacxin, kho where soluongton = 0 and LOAI_GVX != 0 and ma_tt = '" + trungtam.matrungtam + "' ", nachos.sqlCon);
            DataTable table4 = new DataTable();
            adapt4.Fill(table4);
            Goivacxin.DataSource = new BindingSource(table4, null);

            nachos.sqlCon.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void showInfoToRegister()
        {
            label10.Show();
            Hoten.Show();
            label6.Show();
            Ngaysinh.Show();
            label8.Show();
            Diachi.Show();
            label7.Show();
            Sdt.Show();
            label9.Show();
            Cmnd.Show();

            label20.Hide();
            Makh.Hide();
        }

        private void disableShowInfoToRegister()
        {
            label10.Hide();
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
            HotenNGH.Show();
            label24.Show();
            HotenNGH.Show();
            NgaysinhNGH.Show();
            label23.Show();
            label22.Show();
            DiachiNGH.Show();
            SdtNGH.Show();
        }
        private void disableShowInfoUnder18ToRegister()
        {
            label25.Hide();
            HotenNGH.Hide();
            label23.Hide();
            HotenNGH.Hide();
            NgaysinhNGH.Hide();
            label24.Hide();
            label22.Hide();
            DiachiNGH.Hide();
            SdtNGH.Hide();
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

                        var strSQLCommand = "EXEC dbo.INSERT_PDKT '" + phieudangkytiem.maphieudangkytiem + "', '" + phieudangkytiem.makhachhang + "', '" + phieudangkytiem.thoigian + "', '" + phieudangkytiem.trungtam + "', '" + phieudangkytiem.vacxin + "'";  // statement is wrong! will raise an exception
                        var command = new SqlCommand(strSQLCommand, nachos.sqlCon);
                        command.ExecuteNonQuery();

                        sqlCommand = new SqlCommand("SELECT COUNT(*) FROM PHIEUDATMUAVX", nachos.sqlCon);
                        int numOrder = (Int32)sqlCommand.ExecuteScalar();
                        numOrder += 1;
                        phieudatmua.maphieudatmua = "DM" + numOrder.ToString();

                        sqlCommand = new SqlCommand("SELECT TEN_GVX FROM GOIVACXIN WHERE MA_GVX='" + phieudangkytiem.vacxin + "'", nachos.sqlCon);
                        phieudatmua.tenvacxin = (String)sqlCommand.ExecuteScalar();
                        phieudatmua.magoivacxin = phieudangkytiem.vacxin;
                        phieudatmua.maphieudangkytiem = phieudangkytiem.maphieudangkytiem;
                        
                        strSQLCommand = "EXEC dbo.INSERT_PDMVX '" + phieudatmua.maphieudatmua + "', '" + phieudatmua.maphieudangkytiem + "', '" + phieudatmua.magoivacxin + "', '" + phieudatmua.tenvacxin + "'";  // statement is wrong! will raise an exception
                        command = new SqlCommand(strSQLCommand, nachos.sqlCon);
                        command.ExecuteNonQuery();
                    }
                    catch (SqlException sqlEx)
                    {
                        MessageBox.Show(sqlEx.Message);
                    }
                    MessageBox.Show("Đặt mua vacxin thành công");
                    navigateToPurchase();
                }
                else
                {
                    try
                    {
                        object selecteditem = Dktrungtamtiem.SelectedValue;
                        phieudangkytiem.trungtam = selecteditem.ToString();
                        phieudangkytiem.thoigian = Dkngaytiem.Text;
                        phieudangkytiem.makhachhang = Makh.Text;

                        SqlCommand sqlCommand = new SqlCommand("SELECT COUNT(*) FROM PHIEUDKTIEM", nachos.sqlCon);
                        int num = (Int32)sqlCommand.ExecuteScalar();
                        num += 1;
                        phieudangkytiem.maphieudangkytiem = "DK" + num.ToString();

                        var strSQLCommand = "EXEC dbo.INSERT_PDKT '" + phieudangkytiem.maphieudangkytiem + "', '" + phieudangkytiem.makhachhang + "', '" + phieudangkytiem.thoigian + "', '" + phieudangkytiem.trungtam + "', null";  // statement is wrong! will raise an exception
                        var command = new SqlCommand(strSQLCommand, nachos.sqlCon);
                        command.ExecuteNonQuery();

                        sqlCommand = new SqlCommand("SELECT COUNT(*) FROM PHIEUDATMUAVX", nachos.sqlCon);
                        int numOrder = (Int32)sqlCommand.ExecuteScalar();
                        numOrder += 1;
                        phieudatmua.tenvacxin = Vacxinngoai.Text;
                        phieudatmua.maphieudatmua = "DM" + numOrder.ToString();
                        phieudatmua.maphieudangkytiem = phieudangkytiem.maphieudangkytiem;

                        strSQLCommand = "EXEC dbo.INSERT_PDMVX '" + phieudatmua.maphieudatmua + "', '" + phieudatmua.maphieudangkytiem + "', null, '" + phieudatmua.tenvacxin + "'";  // statement is wrong! will raise an exception
                        command = new SqlCommand(strSQLCommand, nachos.sqlCon);
                        command.ExecuteNonQuery();
                    }
                    
                    catch (SqlException sqlEx)
                    {
                        MessageBox.Show(sqlEx.Message);
                    }
                    MessageBox.Show("Đặt mua vacxin thành công");
                    navigateToPurchase();
                }
            }
            else
            {
                if (checkBox3.Checked)
                {
                    SqlCommand sqlCommand = new SqlCommand("SELECT COUNT(*) FROM KHACHHANG", nachos.sqlCon);
                    int numCustomers = (Int32)sqlCommand.ExecuteScalar();
                    numCustomers += 1;
                    khachhang.makhachhang = "KH" + numCustomers.ToString();
                    khachhang.hoten = Hoten.Text;
                    khachhang.ngaysinh = Ngaysinh.Text;
                    khachhang.diachi = Diachi.Text;
                    khachhang.cmnd = Cmnd.Text;
                    khachhang.sdt = Sdt.Text;
                    //nguoi giam ho
                    nguoigiamho.hoten = HotenNGH.Text;
                    nguoigiamho.ngaysinh = NgaysinhNGH.Text;
                    nguoigiamho.sdt = SdtNGH.Text;
                    nguoigiamho.diachi = DiachiNGH.Text;
                    nguoigiamho.khachhang = khachhang.makhachhang;

                    if (!checkBox2.Checked)
                    {
                        NgaysinhNGH.Text = "01/01/2022";
                    }

                    try
                    {
                        var strSQLCommand = "EXEC dbo.INSERT_KH '" + khachhang.makhachhang + "', N'" + khachhang.hoten + "', '" + khachhang.ngaysinh + "', '" + khachhang.diachi + "', '" + khachhang.sdt + "', '" + khachhang.cmnd + "', '" + nguoigiamho.hoten + "', '" + nguoigiamho.ngaysinh + "', '" + nguoigiamho.sdt + "', '" + nguoigiamho.diachi + "'";  // statement is wrong! will raise an exception
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
                        //
                        sqlCommand = new SqlCommand("SELECT COUNT(*) FROM PHIEUDKTIEM", nachos.sqlCon);
                        int num = (Int32)sqlCommand.ExecuteScalar();
                        num += 1;
                        phieudangkytiem.maphieudangkytiem = "DK" + num.ToString();

                        var strSQLCommand = "EXEC dbo.INSERT_PDKT '" + phieudangkytiem.maphieudangkytiem + "', '" + phieudangkytiem.makhachhang + "', '" + phieudangkytiem.thoigian + "', '" + phieudangkytiem.trungtam + "', '" + phieudangkytiem.vacxin + "' ";  // statement is wrong! will raise an exception
                        var command = new SqlCommand(strSQLCommand, nachos.sqlCon);
                        command.ExecuteNonQuery();

                        sqlCommand = new SqlCommand("SELECT COUNT(*) FROM PHIEUDATMUAVX", nachos.sqlCon);
                        int numOrder = (Int32)sqlCommand.ExecuteScalar();
                        numOrder += 1;
                        phieudatmua.maphieudatmua = "DM" + numOrder.ToString();
                        phieudatmua.maphieudangkytiem = phieudangkytiem.maphieudangkytiem;
                        phieudatmua.magoivacxin = phieudangkytiem.vacxin;

                        sqlCommand = new SqlCommand("SELECT TEN_GVX FROM GOIVACXIN WHERE MA_GVX='" + phieudangkytiem.vacxin + "'", nachos.sqlCon);
                        phieudatmua.tenvacxin = (String)sqlCommand.ExecuteScalar();

                        strSQLCommand = "EXEC dbo.INSERT_PDMVX '" + phieudatmua.maphieudatmua + "', '" + phieudatmua.maphieudangkytiem + "', '" + phieudatmua.magoivacxin + "', '" + phieudatmua.tenvacxin + "'";  // statement is wrong! will raise an exception
                        command = new SqlCommand(strSQLCommand, nachos.sqlCon);
                        command.ExecuteNonQuery();
                    }
                    catch (SqlException sqlEx)
                    {
                        MessageBox.Show(sqlEx.Message);
                    }
                    MessageBox.Show("Đặt mua vacxin thành công");
                    navigateToPurchase();
                }

                else
                {
                    SqlCommand sqlCommand = new SqlCommand("SELECT COUNT(*) FROM KHACHHANG", nachos.sqlCon);
                    int numCustomers = (Int32)sqlCommand.ExecuteScalar();
                    numCustomers += 1;
                    khachhang.makhachhang = "KH" + numCustomers.ToString();

                    try
                    {
                        sqlCommand = new SqlCommand("SELECT COUNT(*) FROM PHIEUDKTIEM", nachos.sqlCon);
                        int num = (Int32)sqlCommand.ExecuteScalar();
                        num += 1;
                        phieudangkytiem.maphieudangkytiem = "DK" + num.ToString();

                        object selecteditem = Dktrungtamtiem.SelectedValue;
                        phieudangkytiem.trungtam = selecteditem.ToString();
                        object selecteditem2 = Vacxin.SelectedValue;
                        phieudangkytiem.vacxin = selecteditem2.ToString();
                        phieudangkytiem.thoigian = Dkngaytiem.Text;
                        phieudangkytiem.makhachhang = khachhang.makhachhang;

                        var strSQLCommand = "EXEC dbo.INSERT_PDKT '" + phieudangkytiem.maphieudangkytiem + "', '" + phieudangkytiem.makhachhang + "', '" + phieudangkytiem.thoigian + "', '" + phieudangkytiem.trungtam + "', null";  // statement is wrong! will raise an exception
                        var command = new SqlCommand(strSQLCommand, nachos.sqlCon);
                        command.ExecuteNonQuery();

                        sqlCommand = new SqlCommand("SELECT COUNT(*) FROM PHIEUDATMUAVX", nachos.sqlCon);
                        int numOrder = (Int32)sqlCommand.ExecuteScalar();
                        numOrder += 1;
                        phieudatmua.maphieudatmua = "DM" + numOrder.ToString();
                        phieudatmua.maphieudangkytiem = phieudangkytiem.maphieudangkytiem;
                        phieudatmua.tenvacxin = Vacxinngoai.Text;

                        strSQLCommand = "EXEC dbo.INSERT_PDMVX '" + phieudatmua.maphieudatmua + "', '" + phieudangkytiem.maphieudangkytiem + "', null, '" + phieudatmua.tenvacxin + "'";  // statement is wrong! will raise an exception
                        command = new SqlCommand(strSQLCommand, nachos.sqlCon);
                        command.ExecuteNonQuery();
                    }

                    catch (SqlException sqlEx)
                    {
                        MessageBox.Show(sqlEx.Message);
                    }
                    MessageBox.Show("Đặt mua vacxin thành công");
                    navigateToPurchase();
                }
            }
            nachos.sqlCon.Close();
        }

        private void showInfoVacxin()
        {
            label17.Show();
            Vacxin.Show();
            label2.Hide();
            Vacxinngoai.Hide();
        }

        private void disableShowInfoVacxin()
        {
            label17.Hide();
            Vacxin.Hide();
            label2.Show();
            Vacxinngoai.Show();
        }

        private void navigateToPurchase()
        {
            this.Hide();
            MHThanhtoan thanhtoan = new MHThanhtoan();
            thanhtoan.ShowDialog();
            this.Close();
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

        private void MHdatmuavacxin_Load(object sender, EventArgs e)
        {

        }
    }
}
