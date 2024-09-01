namespace finalprojectbanking
{
    partial class MainUser
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
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            SuspendLayout();
            // 
            // button2
            // 
            button2.Location = new Point(998, 309);
            button2.Name = "button2";
            button2.Size = new Size(432, 60);
            button2.TabIndex = 18;
            button2.Text = "2. การชำระเงินของสมาชิก ";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Location = new Point(434, 309);
            button1.Name = "button1";
            button1.Size = new Size(432, 60);
            button1.TabIndex = 17;
            button1.Text = "1. การฝากเงินสัจจะสะสม ";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 18F);
            label3.Location = new Point(873, 197);
            label3.Name = "label3";
            label3.Size = new Size(100, 41);
            label3.TabIndex = 16;
            label3.Text = "สมาชิก";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 18F);
            label2.Location = new Point(639, 126);
            label2.Name = "label2";
            label2.Size = new Size(577, 41);
            label2.TabIndex = 15;
            label2.Text = "ตำบลหนองยายโต๊ะ อำเภอชัยบาดาล จังหวัดลพบุรี ";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F);
            label1.Location = new Point(616, 85);
            label1.Name = "label1";
            label1.Size = new Size(664, 41);
            label1.TabIndex = 14;
            label1.Text = "ระบบบริหารจัดการกลุ่มออมทรัพย์เพื่อการผลิตบ้านท่ารวก ";
            // 
            // button3
            // 
            button3.Location = new Point(998, 410);
            button3.Name = "button3";
            button3.Size = new Size(432, 60);
            button3.TabIndex = 20;
            button3.Text = "4. การสรุปเงินฝากสมาชิก ";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(434, 410);
            button4.Name = "button4";
            button4.Size = new Size(432, 60);
            button4.TabIndex = 19;
            button4.Text = "3. การกู้เงิน";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.Location = new Point(434, 526);
            button5.Name = "button5";
            button5.Size = new Size(432, 60);
            button5.TabIndex = 21;
            button5.Text = "5. การลาออกของสมาชิก ";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button6
            // 
            button6.Location = new Point(998, 526);
            button6.Name = "button6";
            button6.Size = new Size(432, 60);
            button6.TabIndex = 22;
            button6.Text = "6.ค้นหาสมาชิก";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // MainUser
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1902, 1033);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button3);
            Controls.Add(button4);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "MainUser";
            Text = "MainUser";
            Load += MainUser_Load;
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
        private Button button4;
        private Button button5;
        private Button button6;
    }
}