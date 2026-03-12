namespace MinimartMIS
{
    partial class frmMinimart
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
            menuStrip1 = new MenuStrip();
            mnuCRUD = new ToolStripMenuItem();
            mnuProduct = new ToolStripMenuItem();
            mnuCategory = new ToolStripMenuItem();
            mnuEmployee = new ToolStripMenuItem();
            mnuReport = new ToolStripMenuItem();
            mnuProduct_by_Category = new ToolStripMenuItem();
            mnuEmployee_Sales = new ToolStripMenuItem();
            mnuPOS = new ToolStripMenuItem();
            mnuLogin = new ToolStripMenuItem();
            mnuLogout = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { mnuCRUD, mnuReport, mnuPOS, mnuLogin, mnuLogout });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.RenderMode = ToolStripRenderMode.System;
            menuStrip1.Size = new Size(1066, 28);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // mnuCRUD
            // 
            mnuCRUD.DropDownItems.AddRange(new ToolStripItem[] { mnuProduct, mnuCategory, mnuEmployee });
            mnuCRUD.Name = "mnuCRUD";
            mnuCRUD.Size = new Size(95, 24);
            mnuCRUD.Text = "จัดการข้อมูล";
            // 
            // mnuProduct
            // 
            mnuProduct.Name = "mnuProduct";
            mnuProduct.Size = new Size(239, 26);
            mnuProduct.Text = "จัดการข้อมูลสินค้า";
            mnuProduct.Click += mnuProduct_Click;
            // 
            // mnuCategory
            // 
            mnuCategory.Name = "mnuCategory";
            mnuCategory.Size = new Size(239, 26);
            mnuCategory.Text = "จัดการข้อมูลประเภทสินค้า";
            mnuCategory.Click += mnuCategory_Click;
            // 
            // mnuEmployee
            // 
            mnuEmployee.Name = "mnuEmployee";
            mnuEmployee.Size = new Size(239, 26);
            mnuEmployee.Text = "จัดการข้อมูลพนักงาน";
            mnuEmployee.Click += mnuEmployee_Click;
            // 
            // mnuReport
            // 
            mnuReport.DropDownItems.AddRange(new ToolStripItem[] { mnuProduct_by_Category, mnuEmployee_Sales });
            mnuReport.Name = "mnuReport";
            mnuReport.Size = new Size(86, 24);
            mnuReport.Text = "แสดงข้อมูล";
            // 
            // mnuProduct_by_Category
            // 
            mnuProduct_by_Category.Name = "mnuProduct_by_Category";
            mnuProduct_by_Category.Size = new Size(232, 26);
            mnuProduct_by_Category.Text = "ข้อมูลสินค้าตามประเภท";
            mnuProduct_by_Category.Click += mnuProduct_by_Category_Click;
            // 
            // mnuEmployee_Sales
            // 
            mnuEmployee_Sales.Name = "mnuEmployee_Sales";
            mnuEmployee_Sales.Size = new Size(232, 26);
            mnuEmployee_Sales.Text = "ข้อมูลสินค้าตามพนักงาน";
            mnuEmployee_Sales.Click += mnuEmployee_Sales_Click;
            // 
            // mnuPOS
            // 
            mnuPOS.Name = "mnuPOS";
            mnuPOS.Size = new Size(104, 24);
            mnuPOS.Text = "จำหน่ายสินค้า";
            mnuPOS.Click += mnuPOS_Click;
            // 
            // mnuLogin
            // 
            mnuLogin.Name = "mnuLogin";
            mnuLogin.Size = new Size(80, 24);
            mnuLogin.Text = "เข้าสู่ระบบ";
            mnuLogin.Click += mnuLogin_Click;
            // 
            // mnuLogout
            // 
            mnuLogout.Name = "mnuLogout";
            mnuLogout.Size = new Size(101, 24);
            mnuLogout.Text = "ออกจากระบบ";
            mnuLogout.Click += mnuLogout_Click;
            // 
            // frmMinimart
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1066, 654);
            Controls.Add(menuStrip1);
            IsMdiContainer = true;
            MainMenuStrip = menuStrip1;
            Name = "frmMinimart";
            Text = "frmMinimar";
            Load += frmMinimar_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem mnuCRUD;
        private ToolStripMenuItem mnuProduct;
        private ToolStripMenuItem mnuCategory;
        private ToolStripMenuItem mnuEmployee;
        private ToolStripMenuItem mnuReport;
        private ToolStripMenuItem mnuProduct_by_Category;
        private ToolStripMenuItem mnuEmployee_Sales;
        private ToolStripMenuItem mnuPOS;
        private ToolStripMenuItem mnuLogin;
        private ToolStripMenuItem mnuLogout;
    }
}