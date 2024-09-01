using System;
using System.Linq;
using System.Windows.Forms;
using finalprojectbanking.Model;

namespace finalprojectbanking
{
    public partial class UserEditOrdloans : Form
    {
        public UserEditOrdloans()
        {
            InitializeComponent();
            txtUsername.TextChanged += TxtUsername_TextChanged;
            txtUsername1.TextChanged += TxtUsername1_TextChanged;
            txtUsername2.TextChanged += TxtUsername2_TextChanged;
            txtUsername3.TextChanged += TxtUsername3_TextChanged;
        }

        private readonly dbcontext _dbContext = new dbcontext();

        private void TxtUsername_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string username = txtUsername.Text;
                if (string.IsNullOrEmpty(username))
                {
                    ClearFields();
                    return;
                }

                var ordLone = _dbContext.OrdLones.FirstOrDefault(u => u.Username == username);
                if (ordLone != null)
                {
                    PopulateOrdLoneFields(ordLone);
                }
                else
                {
                    ClearFields();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"เกิดข้อผิดพลาด: {ex.Message}\n{ex.StackTrace}", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PopulateOrdLoneFields(OrdLone ordLone)
        {
            txtFamily.Text = ordLone.Family;
            txtIdCard.Text = ordLone.IdCard;
            txtPhone.Text = ordLone.Phone;
            txtFullname.Text = ordLone.Fullname;
            txtUsername1.Text = ordLone.Username;
            txtUsername2.Text = ordLone.Username1;
            txtUsername3.Text = ordLone.Username2;
            txtFullname1.Text = ordLone.Fullname1;
            txtFullname2.Text = ordLone.Fullname2;
            txtFullname3.Text = ordLone.Fullname3;
            txtPhone1.Text = ordLone.Phone1;
            txtPhone2.Text = ordLone.Phone2;
            txtPhone3.Text = ordLone.Phone3;
            txtLoneMoney.Text = ordLone.LoneMoney.ToString();
            txtLoneMoney1.Text = ordLone.LoneMoney1.ToString();
            txtMoneyOld.Text = ordLone.MoneyOld.ToString();
            txtNumberLone.Text = ordLone.NumberLone;
            txtTotalMoneyLone.Text = ordLone.TotalMoneyLone.ToString();
        }

        private void ClearFields()
        {
            txtFamily.Text = string.Empty;
            txtIdCard.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtFullname.Text = string.Empty;
            txtUsername1.Text = string.Empty;
            txtUsername2.Text = string.Empty;
            txtUsername3.Text = string.Empty;
            txtFullname1.Text = string.Empty;
            txtFullname2.Text = string.Empty;
            txtFullname3.Text = string.Empty;
            txtPhone1.Text = string.Empty;
            txtPhone2.Text = string.Empty;
            txtPhone3.Text = string.Empty;
            txtLoneMoney.Text = string.Empty;
            txtLoneMoney1.Text = string.Empty;
            txtMoneyOld.Text = string.Empty;
            txtNumberLone.Text = string.Empty;
            txtTotalMoneyLone.Text = string.Empty;
            txtEditUsername1.Text = string.Empty;
            txtEditUsername2.Text = string.Empty;
            txtEditUsername3.Text = string.Empty;
        }

        private void TxtUsername1_TextChanged(object sender, EventArgs e)
        {
            SearchUser(txtUsername1, txtFullname1, txtPhone1);
        }

        private void TxtUsername2_TextChanged(object sender, EventArgs e)
        {
            SearchUser(txtUsername2, txtFullname2, txtPhone2);
        }

        private void TxtUsername3_TextChanged(object sender, EventArgs e)
        {
            SearchUser(txtUsername3, txtFullname3, txtPhone3);
        }

        private void SearchUser(TextBox usernameTextBox, params TextBox[] fields)
        {
            try
            {
                string username = usernameTextBox.Text;
                if (string.IsNullOrEmpty(username))
                {
                    // Clear the fields if username is empty
                    foreach (var field in fields)
                    {
                        field.Text = string.Empty;
                    }
                    return;
                }

                var user = _dbContext.Users.FirstOrDefault(u => u.Username == username);
                if (user != null)
                {
                    if (fields.Length > 0) fields[0].Text = user.Fullname;
                    if (fields.Length > 1) fields[1].Text = user.Phone;
                }
                else
                {
                    // Clear the fields if user is not found
                    foreach (var field in fields)
                    {
                        field.Text = string.Empty;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"เกิดข้อผิดพลาด: {ex.Message}\n{ex.StackTrace}", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void UserEditOrdloans_Load(object sender, EventArgs e)
        {
            // Any initialization code here.
        }

        private void Save_Click(object sender, EventArgs e)
        {
            try
            {
                // ตรวจสอบข้อมูลจาก TextBox
                if (string.IsNullOrEmpty(txtUsername.Text))
                {
                    MessageBox.Show("กรุณากรอก Username", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // ค้นหาข้อมูลในฐานข้อมูล OrdLones
                var ordLone = _dbContext.OrdLones.FirstOrDefault(u => u.Username == txtUsername.Text);
                if (ordLone == null)
                {
                    MessageBox.Show("ไม่พบข้อมูลในตาราง OrdLone ที่มี Username นี้", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // อัปเดตข้อมูลในตาราง OrdLones
                ordLone.Username1 = txtUsername1.Text;
                ordLone.Fullname1 = txtFullname1.Text;
                ordLone.Phone1 = txtPhone1.Text;
                ordLone.Username2 = txtUsername2.Text;
                ordLone.Fullname2 = txtFullname2.Text;
                ordLone.Phone2 = txtPhone2.Text;
                ordLone.Username3 = txtUsername3.Text;
                ordLone.Fullname3 = txtFullname3.Text;
                ordLone.Phone3 = txtPhone3.Text;
                ordLone.MoneyOld = double.Parse(txtMoneyOld.Text);
                ordLone.LoneMoney = double.Parse(txtLoneMoney.Text);
                ordLone.NumberLone = txtNumberLone.Text;
                ordLone.LoneMoney1 = double.Parse(txtLoneMoney1.Text);
                ordLone.TotalMoneyLone = double.Parse(txtTotalMoneyLone.Text);

                // ค้นหาข้อมูลในตาราง EditOraLone
                var editOraLone = _dbContext.EditOraLones.FirstOrDefault(e => e.Username == txtUsername.Text);
                if (editOraLone == null)
                {
                    // ถ้าไม่พบข้อมูล ให้สร้างรายการใหม่
                    editOraLone = new EditOraLone
                    {
                        Username = txtUsername.Text
                    };
                    _dbContext.EditOraLones.Add(editOraLone);
                }

                // อัปเดตข้อมูลในตาราง EditOraLone
                editOraLone.Family = txtFamily.Text;
                editOraLone.IdCard = txtIdCard.Text;
                editOraLone.Phone = txtPhone.Text;
                editOraLone.Fullname = txtFullname.Text;
                editOraLone.Username1 = txtUsername1.Text;
                editOraLone.Fullname1 = txtFullname1.Text;
                editOraLone.Phone1 = txtPhone1.Text;
                editOraLone.EditUsername1 = txtEditUsername1.Text;
                editOraLone.Username2 = txtUsername2.Text;
                editOraLone.Fullname2 = txtFullname2.Text;
                editOraLone.Phone2 = txtPhone2.Text;
                editOraLone.EditUsername2 = txtEditUsername2.Text;
                editOraLone.Username3 = txtUsername3.Text;
                editOraLone.Fullname3 = txtFullname3.Text;
                editOraLone.Phone3 = txtPhone3.Text;
                editOraLone.EditUsername3 = txtEditUsername3.Text;
                editOraLone.MoneyOld = double.Parse(txtMoneyOld.Text);
                editOraLone.LoneMoney = double.Parse(txtLoneMoney.Text);
                editOraLone.NumberLone = txtNumberLone.Text;
                editOraLone.LoneMoney1 = double.Parse(txtLoneMoney1.Text);
                editOraLone.TotalMoneyLone = double.Parse(txtTotalMoneyLone.Text);

                // บันทึกข้อมูลลงในฐานข้อมูล
                _dbContext.SaveChanges();

                // แสดงข้อความแจ้งเตือน
                MessageBox.Show("อัปเดตข้อมูลเรียบร้อย", "สำเร็จ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // เคลียร์ฟิลด์
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"เกิดข้อผิดพลาด: {ex.Message}\n{ex.StackTrace}", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnsearch_Click(object sender, EventArgs e)
        {
            try
            {
                // ตรวจสอบข้อมูลจาก TextBox
                if (string.IsNullOrEmpty(txtUsername.Text))
                {
                    MessageBox.Show("กรุณากรอก Username เพื่อค้นหา", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // ค้นหาข้อมูลในตาราง EditOraLone
                var editOraLone = _dbContext.EditOraLones.FirstOrDefault(e => e.Username == txtUsername.Text);
                if (editOraLone == null)
                {
                    MessageBox.Show("ไม่พบข้อมูลในตาราง EditOraLone ที่มี Username นี้", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // แสดงข้อมูลในฟิลด์ที่ต้องการ
                txtUsername.Text = editOraLone.Username;
                txtFamily.Text = editOraLone.Family;
                txtIdCard.Text = editOraLone.IdCard;
                txtPhone.Text = editOraLone.Phone;
                txtFullname.Text = editOraLone.Fullname;
                txtUsername1.Text = editOraLone.Username1;
                txtFullname1.Text = editOraLone.Fullname1;
                txtPhone1.Text = editOraLone.Phone1;
                txtEditUsername1.Text = editOraLone.EditUsername1;
                txtUsername2.Text = editOraLone.Username2;
                txtFullname2.Text = editOraLone.Fullname2;
                txtPhone2.Text = editOraLone.Phone2;
                txtEditUsername2.Text = editOraLone.EditUsername2;
                txtUsername3.Text = editOraLone.Username3;
                txtFullname3.Text = editOraLone.Fullname3;
                txtPhone3.Text = editOraLone.Phone3;
                txtEditUsername3.Text = editOraLone.EditUsername3;
                txtMoneyOld.Text = editOraLone.MoneyOld.ToString();
                txtLoneMoney.Text = editOraLone.LoneMoney.ToString();
                txtNumberLone.Text = editOraLone.NumberLone;
                txtLoneMoney1.Text = editOraLone.LoneMoney1.ToString();
                txtTotalMoneyLone.Text = editOraLone.TotalMoneyLone.ToString();

                // แสดงข้อความแจ้งเตือนว่าพบข้อมูล
                MessageBox.Show("พบข้อมูลและแสดงในฟิลด์เรียบร้อย", "สำเร็จ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"เกิดข้อผิดพลาด: {ex.Message}\n{ex.StackTrace}", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}

