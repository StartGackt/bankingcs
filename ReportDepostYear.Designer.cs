﻿namespace Projectfinal
{
    partial class ReportDepostYear
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportDepostYear));
            dataGridView1 = new DataGridView();
            comboBox1 = new ComboBox();
            lblPassword = new Label();
            label3 = new Label();
            dateTimePicker1 = new DateTimePicker();
            label2 = new Label();
            label1 = new Label();
            comboBox2 = new ComboBox();
            label4 = new Label();
            print = new Button();
            button3 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(297, 342);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1246, 403);
            dataGridView1.TabIndex = 97;
            // 
            // comboBox1
            // 
            comboBox1.Font = new Font("Microsoft Sans Serif", 17.9999981F, FontStyle.Bold);
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(373, 247);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(558, 44);
            comboBox1.TabIndex = 96;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Microsoft Sans Serif", 22.1999989F, FontStyle.Bold);
            lblPassword.ForeColor = Color.Transparent;
            lblPassword.Location = new Point(235, 247);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(113, 42);
            lblPassword.TabIndex = 95;
            lblPassword.Text = "เลือกปี";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 25.8F, FontStyle.Bold);
            label3.ForeColor = Color.Transparent;
            label3.Location = new Point(581, 180);
            label3.Name = "label3";
            label3.Size = new Size(754, 51);
            label3.TabIndex = 94;
            label3.Text = "รายงานการฝากเงินสัจจะออมทรัพย์ประจำปี ";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(1596, 61);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(250, 27);
            dateTimePicker1.TabIndex = 93;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 25.8F, FontStyle.Bold);
            label2.ForeColor = Color.Gold;
            label2.Location = new Point(584, 118);
            label2.Name = "label2";
            label2.Size = new Size(856, 51);
            label2.TabIndex = 92;
            label2.Text = "ตำบลหนองยายโต๊ะ อำเภอชัยบาดาล จังหวัดลพบุรี ";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 25.8F, FontStyle.Bold);
            label1.ForeColor = Color.Gold;
            label1.Location = new Point(548, 61);
            label1.Name = "label1";
            label1.Size = new Size(991, 51);
            label1.TabIndex = 91;
            label1.Text = "ระบบบริหารจัดการกลุ่มออมทรัพย์เพื่อการผลิตบ้านท่ารวก ";
            // 
            // comboBox2
            // 
            comboBox2.Font = new Font("Microsoft Sans Serif", 17.9999981F, FontStyle.Bold);
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(1089, 250);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(558, 44);
            comboBox2.TabIndex = 99;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 22.1999989F, FontStyle.Bold);
            label4.ForeColor = Color.Transparent;
            label4.Location = new Point(951, 250);
            label4.Name = "label4";
            label4.Size = new Size(168, 42);
            label4.TabIndex = 98;
            label4.Text = "เลือกเดือน";
            // 
            // print
            // 
            print.BackColor = Color.DarkGreen;
            print.Font = new Font("Microsoft Sans Serif", 23.9999981F, FontStyle.Bold);
            print.ForeColor = Color.Transparent;
            print.Location = new Point(807, 797);
            print.Name = "print";
            print.Size = new Size(195, 74);
            print.TabIndex = 221;
            print.Text = "พิมพ์";
            print.UseVisualStyleBackColor = false;
            print.Click += print_Click;
            // 
            // button3
            // 
            button3.BackColor = Color.DarkGreen;
            button3.Font = new Font("Microsoft Sans Serif", 23.9999981F, FontStyle.Bold);
            button3.ForeColor = Color.Transparent;
            button3.Image = (Image)resources.GetObject("button3.Image");
            button3.Location = new Point(1739, 895);
            button3.Name = "button3";
            button3.Size = new Size(64, 47);
            button3.TabIndex = 222;
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // ReportDepostYear
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkGreen;
            ClientSize = new Size(1902, 1033);
            Controls.Add(button3);
            Controls.Add(print);
            Controls.Add(comboBox2);
            Controls.Add(label4);
            Controls.Add(dataGridView1);
            Controls.Add(comboBox1);
            Controls.Add(lblPassword);
            Controls.Add(label3);
            Controls.Add(dateTimePicker1);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "ReportDepostYear";
            Text = "ReportDepostYear";
            Load += ReportDepostYear_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private ComboBox comboBox1;
        private Label lblPassword;
        private Label label3;
        private DateTimePicker dateTimePicker1;
        private Label label2;
        private Label label1;
        private ComboBox comboBox2;
        private Label label4;
        private Button button2;
        private Button button3;
        private Button print;
    }
}