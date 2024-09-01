namespace finalprojectbanking
{
    partial class MainAdminUserDiv
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
            button2 = new Button();
            button1 = new Button();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            button3 = new Button();
            SuspendLayout();
            // 
            // button2
            // 
            button2.Location = new Point(704, 414);
            button2.Name = "button2";
            button2.Size = new Size(432, 60);
            button2.TabIndex = 18;
            button2.Text = "รายครอบครัว ";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Location = new Point(704, 322);
            button1.Name = "button1";
            button1.Size = new Size(432, 60);
            button1.TabIndex = 17;
            button1.Text = "รายบุคคล ";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 18F);
            label3.Location = new Point(584, 192);
            label3.Name = "label3";
            label3.Size = new Size(658, 41);
            label3.TabIndex = 16;
            label3.Text = "         ข้อมูลเกี่ยวกับเจ้าหน้าที่กองทุน : การปันผลสมาชิก ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 18F);
            label2.Location = new Point(636, 121);
            label2.Name = "label2";
            label2.Size = new Size(577, 41);
            label2.TabIndex = 15;
            label2.Text = "ตำบลหนองยายโต๊ะ อำเภอชัยบาดาล จังหวัดลพบุรี ";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F);
            label1.Location = new Point(613, 80);
            label1.Name = "label1";
            label1.Size = new Size(664, 41);
            label1.TabIndex = 14;
            label1.Text = "ระบบบริหารจัดการกลุ่มออมทรัพย์เพื่อการผลิตบ้านท่ารวก ";
            // 
            // button3
            // 
            button3.Location = new Point(704, 514);
            button3.Name = "button3";
            button3.Size = new Size(432, 60);
            button3.TabIndex = 19;
            button3.Text = "สรุปการปันผลให้สมาชิกทั้งหมด";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // MainAdminUserDiv
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1902, 1033);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "MainAdminUserDiv";
            Text = "MainAdminUserDiv";
            Load += MainAdminUserDiv_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button2;
        private Button button1;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button button3;
    }
}