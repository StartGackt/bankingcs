﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using Projectfinal.Model;

namespace Projectfinal
{
    public partial class ReportDepostMonth : Form
    {
        private readonly dbcontext _dbContext = new dbcontext();

        public ReportDepostMonth()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            // Set ComboBox to DropDownList style to prevent free text entry
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;

            // เพิ่ม: เติมข้อมูลเดือนลงใน ComboBox
            string[] months = new string[] {
                "มกราคม", "กุมภาพันธ์", "มีนาคม", "เมษายน", "พฤษภาคม", "มิถุนายน",
                "กรกฎาคม", "สิงหาคม", "กันยายน", "ตุลาคม", "พฤศจิกายน", "ธันวาคม"
            };
            comboBox1.Items.AddRange(months);

            // เพิ่ม: เชื่อม event handler
            comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;

            // Configure DataGridView
            dataGridView1.AutoGenerateColumns = false;
            SetupDataGridViewColumns();
        }

        private void SetupDataGridViewColumns()
        {
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.AddRange(
                new DataGridViewTextBoxColumn { Name = "Username", HeaderText = "Username", DataPropertyName = "Username" },
                new DataGridViewTextBoxColumn { Name = "Family", HeaderText = "Family", DataPropertyName = "Family" },
                new DataGridViewTextBoxColumn { Name = "Fullname", HeaderText = "Fullname", DataPropertyName = "Fullname" },
                new DataGridViewTextBoxColumn { Name = "MoneyTotal", HeaderText = "Money Total", DataPropertyName = "MoneyTotal", DefaultCellStyle = { Format = "N2" } },
                new DataGridViewTextBoxColumn { Name = "TimeMoney", HeaderText = "Time", DataPropertyName = "TimeMoney", DefaultCellStyle = { Format = "dd/MM/yyyy" } }
            );
        }

        private void ReportDepostMonth_Load(object sender, EventArgs e)
        {
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MainReprots mainReprots = new MainReprots();
            mainReprots.Show();
            this.Hide();
        }

        private void SearchByMonth()
        {
            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("กรุณาเลือกเดือนที่ต้องการค้นหา", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Get selected month (1-12)
                int selectedMonth = comboBox1.SelectedIndex + 1;

                // Query MoneyTrans data
                var transactions = _dbContext.MoneyTranss
                    .Where(mt => mt.TimeMoney.Month == selectedMonth)
                    .Select(mt => new
                    {
                        mt.Username,
                        mt.Family,
                        mt.Fullname,
                        mt.MoneyTotal,
                        mt.TimeMoney
                    })
                    .OrderBy(mt => mt.TimeMoney)
                    .ToList();

                // Update DataGridView
                dataGridView1.DataSource = transactions;

                if (!transactions.Any())
                {
                    MessageBox.Show("ไม่พบข้อมูลในเดือนที่เลือก", "ผลการค้นหา", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"เกิดข้อผิดพลาด: {ex.Message}", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // เพิ่ม: event handler สำหรับ ComboBox
        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SearchByMonth();
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        //printdata
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                // 📌 สร้างโฟลเดอร์ปลายทางบน Desktop
                string directoryPath = new PathConf().getPDFPath();
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }

                // 📌 สร้างชื่อไฟล์ PDF ตามวันที่
                string fileName = $"DepositReport_{DateTime.Now:yyyyMMddHHmmss}.pdf";
                string fullPath = Path.Combine(directoryPath, fileName);

                // 📌 สร้างเอกสาร PDF
                PdfDocument document = new PdfDocument();
                document.Info.Title = "รายงานการฝากเงิน";
                PdfPage page = document.AddPage();
                XGraphics gfx = XGraphics.FromPdfPage(page);

                // 📌 กำหนดฟอนต์สำหรับภาษาไทย
                XFont titleFont = new XFont("Kanit-Bold", 18);
                XFont headerFont = new XFont("Kanit-Bold", 12);
                XFont contentFont = new XFont("Kanit-Bold", 10);
                XPen pen = new XPen(XColors.Black, 1);

                // 🔹 วาดหัวเรื่อง
                gfx.DrawString("ระบบบริหารจัดการกลุ่มออมทรัพย์", titleFont, XBrushes.Black,
                    new XRect(0, 40, page.Width, 30), XStringFormats.Center);
                gfx.DrawString("ตำบลหนองยายโต๊ะ อำเภอชัยบาดาล จังหวัดลพบุรี", headerFont, XBrushes.Black,
                    new XRect(0, 70, page.Width, 20), XStringFormats.Center);
                gfx.DrawString("รายงานการฝากเงิน", headerFont, XBrushes.Black,
                    new XRect(0, 100, page.Width, 20), XStringFormats.Center);

                // 🔹 วาดเส้นใต้หัวข้อ
                gfx.DrawLine(pen, 50, 130, page.Width - 50, 130);

                // 🔹 กำหนดตำแหน่งเริ่มต้นของข้อมูล
                double y = 150;
                double leftX = 50;
                double columnWidth = (page.Width - 100) / 5; // คำนวณให้แต่ละคอลัมน์กว้างเท่ากัน
                double rowHeight = 20;

                // 🔹 วาด Header ของตาราง
                string[] headers = { "Username", "Family", "Fullname", "Money Total", "Time" };
                double currentX = leftX;
                foreach (var header in headers)
                {
                    gfx.DrawString(header, headerFont, XBrushes.Black, new XPoint(currentX, y));
                    currentX += columnWidth;
                }
                y += rowHeight;

                // 🔹 วาดข้อมูลจาก DataGridView
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.IsNewRow) continue; // ข้ามแถวว่าง

                    currentX = leftX;
                    for (int i = 0; i < headers.Length; i++)
                    {
                        string value = row.Cells[i].Value?.ToString() ?? "";
                        gfx.DrawString(value, contentFont, XBrushes.Black, new XPoint(currentX, y));
                        currentX += columnWidth;
                    }
                    y += rowHeight;

                    // 🛑 ตรวจสอบว่าต้องขึ้นหน้าใหม่หรือไม่
                    if (y > page.Height - 50)
                    {
                        page = document.AddPage();
                        gfx = XGraphics.FromPdfPage(page);
                        y = 50;
                    }
                }

                // 📌 บันทึกไฟล์ PDF
                document.Save(fullPath);

                // 📌 เปิดไฟล์ PDF หลังจากสร้างเสร็จ
                if (File.Exists(fullPath))
                {
                    MessageBox.Show($"สร้าง PDF สำเร็จ!\nบันทึกที่: {fullPath}",
                        "สำเร็จ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    try
                    {
                        Process.Start("explorer.exe", fullPath);
                    }
                    catch
                    {
                        // ถ้าเปิดไฟล์ไม่สำเร็จ ให้ข้ามไป
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"เกิดข้อผิดพลาด: {ex.Message}\n{ex.StackTrace}",
                    "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
