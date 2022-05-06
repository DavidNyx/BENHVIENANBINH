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
    public partial class MHDatHangVacXin : Form
    {
        DataSet ds = null, ds2 = null;
        String maNCC = "";
        public MHDatHangVacXin()
        {
            InitializeComponent();
            string connString = @"Data Source=" + nachos.servername + ";Initial Catalog=" + nachos.dbname + ";Integrated Security=True;" + "UID=" + nachos.username.Trim() + "password=" + nachos.password.Trim();
            nachos.sqlCon = new SqlConnection(connString);
        }

        private void duyetvacxin_Load(object sender, EventArgs e)
        {
            nachos.sqlCon.Open();

            SqlDataAdapter adapt3 = new SqlDataAdapter("SELECT MA_PDMVX, MA_PDKT, TEN_GVX FROM PHIEUDATMUAVX WHERE DUYET_PDMVX=0", nachos.sqlCon);
            DataTable table3 = new DataTable();
            SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(adapt3);

            ds = new DataSet();
            adapt3.Fill(ds, "tblPDM");
            danhsachxetduyet.DataSource = ds.Tables["tblPDM"];

            SqlDataAdapter adapt4 = new SqlDataAdapter("SELECT * FROM NHACUNGCAP", nachos.sqlCon);
            DataTable table4 = new DataTable();
            SqlCommandBuilder cmdBuilder2 = new SqlCommandBuilder(adapt3);

            ds2 = new DataSet();
            adapt4.Fill(ds2, "tblNCC");
            nhacungcapvx.DataSource = ds2.Tables["tblNCC"];

            nachos.sqlCon.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index == -1) return;
            
            try
            {
                DataRow row = ds.Tables["tblPDM"].Rows[index];
                maPhieuDM.Text = " " + row["MA_PDMVX"].ToString();
                tenVX.Text = " " + row["TEN_GVX"].ToString();
                nachos.tenVacXin = tenVX.Text;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            nachos.sqlCon.Open();

            SqlCommand sqlCommand = new SqlCommand("SELECT MA_GVX FROM PHIEUDATMUAVX WHERE MA_PDMVX='" + maPhieuDM.Text + "' AND DUYET_PDMVX=0", nachos.sqlCon);
            String maGVX = (String)sqlCommand.ExecuteScalar();

            if (maGVX != null || maGVX != "null")
            {
                sqlCommand = new SqlCommand("UPDATE PHIEUDATMUAVX SET DUYET_PDMVX=1 WHERE MA_PDMVX='" + maPhieuDM.Text + "'", nachos.sqlCon);
                sqlCommand.ExecuteNonQuery();

                SqlDataAdapter adapt3 = new SqlDataAdapter("SELECT MA_PDMVX, MA_PDKT, TEN_GVX FROM PHIEUDATMUAVX WHERE DUYET_PDMVX=0", nachos.sqlCon);
                DataTable table3 = new DataTable();
                SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(adapt3);

                ds = new DataSet();
                adapt3.Fill(ds, "tblPDM");
                danhsachxetduyet.DataSource = ds.Tables["tblPDM"];
                maPhieuDM.Text = " ";
                tenVX.Text = " ";
            }
            else
            {
                nhapGiaVacXin nhapGiaVacXin = new nhapGiaVacXin();
                nhapGiaVacXin.ShowDialog();

                sqlCommand = new SqlCommand("UPDATE PHIEUDATMUAVX SET DUYET_PDMVX=1 WHERE MA_PDMVX='" + maPhieuDM.Text + "'", nachos.sqlCon);
                sqlCommand.ExecuteNonQuery();

                sqlCommand = new SqlCommand("UPDATE GOIVACXIN SET GIATIEN=" + nachos.giaTien.ToString() + " WHERE MA_GVX='" + maGVX + "'", nachos.sqlCon);
                sqlCommand.ExecuteNonQuery();

                SqlDataAdapter adapt3 = new SqlDataAdapter("SELECT MA_PDMVX, MA_PDKT, TEN_GVX FROM PHIEUDATMUAVX WHERE DUYET_PDMVX=0", nachos.sqlCon);
                DataTable table3 = new DataTable();
                SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(adapt3);

                ds = new DataSet();
                adapt3.Fill(ds, "tblPDM");
                danhsachxetduyet.DataSource = ds.Tables["tblPDM"];
                maPhieuDM.Text = " ";
                tenVX.Text = " ";
            }

            nachos.sqlCon.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            nachos.sqlCon.Open();

            SqlCommand sqlCommand = new SqlCommand("SELECT COUNT(*) FROM PHIEUDATMUAVX WHERE MA_DSDMVX IS NULL AND MA_GVX IS NULL", nachos.sqlCon);
            Int32 count = (Int32)sqlCommand.ExecuteScalar();

            if (count > 0)
            {
                sqlCommand = new SqlCommand("SELECT COUNT(*) FROM DANHSACHDATMUAVX", nachos.sqlCon);
                int num = (Int32)sqlCommand.ExecuteScalar();
                num += 1;

                sqlCommand = new SqlCommand("DECLARE @time DateTime = GETDATE(); INSERT DANHSACHDATMUAVX VALUES('DS" + num.ToString() + "', @time, 1)", nachos.sqlCon);
                sqlCommand.ExecuteNonQuery();

                sqlCommand = new SqlCommand("UPDATE PHIEUDATMUAVX SET MA_DSDMVX='DS" + num.ToString() + "' WHERE MA_DSDMVX IS NULL", nachos.sqlCon);
                sqlCommand.ExecuteNonQuery();

                sqlCommand = new SqlCommand("SELECT COUNT(*) FROM PHIEUNHAPHANG", nachos.sqlCon);
                int num2 = (Int32)sqlCommand.ExecuteScalar();
                num2 += 1;

                sqlCommand = new SqlCommand("DECLARE @time DateTime = GETDATE(); INSERT PHIEUNHAPHANG VALUES('PN" + num2.ToString() + "', 'DS"+ num.ToString() + "', '" + maNCC + "', @time)", nachos.sqlCon);
                sqlCommand.ExecuteNonQuery();

                SqlDataAdapter adapt = new SqlDataAdapter("SELECT * FROM PHIEUNHAPHANG WHERE MA_PNH='PN" + num2.ToString() + "'", nachos.sqlCon);
                DataTable table = new DataTable();
                adapt.Fill(table);
                Phieudathang.DataSource = new BindingSource(table, null);
            }
            else
            {
                MessageBox.Show("Không có đủ vacxin đặt mua để lập danh sách");
            }
            nachos.sqlCon.Close();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index == -1) return;

            try
            {
                DataRow row = ds2.Tables["tblNCC"].Rows[index];
                nhaCungCap.Text = row["TEN_NCC"].ToString();
                maNCC = row["MA_NCC"].ToString();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
