using finalprojectbanking.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace finalprojectbanking
{
    public partial class AdminRegisterForm : Form
    {
        public AdminRegisterForm()
        {
            InitializeComponent();
        }

        dbcontext dbcontext = new dbcontext();

        private void btadd_Click(object sender, EventArgs e)
        {
            try
            {
                // ตรวจสอบข้อมูลที่ป้อนเข้ามา
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

                if (string.IsNullOrEmpty(txtIdcard.Text))
                {
                    MessageBox.Show("กรุณากรอกรหัสบัตรประชาชน", "ผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtIdcard.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(txtPhone.Text))
                {
                    MessageBox.Show("กรุณากรอกเบอร์โทรศัพท์", "ผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPhone.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(txtFullname.Text))
                {
                    MessageBox.Show("กรุณากรอกชื่อ-นามสกุล", "ผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtFullname.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(txtAddress.Text))
                {
                    MessageBox.Show("กรุณากรอกที่อยู่", "ผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtAddress.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(txtPosition.Text))
                {
                    MessageBox.Show("กรุณากรอกตําแหน่ง", "ผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPosition.Focus();
                    return;
                }

                // สร้างอ็อบเจ็กต์ AdminRegister
                var adminRegister = new AdminRegister
                {
                    Username = txtUsername.Text,
                    Password = txtPassword.Text,
                    Idcard = txtIdcard.Text,
                    Phone = txtPhone.Text,
                    Fullname = txtFullname.Text,
                    Address = txtAddress.Text,
                    Time = DateTime.Now.ToString("hh:mm:ss tt"),
                    Position = txtPosition.Text
                };

                // เพิ่มข้อมูลและบันทึก
                dbcontext.AdminRegisters.Add(adminRegister);
                dbcontext.SaveChanges();

                MessageBox.Show("เพิ่มข้อมูลสำเร็จ", "สำเร็จ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception dbEx)
            {
                // ดึงรายละเอียดข้อผิดพลาด
                var innerException = dbEx.InnerException?.InnerException;
                MessageBox.Show($"ข้อผิดพลาดในการอัปเดตฐานข้อมูล: {innerException?.Message ?? dbEx.Message}", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
