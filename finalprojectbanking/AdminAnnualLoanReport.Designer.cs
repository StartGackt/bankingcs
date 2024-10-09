namespace finalprojectbanking
{
    partial class AdminAnnualLoanReport
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
            dataGridView1 = new DataGridView();
            dateTimePicker2 = new DateTimePicker();
            label6 = new Label();
            label5 = new Label();
            comboBox1 = new ComboBox();
            label4 = new Label();
            dateTimePicker1 = new DateTimePicker();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            Search = new Button();
            btnsearch = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = SystemColors.ButtonHighlight;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(300, 318);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1335, 383);
            dataGridView1.TabIndex = 72;
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.Location = new Point(1235, 271);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(250, 27);
            dateTimePicker2.TabIndex = 71;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 18F);
            label6.Location = new Point(1082, 260);
            label6.Name = "label6";
            label6.Size = new Size(111, 41);
            label6.TabIndex = 70;
            label6.Text = " ณ วันที่";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 18F);
            label5.Location = new Point(343, 260);
            label5.Name = "label5";
            label5.Size = new Size(146, 41);
            label5.TabIndex = 69;
            label5.Text = "ประจำเดือน";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "มกราคม", "กุมภาพันธ์", "มีนาคม", "เมษายน", "พฤษภาคม", "มิถุนายน", "กรกฎาคม", "สิงหาคม", "กันยายน", "ตุลาคม", "พฤศจิกายน", "ธันวาคม" });
            comboBox1.Location = new Point(513, 273);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(467, 28);
            comboBox1.TabIndex = 68;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(1643, 30);
            label4.Name = "label4";
            label4.Size = new Size(50, 20);
            label4.TabIndex = 67;
            label4.Text = "label4";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(1552, 66);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(250, 27);
            dateTimePicker1.TabIndex = 66;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 18F);
            label3.Location = new Point(793, 191);
            label3.Name = "label3";
            label3.Size = new Size(276, 41);
            label3.TabIndex = 65;
            label3.Text = "รายงานการกู้เงินสามัญ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 18F);
            label2.Location = new Point(619, 133);
            label2.Name = "label2";
            label2.Size = new Size(577, 41);
            label2.TabIndex = 64;
            label2.Text = "ตำบลหนองยายโต๊ะ อำเภอชัยบาดาล จังหวัดลพบุรี ";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F);
            label1.Location = new Point(600, 90);
            label1.Name = "label1";
            label1.Size = new Size(664, 41);
            label1.TabIndex = 63;
            label1.Text = "ระบบบริหารจัดการกลุ่มออมทรัพย์เพื่อการผลิตบ้านท่ารวก ";
            // 
            // Search
            // 
            Search.Location = new Point(472, 780);
            Search.Name = "Search";
            Search.Size = new Size(168, 60);
            Search.TabIndex = 73;
            Search.Text = "ค้นหา";
            Search.UseVisualStyleBackColor = true;
            // 
            // btnsearch
            // 
            btnsearch.Location = new Point(867, 780);
            btnsearch.Name = "btnsearch";
            btnsearch.Size = new Size(168, 60);
            btnsearch.TabIndex = 74;
            btnsearch.Text = "ค้นหา";
            btnsearch.UseVisualStyleBackColor = true;
            btnsearch.Click += btnsearch_Click;
            // 
            // AdminAnnualLoanReport
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1902, 1033);
            Controls.Add(btnsearch);
            Controls.Add(Search);
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
            Name = "AdminAnnualLoanReport";
            Text = "AdminAnnualLoanReport";
            Load += AdminAnnualLoanReport_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private DateTimePicker dateTimePicker2;
        private Label label6;
        private Label label5;
        private ComboBox comboBox1;
        private Label label4;
        private DateTimePicker dateTimePicker1;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button Search;
        private Button btnsearch;
    }
}