namespace finalprojectbanking
{
    partial class MainAdminReport
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
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            button7 = new Button();
            button8 = new Button();
            SuspendLayout();
            // 
            // button3
            // 
            button3.Location = new Point(740, 443);
            button3.Name = "button3";
            button3.Size = new Size(432, 60);
            button3.TabIndex = 25;
            button3.Text = "รายงานการกู้เงินประจำเดือน (เงินกู้ฉุกเฉิน) ";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.Location = new Point(740, 343);
            button2.Name = "button2";
            button2.Size = new Size(432, 60);
            button2.TabIndex = 24;
            button2.Text = "รายงานการฝากเงินสัจจะออมทรัพย์ประจำปี ";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Location = new Point(740, 251);
            button1.Name = "button1";
            button1.Size = new Size(432, 60);
            button1.TabIndex = 23;
            button1.Text = "รายงานการฝากเงินสัจจะออมทรัพย์ประจำเดือน ";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 18F);
            label3.ForeColor = SystemColors.ButtonHighlight;
            label3.Location = new Point(698, 170);
            label3.Name = "label3";
            label3.Size = new Size(540, 41);
            label3.TabIndex = 22;
            label3.Text = "ข้อมูลเกี่ยวกับเจ้าหน้าที่กองทุน - พิมพ์รายงาน ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 18F);
            label2.ForeColor = SystemColors.ButtonHighlight;
            label2.Location = new Point(672, 96);
            label2.Name = "label2";
            label2.Size = new Size(577, 41);
            label2.TabIndex = 21;
            label2.Text = "ตำบลหนองยายโต๊ะ อำเภอชัยบาดาล จังหวัดลพบุรี ";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F);
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(649, 55);
            label1.Name = "label1";
            label1.Size = new Size(664, 41);
            label1.TabIndex = 20;
            label1.Text = "ระบบบริหารจัดการกลุ่มออมทรัพย์เพื่อการผลิตบ้านท่ารวก ";
            // 
            // button7
            // 
            button7.Location = new Point(740, 617);
            button7.Name = "button7";
            button7.Size = new Size(432, 60);
            button7.TabIndex = 30;
            button7.Text = "ทะเบียนคุมลูกหนี้เงินกู้ ";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // button8
            // 
            button8.Location = new Point(740, 525);
            button8.Name = "button8";
            button8.Size = new Size(432, 60);
            button8.TabIndex = 29;
            button8.Text = "รายงานการกู้เงินประจำปี (เงินกู้สามัญ)";
            button8.UseVisualStyleBackColor = true;
            button8.Click += button8_Click;
            // 
            // MainAdminReport
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkGreen;
            ClientSize = new Size(1902, 1033);
            Controls.Add(button7);
            Controls.Add(button8);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "MainAdminReport";
            Text = "MainAdminReport";
            Load += MainAdminReport_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button3;
        private Button button2;
        private Button button1;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button button7;
        private Button button8;
    }
}