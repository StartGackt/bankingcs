namespace finalprojectbanking
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            button1 = new Button();
            dateTimePicker1 = new DateTimePicker();
            Username = new Label();
            Password = new Label();
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            button2 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F);
            label1.Location = new Point(661, 198);
            label1.Name = "label1";
            label1.Size = new Size(664, 41);
            label1.TabIndex = 0;
            label1.Text = "ระบบบริหารจัดการกลุ่มออมทรัพย์เพื่อการผลิตบ้านท่ารวก ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 18F);
            label2.Location = new Point(680, 241);
            label2.Name = "label2";
            label2.Size = new Size(577, 41);
            label2.TabIndex = 1;
            label2.Text = "ตำบลหนองยายโต๊ะ อำเภอชัยบาดาล จังหวัดลพบุรี ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 18F);
            label3.Location = new Point(885, 308);
            label3.Name = "label3";
            label3.Size = new Size(175, 41);
            label3.TabIndex = 2;
            label3.Text = "การเข้าสู่ระบบ";
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.Black;
            button1.Location = new Point(728, 649);
            button1.Name = "button1";
            button1.Size = new Size(184, 62);
            button1.TabIndex = 3;
            button1.Text = "เข้าสู่ระบบ";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(1640, 95);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(250, 27);
            dateTimePicker1.TabIndex = 4;
            // 
            // Username
            // 
            Username.AutoSize = true;
            Username.Font = new Font("Segoe UI", 16.2F);
            Username.Location = new Point(418, 436);
            Username.Name = "Username";
            Username.Size = new Size(273, 38);
            Username.TabIndex = 6;
            Username.Text = "  ชื่อผู้ใช้งาน (เจ้าหน้าที่)";
            // 
            // Password
            // 
            Password.AutoSize = true;
            Password.Font = new Font("Segoe UI", 16.2F);
            Password.Location = new Point(433, 532);
            Password.Name = "Password";
            Password.Size = new Size(116, 38);
            Password.TabIndex = 7;
            Password.Text = " รหัสผ่าน";
            // 
            // txtUsername
            // 
            txtUsername.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtUsername.Location = new Point(751, 436);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(574, 43);
            txtUsername.TabIndex = 8;
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPassword.Location = new Point(751, 545);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(574, 43);
            txtPassword.TabIndex = 9;
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button2.ForeColor = Color.Black;
            button2.Location = new Point(1114, 649);
            button2.Name = "button2";
            button2.Size = new Size(184, 62);
            button2.TabIndex = 10;
            button2.Text = "เข้าสู่ระบบ";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkGreen;
            ClientSize = new Size(1902, 1033);
            Controls.Add(button2);
            Controls.Add(txtPassword);
            Controls.Add(txtUsername);
            Controls.Add(Password);
            Controls.Add(Username);
            Controls.Add(dateTimePicker1);
            Controls.Add(button1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            ForeColor = Color.White;
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Button button1;
        private DateTimePicker dateTimePicker1;
        private Label Username;
        private Label Password;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private Button button2;
    }
}
