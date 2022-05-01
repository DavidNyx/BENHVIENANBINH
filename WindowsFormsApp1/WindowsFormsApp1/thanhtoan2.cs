﻿using System;
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
    public partial class thanhtoan2 : Form
    {
        DateTime time;
        public thanhtoan2()
        {
            InitializeComponent();
            string connString = @"Data Source=" + nachos.servername + ";Initial Catalog=" + nachos.dbname + ";Integrated Security=True;" + "UID=" + nachos.username.Trim() + "password=" + nachos.password.Trim();
            nachos.sqlCon = new SqlConnection(connString);

        }

        private void thanhtoan2_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            object selecteditem = comboBox1.SelectedValue;
            string maPhieuDKT = selecteditem.ToString();
            nachos.sqlCon.Open();
            SqlCommand sqlCommand = new SqlCommand("SELECT GETDATE()", nachos.sqlCon);
            time = (DateTime)sqlCommand.ExecuteScalar();

            sqlCommand = new SqlCommand("SELECT HINHTHUCTHANHTOAN FROM HOADON WHERE MA_PDKT='" + maPhieuDKT + "' AND DATHANHTOAN=0", nachos.sqlCon);
            Boolean hinhThucThanhToan = (Boolean)sqlCommand.ExecuteScalar();

            if (!hinhThucThanhToan)
            {
                hinhThucTT.Text = "1 lần";
                sqlCommand = new SqlCommand("SELECT TONGTIEN FROM HOADON WHERE MA_PDKT='" + maPhieuDKT + "' AND DATHANHTOAN=0", nachos.sqlCon);
                double tienTra = (double)sqlCommand.ExecuteScalar();
                tienCanTra.Text = tienTra.ToString();
                ngayLapHD.Text = time.ToString("D");

                var strSQLCommand = "UPDATE HOADON SET DATHANHTOAN=1 WHERE MA_PDKT='" + maPhieuDKT + "'";
                var command = new SqlCommand(strSQLCommand, nachos.sqlCon);
                strSQLCommand = "UPDATE HOADON SET NGAYLAP_HD='" + time.ToString("d") + "' WHERE MA_PDKT='" + maPhieuDKT + "'";
                command = new SqlCommand(strSQLCommand, nachos.sqlCon);
                strSQLCommand = "UPDATE HOADON SET STK='" + textBox3.Text + "' WHERE MA_PDKT='" + maPhieuDKT + "'";
                command = new SqlCommand(strSQLCommand, nachos.sqlCon);
                command.ExecuteNonQuery();
                MessageBox.Show("Thanh toán thành công");
            }
            else
            {
                hinhThucTT.Text = "Theo đợt";
                sqlCommand = new SqlCommand("SELECT TOP 1 CT.DOTTHANHTOAN FROM CHITIET_HD CT JOIN HOADON HD ON CT.MA_HD = HD.MA_HD WHERE MA_PDKT='" + maPhieuDKT + "' AND CT.DATHANHTOAN=0 ", nachos.sqlCon);
                Int32 dot = (Int32)sqlCommand.ExecuteScalar();
                dotTT.Text = dot.ToString();

                sqlCommand = new SqlCommand("SELECT CT.SOTIENTHANHTOAN FROM CHITIET_HD CT JOIN HOADON HD ON CT.MA_HD = HD.MA_HD WHERE MA_PDKT='" + maPhieuDKT + "' AND CT.DOTTHANHTOAN=" + dot.ToString(), nachos.sqlCon);
                double tienTra = (double)sqlCommand.ExecuteScalar();
                tienCanTra.Text = tienTra.ToString();

                sqlCommand = new SqlCommand("SELECT CT.MA_HD FROM CHITIET_HD CT JOIN HOADON HD ON CT.MA_HD = HD.MA_HD WHERE MA_PDKT='" + maPhieuDKT + "' AND CT.DATHANHTOAN=0 ", nachos.sqlCon);
                String maHD = (String)sqlCommand.ExecuteScalar();

                var strSQLCommand = "EXEC dbo.CAP_NHAP_HOA_DON '" + maHD + "', " + dot.ToString() + ", null, '" + time.ToString("d") + "', 1";
                var command = new SqlCommand(strSQLCommand, nachos.sqlCon);
                command.ExecuteNonQuery();
                MessageBox.Show("Thanh toán thành công");
            }
            nachos.sqlCon.Close();
        }

        private void traCuuBtn1_Click(object sender, EventArgs e)
        {
            nachos.sqlCon.Open();
            SqlCommand sqlCommand = new SqlCommand("SELECT TEN_KH FROM KHACHHANG WHERE MA_KH='" + maKH.Text + "'", nachos.sqlCon);
            String customerName = (String)sqlCommand.ExecuteScalar();
            hoTen.Text = customerName;

            sqlCommand = new SqlCommand("SELECT NGAYSINH FROM KHACHHANG WHERE MA_KH='" + maKH.Text + "'", nachos.sqlCon);
            DateTime DOB = (DateTime)sqlCommand.ExecuteScalar();
            ngaySinh.Text = DOB.ToString("D");

            sqlCommand = new SqlCommand("SELECT DIACHI_KH FROM KHACHHANG WHERE MA_KH='" + maKH.Text + "'", nachos.sqlCon);
            String addr = (String)sqlCommand.ExecuteScalar();
            diaChi.Text = addr;

            sqlCommand = new SqlCommand("SELECT SDT_KH FROM KHACHHANG WHERE MA_KH='" + maKH.Text + "'", nachos.sqlCon);
            String phone = (String)sqlCommand.ExecuteScalar();
            sdt.Text = phone;

            sqlCommand = new SqlCommand("SELECT CMND FROM KHACHHANG WHERE MA_KH='" + maKH.Text + "'", nachos.sqlCon);
            String cid = (String)sqlCommand.ExecuteScalar();
            cmnd.Text = cid;

            sqlCommand = new SqlCommand("SELECT HOTEN_NGH FROM NGUOIGIAMHO WHERE MA_KH='" + maKH.Text + "'", nachos.sqlCon);
            String supervisorName = (String)sqlCommand.ExecuteScalar();
            hoTenNGH.Text = supervisorName;

            sqlCommand = new SqlCommand("SELECT NGAYSINH_NGH FROM NGUOIGIAMHO WHERE MA_KH='" + maKH.Text + "'", nachos.sqlCon);
            DateTime supervisorDOB = (DateTime)sqlCommand.ExecuteScalar();
            ngaySinhNGH.Text = supervisorDOB.ToString("d");

            sqlCommand = new SqlCommand("SELECT DIACHI_NGH FROM NGUOIGIAMHO WHERE MA_KH='" + maKH.Text + "'", nachos.sqlCon);
            String supervisorAddr = (String)sqlCommand.ExecuteScalar();
            diaChiNGH.Text = supervisorAddr;

            sqlCommand = new SqlCommand("SELECT SDT_NGH FROM NGUOIGIAMHO WHERE MA_KH='" + maKH.Text + "'", nachos.sqlCon);
            String supervisorPhone = (String)sqlCommand.ExecuteScalar();
            sdtNGH.Text = supervisorPhone;

            SqlCommand cmd = new SqlCommand("select PDKT.MA_PDKT from PHIEUDKTIEM PDKT JOIN HOADON HD ON PDKT.MA_PDKT=HD.MA_PDKT WHERE PDKT.MA_KH='" + maKH.Text + "' AND HD.DATHANHTOAN=0", nachos.sqlCon);
            SqlDataAdapter adapt = new SqlDataAdapter();
            adapt.SelectCommand = cmd;
            DataTable table = new DataTable();
            adapt.Fill(table);
            comboBox1.DataSource = table;
            comboBox1.DisplayMember = "MA_PDKT";
            comboBox1.ValueMember = "MA_PDKT";
            nachos.sqlCon.Close();
        }

        private void traCuuBtn2_Click(object sender, EventArgs e)
        {
            nachos.sqlCon.Open();
            object selecteditem = comboBox1.SelectedValue;
            string maPhieuDKT = selecteditem.ToString();

            SqlCommand sqlCommand = new SqlCommand("SELECT GVX.TEN_GVX FROM PHIEUDKTIEM PDKT JOIN GOIVACXIN GVX ON PDKT.MA_GVX = GVX.MA_GVX WHERE PDKT.MA_PDKT='" + maPhieuDKT + "'", nachos.sqlCon);
            String vacxinTiem = (String)sqlCommand.ExecuteScalar();
            tenVX.Text = vacxinTiem;

            sqlCommand = new SqlCommand("SELECT THOIGIANTIEM FROM PHIEUDKTIEM WHERE MA_PDKT='" + maPhieuDKT + "'", nachos.sqlCon);
            DateTime thoiGianTiem = (DateTime)sqlCommand.ExecuteScalar();
            ngayTiem.Text = thoiGianTiem.ToString("D");

            sqlCommand = new SqlCommand("SELECT TT.TEN_TT FROM PHIEUDKTIEM PDKT JOIN TRUNGTAM TT ON PDKT.MA_TT = TT.MA_TT WHERE PDKT.MA_PDKT='" + maPhieuDKT + "'", nachos.sqlCon);
            String trungTamTiem = (String)sqlCommand.ExecuteScalar();
            trungTam.Text = trungTamTiem;

            sqlCommand = new SqlCommand("SELECT GVX.GIATIEN FROM PHIEUDKTIEM PDKT JOIN GOIVACXIN GVX ON PDKT.MA_GVX = GVX.MA_GVX WHERE PDKT.MA_PDKT='" + maPhieuDKT + "'", nachos.sqlCon);
            double giaTien = (double)sqlCommand.ExecuteScalar();
            tongTien.Text = giaTien.ToString();

            sqlCommand = new SqlCommand("SELECT GETDATE()", nachos.sqlCon);
            time = (DateTime)sqlCommand.ExecuteScalar();

            sqlCommand = new SqlCommand("SELECT HINHTHUCTHANHTOAN FROM HOADON WHERE MA_PDKT='" + maPhieuDKT + "' AND DATHANHTOAN=0", nachos.sqlCon);
            Boolean hinhThucThanhToan = (Boolean)sqlCommand.ExecuteScalar();

            if (!hinhThucThanhToan)
            {
                hinhThucTT.Text = "1 lần";
                sqlCommand = new SqlCommand("SELECT TONGTIEN FROM HOADON WHERE MA_PDKT='" + maPhieuDKT + "' AND DATHANHTOAN=0", nachos.sqlCon);
                double tienTra = (double)sqlCommand.ExecuteScalar();
                tienCanTra.Text = tienTra.ToString();
                ngayLapHD.Text = time.ToString("D");

            }
            else
            {
                hinhThucTT.Text = "Theo đợt";
                sqlCommand = new SqlCommand("SELECT TOP 1 CT.DOTTHANHTOAN FROM CHITIET_HD CT JOIN HOADON HD ON CT.MA_HD = HD.MA_HD WHERE MA_PDKT='" + maPhieuDKT + "' AND CT.DATHANHTOAN=0 ", nachos.sqlCon);
                Int32 dot = (Int32)sqlCommand.ExecuteScalar();
                dotTT.Text = dot.ToString();

                sqlCommand = new SqlCommand("SELECT CT.SOTIENTHANHTOAN FROM CHITIET_HD CT JOIN HOADON HD ON CT.MA_HD = HD.MA_HD WHERE MA_PDKT='" + maPhieuDKT + "' AND CT.DOTTHANHTOAN=" + dot.ToString(), nachos.sqlCon);
                double tienTra = (double)sqlCommand.ExecuteScalar();
                tienCanTra.Text = tienTra.ToString();
            }

            nachos.sqlCon.Close();
        }
    }
}
