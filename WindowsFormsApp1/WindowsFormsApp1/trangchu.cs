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
using System.IO;

namespace WindowsFormsApp1
{
    public partial class trangchu : Form
    {
        public trangchu()
        {
            InitializeComponent();
            int count = 0;
            //tim file
            var path = Path.Combine(Directory.GetCurrentDirectory(), "config.txt");
            foreach (string line in System.IO.File.ReadLines(path))
            {
                if (count == 0)
                {
                    nachos.servername = line;
                }
                else if (count == 1)
                {
                    nachos.dbname = line;
                }
                count++;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            menukhachhang them = new menukhachhang();
            them.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            dangnhapnhanvien them = new dangnhapnhanvien();
            them.ShowDialog();
            this.Close();
        }
    }
    public static class nachos
    {
        public static SqlConnection sqlCon = null;
        public static string username = "";
        public static string servername = "";
        public static string dbname = "";
        public static string password = "";
        public static string id = "";
    }
}
