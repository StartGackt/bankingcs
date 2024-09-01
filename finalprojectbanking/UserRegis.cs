using System;
using System.Linq;
using System.Windows.Forms;
using finalprojectbanking.Model;

namespace finalprojectbanking
{
    public partial class UserRegis : Form
    {
        public UserRegis()
        {
            InitializeComponent();
        }
        private readonly dbcontext _dbContext = new dbcontext();

        private void UserRegis_Load(object sender, EventArgs e)
        {
            GenerateNewUsername();
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtFamily.Text))
                {
                    MessageBox.Show("กรุณากรอกนามสกุล", "ผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtFamily.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(txtIdCard.Text))
                {
                    MessageBox.Show("กรุณากรอกรหัสบัตรประชาชน", "ผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtIdCard.Focus();
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
                if (string.IsNullOrEmpty(txtUser1.Text))
                {
                    MessageBox.Show("กรุณากรอกชื่อผู้ติดต่อ", "ผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtUser1.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(txtPhoneUser1.Text))
                {
                    MessageBox.Show("กรุณากรอกเบอร์โทรศัพท์ผู้ติดต่อ", "ผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPhoneUser1.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(txtUser2.Text))
                {
                    MessageBox.Show("กรุณากรอกชื่อผู้ติดต่อสำรอง", "ผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtUser2.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(txtPhoneUser2.Text))
                {
                    MessageBox.Show("กรุณากรอกเบอร์โทรศัพท์ผู้ติดต่อสำรอง", "ผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPhoneUser2.Focus();
                    return;
                }

                var user = new User()
                {
                    Username = txtUsername.Text,
                    Family = txtFamily.Text,
                    IdCard = txtIdCard.Text,
                    Phone = txtPhone.Text,
                    Fullname = txtFullname.Text,
                    Address = txtAddress.Text,
                    User1 = txtUser1.Text,
                    PhoneUser1 = txtPhoneUser1.Text,
                    User2 = txtUser2.Text,
                    PhoneUser2 = txtPhoneUser2.Text
                };

                _dbContext.Users.Add(user);
                _dbContext.SaveChanges();

                MessageBox.Show("เพิ่มข้อมูลสำเร็จ", "สำเร็จ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
                GenerateNewUsername(); // Generate new username after adding user
            }
            catch (Exception ex)
            {
                MessageBox.Show($"ข้อผิดพลาดในการอัปเดตฐานข้อมูล: {ex.InnerException?.Message ?? ex.Message}", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GenerateNewUsername()
        {
            // Generate a new username based on the number of users in the database
            int userCount = _dbContext.Users.Count() + 1;
            txtUsername.Text = $"{userCount:D3}"; // Format as user00001, user00002, etc.
        }

        private void ClearForm()
        {
            txtUsername.Clear();
            txtFamily.Clear();
            txtIdCard.Clear();
            txtPhone.Clear();
            txtFullname.Clear();
            txtAddress.Clear();
            txtUser1.Clear();
            txtPhoneUser1.Clear();
            txtUser2.Clear();
            txtPhoneUser2.Clear();
        }
    }
}
