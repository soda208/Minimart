namespace MinimartMIS
{
    partial class frmEditEmployees
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
            btnClearForm = new Button();
            btnSave = new Button();
            groupBox1 = new GroupBox();
            cboPosition = new ComboBox();
            cboTitle = new ComboBox();
            txtConfirmPassword = new TextBox();
            txtPassword = new TextBox();
            txtUserName = new TextBox();
            txtLastName = new TextBox();
            txtFirstName = new TextBox();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            txtEmployeeID = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // btnClearForm
            // 
            btnClearForm.Location = new Point(644, 58);
            btnClearForm.Name = "btnClearForm";
            btnClearForm.Size = new Size(104, 37);
            btnClearForm.TabIndex = 16;
            btnClearForm.Text = "ล้างฟอร์ม";
            btnClearForm.UseVisualStyleBackColor = true;
            btnClearForm.Click += btnClearForm_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(491, 58);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(104, 37);
            btnSave.TabIndex = 15;
            btnSave.Text = "บันทึก";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(cboPosition);
            groupBox1.Controls.Add(cboTitle);
            groupBox1.Controls.Add(txtConfirmPassword);
            groupBox1.Controls.Add(txtPassword);
            groupBox1.Controls.Add(txtUserName);
            groupBox1.Controls.Add(txtLastName);
            groupBox1.Controls.Add(txtFirstName);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(txtEmployeeID);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(432, 426);
            groupBox1.TabIndex = 14;
            groupBox1.TabStop = false;
            groupBox1.Text = "จัดการรายชื่อพนักงาน";
            // 
            // cboPosition
            // 
            cboPosition.FormattingEnabled = true;
            cboPosition.Items.AddRange(new object[] { "Sale Manager", "Sale Representative" });
            cboPosition.Location = new Point(138, 206);
            cboPosition.Name = "cboPosition";
            cboPosition.Size = new Size(235, 28);
            cboPosition.TabIndex = 19;
            // 
            // cboTitle
            // 
            cboTitle.FormattingEnabled = true;
            cboTitle.Items.AddRange(new object[] { "นาย", "นาง", "นางสาว" });
            cboTitle.Location = new Point(138, 80);
            cboTitle.Name = "cboTitle";
            cboTitle.Size = new Size(235, 28);
            cboTitle.TabIndex = 18;
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.Location = new Point(138, 340);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.Size = new Size(235, 27);
            txtConfirmPassword.TabIndex = 17;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(138, 297);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(235, 27);
            txtPassword.TabIndex = 16;
            // 
            // txtUserName
            // 
            txtUserName.Location = new Point(138, 252);
            txtUserName.Name = "txtUserName";
            txtUserName.Size = new Size(235, 27);
            txtUserName.TabIndex = 15;
            // 
            // txtLastName
            // 
            txtLastName.Location = new Point(138, 165);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(235, 27);
            txtLastName.TabIndex = 13;
            // 
            // txtFirstName
            // 
            txtFirstName.Location = new Point(138, 120);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(235, 27);
            txtFirstName.TabIndex = 12;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(18, 340);
            label8.Name = "label8";
            label8.Size = new Size(91, 20);
            label8.TabIndex = 11;
            label8.Text = "ยืนยันรหัสผ่าน";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(17, 297);
            label7.Name = "label7";
            label7.Size = new Size(57, 20);
            label7.TabIndex = 10;
            label7.Text = "รหัสผ่าน";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(17, 252);
            label6.Name = "label6";
            label6.Size = new Size(72, 20);
            label6.TabIndex = 9;
            label6.Text = "ชื่อผู้ใช้งาน";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(17, 214);
            label5.Name = "label5";
            label5.Size = new Size(78, 20);
            label5.TabIndex = 8;
            label5.Text = "ตำแหน่งงาน";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(17, 168);
            label4.Name = "label4";
            label4.Size = new Size(58, 20);
            label4.TabIndex = 7;
            label4.Text = "นามสกุล";
            // 
            // txtEmployeeID
            // 
            txtEmployeeID.Location = new Point(138, 43);
            txtEmployeeID.Name = "txtEmployeeID";
            txtEmployeeID.Size = new Size(235, 27);
            txtEmployeeID.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(17, 123);
            label3.Name = "label3";
            label3.Size = new Size(26, 20);
            label3.TabIndex = 2;
            label3.Text = "ชื่อ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(17, 80);
            label2.Name = "label2";
            label2.Size = new Size(66, 20);
            label2.TabIndex = 1;
            label2.Text = "คำนำหน้า";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(17, 46);
            label1.Name = "label1";
            label1.Size = new Size(82, 20);
            label1.TabIndex = 0;
            label1.Text = "รหัสพนักงาน";
            // 
            // frmEditEmployees
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(224, 224, 224);
            ClientSize = new Size(800, 450);
            Controls.Add(btnClearForm);
            Controls.Add(btnSave);
            Controls.Add(groupBox1);
            Name = "frmEditEmployees";
            Text = "frmEditEmployee";
            Load += frmEditEmployees_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button btnClearForm;
        private Button btnSave;
        private GroupBox groupBox1;
        private TextBox txtEmployeeID;
        private Label label3;
        private Label label2;
        private Label label1;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private ComboBox cboPosition;
        private ComboBox cboTitle;
        private TextBox txtConfirmPassword;
        private TextBox txtPassword;
        private TextBox txtUserName;
        private TextBox txtLastName;
        private TextBox txtFirstName;
        private Label label8;
    }
}