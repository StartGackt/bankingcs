using System;
using System.Linq;
using System.Windows.Forms;
using finalprojectbanking.Model;

namespace finalprojectbanking
{
    public partial class AdminAnnualLoanReport : Form
    {
        private readonly dbcontext _dbContext = new dbcontext();

        public AdminAnnualLoanReport()
        {
            InitializeComponent();
        }

        private void AdminAnnualLoanReport_Load(object sender, EventArgs e)
        {
            // แสดงตัวเลข 1-12 ใน ComboBox ให้เลือกเดือน
            comboBox1.DataSource = Enumerable.Range(1, 12).ToList();

            // ป้องกันการสร้างคอลัมน์อัตโนมัติ
            dataGridView1.AutoGenerateColumns = false;

            // ลบคอลัมน์ที่มีอยู่ก่อนหน้านี้ (ถ้ามี)
            dataGridView1.Columns.Clear();

            // เพิ่มคอลัมน์และตั้งค่า DataPropertyName
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
                Name = "LoneMoney",
                HeaderText = "Loan Amount",
                DataPropertyName = "LoneMoney"
            });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Invan",
                HeaderText = "Interest (8%)",
                DataPropertyName = "Invan"
            });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Total",
                HeaderText = "Total Amount",
                DataPropertyName = "Total"
            });

            // ตั้งค่า DefaultCellStyle.Format สำหรับการแสดงผลจำนวนเงิน
            dataGridView1.Columns["LoneMoney"].DefaultCellStyle.Format = "C2";
            dataGridView1.Columns["Invan"].DefaultCellStyle.Format = "C2";
            dataGridView1.Columns["Total"].DefaultCellStyle.Format = "C2";

            // กำหนดให้ ComboBox เลือกได้เฉพาะรายการที่กำหนด
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void Search_Click(object sender, EventArgs e)
        {
            
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            try
            {
                int selectedMonth = (int)comboBox1.SelectedItem;

                var loanData = _dbContext.OrdLones
                    .Where(loan => loan.TimeLone.Month == selectedMonth)
                    .Select(loan => new
                    {
                        loan.Username,
                        loan.Fullname,
                        loan.LoneMoney,
                        Invan = (decimal)loan.LoneMoney * 0.08m, // คำนวณดอกเบี้ย 8%
                        Total = (decimal)loan.LoneMoney + ((decimal)loan.LoneMoney * 0.08m) // คำนวณยอดรวม
                    })
                    .ToList();

                // แสดงจำนวนข้อมูลที่ดึงมาได้สำหรับการดีบัก
                // MessageBox.Show($"Number of records retrieved: {loanData.Count}", "Debug Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (loanData.Any())
                {
                    dataGridView1.DataSource = null; // เคลียร์ DataSource ก่อนหน้า
                    dataGridView1.DataSource = loanData; // ผูกข้อมูลกับ DataGridView
                }
                else
                {
                    dataGridView1.DataSource = null; // เคลียร์ DataGridView
                    MessageBox.Show("ไม่พบข้อมูลเงินกู้ในเดือนที่เลือก", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"เกิดข้อผิดพลาด: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

}

