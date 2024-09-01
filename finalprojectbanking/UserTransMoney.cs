using System;
using System.Linq;
using System.Windows.Forms;
using finalprojectbanking.Model;

namespace finalprojectbanking
{
    public partial class UserTransMoney : Form
    {
        private readonly dbcontext _dbContext = new dbcontext();
        private MoneyTrans currentTransaction;

        public UserTransMoney()
        {
            InitializeComponent();
            txtUsername.TextChanged += TxtUsername_TextChanged;
            txtMoneyLast.TextChanged += txtMoneyLast_TextChanged;
            btnsearch.Click += btnsearch_Click;
            Edit.Click += Edit_Click; // เพิ่ม event handler สำหรับปุ่มแก้ไข
            del.Click += del_Click; // เพิ่ม event handler สำหรับปุ่มลบ
        }

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

                var user = _dbContext.Users.FirstOrDefault(u => u.Username == username);
                if (user != null)
                {
                    txtFamily.Text = user.Family;
                    txtIdCard.Text = user.IdCard;
                    txtPhone.Text = user.Phone;
                    txtFullname.Text = user.Fullname;
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

        private void ClearFields()
        {
            txtFamily.Clear();
            txtIdCard.Clear();
            txtPhone.Clear();
            txtFullname.Clear();
            txtMoneyOld.Text = "0.00";
            txtMoneyLast.Clear();
            txtMoneyTotal.Clear();
        }

        private void txtMoneyLast_TextChanged(object sender, EventArgs e)
        {
            try
            {
                // ตรวจสอบว่า txtMoneyOld และ txtMoneyLast มีค่าเป็นตัวเลขหรือไม่
                if (decimal.TryParse(txtMoneyOld.Text, out decimal moneyOld) &&
                    decimal.TryParse(txtMoneyLast.Text, out decimal moneyLast))
                {
                    // คำนวณยอดเงินรวม
                    decimal moneyTotal = moneyOld + moneyLast;
                    txtMoneyTotal.Text = moneyTotal.ToString("N2"); // แสดงผลเป็นตัวเลขที่มีทศนิยม 2 ตำแหน่ง
                }
                else
                {
                    // ถ้าค่าที่ป้อนไม่ใช่ตัวเลข ให้ตั้งค่าเริ่มต้น
                    txtMoneyOld.Text = "0.00";
                    txtMoneyTotal.Clear();
                }
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
                string username = txtUsername.Text;
                if (string.IsNullOrEmpty(username))
                {
                    MessageBox.Show("กรุณากรอกชื่อผู้ใช้", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var user = _dbContext.Users.FirstOrDefault(u => u.Username == username);
                if (user != null)
                {
                    txtFamily.Text = user.Family;
                    txtIdCard.Text = user.IdCard;
                    txtPhone.Text = user.Phone;
                    txtFullname.Text = user.Fullname;

                    // ค้นหาและแสดงผลข้อมูลการทำธุรกรรม
                    currentTransaction = _dbContext.MoneyTranss
                        .Where(t => t.Username == username)
                        .OrderByDescending(t => t.TimeMoney)
                        .FirstOrDefault();

                    if (currentTransaction != null)
                    {
                        txtMoneyOld.Text = currentTransaction.MoneyTotal.ToString("N2");
                        txtMoneyLast.Clear();
                        txtMoneyTotal.Clear();
                    }
                    else
                    {
                        txtMoneyOld.Text = "0.00";
                        txtMoneyLast.Clear();
                        txtMoneyTotal.Clear();
                    }
                }
                else
                {
                    MessageBox.Show("ไม่พบข้อมูลผู้ใช้", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ClearFields();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"เกิดข้อผิดพลาด: {ex.Message}\n{ex.StackTrace}", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnadd_Click_1(object sender, EventArgs e)
        {
            try
            {
                // ตรวจสอบค่าที่ป้อนให้ถูกต้อง
                if (!decimal.TryParse(txtMoneyLast.Text, out decimal moneyLast))
                {
                    MessageBox.Show("กรุณากรอกจำนวนเงินฝากใหม่ให้ถูกต้อง", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!decimal.TryParse(txtMoneyOld.Text, out decimal moneyOld))
                {
                    MessageBox.Show("กรุณากรอกจำนวนเงินฝากเก่าให้ถูกต้อง", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // สร้างวัตถุ MoneyTrans เพื่อบันทึกข้อมูลลงฐานข้อมูล
                var moneytrans = new MoneyTrans()
                {
                    Username = txtUsername.Text,
                    Family = txtFamily.Text,
                    Phone = txtPhone.Text,
                    Fullname = txtFullname.Text,
                    IdCard = txtIdCard.Text,
                    MoneyLast = moneyLast,
                    MoneyOld = moneyOld,
                    MoneyTotal = moneyOld + moneyLast,
                    TimeMoney = dateTimePicker2.Value // ใช้ค่า DateTime จาก dateTimePicker
                };

                // บันทึกข้อมูลลงฐานข้อมูล
                _dbContext.MoneyTranss.Add(moneytrans);
                _dbContext.SaveChanges();

                MessageBox.Show("บันทึกข้อมูลสำเร็จ", "สำเร็จ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // ล้างค่าที่ป้อนในฟอร์มหลังจากบันทึกสำเร็จ
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"เกิดข้อผิดพลาด: {ex.Message}\n{ex.StackTrace}", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Edit_Click(object sender, EventArgs e)
        {
            try
            {
                string username = txtUsername.Text;
                if (string.IsNullOrEmpty(username))
                {
                    MessageBox.Show("กรุณากรอกชื่อผู้ใช้", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var user = _dbContext.Users.FirstOrDefault(u => u.Username == username);
                if (user != null)
                {
                    txtFamily.Text = user.Family;
                    txtIdCard.Text = user.IdCard;
                    txtPhone.Text = user.Phone;
                    txtFullname.Text = user.Fullname;

                    // ค้นหาและแสดงผลข้อมูลการทำธุรกรรม
                    currentTransaction = _dbContext.MoneyTranss
                        .Where(t => t.Username == username)
                        .OrderByDescending(t => t.TimeMoney)
                        .FirstOrDefault();

                    if (currentTransaction != null)
                    {
                        txtMoneyOld.Text = currentTransaction.MoneyTotal.ToString("N2");
                        txtMoneyLast.Clear();
                        txtMoneyTotal.Clear();

                        // ล็อคทุกฟิลด์ยกเว้น txtMoneyLast
                        txtFamily.Enabled = false;
                        txtIdCard.Enabled = false;
                        txtPhone.Enabled = false;
                        txtFullname.Enabled = false;
                        txtMoneyOld.Enabled = false;
                        txtMoneyLast.Enabled = true; // เปิดใช้งานเฉพาะ txtMoneyLast
                        txtMoneyTotal.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("ไม่พบข้อมูลการทำธุรกรรม", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        ClearFields();
                    }
                }
                else
                {
                    MessageBox.Show("ไม่พบข้อมูลผู้ใช้", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ClearFields();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"เกิดข้อผิดพลาด: {ex.Message}\n{ex.StackTrace}", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSaveEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (currentTransaction == null)
                {
                    MessageBox.Show("ไม่พบข้อมูลการทำธุรกรรม", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!decimal.TryParse(txtMoneyLast.Text, out decimal moneyLast))
                {
                    MessageBox.Show("กรุณากรอกจำนวนเงินฝากใหม่ให้ถูกต้อง", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                currentTransaction.MoneyLast = moneyLast;
                currentTransaction.MoneyTotal = currentTransaction.MoneyOld + moneyLast;

                _dbContext.SaveChanges();

                MessageBox.Show("แก้ไขข้อมูลสำเร็จ", "สำเร็จ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // ล้างค่าที่ป้อนในฟอร์มหลังจากบันทึกสำเร็จ
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"เกิดข้อผิดพลาด: {ex.Message}\n{ex.StackTrace}", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void del_Click(object sender, EventArgs e)
        {
            try
            {
                string username = txtUsername.Text;
                if (string.IsNullOrEmpty(username))
                {
                    MessageBox.Show("กรุณากรอกชื่อผู้ใช้", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // ค้นหาผู้ใช้จากฐานข้อมูล
                var user = _dbContext.Users.FirstOrDefault(u => u.Username == username);
                if (user != null)
                {
                    // ค้นหาข้อมูลการทำธุรกรรมล่าสุดของผู้ใช้
                    var transaction = _dbContext.MoneyTranss
                        .Where(t => t.Username == username)
                        .OrderByDescending(t => t.TimeMoney)
                        .FirstOrDefault();

                    if (transaction != null)
                    {
                        // ยืนยันการลบข้อมูล
                        var confirmResult = MessageBox.Show("คุณต้องการลบข้อมูลการทำธุรกรรมนี้ใช่หรือไม่?", "ยืนยันการลบ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (confirmResult == DialogResult.Yes)
                        {
                            // ลบข้อมูลการทำธุรกรรม
                            _dbContext.MoneyTranss.Remove(transaction);
                            _dbContext.SaveChanges();

                            MessageBox.Show("ลบข้อมูลการทำธุรกรรมสำเร็จ", "สำเร็จ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // ล้างค่าที่ป้อนในฟอร์มหลังจากลบสำเร็จ
                            ClearFields();
                        }
                    }
                    else
                    {
                        MessageBox.Show("ไม่พบข้อมูลการทำธุรกรรม", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("ไม่พบข้อมูลผู้ใช้", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ClearFields();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"เกิดข้อผิดพลาด: {ex.Message}\n{ex.StackTrace}", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UserTransMoney_Load(object sender, EventArgs e)
        {

        }

        private void txtFamily_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
