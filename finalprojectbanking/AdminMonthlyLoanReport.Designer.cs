namespace finalprojectbanking
{
    partial class AdminMonthlyLoanReport
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label4 = new Label();
            dateTimePicker1 = new DateTimePicker();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            comboBox1 = new ComboBox();
            label5 = new Label();
            label6 = new Label();
            dateTimePicker2 = new DateTimePicker();
            dataGridView1 = new DataGridView();
            Print = new Button();
            Search = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = SystemColors.ButtonHighlight;
            label4.Location = new Point(1645, 13);
            label4.Name = "label4";
            label4.Size = new Size(50, 20);
            label4.TabIndex = 57;
            label4.Text = "label4";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(1550, 36);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(250, 27);
            dateTimePicker1.TabIndex = 56;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 18F);
            label3.ForeColor = SystemColors.ButtonHighlight;
            label3.Location = new Point(791, 161);
            label3.Name = "label3";
            label3.Size = new Size(285, 41);
            label3.TabIndex = 55;
            label3.Text = "รายงานการกู้เงินฉุกเฉิน";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 18F);
            label2.ForeColor = SystemColors.ButtonHighlight;
            label2.Location = new Point(617, 103);
            label2.Name = "label2";
            label2.Size = new Size(577, 41);
            label2.TabIndex = 54;
            label2.Text = "ตำบลหนองยายโต๊ะ อำเภอชัยบาดาล จังหวัดลพบุรี ";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F);
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(598, 60);
            label1.Name = "label1";
            label1.Size = new Size(664, 41);
            label1.TabIndex = 53;
            label1.Text = "ระบบบริหารจัดการกลุ่มออมทรัพย์เพื่อการผลิตบ้านท่ารวก ";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "มกราคม", "กุมภาพันธ์", "มีนาคม", "เมษายน", "พฤษภาคม", "มิถุนายน", "กรกฎาคม", "สิงหาคม", "กันยายน", "ตุลาคม", "พฤศจิกายน", "ธันวาคม" });
            comboBox1.Location = new Point(511, 243);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(467, 28);
            comboBox1.TabIndex = 58;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 18F);
            label5.ForeColor = SystemColors.ButtonHighlight;
            label5.Location = new Point(341, 230);
            label5.Name = "label5";
            label5.Size = new Size(146, 41);
            label5.TabIndex = 59;
            label5.Text = "ประจำเดือน";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 18F);
            label6.ForeColor = SystemColors.ButtonHighlight;
            label6.Location = new Point(1080, 230);
            label6.Name = "label6";
            label6.Size = new Size(111, 41);
            label6.TabIndex = 60;
            label6.Text = " ณ วันที่";
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.Location = new Point(1233, 241);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(250, 27);
            dateTimePicker2.TabIndex = 61;
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = SystemColors.ButtonHighlight;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(298, 288);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1335, 383);
            dataGridView1.TabIndex = 62;
            // 
            // Print
            // 
            Print.Location = new Point(908, 753);
            Print.Name = "Print";
            Print.Size = new Size(168, 60);
            Print.TabIndex = 63;
            Print.Text = "พิมพ์";
            Print.UseVisualStyleBackColor = true;
            // 
            // Search
            // 
            Search.Location = new Point(598, 753);
            Search.Name = "Search";
            Search.Size = new Size(168, 60);
            Search.TabIndex = 64;
            Search.Text = "พิมพ์";
            Search.UseVisualStyleBackColor = true;
            Search.Click += Search_Click;
            // 
            // AdminMonthlyLoanReport
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkGreen;
            ClientSize = new Size(1902, 1033);
            Controls.Add(Search);
            Controls.Add(Print);
            Controls.Add(dataGridView1);
            Controls.Add(dateTimePicker2);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(comboBox1);
            Controls.Add(label4);
            Controls.Add(dateTimePicker1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "AdminMonthlyLoanReport";
            Text = "AdminMonthlyLoanReport";
            Load += AdminMonthlyLoanReport_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label4;
        private DateTimePicker dateTimePicker1;
        private Label label3;
        private Label label2;
        private Label label1;
        private ComboBox comboBox1;
        private Label label5;
        private Label label6;
        private DateTimePicker dateTimePicker2;
        private DataGridView dataGridView1;
        private Button Print;
        private Button Search;
    }
}