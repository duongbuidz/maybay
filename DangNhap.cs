using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyBanVe.Class;

namespace QuanLyBanVe
{
    public partial class LogIn : Form
    {
        public LogIn()
        {
            InitializeComponent();
        }
        private void LogIn_Load(object sender, EventArgs e)
        {
            Function.Connect();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = "Select * from Customer where CustomerID =N'" + textBox1.Text + "'and  CustomerCCCD = N'" + textBox2.Text + "'";
            DataTable dttb = new DataTable();
            dttb = Function.GetDataToDataTable(sql);
            if(dttb.Rows.Count > 0)
            {
                MessageBox.Show("thanh cong");
                this.Hide();
                QuanLyTong quanLyTong = new QuanLyTong();
                quanLyTong.ShowDialog();
            }
            else
            {
                MessageBox.Show("Sai ");
            }
            }

        
    }
    }

