namespace MinimartMIS
{
    partial class frmPOS
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
            txtEmployeeID = new TextBox();
            txtEmployeeName = new TextBox();
            label1 = new Label();
            label2 = new Label();
            txtProductID = new TextBox();
            txtProductName = new TextBox();
            txtUnitPrice = new TextBox();
            txtQuantity = new TextBox();
            txtTotal = new TextBox();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            btnAdd = new Button();
            btnClear = new Button();
            btnSave = new Button();
            btnCancel = new Button();
            groupBox1 = new GroupBox();
            lsvProducts = new ListView();
            label8 = new Label();
            lblNetPrice = new Label();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // txtEmployeeID
            // 
            txtEmployeeID.Location = new Point(102, 29);
            txtEmployeeID.Name = "txtEmployeeID";
            txtEmployeeID.Size = new Size(155, 27);
            txtEmployeeID.TabIndex = 0;
            txtEmployeeID.KeyDown += txtEmployeeID_KeyDown;
            // 
            // txtEmployeeName
            // 
            txtEmployeeName.Location = new Point(365, 29);
            txtEmployeeName.Name = "txtEmployeeName";
            txtEmployeeName.ReadOnly = true;
            txtEmployeeName.Size = new Size(254, 27);
            txtEmployeeName.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(14, 32);
            label1.Name = "label1";
            label1.Size = new Size(82, 20);
            label1.TabIndex = 2;
            label1.Text = "รหัสพนักงาน";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(278, 32);
            label2.Name = "label2";
            label2.Size = new Size(81, 20);
            label2.TabIndex = 3;
            label2.Text = "ชื่อ-นามสกุล";
            // 
            // txtProductID
            // 
            txtProductID.Location = new Point(11, 74);
            txtProductID.Name = "txtProductID";
            txtProductID.Size = new Size(122, 27);
            txtProductID.TabIndex = 6;
            txtProductID.KeyDown += txtProductID_KeyDown;
            // 
            // txtProductName
            // 
            txtProductName.Location = new Point(150, 74);
            txtProductName.Name = "txtProductName";
            txtProductName.ReadOnly = true;
            txtProductName.Size = new Size(143, 27);
            txtProductName.TabIndex = 7;
            // 
            // txtUnitPrice
            // 
            txtUnitPrice.Location = new Point(299, 74);
            txtUnitPrice.Name = "txtUnitPrice";
            txtUnitPrice.ReadOnly = true;
            txtUnitPrice.Size = new Size(122, 27);
            txtUnitPrice.TabIndex = 8;
            // 
            // txtQuantity
            // 
            txtQuantity.Location = new Point(427, 74);
            txtQuantity.Name = "txtQuantity";
            txtQuantity.Size = new Size(103, 27);
            txtQuantity.TabIndex = 9;
            txtQuantity.TextChanged += txtQuantity_TextChanged;
            // 
            // txtTotal
            // 
            txtTotal.Location = new Point(536, 74);
            txtTotal.Name = "txtTotal";
            txtTotal.ReadOnly = true;
            txtTotal.Size = new Size(111, 27);
            txtTotal.TabIndex = 10;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = SystemColors.ActiveBorder;
            label3.Location = new Point(11, 42);
            label3.Name = "label3";
            label3.Size = new Size(65, 20);
            label3.TabIndex = 11;
            label3.Text = "รหัสสินค้า";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = SystemColors.ActiveBorder;
            label4.Location = new Point(150, 42);
            label4.Name = "label4";
            label4.Size = new Size(59, 20);
            label4.TabIndex = 12;
            label4.Text = "ชื่อสินค้า";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = SystemColors.ActiveBorder;
            label5.Location = new Point(299, 42);
            label5.Name = "label5";
            label5.Size = new Size(88, 20);
            label5.TabIndex = 13;
            label5.Text = "ราคาต่อหน่วย";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = SystemColors.ActiveBorder;
            label6.Location = new Point(427, 42);
            label6.Name = "label6";
            label6.Size = new Size(49, 20);
            label6.TabIndex = 14;
            label6.Text = "จำนวน";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = SystemColors.ActiveBorder;
            label7.Location = new Point(536, 42);
            label7.Name = "label7";
            label7.Size = new Size(71, 20);
            label7.TabIndex = 15;
            label7.Text = "รวมเป็นเงิน";
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(749, 120);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(107, 31);
            btnAdd.TabIndex = 16;
            btnAdd.Text = "เพิ่มรายการ";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(749, 176);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(107, 31);
            btnClear.TabIndex = 17;
            btnClear.Text = "clear";
            btnClear.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            btnSave.Enabled = false;
            btnSave.Location = new Point(749, 233);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(107, 31);
            btnSave.TabIndex = 18;
            btnSave.Text = "บันทึก";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(749, 302);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(152, 37);
            btnCancel.TabIndex = 19;
            btnCancel.Text = "ยกเลิกรายการสั่งซื้อ";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = SystemColors.ActiveBorder;
            groupBox1.Controls.Add(lsvProducts);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(txtTotal);
            groupBox1.Controls.Add(txtQuantity);
            groupBox1.Controls.Add(txtUnitPrice);
            groupBox1.Controls.Add(txtProductName);
            groupBox1.Controls.Add(txtProductID);
            groupBox1.Location = new Point(1, 98);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(734, 407);
            groupBox1.TabIndex = 20;
            groupBox1.TabStop = false;
            groupBox1.Text = "รายการสั้ง่ซื้อ";
            // 
            // lsvProducts
            // 
            lsvProducts.FullRowSelect = true;
            lsvProducts.GridLines = true;
            lsvProducts.Location = new Point(21, 115);
            lsvProducts.Name = "lsvProducts";
            lsvProducts.Size = new Size(670, 272);
            lsvProducts.TabIndex = 16;
            lsvProducts.UseCompatibleStateImageBehavior = false;
            lsvProducts.View = View.Details;
            lsvProducts.DoubleClick += lsvProducts_DoubleClick;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(736, 6);
            label8.Name = "label8";
            label8.Size = new Size(71, 20);
            label8.TabIndex = 21;
            label8.Text = "รวมเป็นเงิน";
            // 
            // lblNetPrice
            // 
            lblNetPrice.BackColor = SystemColors.ActiveCaption;
            lblNetPrice.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNetPrice.Location = new Point(749, 29);
            lblNetPrice.Name = "lblNetPrice";
            lblNetPrice.Size = new Size(184, 57);
            lblNetPrice.TabIndex = 22;
            lblNetPrice.Text = "lb";
            // 
            // frmPOS
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(224, 224, 224);
            ClientSize = new Size(951, 556);
            Controls.Add(lblNetPrice);
            Controls.Add(label8);
            Controls.Add(groupBox1);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(btnClear);
            Controls.Add(btnAdd);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtEmployeeName);
            Controls.Add(txtEmployeeID);
            Name = "frmPOS";
            Text = "frmPOS";
            Load += frmPOS_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtEmployeeID;
        private TextBox txtEmployeeName;
        private Label label1;
        private Label label2;
        private TextBox txtProductID;
        private TextBox txtProductName;
        private TextBox txtUnitPrice;
        private TextBox txtQuantity;
        private TextBox txtTotal;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Button btnAdd;
        private Button btnClear;
        private Button btnSave;
        private Button btnCancel;
        private GroupBox groupBox1;
        private ListView lsvProducts;
        private Label label8;
        private Label lblNetPrice;
    }
}