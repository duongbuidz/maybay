using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using QuanLyBanVe.Class;


namespace QuanLyBanVe
{
    public partial class quanlyKH : Form
    {
        DataTable dttb;
        public quanlyKH()
        {
            InitializeComponent();
        }

        private void quanlyKH_Load(object sender, EventArgs e)
        {
            LoadDataGridView();
        }
        private void LoadDataGridView()
        {
            string sql;
            sql = "Select * from Customer";
            dttb = Class.Function.GetDataToDataTable(sql); 
            dataGridView1.DataSource = dttb;           
            dataGridView1.Columns[0].HeaderText = "Id";
            dataGridView1.Columns[1].HeaderText = "Tên Khách Hàng";
            dataGridView1.Columns[2].HeaderText = "Ngày sinh";
            dataGridView1.Columns[3].HeaderText = "Căn cước công dân";
            dataGridView1.Columns[4].HeaderText = "Giới tính";
            dataGridView1.Columns[5].HeaderText = "Số Điện Thoại";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
         private void button1_Click(object sender, EventArgs e)
        {
            button2.Enabled = false;
            button3.Enabled = false;
            button6.Enabled = true;
            button4.Enabled = true;
            button1.Enabled = false;
            ResetValue(); //Xoá trắng các textbox
            textBox1.Enabled = true; //cho phép nhập mới
            textBox1.Focus();
        }
        private void ResetValue()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            maskedTextBox1.Text = "";
            maskedTextBox2.Text = "";
            checkBox1.Checked = false;
            checkBox2.Checked = false;
        }
        

        private void button4_Click(object sender, EventArgs e)
        {
                 string sql, gt;
                if (textBox1.Text.Trim() == "")
                {
                    MessageBox.Show("Bạn phải nhập mã khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox1.Focus();
                    return;
                }
                if (textBox2.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập tên khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox2.Focus();
                    return;
                }
            if (maskedTextBox2.Text == "(    )        -")
            {
                MessageBox.Show("Bạn phải nhập căn cước công dân", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                maskedTextBox2.Focus();
                return;
            }
            if (maskedTextBox1.Text == "(   )     -")
                {
                    MessageBox.Show("Bạn phải nhập điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    maskedTextBox1.Focus();
                    return;
                }
            if (checkBox1.Checked == true)
                    gt = "Nam";
            else
                    gt = "Nữ";
            sql = "SELECT CustomerID FROM Customer WHERE CustomerID=N'" + textBox1.Text.Trim() + "'";
            if (Function.CheckKey(sql))
                {
                    MessageBox.Show("Mã khách hàng này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox1.Focus();
                    textBox1.Text = "";
                    return;
                }
                sql = "INSERT INTO Customer VALUES (N'" + textBox1.Text + "',N'" + textBox2.Text+ "','" + dateTimePicker1.Value + "','" + maskedTextBox2.Text + "', N'" + gt + "','" + maskedTextBox1.Text + "')";
                Function.runSql(sql);
                LoadDataGridView();
                ResetValue();
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = false;
                button6.Enabled = false;
                textBox1.Enabled = false;
            }

        private void dataGridView1_Click_1(object sender, EventArgs e)
        {
            if (button1.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox1.Focus();
                return;
            }
            if (dttb.Rows.Count == 0) //Nếu không có dữ liệu
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            textBox1.Text = dataGridView1.CurrentRow.Cells["CustomerID"].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells["CustomerName"].Value.ToString();
            maskedTextBox1.Text = dataGridView1.CurrentRow.Cells["CustomerSDT"].Value.ToString();
            dateTimePicker1.Value = (DateTime)dataGridView1.CurrentRow.Cells["CustomerDOB"].Value;
            maskedTextBox2.Text = dataGridView1.CurrentRow.Cells["CustomerCCCD"].Value.ToString();
            if (dataGridView1.CurrentRow.Cells["CustomerGender"].Value.ToString() == "Nam") checkBox1.Checked = true;
            else checkBox1.Checked = false;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sql, gt;
            if (dttb.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (textBox1.Text.Trim() == "")
            {
                MessageBox.Show("Bạn phải nhập mã khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox1.Focus();
                return;
            }
            if (textBox2.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox2.Focus();
                return;
            }
            if (maskedTextBox1.Text == "(   )     -")
            {
                MessageBox.Show("Bạn phải nhập điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                maskedTextBox1.Focus();
                return;
            }
            if (maskedTextBox2.Text == "(    )        -")
            {
                MessageBox.Show("Bạn phải nhập căn cước công dân", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                maskedTextBox2.Focus();
                return;
            }
            if (checkBox1.Checked == true)
                gt = "Nam";
            else
                gt = "Nữ";
            sql = "UPDATE Customer SET CustomerName=N'" + textBox2.Text.ToString() + "',CustomerDOB='" + dateTimePicker1.Value + "',CustomerCCCD=N'" + maskedTextBox2.Text.ToString()  + "',CustomerGender=N'" + gt + "',CustomerSDT='" + maskedTextBox1.Text.ToString() + "'WHERE CustomerID=N'" + textBox1.Text.ToString() + "'";
            Function.runSql(sql);
            LoadDataGridView();
            ResetValue();
            button6.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string sql;
            if (dttb.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (textBox1.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                sql = "DELETE Customer WHERE CustomerID=N'" + textBox1.Text + "'";
                Function.RunSqlDel(sql);
                LoadDataGridView();
                ResetValue();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
                ResetValue();
                button6.Enabled = false;
                button1.Enabled = true;
                button3.Enabled = true;
                button2.Enabled = true;
                button4.Enabled = false;
                textBox1.Enabled = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string sql;
            if ((textBox1.Text == "") && (textBox2.Text == ""))
            {
                MessageBox.Show("Bạn hãy nhập điều kiện tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            sql = "SELECT * from Customer WHERE 1=1";
            if (textBox1.Text != "")
                sql += " AND CustomerID LIKE N'%" + textBox1.Text + "%'";
            if (textBox2.Text != "")
                sql += " AND CustomerName LIKE N'%" + textBox2.Text + "%'";
            dttb = Function.GetDataToDataTable(sql);
            if (dttb.Rows.Count == 0)
                MessageBox.Show("Không có bản ghi thoả mãn điều kiện tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                MessageBox.Show("có" + dttb.Rows.Count + " kết quả");
            }
            dataGridView1.DataSource = dttb;
            ResetValue();
        }
    }
    }

