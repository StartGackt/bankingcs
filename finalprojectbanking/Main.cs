﻿using System;
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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new MainRegiscs().Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new MainUser().Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new MainAdmin().Show();
        }
    }
}
