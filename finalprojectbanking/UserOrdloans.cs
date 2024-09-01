using System; // นำเข้า namespace สำหรับการใช้งานฟังก์ชันพื้นฐาน
using System.Linq; // นำเข้า namespace สำหรับการใช้งาน LINQ
using System.Windows.Forms; // นำเข้า namespace สำหรับการใช้งาน Windows Forms
using finalprojectbanking.Model; // นำเข้า namespace สำหรับโมเดลของโปรเจค

namespace finalprojectbanking // เริ่มต้น namespace ของโปรเจค
{
    public partial class UserOrdloans : Form // ประกาศคลาส UserOrdloans ที่สืบทอดจาก Form
    {
        public UserOrdloans() // คอนสตรัคเตอร์ของคลาส
        {
            InitializeComponent(); // เรียกใช้งานฟังก์ชันเพื่อสร้างและกำหนดค่า UI
            txtUsername.TextChanged += TxtUsername_TextChanged; // เพิ่มอีเวนต์เมื่อข้อความใน txtUsername เปลี่ยน
            txtUsername1.TextChanged += TxtUsername1_TextChanged; // เพิ่มอีเวนต์เมื่อข้อความใน txtUsername1 เปลี่ยน
            txtUsername2.TextChanged += TxtUsername2_TextChanged; // เพิ่มอีเวนต์เมื่อข้อความใน txtUsername2 เปลี่ยน
            txtUsername3.TextChanged += TxtUsername3_TextChanged; // เพิ่มอีเวนต์เมื่อข้อความใน txtUsername3 เปลี่ยน
            txtLoneMoney.TextChanged += (sender, e) => CalculateTotalMoney(); // เพิ่มอีเวนต์เพื่อคำนวณยอดเงินเมื่อข้อความใน txtLoneMoney เปลี่ยน
            txtLoneMoney1.TextChanged += (sender, e) => CalculateTotalMoney(); // เพิ่มอีเวนต์เพื่อคำนวณยอดเงินเมื่อข้อความใน txtLoneMoney1 เปลี่ยน
            GenerateLoneNumber(); // เรียกใช้งานฟังก์ชันเพื่อสร้างหมายเลขการกู้เงิน
        }

        private readonly dbcontext _dbContext = new dbcontext(); // สร้างตัวแปร dbContext สำหรับการเข้าถึงฐานข้อมูล

        private void TxtUsername_TextChanged(object sender, EventArgs e) // ฟังก์ชันที่เรียกเมื่อข้อความใน txtUsername เปลี่ยน
        {
            SearchUserAndFillFields(txtUsername, txtFamily, txtIdCard, txtPhone, txtFullname, txtMoneyOld); // ค้นหาผู้ใช้และกรอกข้อมูลในฟิลด์ที่กำหนด
        }

        private void TxtUsername1_TextChanged(object sender, EventArgs e) // ฟังก์ชันที่เรียกเมื่อข้อความใน txtUsername1 เปลี่ยน
        {
            SearchUserAndFillFields(txtUsername1, txtFullname1, txtPhone1); // ค้นหาผู้ใช้และกรอกข้อมูลในฟิลด์ที่กำหนด
        }

        private void TxtUsername2_TextChanged(object sender, EventArgs e) // ฟังก์ชันที่เรียกเมื่อข้อความใน txtUsername2 เปลี่ยน
        {
            SearchUserAndFillFields(txtUsername2, txtFullname2, txtPhone2); // ค้นหาผู้ใช้และกรอกข้อมูลในฟิลด์ที่กำหนด
        }

        private void TxtUsername3_TextChanged(object sender, EventArgs e) // ฟังก์ชันที่เรียกเมื่อข้อความใน txtUsername3 เปลี่ยน
        {
            SearchUserAndFillFields(txtUsername3, txtFullname3, txtPhone3); // ค้นหาผู้ใช้และกรอกข้อมูลในฟิลด์ที่กำหนด
        }

        private void SearchUserAndFillFields(TextBox usernameTextBox, TextBox fullNameTextBox, TextBox phoneTextBox) // ฟังก์ชันค้นหาผู้ใช้และกรอกข้อมูลในฟิลด์
        {
            try // เริ่มต้นบล็อก try เพื่อตรวจจับข้อผิดพลาด
            {
                string username = usernameTextBox.Text; // รับค่าชื่อผู้ใช้จาก TextBox
                if (string.IsNullOrEmpty(username)) // ตรวจสอบว่าชื่อผู้ใช้ว่างหรือไม่
                {
                    ClearFields(fullNameTextBox, phoneTextBox); // ล้างฟิลด์ถ้าชื่อผู้ใช้ว่าง
                    return; // ออกจากฟังก์ชัน
                }

                var user = _dbContext.Users.FirstOrDefault(u => u.Username == username); // ค้นหาผู้ใช้ในฐานข้อมูล
                if (user != null) // ถ้าพบผู้ใช้
                {
                    fullNameTextBox.Text = user.Fullname; // กรอกชื่อเต็มในฟิลด์
                    phoneTextBox.Text = user.Phone; // กรอกหมายเลขโทรศัพท์ในฟิลด์
                }
                else // ถ้าไม่พบผู้ใช้
                {
                    ClearFields(fullNameTextBox, phoneTextBox); // ล้างฟิลด์
                }
            }
            catch (Exception ex) // จับข้อผิดพลาด
            {
                MessageBox.Show($"เกิดข้อผิดพลาด: {ex.Message}\n{ex.StackTrace}", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error); // แสดงข้อความข้อผิดพลาด
            }
        }

        private void SearchUserAndFillFields(TextBox usernameTextBox, TextBox familyTextBox, TextBox idCardTextBox, TextBox phoneTextBox, TextBox fullNameTextBox, TextBox moneyOldTextBox) // ฟังก์ชันค้นหาผู้ใช้และกรอกข้อมูลในฟิลด์
        {
            try // เริ่มต้นบล็อก try เพื่อตรวจจับข้อผิดพลาด
            {
                string username = usernameTextBox.Text; // รับค่าชื่อผู้ใช้จาก TextBox
                if (string.IsNullOrEmpty(username)) // ตรวจสอบว่าชื่อผู้ใช้ว่างหรือไม่
                {
                    ClearFields(familyTextBox, idCardTextBox, phoneTextBox, fullNameTextBox, moneyOldTextBox); // ล้างฟิลด์ถ้าชื่อผู้ใช้ว่าง
                    return; // ออกจากฟังก์ชัน
                }

                var user = _dbContext.Users.FirstOrDefault(u => u.Username == username); // ค้นหาผู้ใช้ในฐานข้อมูล
                if (user != null) // ถ้าพบผู้ใช้
                {
                    familyTextBox.Text = user.Family; // กรอกข้อมูลครอบครัวในฟิลด์
                    idCardTextBox.Text = user.IdCard; // กรอกหมายเลขบัตรประชาชนในฟิลด์
                    phoneTextBox.Text = user.Phone; // กรอกหมายเลขโทรศัพท์ในฟิลด์
                    fullNameTextBox.Text = user.Fullname; // กรอกชื่อเต็มในฟิลด์

                    var transaction = _dbContext.MoneyTranss // ค้นหาธุรกรรมล่าสุดของผู้ใช้
                        .Where(t => t.Username == username)
                        .OrderByDescending(t => t.TimeMoney)
                        .FirstOrDefault();

                    if (transaction != null) // ถ้าพบธุรกรรม
                    {
                        moneyOldTextBox.Text = transaction.MoneyTotal.ToString("N2"); // กรอกยอดเงินในฟิลด์
                    }
                    else // ถ้าไม่พบธุรกรรม
                    {
                        moneyOldTextBox.Text = "0.00"; // กรอกยอดเงินเป็น 0.00
                    }
                }
                else // ถ้าไม่พบผู้ใช้
                {
                    ClearFields(familyTextBox, idCardTextBox, phoneTextBox, fullNameTextBox, moneyOldTextBox); // ล้างฟิลด์
                }
            }
            catch (Exception ex) // จับข้อผิดพลาด
            {
                MessageBox.Show($"เกิดข้อผิดพลาด: {ex.Message}\n{ex.StackTrace}", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error); // แสดงข้อความข้อผิดพลาด
            }
        }

        private void ClearFields(params TextBox[] textBoxes) // ฟังก์ชันล้างฟิลด์
        {
            foreach (var textBox in textBoxes) // วนลูปผ่าน TextBox ที่ส่งเข้ามา
            {
                textBox.Clear(); // ล้างข้อความใน TextBox
            }
        }

        private void GenerateLoneNumber() // ฟังก์ชันสร้างหมายเลขการกู้เงิน
        {
            try
            {
                // เรียกหมายเลขล่าสุดจากฐานข้อมูล
                var lastLoan = _dbContext.OrdLones
                    .OrderByDescending(l => l.Id) // หรือใช้ `NumberLone` หากมีการจัดเก็บหมายเลขในรูปแบบลำดับ
                    .FirstOrDefault();

                // กำหนดลำดับใหม่
                int newNumber = 1; // ค่าเริ่มต้นของหมายเลขใหม่

                if (lastLoan != null)
                {
                    // แยกหมายเลขและลำดับจากหมายเลขล่าสุด
                    var parts = lastLoan.NumberLone.Split('-');
                    if (parts.Length == 2 && int.TryParse(parts[1], out int lastSequence))
                    {
                        newNumber = lastSequence + 1; // เพิ่มลำดับใหม่
                    }
                }

                // สร้างหมายเลขใหม่
                string newLoanNumber = $"ORD-{newNumber:D3}"; // ใช้วันปัจจุบันและเพิ่มลำดับ

                txtNumberLone.Text = newLoanNumber;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"เกิดข้อผิดพลาดในการสร้างรหัสการกู้เงิน: {ex.Message}", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CalculateTotalMoney()
        {
            try
            {
                // กำหนดค่าเริ่มต้นให้กับตัวแปรจาก TextBox
                double loanAmount = double.TryParse(txtLoneMoney.Text.Trim(), out double la) ? la : 0;
                int months = int.TryParse(txtLoneMoney1.Text.Trim(), out int m) ? m : 0;

                // กำหนดอัตราดอกเบี้ย
                double interestRate = 0.08;

                // คำนวณดอกเบี้ย
                double interest = loanAmount * interestRate;

                // คำนวณยอดเงินกู้รวม
                double totalLoan = loanAmount + interest;

                // คำนวณผลรวมโดยหารด้วยจำนวนเดือน
                double total = totalLoan / months;

                // แสดงผลลัพธ์ใน TextBox
                txtTotalMoneyLone.Text = total.ToString("0.00");
            }
            catch (Exception ex)
            {
                MessageBox.Show("เกิดข้อผิดพลาดในการคำนวณยอดเงินกู้: " + ex.Message, "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void UserOrdloans_Load(object sender, EventArgs e) // ฟังก์ชันที่เรียกเมื่อโหลดฟอร์ม
        {
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            try
            {
                // ตรวจสอบว่าฟิลด์ที่จำเป็นถูกกรอกแล้ว
                if (string.IsNullOrEmpty(txtUsername.Text.Trim()) ||
                    string.IsNullOrEmpty(txtFamily.Text.Trim()) ||
                    string.IsNullOrEmpty(txtIdCard.Text.Trim()) ||
                    string.IsNullOrEmpty(txtPhone.Text.Trim()) ||
                    string.IsNullOrEmpty(txtFullname.Text.Trim()) ||
                    string.IsNullOrEmpty(txtLoneMoney.Text.Trim()) ||
                    string.IsNullOrEmpty(txtLoneMoney1.Text.Trim()) ||
                    string.IsNullOrEmpty(txtTotalMoneyLone.Text.Trim()))
                {
                    MessageBox.Show("กรุณากรอกข้อมูลให้ครบถ้วน.", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // สร้างออบเจ็กต์ใหม่สำหรับการกู้เงิน
                var newLoan = new OrdLone
                {
                    Username = txtUsername.Text.Trim(),
                    Family = txtFamily.Text.Trim(),
                    IdCard = txtIdCard.Text.Trim(),
                    Phone = txtPhone.Text.Trim(),
                    Fullname = txtFullname.Text.Trim(),
                    Username1 = txtUsername1.Text.Trim(),
                    Fullname1 = txtFullname1.Text.Trim(),
                    Phone1 = txtPhone1.Text.Trim(),
                    Username2 = txtUsername2.Text.Trim(),
                    Fullname2 = txtFullname2.Text.Trim(),
                    Phone2 = txtPhone2.Text.Trim(),
                    Username3 = txtUsername3.Text.Trim(),
                    Fullname3 = txtFullname3.Text.Trim(),
                    Phone3 = txtPhone3.Text.Trim(),
                    MoneyOld = double.TryParse(txtMoneyOld.Text.Trim(), out double moneyOld) ? moneyOld : 0,
                    LoneMoney = double.TryParse(txtLoneMoney.Text.Trim(), out double loneMoney) ? loneMoney : 0,
                    LoneMoney1 = double.TryParse(txtLoneMoney1.Text.Trim(), out double loneMoney1) ? loneMoney1 : 0,
                    TotalMoneyLone = double.TryParse(txtTotalMoneyLone.Text.Trim(), out double totalMoneyLone) ? totalMoneyLone : 0,
                    NumberLone = txtNumberLone.Text.Trim(),
                    TimeLone = DateTime.Now // ใช้เวลาปัจจุบันเป็นเวลาการกู้เงิน
                };

                // เพิ่มข้อมูลใหม่ลงในฐานข้อมูล
                _dbContext.OrdLones.Add(newLoan);
                _dbContext.SaveChanges();

                MessageBox.Show("ข้อมูลการกู้เงินถูกเพิ่มเรียบร้อยแล้ว.", "สำเร็จ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // ทำความสะอาดฟิลด์หลังจากการบันทึก
                ClearFields(txtUsername, txtFamily, txtIdCard, txtPhone, txtFullname, txtLoneMoney, txtTotalMoneyLone, txtNumberLone, txtUsername1, txtFullname1, txtPhone1, txtUsername2, txtFullname2, txtPhone2, txtUsername3, txtFullname3, txtPhone3);
                GenerateLoneNumber(); // สร้างหมายเลขการกู้เงินใหม่หลังจากบันทึก
            }
            catch (Exception ex)
            {
                MessageBox.Show($"เกิดข้อผิดพลาดในการเพิ่มข้อมูลการกู้เงิน: {ex.Message}", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            try
            {
                string username = txtUsername.Text.Trim(); // รับค่า Username จาก TextBox

                if (string.IsNullOrEmpty(username))
                {
                    MessageBox.Show("กรุณากรอก Username เพื่อทำการค้นหา.", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // ตรวจสอบการเชื่อมต่อกับฐานข้อมูล
                if (!_dbContext.Database.CanConnect())
                {
                    MessageBox.Show("ไม่สามารถเชื่อมต่อกับฐานข้อมูลได้.", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // ค้นหาข้อมูลจากฐานข้อมูล
                var loan = _dbContext.OrdLones.FirstOrDefault(o => o.Username == username);

                if (loan != null)
                {
                    // กรอกข้อมูลที่ค้นหาได้ลงในฟิลด์
                    txtUsername.Text = loan.Username;
                    txtFamily.Text = loan.Family;
                    txtIdCard.Text = loan.IdCard;
                    txtPhone.Text = loan.Phone;
                    txtFullname.Text = loan.Fullname;
                    txtUsername1.Text = loan.Username1;
                    txtFullname1.Text = loan.Fullname1;
                    txtPhone1.Text = loan.Phone1;
                    txtUsername2.Text = loan.Username2;
                    txtFullname2.Text = loan.Fullname2;
                    txtPhone2.Text = loan.Phone2;
                    txtUsername3.Text = loan.Username3;
                    txtFullname3.Text = loan.Fullname3;
                    txtPhone3.Text = loan.Phone3;
                    txtMoneyOld.Text = loan.MoneyOld.ToString("N2");
                    txtLoneMoney.Text = loan.LoneMoney.ToString("N2");
                    txtLoneMoney1.Text = loan.LoneMoney1.ToString("N2");
                    txtTotalMoneyLone.Text = loan.TotalMoneyLone.ToString("N2");
                }
                else
                {
                    MessageBox.Show("ไม่พบข้อมูลการกู้เงินที่ต้องการค้นหา.", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"เกิดข้อผิดพลาดในการค้นหาข้อมูลการกู้เงิน: {ex.Message}", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Edit_Click(object sender, EventArgs e)
        {
            try
            {
                string username = txtUsername.Text.Trim(); // รับค่า Username จาก TextBox

                if (string.IsNullOrEmpty(username))
                {
                    MessageBox.Show("กรุณากรอก Username เพื่อทำการแก้ไข.", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // ตรวจสอบการเชื่อมต่อกับฐานข้อมูล
                if (!_dbContext.Database.CanConnect())
                {
                    MessageBox.Show("ไม่สามารถเชื่อมต่อกับฐานข้อมูลได้.", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // ค้นหาข้อมูลจากฐานข้อมูล
                var loan = _dbContext.OrdLones.FirstOrDefault(o => o.Username == username);

                if (loan != null)
                {
                    // อัพเดตเฉพาะข้อมูลการคำนวณการกู้เงิน
                    loan.LoneMoney = double.TryParse(txtLoneMoney.Text.Trim(), out double loneMoney) ? loneMoney : 0;
                    loan.LoneMoney1 = double.TryParse(txtLoneMoney1.Text.Trim(), out double loneMoney1) ? loneMoney1 : 0;
                    loan.TotalMoneyLone = double.TryParse(txtTotalMoneyLone.Text.Trim(), out double totalMoneyLone) ? totalMoneyLone : 0;

                    // บันทึกการเปลี่ยนแปลงลงในฐานข้อมูล
                    _dbContext.SaveChanges();

                    // Clear form fields
                    ClearFields(txtUsername, txtFamily, txtIdCard, txtPhone, txtFullname, txtLoneMoney, txtTotalMoneyLone, txtNumberLone, txtUsername1, txtFullname1, txtPhone1, txtUsername2, txtFullname2, txtPhone2, txtUsername3, txtFullname3, txtPhone3);

                    // Search for the updated loan data again
                    btnsearch_Click(sender, e); 

                    MessageBox.Show("ข้อมูลการกู้เงินถูกแก้ไขเรียบร้อยแล้ว.", "สำเร็จ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("ไม่พบข้อมูลการกู้เงินที่ต้องการแก้ไข.", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"เกิดข้อผิดพลาดในการแก้ไขข้อมูลการกู้เงิน: {ex.Message}", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
