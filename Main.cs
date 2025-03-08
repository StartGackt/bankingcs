﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projectfinal
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new MainUser().Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new MainAdmin().Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new MainRegister().Show();
            this.Hide();
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }
    }
}
