namespace MinimartMIS
{
    partial class frmLogin
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
            txtPassword = new TextBox();
            txtUserName = new TextBox();
            label7 = new Label();
            label6 = new Label();
            btnCancel = new Button();
            btnLogin = new Button();
            User1 = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // txtPassword
            // 
            txtPassword.Anchor = AnchorStyles.None;
            txtPassword.Location = new Point(230, 185);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(235, 27);
            txtPassword.TabIndex = 20;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // txtUserName
            // 
            txtUserName.Anchor = AnchorStyles.None;
            txtUserName.Location = new Point(230, 140);
            txtUserName.Name = "txtUserName";
            txtUserName.Size = new Size(235, 27);
            txtUserName.TabIndex = 19;
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.None;
            label7.AutoSize = true;
            label7.Location = new Point(109, 185);
            label7.Name = "label7";
            label7.Size = new Size(57, 20);
            label7.TabIndex = 18;
            label7.Text = "รหัสผ่าน";
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.None;
            label6.AutoSize = true;
            label6.Location = new Point(109, 140);
            label6.Name = "label6";
            label6.Size = new Size(72, 20);
            label6.TabIndex = 17;
            label6.Text = "ชื่อผู้ใช้งาน";
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.None;
            btnCancel.Location = new Point(395, 305);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(104, 37);
            btnCancel.TabIndex = 4;
            btnCancel.Text = "ยกเลิก";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnLogin
            // 
            btnLogin.Anchor = AnchorStyles.None;
            btnLogin.Location = new Point(207, 305);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(104, 37);
            btnLogin.TabIndex = 3;
            btnLogin.Text = "เข้าสู่ระบบ";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // User1
            // 
            User1.Anchor = AnchorStyles.None;
            User1.Location = new Point(559, 388);
            User1.Name = "User1";
            User1.Size = new Size(118, 29);
            User1.TabIndex = 21;
            User1.Text = "ทดสอบ User1";
            User1.UseVisualStyleBackColor = true;
            User1.Click += User1_Click;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Location = new Point(307, 50);
            label1.Name = "label1";
            label1.Size = new Size(75, 20);
            label1.TabIndex = 22;
            label1.Text = "ระบบLogin";
            // 
            // frmLogin
            // 
            AcceptButton = btnLogin;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(224, 224, 224);
            CancelButton = btnCancel;
            ClientSize = new Size(689, 429);
            Controls.Add(label1);
            Controls.Add(User1);
            Controls.Add(btnCancel);
            Controls.Add(btnLogin);
            Controls.Add(txtPassword);
            Controls.Add(txtUserName);
            Controls.Add(label7);
            Controls.Add(label6);
            Name = "frmLogin";
            Text = "frmLogin";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtPassword;
        private TextBox txtUserName;
        private Label label7;
        private Label label6;
        private Button btnCancel;
        private Button btnLogin;
        private Button User1;
        private Label label1;
    }
}