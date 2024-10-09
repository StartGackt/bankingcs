namespace finalprojectbanking
{
    partial class SearchUser
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
            search = new Label();
            label2 = new Label();
            label1 = new Label();
            txtsearch = new TextBox();
            btnSearch = new Button();
            dataGridView1 = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // search
            // 
            search.AutoSize = true;
            search.Font = new Font("Segoe UI", 18F);
            search.ForeColor = SystemColors.ButtonHighlight;
            search.Location = new Point(425, 260);
            search.Name = "search";
            search.Size = new Size(160, 41);
            search.TabIndex = 19;
            search.Text = "เลขที่สมาชิก";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 18F);
            label2.ForeColor = SystemColors.ButtonHighlight;
            label2.Location = new Point(661, 162);
            label2.Name = "label2";
            label2.Size = new Size(577, 41);
            label2.TabIndex = 18;
            label2.Text = "ตำบลหนองยายโต๊ะ อำเภอชัยบาดาล จังหวัดลพบุรี ";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F);
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(608, 116);
            label1.Name = "label1";
            label1.Size = new Size(664, 41);
            label1.TabIndex = 17;
            label1.Text = "ระบบบริหารจัดการกลุ่มออมทรัพย์เพื่อการผลิตบ้านท่ารวก ";
            // 
            // txtsearch
            // 
            txtsearch.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtsearch.Location = new Point(637, 265);
            txtsearch.Name = "txtsearch";
            txtsearch.Size = new Size(585, 38);
            txtsearch.TabIndex = 20;
            // 
            // btnSearch
            // 
            btnSearch.ForeColor = SystemColors.Desktop;
            btnSearch.Location = new Point(1335, 260);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(116, 41);
            btnSearch.TabIndex = 21;
            btnSearch.Text = "ค้นหา";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(445, 391);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(999, 406);
            dataGridView1.TabIndex = 22;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // SearchUser
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkGreen;
            ClientSize = new Size(1902, 1033);
            Controls.Add(dataGridView1);
            Controls.Add(btnSearch);
            Controls.Add(txtsearch);
            Controls.Add(search);
            Controls.Add(label2);
            Controls.Add(label1);
            ForeColor = SystemColors.ButtonHighlight;
            Name = "SearchUser";
            Text = "SearchUser";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label search;
        private Label label2;
        private Label label1;
        private TextBox txtsearch;
        private Button btnSearch;
        private DataGridView dataGridView1;
    }
}