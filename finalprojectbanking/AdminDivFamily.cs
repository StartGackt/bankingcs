using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Data.Entity; // or using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Threading.Tasks;
using finalprojectbanking.Model;
using System.Windows.Forms;

namespace finalprojectbanking
{
    public partial class AdminDivFamily : Form
    {
        private readonly dbcontext _dbContext = new dbcontext();

        public AdminDivFamily()
        {
            InitializeComponent();
            txtFamily.TextChanged += TxtFamily_TextChanged;
        }

        private void AdminDivFamily_Load(object sender, EventArgs e)
        {
            // Initialization code if needed
        }

        private void TxtFamily_TextChanged(object sender, EventArgs e)
        {
            string familyInput = txtFamily.Text.Trim();

            if (!string.IsNullOrEmpty(familyInput))
            {
                if (dataGridView1.Columns.Count == 0)
                {
                    dataGridView1.Columns.Add("Username", "Username");
                    dataGridView1.Columns.Add("Fullname", "Fullname");
                    dataGridView1.Columns.Add("MoneyTotal", "Money Total");
                    dataGridView1.Columns.Add("UpdatedMoneyTotal", "Updated MoneyTotal (+4%)");
                    dataGridView1.Columns.Add("Money4PercentIncrease", "Money 4% Increase");
                    dataGridView1.Columns.Add("TimeMoney", "Time of Transaction");
                }

                var familyData = _dbContext.MoneyTranss
                                           .Where(mt => mt.Family == familyInput)
                                           .OrderByDescending(mt => mt.TimeMoney)
                                           .ToList();

                dataGridView1.Rows.Clear();

                decimal totalMoneyTotal = 0;
                decimal totalMoney4PercentIncrease = 0;

                foreach (var record in familyData)
                {
                    var updatedMoneyTotal = record.MoneyTotal * 1.04m;
                    var money4PercentIncrease = updatedMoneyTotal - record.MoneyTotal;

                    // เพิ่มแถวใหม่และกำหนดสีดำให้กับข้อความ
                    int rowIndex = dataGridView1.Rows.Add(record.Username, record.Fullname, record.MoneyTotal, updatedMoneyTotal, money4PercentIncrease, record.TimeMoney);

                    // กำหนดสีดำให้กับข้อความในแต่ละแถว
                    dataGridView1.Rows[rowIndex].DefaultCellStyle.ForeColor = Color.Black;

                    totalMoneyTotal += record.MoneyTotal;
                    totalMoney4PercentIncrease += money4PercentIncrease;
                }

                // Update the sum of Money Total in txtSumMoney
                txtSumMoney.Text = totalMoneyTotal.ToString("N2");

                // Update the sum of Money 4% Increase in txtMoneyDivide
                txtMoneyDivide.Text = totalMoney4PercentIncrease.ToString("N2");
            }
            else
            {
                dataGridView1.Rows.Clear();
                txtSumMoney.Text = "0.00";
                txtMoneyDivide.Text = "0.00";
            }
        }
    }
}