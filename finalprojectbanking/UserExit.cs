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
    public partial class UserExit : Form
    {
        private readonly dbcontext _dbContext = new dbcontext();
        public UserExit()
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
                var user = _dbContext.Users.FirstOrDefault(u => u.Username == username);
                if (user != null)
                {
                    txtFamily.Text = user.Family;
                    txtIdCard.Text = user.IdCard;
                    txtPhone.Text = user.Phone;
                    txtFullname.Text = user.Fullname;
                    txtAddress.Text = user.Address;
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
            txtAddress.Clear();
        }
        private void UserExit_Load(object sender, EventArgs e)
        {

        }

        private void btnadd_Click(object sender, EventArgs e)
        {

        }
    }
}
