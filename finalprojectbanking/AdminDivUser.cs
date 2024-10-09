using finalprojectbanking.Model;
using System.Data;

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
    public partial class AdminDivUser : Form
    {
        private readonly dbcontext _dbContext = new dbcontext();

        public AdminDivUser()
        {
            InitializeComponent();
            txtUsername.TextChanged += TxtUsername_TextChanged;
        }

        private void TxtUsername_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string username = txtUsername.Text;
                if (string.IsNullOrEmpty(username))
                {
                    return;
                }
                var user = _dbContext.MoneyTranss.FirstOrDefault(u => u.Username == username);
                if (user != null)
                {
                    txtFamily.Text = user.Family;
                    txtFullname.Text = user.Fullname;
                    CalculateDividend(username);
                }
                else
                {
                    ClearFields();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"เกิดข้อผิดพลาด: {ex.Message}\n{ex.StackTrace}", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CalculateDividend(string username)
        {
            try
            {
                var latestDeposit = _dbContext.MoneyTranss
                    .Where(t => t.Username == username)
                    .OrderByDescending(t => t.TimeMoney)
                    .FirstOrDefault();

                if (latestDeposit != null)
                {
                    txtMoneyDivide.Text = latestDeposit.MoneyTotal.ToString("C");
                    decimal dividend = latestDeposit.MoneyTotal * 0.04m;
                    txtMoneySumDivide.Text = dividend.ToString("C");
                }
                else
                {
                    txtMoneyDivide.Text = "No deposits found.";
                    txtMoneySumDivide.Text = "No deposits found.";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error calculating dividend: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearFields()
        {
            txtFamily.Clear();
            txtFullname.Clear();
            txtMoneyDivide.Clear();
            txtMoneySumDivide.Clear();
        }

        private void AdminDivUser_Load(object sender, EventArgs e)
        {
            // Initialization code if needed
        }


        private void print_Click(object sender, EventArgs e)
        {
            try
            {
                // Check if all fields have data
                if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtFamily.Text) ||
                    string.IsNullOrWhiteSpace(txtFullname.Text) || string.IsNullOrWhiteSpace(txtMoneyDivide.Text) ||
                    string.IsNullOrWhiteSpace(txtMoneySumDivide.Text))
                {
                    MessageBox.Show("Please fill in all fields", "Incomplete Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Set directory for saving PDF
                string directoryPath = @"C:\Users\Thest\source\repos\bankingcs\Filepdf";
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }

                // Create PDF filename
                string fileName = $"Member_Dividend_Report_{DateTime.Now:yyyyMMddHHmmss}.pdf";
                string fullPath = IoPath.Combine(directoryPath, fileName);

                // Check and display font file path
                string fontPath = @"C:\Users\Thest\Source\Repos\bankingcs\finalprojectbanking\Fonts\Athiti-Light.ttf";
                MessageBox.Show($"Using font from: {fontPath}", "Font Location", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (!File.Exists(fontPath))
                {
                    throw new FileNotFoundException($"Font file not found at: {fontPath}");
                }

                // Create PDF
                using (var writer = new PdfWriter(fullPath))
                using (var pdf = new PdfDocument(writer))
                using (var document = new iText.Layout.Document(pdf))
                {
                    // Set font
                    PdfFont font = PdfFontFactory.CreateFont(fontPath, PdfEncodings.IDENTITY_H, PdfFontFactory.EmbeddingStrategy.FORCE_EMBEDDED);
                    document.SetFont(font);

                    // Add title
                    document.Add(new Paragraph("ระบบบริหารจัดการกลุ่มออมทรัพย์เพื่อการผลิตบ้านท่ารวก")
                        .SetFontSize(18)
                        .SetBold()
                        .SetTextAlignment(TextAlignment.CENTER));

                    document.Add(new Paragraph("ตำบลหนองยายโต๊ะ อำเภอชัยบาดาล จังหวัดลพบุรี")
                        .SetFontSize(16)
                        .SetTextAlignment(TextAlignment.CENTER));

                    document.Add(new Paragraph("ข้อมูลเกี่ยวกับเจ้าหน้าที่กองทุน : การปันผลสมาชิกรายบุคคล")
                        .SetFontSize(16)
                        .SetTextAlignment(TextAlignment.CENTER));


                    // Create a table with 5 columns
                    Table table = new Table(5);
                    table.SetWidth(UnitValue.CreatePercentValue(100)); // Set table width to 100% of the page

                    // Add headers
                    table.AddHeaderCell(new Cell().Add(new Paragraph("เลขที่สมาชิก").SetFontSize(12).SetBold().SetTextAlignment(TextAlignment.CENTER))); // Member Number
                    table.AddHeaderCell(new Cell().Add(new Paragraph("รหัสครอบครัว").SetFontSize(12).SetBold().SetTextAlignment(TextAlignment.CENTER))); // Family Code
                    table.AddHeaderCell(new Cell().Add(new Paragraph("ชื่อ - นามสกุล").SetFontSize(12).SetBold().SetTextAlignment(TextAlignment.CENTER))); // Name - Surname
                    table.AddHeaderCell(new Cell().Add(new Paragraph("เงินที่ฝากในรอบ 1 ปี").SetFontSize(12).SetBold().SetTextAlignment(TextAlignment.CENTER))); // Deposit Amount in 1 Year
                    table.AddHeaderCell(new Cell().Add(new Paragraph("จำนวนเงินปันผล").SetFontSize(12).SetBold().SetTextAlignment(TextAlignment.CENTER))); // Dividend Amount

                    // Add data rows
                    table.AddCell(new Cell().Add(new Paragraph(txtUsername.Text).SetFontSize(12).SetTextAlignment(TextAlignment.CENTER))); // Member Number
                    table.AddCell(new Cell().Add(new Paragraph(txtFamily.Text).SetFontSize(12).SetTextAlignment(TextAlignment.CENTER)));   // Family Code
                    table.AddCell(new Cell().Add(new Paragraph(txtFullname.Text).SetFontSize(12).SetTextAlignment(TextAlignment.CENTER))); // Name - Surname
                                                                                                                                           // Deposit Amount
                    table.AddCell(new Cell().Add(new Paragraph($"{txtMoneyDivide.Text} บาท")
                        .SetFontSize(12)
                        .SetTextAlignment(TextAlignment.CENTER)));

                    // Dividend Amount
                    table.AddCell(new Cell().Add(new Paragraph($"{txtMoneySumDivide.Text} บาท")
                        .SetFontSize(12)
                        .SetTextAlignment(TextAlignment.CENTER)));


                    // Add the table to the document
                    document.Add(table);

                    // Close PDF document
                    document.Close();
                    LogDebug("PDF document closed.");
                }

                // Check if file was created
                if (File.Exists(fullPath))
                {
                    MessageBox.Show($"PDF created successfully!\nSaved at: {fullPath}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    throw new IOException("PDF file was not created after the operation");
                }
            }
            catch (UnauthorizedAccessException uaEx)
            {
                MessageBox.Show($"No permission to write file: {uaEx.Message}", "Access Rights Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (FileNotFoundException fnfEx)
            {
                MessageBox.Show($"File not found: {fnfEx.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (iText.Kernel.Exceptions.PdfException pdfEx)
            {
                string errorDetails = GetPdfErrorDetails(pdfEx);
                MessageBox.Show($"Error creating PDF:\n\n{pdfEx.Message}\n\nPossible causes:\n{errorDetails}",
                                "PDF Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred:\n\n{ex.Message}\n\nStack Trace:\n{ex.StackTrace}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private string GetPdfErrorDetails(iText.Kernel.Exceptions.PdfException pdfEx)
        {
            string details = "";

            if (pdfEx.Message.Contains("font"))
            {
                details += "- There may be an issue with the font file. Check if the font file exists and is accessible.\n";
            }
            if (pdfEx.Message.Contains("access") || pdfEx.Message.Contains("permission"))
            {
                details += "- There may be an access rights issue. Check if the program has permission to write files in the specified folder.\n";
            }
            if (pdfEx.Message.Contains("file") || pdfEx.Message.Contains("path"))
            {
                details += "- There may be an issue with the file path. Check if the specified path is correct and accessible.\n";
            }
            if (pdfEx.Message.Contains("memory") || pdfEx.Message.Contains("resource"))
            {
                details += "- There may be an issue with memory or system resources. Try closing unnecessary programs and try again.\n";
            }

            if (string.IsNullOrEmpty(details))
            {
                details = "- Unable to identify the specific cause. Please check the error details and try again.\n";
            }

            details += $"\nError details: {pdfEx.Message}\n";
            if (pdfEx.InnerException != null)
            {
                details += $"Inner exception: {pdfEx.InnerException.Message}\n";
            }

            return details;
        }

        private void LogDebug(string message)
        {
            string logPath = IoPath.Combine(AppDomain.CurrentDomain.BaseDirectory, "debug_log.txt");
            File.AppendAllText(logPath, $"[{DateTime.Now}] {message}\n");
        }

    }
}






  

    



