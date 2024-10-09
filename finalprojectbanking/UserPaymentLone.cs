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
            txtTotalUserPay.TextChanged += txtUserPay_TextChanged;

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
            if (decimal.TryParse(txtMoneyFirst.Text, out decimal moneyFirst) &&
               decimal.TryParse(txtInterest.Text, out decimal interest) &&
               decimal.TryParse(txtUserPay.Text, out decimal userPay))
            {
                decimal totalAmount = moneyFirst + interest;
                decimal remainingAmount = totalAmount - userPay;
                txtTotalUserPay.Text = remainingAmount.ToString("F2");
            }
            else
            {
                MessageBox.Show("กรุณากรอกข้อมูลที่ถูกต้อง", "ข้อมูลไม่ครบ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                // Check loan type and convert to int
                int category = 0;
                if (txtNuneycetegory.Text == "กู้สามัญ")
                {
                    category = 1; // Assume 1 is for regular loan
                }
                else if (txtNuneycetegory.Text == "กู้ฉุกเฉิน")
                {
                    category = 2; // Assume 2 is for emergency loan
                }
                else
                {
                    MessageBox.Show("ประเภทการกู้ไม่ถูกต้อง", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Stop execution if loan type is invalid
                }

                // Create a new Payment object
                var newpay = new UserPayment
                {
                    Username = txtUsername.Text,
                    Family = txtFamily.Text,
                    IdCard = txtIdCard.Text,
                    Phone = txtPhone.Text,
                    Fullname = txtFullname.Text,
                    Nuneycetegory = category,
                    NumberLone = txtNumberLone.Text,
                    LoneMoney = decimal.Parse(txtLoneMoney.Text),
                    MoneyFirst = (int)Math.Round(decimal.Parse(txtMoneyFirst.Text)),
                    Interest = (int)Math.Round(decimal.Parse(txtInterest.Text)),
                    UserPay = decimal.Parse(txtUserPay.Text),
                    TotalUserPay = decimal.Parse(txtTotalUserPay.Text)
                };

                // Add payment data to the database
                _dbContext.UserPayments.Add(newpay);
                _dbContext.SaveChanges();

                decimal remainingAmount = newpay.LoneMoney - newpay.UserPay;
                txtLoneMoney.Text = remainingAmount.ToString();

                MessageBox.Show("บันทึกข้อมูลสำเร็จ", "สำเร็จ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // Log the inner exception for more details
                ShowError(ex.InnerException ?? ex);
            }
        }

        private void btnedit_Click(object sender, EventArgs e)
        {

        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            try
            {
                // ค้นหาจาก Username ที่กรอกใน txtUsername
                string username = txtUsername.Text;
                var payment = _dbContext.UserPayments.FirstOrDefault(p => p.Username == username);

                if (payment != null)
                {
                    // ถ้าพบข้อมูลการกู้ยืม ให้แสดงข้อมูลใน TextBox
                    txtFamily.Text = payment.Family;
                    txtIdCard.Text = payment.IdCard;
                    txtPhone.Text = payment.Phone;
                    txtFullname.Text = payment.Fullname;
                    txtNuneycetegory.Text = (payment.Nuneycetegory == 1) ? "กู้สามัญ" : "กู้ฉุกเฉิน";
                    txtLoneMoney.Text = payment.LoneMoney.ToString();
                    txtMoneyFirst.Text = payment.MoneyFirst.ToString();
                    txtInterest.Text = payment.Interest.ToString();
                    txtUserPay.Text = payment.UserPay.ToString();
                    txtTotalUserPay.Text = payment.TotalUserPay.ToString();
                }
                else
                {
                    // ถ้าไม่พบข้อมูล ให้แสดงข้อความแจ้งเตือน
                    MessageBox.Show("ไม่พบข้อมูลการกู้ยืมของผู้ใช้นี้", "ไม่พบข้อมูล", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                // Handle error and display a friendly message
                MessageBox.Show("เกิดข้อผิดพลาดในการค้นหาข้อมูล: " + ex.Message, "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        }
} 
 

