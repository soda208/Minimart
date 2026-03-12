namespace MinimartMIS
{
    partial class frmEditCategory
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
            groupBox1 = new GroupBox();
            txtDescription = new TextBox();
            txtCategoryName = new TextBox();
            txtCategoryID = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            btnClear = new Button();
            btnSave = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.AutoSize = true;
            groupBox1.Controls.Add(txtDescription);
            groupBox1.Controls.Add(txtCategoryName);
            groupBox1.Controls.Add(txtCategoryID);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(32, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(397, 346);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "จัดการหมวดหมู่สินค้า";
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(138, 153);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(235, 117);
            txtDescription.TabIndex = 7;
            // 
            // txtCategoryName
            // 
            txtCategoryName.Location = new Point(138, 95);
            txtCategoryName.Name = "txtCategoryName";
            txtCategoryName.Size = new Size(235, 27);
            txtCategoryName.TabIndex = 6;
            // 
            // txtCategoryID
            // 
            txtCategoryID.Location = new Point(138, 43);
            txtCategoryID.Name = "txtCategoryID";
            txtCategoryID.Size = new Size(235, 27);
            txtCategoryID.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(17, 156);
            label3.Name = "label3";
            label3.Size = new Size(72, 20);
            label3.TabIndex = 2;
            label3.Text = "รายละเอียด";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(17, 98);
            label2.Name = "label2";
            label2.Size = new Size(109, 20);
            label2.TabIndex = 1;
            label2.Text = "ชื่อหมวดหมู่สินค้า";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(17, 46);
            label1.Name = "label1";
            label1.Size = new Size(115, 20);
            label1.TabIndex = 0;
            label1.Text = "รหัสหมวดหมู่สินค้า";
            // 
            // btnClear
            // 
            btnClear.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnClear.AutoSize = true;
            btnClear.Location = new Point(266, 337);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(104, 37);
            btnClear.TabIndex = 13;
            btnClear.Text = "ล้างฟอร์ม";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnSave.AutoSize = true;
            btnSave.Location = new Point(113, 337);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(104, 37);
            btnSave.TabIndex = 12;
            btnSave.Text = "บันทึก";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // frmEditCategory
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(224, 224, 224);
            ClientSize = new Size(469, 452);
            Controls.Add(btnClear);
            Controls.Add(btnSave);
            Controls.Add(groupBox1);
            Name = "frmEditCategory";
            Text = "frmEditCategory";
            Load += frmEditCategory_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private TextBox txtDescription;
        private TextBox txtCategoryName;
        private TextBox txtCategoryID;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button btnClear;
        private Button btnSave;
    }
}