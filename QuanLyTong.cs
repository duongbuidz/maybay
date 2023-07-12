using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanVe
{
    public partial class QuanLyTong : Form
    {
        public QuanLyTong()
        {
            InitializeComponent();
        }

        private void QuanLyTong_Load(object sender, EventArgs e)
        {
            Class.Function.Connect();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Class.Function.Disconnect();    
            Application.Exit();
        }

        private void kháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            quanlyKH qlkh = new quanlyKH();
            qlkh.ShowDialog();
        }
    }
}
