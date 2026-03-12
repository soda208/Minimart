namespace MinimartMIS
{
    partial class frmEmployees
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
            dgvEmployees = new DataGridView();
            btnDelete = new Button();
            btnInsert = new Button();
            txtSearch = new TextBox();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvEmployees).BeginInit();
            SuspendLayout();
            // 
            // dgvEmployees
            // 
            dgvEmployees.AllowUserToAddRows = false;
            dgvEmployees.AllowUserToDeleteRows = false;
            dgvEmployees.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvEmployees.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvEmployees.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEmployees.Location = new Point(31, 119);
            dgvEmployees.Name = "dgvEmployees";
            dgvEmployees.ReadOnly = true;
            dgvEmployees.RowHeadersWidth = 51;
            dgvEmployees.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEmployees.Size = new Size(741, 319);
            dgvEmployees.TabIndex = 11;
            dgvEmployees.CellClick += dgvEmployees_CellClick;
            dgvEmployees.CellDoubleClick += dgvEmployees_CellDoubleClick;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(709, 49);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(62, 28);
            btnDelete.TabIndex = 15;
            btnDelete.Text = "ลบ";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnInsert
            // 
            btnInsert.Location = new Point(623, 49);
            btnInsert.Name = "btnInsert";
            btnInsert.Size = new Size(62, 28);
            btnInsert.TabIndex = 14;
            btnInsert.Text = "เพิ่ม";
            btnInsert.UseVisualStyleBackColor = true;
            btnInsert.Click += btnInsert_Click;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(334, 52);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(266, 27);
            txtSearch.TabIndex = 13;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(195, 57);
            label2.Name = "label2";
            label2.Size = new Size(93, 20);
            label2.TabIndex = 12;
            label2.Text = "ค้นหาพนักงาน";
            // 
            // frmEmployees
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(224, 224, 224);
            ClientSize = new Size(800, 450);
            Controls.Add(btnDelete);
            Controls.Add(btnInsert);
            Controls.Add(txtSearch);
            Controls.Add(label2);
            Controls.Add(dgvEmployees);
            Name = "frmEmployees";
            Text = "frmEmployee";
            Load += frmEmployees_Load;
            ((System.ComponentModel.ISupportInitialize)dgvEmployees).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvEmployees;
        private Button btnDelete;
        private Button btnInsert;
        private TextBox txtSearch;
        private Label label2;
    }
}