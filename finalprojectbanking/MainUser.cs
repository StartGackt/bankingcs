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
    public partial class MainUser : Form
    {
        public MainUser()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            new SearchUser().Show();
        }

        private void MainUser_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            new UserTransMoney().Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new MainUserLone().Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new UserPaymentLone().Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new UserSumMoneytrans().Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            new UserExit().Show();
        }
    }
}
