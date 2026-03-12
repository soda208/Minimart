namespace MinimartMIS
{
    partial class frmEmployees_Sales
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
            dgvReceipt = new DataGridView();
            dgvEmployees = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvReceipt).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvEmployees).BeginInit();
            SuspendLayout();
            // 
            // dgvReceipt
            // 
            dgvReceipt.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            dgvReceipt.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReceipt.Location = new Point(419, 12);
            dgvReceipt.Name = "dgvReceipt";
            dgvReceipt.RowHeadersWidth = 51;
            dgvReceipt.Size = new Size(466, 522);
            dgvReceipt.TabIndex = 0;
            // 
            // dgvEmployees
            // 
            dgvEmployees.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            dgvEmployees.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEmployees.Location = new Point(12, 12);
            dgvEmployees.Name = "dgvEmployees";
            dgvEmployees.RowHeadersWidth = 51;
            dgvEmployees.Size = new Size(380, 522);
            dgvEmployees.TabIndex = 1;
            dgvEmployees.CellMouseUp += dgvEmployees_CellMouseUp;
            // 
            // frmEmployees_Sales
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(894, 546);
            Controls.Add(dgvEmployees);
            Controls.Add(dgvReceipt);
            Name = "frmEmployees_Sales";
            Text = "frmEmployees_Sales";
            Load += frmEmployees_Sales_Load;
            ((System.ComponentModel.ISupportInitialize)dgvReceipt).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvEmployees).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvReceipt;
        private DataGridView dgvEmployees;
    }
}