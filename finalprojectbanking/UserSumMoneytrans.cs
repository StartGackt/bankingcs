using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using finalprojectbanking.Model;

namespace finalprojectbanking
{
    public partial class UserSumMoneytrans : Form
    {
        private readonly dbcontext _dbContext = new dbcontext();
        public UserSumMoneytrans()
        {
            InitializeComponent();
            txtUsername.TextChanged += TxtUsername_TextChanged;
        }

        private void TxtUsername_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string username = txtUsername.Text;
                if (string.IsNullOrEmpty(username))
                {
                    return;
                }

                // Fetch the user details
                var user = _dbContext.Users.FirstOrDefault(u => u.Username == username);
                if (user != null)
                {
                    txtFamily.Text = user.Family;
                    txtIdCard.Text = user.IdCard;
                    txtPhone.Text = user.Phone;
                    txtFullname.Text = user.Fullname;

                    // Fetch all MoneyTrans records for this family
                    var moneyTransRecords = _dbContext.MoneyTranss
                        .Where(mt => mt.Family == user.Family)
                        .ToList();

                    // Now group by Username and select the latest entry
                    var latestMoneyTransList = moneyTransRecords
                        .GroupBy(mt => mt.Username)
                        .Select(g => g.OrderByDescending(mt => mt.TimeMoney).FirstOrDefault())  // Get the latest transaction
                        .Where(mt => mt != null)  // Ensure no null records
                        .Select(mt => new
                        {
                            Username = mt.Username ?? "N/A",  // Handle null usernames
                            Fullname = user.Fullname ?? "N/A",
                            MoneyTotal = mt.MoneyTotal
                        })
                        .ToList();

                    // Populate DataGridView with the latest records
                    dataGridView1.DataSource = latestMoneyTransList;

                    // Calculate the sum of MoneyTotal
                    var sumMoneyTotal = latestMoneyTransList.Sum(mt => mt.MoneyTotal);
                    txtUsersum.Text = sumMoneyTotal.ToString("N2");  // Format the sum
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

        }
        private void UserSumMoneytrans_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
