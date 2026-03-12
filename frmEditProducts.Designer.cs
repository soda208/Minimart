namespace MinimartMIS
{
    partial class frmEditProducts
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
            cboCategory = new ComboBox();
            txtUnitsInStock = new TextBox();
            txtUnitPrice = new TextBox();
            txtProductName = new TextBox();
            txtProductID = new TextBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            groupBox2 = new GroupBox();
            radDiscontinued = new RadioButton();
            radContinued = new RadioButton();
            btnSave = new Button();
            btnClear = new Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(cboCategory);
            groupBox1.Controls.Add(txtUnitsInStock);
            groupBox1.Controls.Add(txtUnitPrice);
            groupBox1.Controls.Add(txtProductName);
            groupBox1.Controls.Add(txtProductID);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(43, 30);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(397, 346);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "จัดการข้อมูลสินค้า";
            // 
            // cboCategory
            // 
            cboCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCategory.FormattingEnabled = true;
            cboCategory.Location = new Point(107, 261);
            cboCategory.Name = "cboCategory";
            cboCategory.Size = new Size(273, 28);
            cboCategory.TabIndex = 9;
            // 
            // txtUnitsInStock
            // 
            txtUnitsInStock.Location = new Point(107, 207);
            txtUnitsInStock.Name = "txtUnitsInStock";
            txtUnitsInStock.Size = new Size(235, 27);
            txtUnitsInStock.TabIndex = 8;
            // 
            // txtUnitPrice
            // 
            txtUnitPrice.Location = new Point(107, 149);
            txtUnitPrice.Name = "txtUnitPrice";
            txtUnitPrice.Size = new Size(235, 27);
            txtUnitPrice.TabIndex = 7;
            // 
            // txtProductName
            // 
            txtProductName.Location = new Point(107, 95);
            txtProductName.Name = "txtProductName";
            txtProductName.Size = new Size(235, 27);
            txtProductName.TabIndex = 6;
            // 
            // txtProductID
            // 
            txtProductID.Location = new Point(107, 45);
            txtProductID.Name = "txtProductID";
            txtProductID.Size = new Size(235, 27);
            txtProductID.TabIndex = 5;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(17, 263);
            label5.Name = "label5";
            label5.Size = new Size(84, 20);
            label5.TabIndex = 4;
            label5.Text = "ประเภทสินค้า";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(17, 207);
            label4.Name = "label4";
            label4.Size = new Size(49, 20);
            label4.TabIndex = 3;
            label4.Text = "จำนวน";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(17, 156);
            label3.Name = "label3";
            label3.Size = new Size(38, 20);
            label3.TabIndex = 2;
            label3.Text = "ราคา";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(17, 98);
            label2.Name = "label2";
            label2.Size = new Size(59, 20);
            label2.TabIndex = 1;
            label2.Text = "ชื่อสินค้า";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(17, 46);
            label1.Name = "label1";
            label1.Size = new Size(65, 20);
            label1.TabIndex = 0;
            label1.Text = "รหัสสินค้า";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(radDiscontinued);
            groupBox2.Controls.Add(radContinued);
            groupBox2.Location = new Point(482, 44);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(289, 120);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "สถานะของสินค้า";
            // 
            // radDiscontinued
            // 
            radDiscontinued.AutoSize = true;
            radDiscontinued.Location = new Point(18, 64);
            radDiscontinued.Name = "radDiscontinued";
            radDiscontinued.Size = new Size(99, 24);
            radDiscontinued.TabIndex = 2;
            radDiscontinued.TabStop = true;
            radDiscontinued.Text = "เลิกจำหน่าย";
            radDiscontinued.UseVisualStyleBackColor = true;
            // 
            // radContinued
            // 
            radContinued.AutoSize = true;
            radContinued.Checked = true;
            radContinued.Location = new Point(18, 34);
            radContinued.Name = "radContinued";
            radContinued.Size = new Size(105, 24);
            radContinued.TabIndex = 0;
            radContinued.TabStop = true;
            radContinued.Text = "จำหน่ายปกติ";
            radContinued.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(482, 210);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(104, 37);
            btnSave.TabIndex = 10;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(635, 210);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(104, 37);
            btnClear.TabIndex = 11;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // frmEditProducts
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(224, 224, 224);
            ClientSize = new Size(800, 450);
            Controls.Add(btnClear);
            Controls.Add(btnSave);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "frmEditProducts";
            Text = "Form2";
            Load += frmEditProducts_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private ComboBox cboCategory;
        private TextBox txtUnitsInStock;
        private TextBox txtUnitPrice;
        private TextBox txtProductName;
        private TextBox txtProductID;
        private GroupBox groupBox2;
        private RadioButton radDiscontinued;
        private RadioButton radContinued;
        private Button btnSave;
        private Button btnClear;
    }
}