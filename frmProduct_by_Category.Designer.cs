namespace MinimartMIS
{
    partial class frmProduct_by_Category
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
            dgvCategory = new DataGridView();
            dgvProduct = new DataGridView();
            Showall = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvCategory).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvProduct).BeginInit();
            SuspendLayout();
            // 
            // dgvCategory
            // 
            dgvCategory.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            dgvCategory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCategory.Location = new Point(12, 12);
            dgvCategory.Name = "dgvCategory";
            dgvCategory.RowHeadersWidth = 51;
            dgvCategory.Size = new Size(334, 494);
            dgvCategory.TabIndex = 0;
            dgvCategory.CellMouseUp += dgvCategory_CellMouseUp;
            // 
            // dgvProduct
            // 
            dgvProduct.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            dgvProduct.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProduct.Location = new Point(351, 12);
            dgvProduct.Name = "dgvProduct";
            dgvProduct.RowHeadersWidth = 51;
            dgvProduct.Size = new Size(436, 494);
            dgvProduct.TabIndex = 1;
            // 
            // Showall
            // 
            Showall.Location = new Point(24, 282);
            Showall.Name = "Showall";
            Showall.Size = new Size(148, 39);
            Showall.TabIndex = 2;
            Showall.Text = "แสดงสินค้าทั้งหมด";
            Showall.UseVisualStyleBackColor = true;
            Showall.Click += Showall_Click;
            // 
            // frmProduct_by_Category
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(805, 521);
            Controls.Add(Showall);
            Controls.Add(dgvProduct);
            Controls.Add(dgvCategory);
            Name = "frmProduct_by_Category";
            Text = "frmProduct_by_Category";
            Load += frmProduct_by_Category_Load;
            ((System.ComponentModel.ISupportInitialize)dgvCategory).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvProduct).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvCategory;
        private DataGridView dgvProduct;
        private Button Showall;
    }
}