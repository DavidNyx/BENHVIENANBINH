using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class MHThanhtoan : Form
    {
        double giaTien = 0, giaTienDot1 = 0;
        DateTime time;
        public MHThanhtoan()
        {
            InitializeComponent();
            string connString = @"Data Source=" + nachos.servername + ";Initial Catalog=" + nachos.dbname + ";Integrated Security=True;" + "UID=" + nachos.username.Trim() + "password=" + nachos.password.Trim();
            nachos.sqlCon = new SqlConnection(connString);
            nachos.sqlCon.Open();

            Hinhthuc.Items.Add("1 lần");
            Hinhthuc.Items.Add("theo đợt");
            
            SqlCommand sqlCommand = new SqlCommand("SELECT TEN_KH FROM KHACHHANG WHERE MA_KH='" + phieudangkytiem.makhachhang + "'", nachos.sqlCon);
            String customerName = (String)sqlCommand.ExecuteScalar();
            hoTen.Text = customerName;

            sqlCommand = new SqlCommand("SELECT NGAYSINH FROM KHACHHANG WHERE MA_KH='" + phieudangkytiem.makhachhang + "'", nachos.sqlCon);
            DateTime DOB = (DateTime)sqlCommand.ExecuteScalar();
            ngaySinh.Text = DOB.ToString("D");
            //ngaySinh.Text = khachhang.ngaysinh;

            sqlCommand = new SqlCommand("SELECT DIACHI_KH FROM KHACHHANG WHERE MA_KH='" + phieudangkytiem.makhachhang + "'", nachos.sqlCon);
            String addr = (String)sqlCommand.ExecuteScalar();
            diaChi.Text = addr;

            sqlCommand = new SqlCommand("SELECT SDT_KH FROM KHACHHANG WHERE MA_KH='" + phieudangkytiem.makhachhang + "'", nachos.sqlCon);
            String phone = (String)sqlCommand.ExecuteScalar();
            sdt.Text = phone;

            sqlCommand = new SqlCommand("SELECT CMND FROM KHACHHANG WHERE MA_KH='" + phieudangkytiem.makhachhang + "'", nachos.sqlCon);
            String cid = (String)sqlCommand.ExecuteScalar();
            cmnd.Text = cid;

            sqlCommand = new SqlCommand("SELECT HOTEN_NGH FROM NGUOIGIAMHO WHERE MA_KH='" + phieudangkytiem.makhachhang + "'", nachos.sqlCon);
            String supervisorName = (String)sqlCommand.ExecuteScalar();
            hoTenNGH.Text = supervisorName;

            sqlCommand = new SqlCommand("SELECT NGAYSINH_NGH FROM NGUOIGIAMHO WHERE MA_KH='" + phieudangkytiem.makhachhang + "'", nachos.sqlCon);
            DateTime supervisorDOB = (DateTime)sqlCommand.ExecuteScalar();
            ngaySinhNGH.Text = supervisorDOB.ToString("d");
            //ngaySinhNGH.Text = nguoigiamho.ngaysinh;

            sqlCommand = new SqlCommand("SELECT DIACHI_NGH FROM NGUOIGIAMHO WHERE MA_KH='" + phieudangkytiem.makhachhang + "'", nachos.sqlCon);
            String supervisorAddr = (String)sqlCommand.ExecuteScalar();
            diaChiNGH.Text = supervisorAddr;

            sqlCommand = new SqlCommand("SELECT SDT_NGH FROM NGUOIGIAMHO WHERE MA_KH='" + phieudangkytiem.makhachhang + "'", nachos.sqlCon);
            String supervisorPhone = (String)sqlCommand.ExecuteScalar();
            sdtNGH.Text = supervisorPhone;

            //sqlCommand = new SqlCommand("SELECT MA_PDKT FROM PHIEUDKTIEM WHERE MA_KH='" + phieudangkytiem.makhachhang + "'", nachos.sqlCon);
            //String maPhieuDKTiem = (String)sqlCommand.ExecuteScalar();
            maPhieuDKT.Text = phieudangkytiem.maphieudangkytiem;

            sqlCommand = new SqlCommand("SELECT GVX.TEN_GVX FROM PHIEUDKTIEM PDKT JOIN GOIVACXIN GVX ON PDKT.MA_GVX = GVX.MA_GVX WHERE PDKT.MA_KH='" + phieudangkytiem.makhachhang + "'", nachos.sqlCon);
            //String vacxinTiem = (String)sqlCommand.ExecuteScalar();
            goivacxin.tenvacxin = (String)sqlCommand.ExecuteScalar();
            tenVX.Text = goivacxin.tenvacxin;

            //sqlCommand = new SqlCommand("SELECT THOIGIANTIEM FROM PHIEUDKTIEM WHERE MA_KH='" + phieudangkytiem.makhachhang + "'", nachos.sqlCon);
            //DateTime thoiGianTiem = (DateTime)sqlCommand.ExecuteScalar();
            //ngayTiem.Text = thoiGianTiem.ToString("D");
            ngayTiem.Text = phieudangkytiem.thoigian;

            sqlCommand = new SqlCommand("SELECT TT.TEN_TT FROM PHIEUDKTIEM PDKT JOIN TRUNGTAM TT ON PDKT.MA_TT = TT.MA_TT WHERE PDKT.MA_KH='" + phieudangkytiem.makhachhang + "'", nachos.sqlCon);
            String trungTamTiem = (String)sqlCommand.ExecuteScalar();
            trungtam.tentrungtam = trungTamTiem;
            trungTam.Text = trungtam.tentrungtam;

            sqlCommand = new SqlCommand("SELECT GVX.GIATIEN FROM PHIEUDKTIEM PDKT JOIN GOIVACXIN GVX ON PDKT.MA_GVX = GVX.MA_GVX WHERE PDKT.MA_KH='" + phieudangkytiem.makhachhang + "'", nachos.sqlCon);
            giaTien = (double)sqlCommand.ExecuteScalar();
            giaTienDot1 = (double)(giaTien * 0.25);
            hoadon.tongtien = giaTien;
            tongTien.Text = hoadon.tongtien.ToString();

            sqlCommand = new SqlCommand("SELECT GETDATE()", nachos.sqlCon);
            time = (DateTime)sqlCommand.ExecuteScalar();

            nachos.sqlCon.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void thanhtoan_Load(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Hinhthuc.SelectedItem.ToString() == "1 lần" && Hinhthuc.SelectedItem != null)
            {
                
                dotThanhToan.Text = "1 lần";
                ngayLapHD.Text = time.ToString("D");

                tienCanTra.Text = giaTien.ToString();
                
            }
            else if (Hinhthuc.SelectedItem.ToString() == "theo đợt" && Hinhthuc.SelectedItem != null)
            {
                dotThanhToan.Text = "theo đợt";
                ngayLapHD.Text = time.ToString("D");

                tienCanTra.Text = giaTienDot1.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            nachos.sqlCon.Open();
            try
            {
                if (Hinhthuc.SelectedItem.ToString() == "1 lần" && Hinhthuc.SelectedItem != null)
                {
                    SqlCommand sqlCommand = new SqlCommand("SELECT COUNT(*) FROM HOADON", nachos.sqlCon);
                    int num = (Int32)sqlCommand.ExecuteScalar();
                    num += 1;
                    hoadon.mahoadon = "HD" + num.ToString();
                    hoadon.maphieudangkytiem = phieudangkytiem.maphieudangkytiem;
                    hoadon.ngaylap = time.ToString("d");
                    hoadon.stk = Stk.Text;

                    var strSQLCommand = "EXEC dbo.THANH_TOAN_1_LAN '" + hoadon.mahoadon + "', '" + hoadon.ngaylap + "', '" + hoadon.maphieudangkytiem + "', '" + hoadon.stk + "', 1, " + hoadon.tongtien;  // statement is wrong! will raise an exception
                    var command = new SqlCommand(strSQLCommand, nachos.sqlCon);
                    command.ExecuteNonQuery();
                }
                else if (Hinhthuc.SelectedItem.ToString() == "theo đợt" && Hinhthuc.SelectedItem != null)
                {
                    SqlCommand sqlCommand = new SqlCommand("SELECT COUNT(*) FROM HOADON", nachos.sqlCon);
                    int num = (Int32)sqlCommand.ExecuteScalar();
                    num += 1;
                    hoadon.mahoadon = "HD" + num.ToString();
                    hoadon.maphieudangkytiem = phieudangkytiem.maphieudangkytiem;
                    hoadon.ngaylap = time.ToString("d");
                    hoadon.stk = Stk.Text;

                    var strSQLCommand = "EXEC dbo.THANH_TOAN_THEO_DOT '" + hoadon.mahoadon + "', '" + hoadon.ngaylap + "', '" + hoadon.ngaylap + "', '" + hoadon.stk + "', " + hoadon.tongtien;  // statement is wrong! will raise an exception
                    var command = new SqlCommand(strSQLCommand, nachos.sqlCon);
                    command.ExecuteNonQuery();

                    /*strSQLCommand = "UPDATE CHITIET_HD SET DATHANHTOAN=0 WHERE MA_HD='" + hoadon.mahoadon + "' AND DOTTHANHTOAN=1";
                    command = new SqlCommand(strSQLCommand, nachos.sqlCon);
                    command.ExecuteNonQuery();*/
                }
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show(sqlEx.Message);
            }
            MessageBox.Show("Thanh toán thành công!");
            nachos.sqlCon.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            nachos.sqlCon.Open();
            try
            {
                if (Hinhthuc.SelectedItem.ToString() == "1 lần" && Hinhthuc.SelectedItem != null)
                {
                    SqlCommand sqlCommand = new SqlCommand("SELECT COUNT(*) FROM HOADON", nachos.sqlCon);
                    int num = (Int32)sqlCommand.ExecuteScalar();
                    num += 1;

                    var strSQLCommand = "EXEC dbo.THANH_TOAN_1_LAN 'HD" + num.ToString() + "', '" + time.ToString("d") + "', '" + maPhieuDKT.Text + "', '" + Stk.Text + "', 1, " + tongTien.Text;  // statement is wrong! will raise an exception
                    var command = new SqlCommand(strSQLCommand, nachos.sqlCon);
                    command.ExecuteNonQuery();
                }
                else if (Hinhthuc.SelectedItem.ToString() == "theo đợt" && Hinhthuc.SelectedItem != null)
                {
                    SqlCommand sqlCommand = new SqlCommand("SELECT COUNT(*) FROM HOADON", nachos.sqlCon);
                    int num = (Int32)sqlCommand.ExecuteScalar();
                    num += 1;

                    var strSQLCommand = "EXEC dbo.THANH_TOAN_THEO_DOT 'HD" + num.ToString() + "', '" + time.ToString("d") + "', '" + maPhieuDKT.Text + "', '" + Stk.Text + "', " + tongTien.Text;  // statement is wrong! will raise an exception
                    var command = new SqlCommand(strSQLCommand, nachos.sqlCon);
                    command.ExecuteNonQuery();
                }
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show(sqlEx.Message);
            }
            MessageBox.Show("Thanh toán thành công!");
            nachos.sqlCon.Close();
        }
    }
}
