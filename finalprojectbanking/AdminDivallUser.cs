using finalprojectbanking.Model;
using System.Data;
using System;

// iText7 core
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;

// iText7 font handling
using iText.IO.Font;
using iText.Kernel.Font;
using iText.IO.Font.Constants;

// Additional iText7 modules that might be useful
using iText.Kernel.Geom;
using iText.Kernel.Colors;
using iText.IO.Image;

// Bouncy Castle related (if needed)
using iText.Kernel.Crypto;

// For file operations
using System.IO;
using IoPath = System.IO.Path;

namespace finalprojectbanking
{
    public partial class AdminDivallUser : Form
    {
        private readonly dbcontext _dbContext = new dbcontext();
        public AdminDivallUser()
        {
            InitializeComponent();
        }

        private void AdminDivallUser_Load(object sender, EventArgs e)
        {

        }

        private void Search_Click(object sender, EventArgs e)
        {
            // Ensure the DataGridView has the necessary columns
            if (dataGridView1.Columns.Count == 0)
            {
                dataGridView1.Columns.Add("Username", "Username");
                dataGridView1.Columns.Add("Fullname", "Fullname");
                dataGridView1.Columns.Add("Family", "Family"); // Add Family column
                dataGridView1.Columns.Add("MoneyTotal", "Money Total");
                dataGridView1.Columns.Add("UpdatedMoneyTotal", "Updated MoneyTotal (+4%)");
                dataGridView1.Columns.Add("Money4PercentIncrease", "Money 4% Increase");
                dataGridView1.Columns.Add("TimeMoney", "Time of Transaction");
            }

            // Query all records from the MoneyTrans table
            var allData = _dbContext.MoneyTranss
                                    .OrderByDescending(mt => mt.TimeMoney)
                                    .ToList();

            // Group by Username and get the latest record for each Username
            var groupedData = allData
                                .GroupBy(mt => mt.Username)
                                .Select(g => g.First())
                                .ToList();

            // Sort by Family
            var sortedData = groupedData
                                .OrderBy(record => record.Family)
                                .ToList();

            dataGridView1.Rows.Clear();

            decimal totalMoneyTotal = 0;
            decimal totalMoney4PercentIncrease = 0;

            foreach (var record in sortedData)
            {
                var updatedMoneyTotal = record.MoneyTotal * 1.04m;
                var money4PercentIncrease = updatedMoneyTotal - record.MoneyTotal;

                // เพิ่มแถวใหม่และกำหนดสีดำให้กับข้อความ
                int rowIndex = dataGridView1.Rows.Add(record.Username, record.Fullname, record.Family, record.MoneyTotal, updatedMoneyTotal, money4PercentIncrease, record.TimeMoney);

                // กำหนดสีดำให้กับข้อความในแต่ละแถว
                dataGridView1.Rows[rowIndex].DefaultCellStyle.ForeColor = System.Drawing.Color.Black;


                totalMoneyTotal += record.MoneyTotal;
                totalMoney4PercentIncrease += money4PercentIncrease;
            }

            // Update the sum of Money Total in txtSumMoney
            txtSumMoney.Text = totalMoneyTotal.ToString("N2");

            // Update the sum of Money 4% Increase in txtMoneyDivide
            txtMoneyDivide.Text = totalMoney4PercentIncrease.ToString("N2");
        }
    }
}
