using System;
using System.Linq;
using System.Windows.Forms;
using finalprojectbanking.Model;

namespace finalprojectbanking
{
    public partial class SearchUser : Form
    {
        public SearchUser()
        {
            InitializeComponent();
        }

        private readonly dbcontext _dbContext = new dbcontext();

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            // ดึงข้อความค้นหาจาก TextBox
            var search = txtsearch.Text.Trim();

            // ค้นหาข้อมูลผู้ใช้จากฐานข้อมูล
            var users = _dbContext.Users
                        .Where(u => u.Username.Contains(search) || u.Fullname.Contains(search))
                        .ToList();

            // แสดงผลลัพธ์ใน DataGridView
            if (users.Any())
            {
                dataGridView1.DataSource = users;
            }
            else
            {
                MessageBox.Show("ไม่พบข้อมูลผู้ใช้ที่ค้นหา", "ผลลัพธ์", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView1.DataSource = null;
            }
        }
    }
}
