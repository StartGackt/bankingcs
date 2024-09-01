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
    public partial class MainAdminUserDiv : Form
    {
        public MainAdminUserDiv()
        {
            InitializeComponent();
        }

        private void MainAdminUserDiv_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            new AdminDivUser().Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new AdminDivFamily().Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new AdminDivallUser().Show();
        }
    }
}
