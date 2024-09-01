using System;
using System.Linq;
using System.Windows.Forms;
using finalprojectbanking.Model;

namespace finalprojectbanking
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        dbcontext dbcontext = new dbcontext();

        private void Form1_Load(object sender, EventArgs e)
        {
            // สามารถใช้โหลดข้อมูลเริ่มต้นที่นี่ถ้าต้องการ
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // ตรวจสอบว่าข้อมูลที่ป้อนเข้ามามีค่าไหม
                if (string.IsNullOrEmpty(txtUsername.Text))
                {
                    MessageBox.Show("กรุณากรอกชื่อผู้ใช้งาน", "ผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtUsername.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(txtPassword.Text))
                {
                    MessageBox.Show("กรุณากรอกรหัสผ่าน", "ผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPassword.Focus();
                    return;
                }

                // ค้นหาผู้ใช้งานในฐานข้อมูล
                var user = dbcontext.AdminRegisters
                                   .FirstOrDefault(u => u.Username == txtUsername.Text && u.Password == txtPassword.Text);

                if (user != null)
                {
                    // ผู้ใช้งานที่เข้าสู่ระบบสำเร็จ
                    MessageBox.Show($"ยินดีต้อนรับ {user.Fullname}", "เข้าสู่ระบบสำเร็จ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // เปิดฟอร์ม Main
                    Main main = new Main();
                    main.Show();

                    // ปิดฟอร์มปัจจุบัน (Form1)
                    this.Hide();
                }
                else
                {
                    // ข้อผิดพลาดในการเข้าสู่ระบบ
                    MessageBox.Show("ชื่อผู้ใช้งานหรือรหัสผ่านไม่ถูกต้อง", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"ข้อผิดพลาด: {ex.Message}", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
