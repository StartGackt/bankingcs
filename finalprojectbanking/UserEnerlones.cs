using System;
using System.Linq;
using System.Windows.Forms;
using finalprojectbanking.Model;

namespace finalprojectbanking
{
    public partial class UserEnerlones : Form
    {
        private readonly dbcontext _dbContext = new dbcontext();

        public UserEnerlones()
        {
            InitializeComponent();
            InitializeEventHandlers();
            GenerateLoanNumber();
        }

        private void InitializeEventHandlers()
        {
            txtUsername.TextChanged += (sender, e) => SearchUserAndFillFields(txtUsername, txtFamily, txtIdCard, txtPhone, txtFullname, txtMoneyOld);
            txtUsername1.TextChanged += (sender, e) => SearchUserAndFillFields(txtUsername1, txtFullname1, txtPhone1);
            txtUsername2.TextChanged += (sender, e) => SearchUserAndFillFields(txtUsername2, txtFullname2, txtPhone2);
            txtUsername3.TextChanged += (sender, e) => SearchUserAndFillFields(txtUsername3, txtFullname3, txtPhone3);
            txtLoneMoney.TextChanged += (sender, e) => CalculateTotalMoney();
        }

        private void SearchUserAndFillFields(TextBox usernameTextBox, TextBox fullNameTextBox, TextBox phoneTextBox)
        {
            string username = usernameTextBox.Text;
            if (string.IsNullOrEmpty(username))
            {
                ClearFields(fullNameTextBox, phoneTextBox);
                return;
            }

            var user = _dbContext.Users.FirstOrDefault(u => u.Username == username);
            if (user != null)
            {
                fullNameTextBox.Text = user.Fullname;
                phoneTextBox.Text = user.Phone;
            }
            else
            {
                ClearFields(fullNameTextBox, phoneTextBox);
            }
        }

        private void SearchUserAndFillFields(TextBox usernameTextBox, TextBox familyTextBox, TextBox idCardTextBox, TextBox phoneTextBox, TextBox fullNameTextBox, TextBox moneyOldTextBox)
        {
            string username = usernameTextBox.Text;
            if (string.IsNullOrEmpty(username))
            {
                ClearFields(familyTextBox, idCardTextBox, phoneTextBox, fullNameTextBox, moneyOldTextBox);
                return;
            }

            var user = _dbContext.Users.FirstOrDefault(u => u.Username == username);
            if (user != null)
            {
                familyTextBox.Text = user.Family;
                idCardTextBox.Text = user.IdCard;
                phoneTextBox.Text = user.Phone;
                fullNameTextBox.Text = user.Fullname;

                var transaction = _dbContext.MoneyTranss
                    .Where(t => t.Username == username)
                    .OrderByDescending(t => t.TimeMoney)
                    .FirstOrDefault();

                moneyOldTextBox.Text = transaction?.MoneyTotal.ToString("N2") ?? "0.00";
            }
            else
            {
                ClearFields(familyTextBox, idCardTextBox, phoneTextBox, fullNameTextBox, moneyOldTextBox);
            }
        }

        private void ClearFields(params TextBox[] textBoxes)
        {
            foreach (var textBox in textBoxes)
            {
                textBox.Clear();
            }
        }

        private void GenerateLoanNumber()
        {




            var lastLoan = _dbContext.Emers
                .OrderByDescending(e => e.NumberLone)
                .FirstOrDefault();

            int newSequence = 1;

            if (lastLoan != null && lastLoan.NumberLone.Length > 5)
            {
                string lastSequenceStr = lastLoan.NumberLone.Substring(5);
                if (int.TryParse(lastSequenceStr, out int lastSequence))
                {
                    newSequence = lastSequence + 1;
                }
            }

            txtNumberLone.Text = $"Emer-{newSequence:D3}";
        }

        private void CalculateTotalMoney()
        {
            if (decimal.TryParse(txtLoneMoney.Text, out decimal loanAmount))
            {
                decimal interest = loanAmount * 0.01m;
                txtTotalMoneyLone.Text = (loanAmount + interest).ToString("F2");
            }
            else
            {
                txtTotalMoneyLone.Clear();
            }
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            if (!ValidateInputFields())
            {
                MessageBox.Show("กรุณากรอกข้อมูลให้ครบถ้วนและถูกต้อง.", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var newLoan = CreateNewLoan();
            _dbContext.Emers.Add(newLoan);
            _dbContext.SaveChanges();

            MessageBox.Show("ข้อมูลการกู้เงินถูกเพิ่มเรียบร้อยแล้ว.", "สำเร็จ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearFields(txtUsername, txtFamily, txtIdCard, txtPhone, txtFullname, txtLoneMoney, txtTotalMoneyLone, txtNumberLone, txtUsername1, txtFullname1, txtPhone1, txtUsername2, txtFullname2, txtPhone2, txtUsername3, txtFullname3, txtPhone3);
            GenerateLoanNumber();
        }

        private bool ValidateInputFields()
        {
            return !string.IsNullOrEmpty(txtUsername.Text.Trim()) &&
                   !string.IsNullOrEmpty(txtFamily.Text.Trim()) &&
                   !string.IsNullOrEmpty(txtIdCard.Text.Trim()) &&
                   !string.IsNullOrEmpty(txtPhone.Text.Trim()) &&
                   !string.IsNullOrEmpty(txtFullname.Text.Trim()) &&
                   double.TryParse(txtLoneMoney.Text.Trim(), out _) &&
                   double.TryParse(txtTotalMoneyLone.Text.Trim(), out _);
        }

        private Emer CreateNewLoan()
        {
            return new Emer
            {
                Username = txtUsername.Text.Trim(),
                Family = txtFamily.Text.Trim(),
                IdCard = txtIdCard.Text.Trim(),
                Phone = txtPhone.Text.Trim(),
                Fullname = txtFullname.Text.Trim(),
                Username1 = txtUsername1.Text.Trim(),
                Fullname1 = txtFullname1.Text.Trim(),
                Phone1 = txtPhone1.Text.Trim(),
                Username2 = txtUsername2.Text.Trim(),
                Fullname2 = txtFullname2.Text.Trim(),
                Phone2 = txtPhone2.Text.Trim(),
                Username3 = txtUsername3.Text.Trim(),
                Fullname3 = txtFullname3.Text.Trim(),
                Phone3 = txtPhone3.Text.Trim(),
                MoneyOld = double.TryParse(txtMoneyOld.Text.Trim(), out double moneyOld) ? moneyOld : 0,
                LoneMoney = double.TryParse(txtLoneMoney.Text.Trim(), out double loneMoney) ? loneMoney : 0,
                TotalMoneyLone = double.TryParse(txtTotalMoneyLone.Text.Trim(), out double totalMoneyLone) ? totalMoneyLone : 0,
                NumberLone = txtNumberLone.Text.Trim(),
                TimeLone = DateTime.Now
            };
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            if (string.IsNullOrEmpty(username)) return;

            if (!_dbContext.Database.CanConnect())
            {
                MessageBox.Show("ไม่สามารถเชื่อมต่อกับฐานข้อมูลได้.", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var loan = _dbContext.Emers
                .Where(o => o.Username == username)
                .OrderByDescending(o => o.TimeLone)
                .FirstOrDefault();

            if (loan != null)
            {
                FillLoanDetails(loan);
            }
            else
            {
                MessageBox.Show("ไม่พบข้อมูลการกู้เงินที่ต้องการค้นหา.", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void FillLoanDetails(Emer loan)
        {
            txtUsername.Text = loan.Username;
            txtFamily.Text = loan.Family;
            txtIdCard.Text = loan.IdCard;
            txtPhone.Text = loan.Phone;
            txtFullname.Text = loan.Fullname;
            txtUsername1.Text = loan.Username1;
            txtFullname1.Text = loan.Fullname1;
            txtPhone1.Text = loan.Phone1;
            txtUsername2.Text = loan.Username2;
            txtFullname2.Text = loan.Fullname2;
            txtPhone2.Text = loan.Phone2;
            txtUsername3.Text = loan.Username3;
            txtFullname3.Text = loan.Fullname3;
            txtPhone3.Text = loan.Phone3;
            txtMoneyOld.Text = loan.MoneyOld.ToString("N2");
            txtNumberLone.Text = loan.NumberLone;
            txtLoneMoney.Text = loan.LoneMoney.ToString("N2");
            txtTotalMoneyLone.Text = loan.TotalMoneyLone.ToString("N2");
        }

        private void Edit_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            if (string.IsNullOrEmpty(username)) return;

            if (!_dbContext.Database.CanConnect())
            {
                MessageBox.Show("ไม่สามารถเชื่อมต่อกับฐานข้อมูลได้.", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var loan = _dbContext.Emers.FirstOrDefault(o => o.Username == username);
            if (loan != null)
            {
                UpdateLoanDetails(loan);
                _dbContext.SaveChanges();
                ClearFields(txtUsername, txtFamily, txtIdCard, txtPhone, txtFullname, txtLoneMoney, txtTotalMoneyLone, txtNumberLone, txtUsername1, txtFullname1, txtPhone1, txtUsername2, txtFullname2, txtPhone2, txtUsername3, txtFullname3, txtPhone3);
                btnsearch_Click(sender, e);
                MessageBox.Show("ข้อมูลการกู้เงินถูกแก้ไขเรียบร้อยแล้ว.", "สำเร็จ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("ไม่พบข้อมูลการกู้เงินที่ต้องการแก้ไข.", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void UpdateLoanDetails(Emer loan)
        {
            loan.Family = txtFamily.Text.Trim();
            loan.IdCard = txtIdCard.Text.Trim();
            loan.Phone = txtPhone.Text.Trim();
            loan.Fullname = txtFullname.Text.Trim();
            loan.Username1 = txtUsername1.Text.Trim();
            loan.Fullname1 = txtFullname1.Text.Trim();
            loan.Phone1 = txtPhone1.Text.Trim();
            loan.Username2 = txtUsername2.Text.Trim();
            loan.Fullname2 = txtFullname2.Text.Trim();
            loan.Phone2 = txtPhone2.Text.Trim();
            loan.Username3 = txtUsername3.Text.Trim();
            loan.Fullname3 = txtFullname3.Text.Trim();
            loan.Phone3 = txtPhone3.Text.Trim();
            loan.MoneyOld = double.TryParse(txtMoneyOld.Text.Trim(), out double moneyOld) ? moneyOld : 0;
            loan.LoneMoney = double.TryParse(txtLoneMoney.Text.Trim(), out double loneMoney) ? loneMoney : 0;
            loan.TotalMoneyLone = double.TryParse(txtTotalMoneyLone.Text.Trim(), out double totalMoneyLone) ? totalMoneyLone : 0;
            loan.NumberLone = txtNumberLone.Text.Trim();
            loan.TimeLone = DateTime.Now;
        }

        private void UserEnerlones_Load(object sender, EventArgs e)
        {
            // Code to execute when the form loads
        }

        // Example of using GroupBy
        private void GroupLoansByUsername()
        {
            var groupedLoans = _dbContext.Emers
                .GroupBy(l => l.Username)
                .Select(g => new
                {
                    Username = g.Key,
                    TotalLoanAmount = g.Sum(l => l.LoneMoney),
                    Loans = g.ToList()
                })
                .ToList();

            // Example usage of groupedLoans
            foreach (var group in groupedLoans)
            {
                Console.WriteLine($"Username: {group.Username}, Total Loan Amount: {group.TotalLoanAmount}");
                foreach (var loan in group.Loans)
                {
                    Console.WriteLine($"Loan Number: {loan.NumberLone}, Amount: {loan.LoneMoney}");
                }
            }
        }
    }
}