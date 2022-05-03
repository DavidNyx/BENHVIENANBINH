using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class menukhachhang : Form
    {
        public menukhachhang()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            MHdangkytiemchung them = new MHdangkytiemchung();
            them.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            MHdatmuavacxin them = new MHdatmuavacxin();
            them.ShowDialog();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            MHthanhtoanle them = new MHthanhtoanle();
            them.ShowDialog();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            MHtracuutiemchung them = new MHtracuutiemchung();
            them.ShowDialog();
            this.Close();
        }

        private void menukhachhang_Load(object sender, EventArgs e)
        {

        }
    }
    public static class khachhang
    {
        public static string makhachhang = " ";
        public static string hoten = " ";
        public static string cmnd = " ";
        public static string diachi = " ";
        public static string sdt = " ";
        public static string ngaysinh = " ";
    }
    public static class nguoigiamho
    {
        public static string khachhang = " ";
        public static string hoten = " ";
        public static string diachi = " ";
        public static string sdt = " ";
        public static string ngaysinh = " ";
    }
    public static class phieudangkytiem
    {
        public static string makhachhang = " ";
        public static string maphieudangkytiem = " ";
        public static string thoigian = " ";
        public static string trungtam = " ";
        public static string vacxin = " ";
    }
    public static class goivacxin
    {
        public static string doituong = " ";
        public static string ghichu = " ";
        public static float giatien;
        public static string loaivacxin = " ";
        public static string mavacxin = " ";
        public static string tenvacxin = " ";
        public static string vacxintronggoi = " ";
    }
    public static class trungtam
    {
        public static string matrungtam = " ";
        public static string diachi = " ";
        public static string tentrungtam = " ";
        public static string sdt = " ";
    }
    public static class phieudatmua
    {
        public static string maphieudatmua = " ";
        public static string maphieudangkytiem = " ";
        public static string magoivacxin = " ";
        public static bool tinhtrang;
        public static string danhsachdatmua = " ";
    }
}
