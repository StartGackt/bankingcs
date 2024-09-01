namespace finalprojectbanking
{
    partial class MainUserLone
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
            button4 = new Button();
            button2 = new Button();
            button1 = new Button();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            SuspendLayout();
            // 
            // button4
            // 
            button4.Location = new Point(388, 394);
            button4.Name = "button4";
            button4.Size = new Size(432, 60);
            button4.TabIndex = 28;
            button4.Text = "3. การกู้เงินฉุกเฉิน ";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button2
            // 
            button2.Location = new Point(952, 293);
            button2.Name = "button2";
            button2.Size = new Size(432, 60);
            button2.TabIndex = 27;
            button2.Text = "2. การกู้เงินสามัญ (แก้ไขข้อมูลผู้ค้ำประกัน) ";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Location = new Point(388, 293);
            button1.Name = "button1";
            button1.Size = new Size(432, 60);
            button1.TabIndex = 26;
            button1.Text = "1. การกู้เงินสามัญ ";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 18F);
            label3.Location = new Point(827, 181);
            label3.Name = "label3";
            label3.Size = new Size(100, 41);
            label3.TabIndex = 25;
            label3.Text = "สมาชิก";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 18F);
            label2.Location = new Point(593, 110);
            label2.Name = "label2";
            label2.Size = new Size(577, 41);
            label2.TabIndex = 24;
            label2.Text = "ตำบลหนองยายโต๊ะ อำเภอชัยบาดาล จังหวัดลพบุรี ";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F);
            label1.Location = new Point(570, 69);
            label1.Name = "label1";
            label1.Size = new Size(664, 41);
            label1.TabIndex = 23;
            label1.Text = "ระบบบริหารจัดการกลุ่มออมทรัพย์เพื่อการผลิตบ้านท่ารวก ";
            // 
            // MainUserLone
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1902, 1033);
            Controls.Add(button4);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "MainUserLone";
            Text = "MainUserLone";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button4;
        private Button button2;
        private Button button1;
        private Label label3;
        private Label label2;
        private Label label1;
    }
}