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
    public partial class MainAdminReport : Form
    {
        public MainAdminReport()
        {
            InitializeComponent();
        }

        private void MainAdminReport_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            new AdminMonthlysavingsdepositreport().ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new AdminAnnualSavingsDepositReport().ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new AdminMonthlyLoanReport().ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            new AdminAnnualLoanReport().ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            new AdminLoanDebtorControlRegister().ShowDialog();
        }
    }
}
