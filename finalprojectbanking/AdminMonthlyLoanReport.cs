using System;
using System.Linq;
using System.Windows.Forms;
using finalprojectbanking.Model;

namespace finalprojectbanking
{
    public partial class AdminMonthlyLoanReport : Form
    {
        private readonly dbcontext _dbContext = new dbcontext();

        public AdminMonthlyLoanReport()
        {
            InitializeComponent();
        }

        private void AdminMonthlyLoanReport_Load(object sender, EventArgs e)
        {
            // Display numbers 1-12 in ComboBox for month selection
            comboBox1.DataSource = Enumerable.Range(1, 12).ToList();

            // Prevent automatic column generation
            dataGridView1.AutoGenerateColumns = false;

            // Clear existing columns (if any)
            dataGridView1.Columns.Clear();

            // Add columns and set DataPropertyName
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Username",
                HeaderText = "Username",
                DataPropertyName = "Username"
            });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Fullname",
                HeaderText = "Fullname",
                DataPropertyName = "Fullname"
            });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "NumberLone",
                HeaderText = "Number of Loans",
                DataPropertyName = "NumberLone"
            });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "LoneMoney",
                HeaderText = "Loan Amount",
                DataPropertyName = "LoneMoney"
            });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TotalMoneyLone",
                HeaderText = "Total Loan Amount",
                DataPropertyName = "TotalMoneyLone"
            });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Invoice",
                HeaderText = "Interest (1%)",
                DataPropertyName = "Invoice"
            });

            // Set ComboBox to allow only predefined items
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void Search_Click(object sender, EventArgs e)
        {
            try
            {
                int selectedMonth = (int)comboBox1.SelectedItem;

                var loanData = _dbContext.Emers
                    .Where(loan => loan.TimeLone.Month == selectedMonth)
                    .Select(loan => new
                    {
                        loan.Username,
                        loan.Fullname,
                        loan.NumberLone,
                        loan.LoneMoney,
                        loan.TotalMoneyLone,
                        Invoice = loan.LoneMoney * 0.01 // Calculate 1% interest
                    })
                    .ToList();

                // Show the number of records retrieved for debugging
                MessageBox.Show($"Number of records retrieved: {loanData.Count}", "Debug Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (loanData.Any())
                {
                    dataGridView1.DataSource = null; // Clear previous DataSource
                    dataGridView1.DataSource = loanData; // Bind data to DataGridView
                }
                else
                {
                    dataGridView1.DataSource = null; // Clear DataGridView
                    MessageBox.Show("No loan data found for the selected month", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
