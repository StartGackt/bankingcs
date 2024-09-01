using System;
using System.Linq;
using System.Windows.Forms;
using finalprojectbanking.Model;

namespace finalprojectbanking
{
    public partial class UserPaymentLone : Form
    {
        public UserPaymentLone()
        {
            InitializeComponent();
            txtUsername.TextChanged += TxtUsername_TextChanged;
            txtNuneycetegory.TextChanged += txtNuneycetegory_TextChanged;
            
        }

       

        private readonly dbcontext _dbContext = new dbcontext();
        private string currentUsername; // Store the currently active username

        private void TxtUsername_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string username = txtUsername.Text;
                currentUsername = username; // Store the current username

                if (string.IsNullOrEmpty(username))
                {
                    ClearUserFields();
                    return;
                }

                // Search for user data
                var user = _dbContext.Users.FirstOrDefault(u => u.Username == username);
                if (user != null)
                {
                    txtFamily.Text = user.Family;
                    txtIdCard.Text = user.IdCard;
                    txtPhone.Text = user.Phone;
                    txtFullname.Text = user.Fullname;

                    // Clear loan information when a new username is entered
                    ClearLoanFields();
                }
                else
                {
                    ClearUserFields();
                }
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        private void txtNuneycetegory_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string username = txtUsername.Text;
                string Nuneycetegory = txtNuneycetegory.Text.Trim();

                if (string.IsNullOrEmpty(username))
                {
                    MessageBox.Show("กรุณากรอกชื่อผู้ใช้ก่อน", "ข้อมูลไม่ครบ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ClearLoanFields();
                    return;
                }

                bool userHasLoanData = _dbContext.OrdLones.Any(o => o.Username == username) || _dbContext.Emers.Any(e => e.Username == username);
                if (!userHasLoanData)
                {
                    ClearLoanFields();
                    MessageBox.Show("ไม่พบข้อมูลการกู้สำหรับชื่อผู้ใช้นี้", "ข้อมูลไม่ครบ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrEmpty(Nuneycetegory))
                {
                    MessageBox.Show("กรุณากรอกประเภทการกู้", "ข้อมูลไม่ครบ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ClearLoanFields();
                    return;
                }

                decimal loanAmount = 0m;
                decimal interestRate = 0m;
                decimal interestAmount = 0m;

                if (Nuneycetegory == "กู้สามัญ")
                {
                    var ordLone = _dbContext.OrdLones.FirstOrDefault(o => o.Username == username);
                    if (ordLone != null)
                    {
                        txtNumberLone.Text = ordLone.NumberLone ?? "ไม่พบข้อมูล";
                        txtLoneMoney.Text = ordLone.LoneMoney.ToString("F2");

                        loanAmount = Convert.ToDecimal(ordLone.LoneMoney); // Convert double to decimal
                        interestRate = (decimal)0.08; // 8% ดอกเบี้ย
                    }
                    else
                    {
                        ClearLoanFields();
                        MessageBox.Show("ไม่พบข้อมูลการกู้สามัญ", "ข้อมูลไม่ครบ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtNumberLone.Text = "ไม่พบข้อมูล";
                        txtLoneMoney.Text = "ไม่พบข้อมูล";
                        return;
                    }
                }
                else if (Nuneycetegory == "กู้ฉุกเฉิน")
                {
                    var emerLone = _dbContext.Emers.FirstOrDefault(e => e.Username == username);
                    if (emerLone != null)
                    {
                        txtNumberLone.Text = emerLone.NumberLone ?? "ไม่พบข้อมูล";
                        txtLoneMoney.Text = emerLone.LoneMoney.ToString("F2");

                        loanAmount = Convert.ToDecimal(emerLone.LoneMoney); // Convert double to decimal
                        interestRate = (decimal)0.01; // 1% ดอกเบี้ย
                    }
                    else
                    {
                        ClearLoanFields();
                        MessageBox.Show("ไม่พบข้อมูลการกู้ฉุกเฉิน", "ข้อมูลไม่ครบ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtNumberLone.Text = "ไม่พบข้อมูล";
                        txtLoneMoney.Text = "ไม่พบข้อมูล";
                        return;
                    }
                }

                // คำนวณดอกเบี้ย
                interestAmount = loanAmount * interestRate;
                decimal totalWithInterest = loanAmount + interestAmount;

                // แสดงผลลัพธ์
                txtMoneyFirst.Text = loanAmount.ToString("F2");   // เงินหลักที่แยกไว้
                txtInterest.Text = interestAmount.ToString("F2"); // ดอกเบี้ย
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        // Clear user fields
        private void ClearUserFields()
        {
            txtFamily.Clear();
            txtIdCard.Clear();
            txtPhone.Clear();
            txtFullname.Clear();
            ClearLoanFields(); // Also clear loan information
        }

        // Clear loan fields
        private void ClearLoanFields()
        {
            txtNumberLone.Clear();
            txtLoneMoney.Clear();
        }

        // Display error message
        private void ShowError(Exception ex)
        {
            MessageBox.Show($"เกิดข้อผิดพลาด: {ex.Message}\n{ex.StackTrace}", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void UserPaymentLone_Load(object sender, EventArgs e)
        {
            // Initialization code if needed
        }

        private void txtUserPay_TextChanged(object sender, EventArgs e)
        {
            // fix to cal paymext user 

        }
    }
}
