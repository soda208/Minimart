using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MinimartMIS
{
    public partial class frmMinimart : Form
    {
        public frmMinimart()
        {
            InitializeComponent();
        }

        // --- เพิ่ม 3 บรรทัดนี้ ---
        int employeeID = 0;
        string employeeName = string.Empty;
        string position = string.Empty;
        private void mnuProduct_Click(object sender, EventArgs e)
        {
            if (!CheckLogin()) return;
            // เปลี่ยนจาก f.Show() เป็นเรียกฟังก์ชันที่เราสร้างใหม่
            ShowChildForm(new frmProducts());
        }
        private void mnuCategory_Click(object sender, EventArgs e)
        {
            if (!CheckLogin()) return;
            ShowChildForm(new frmCategory());
        }

        private void mnuEmployee_Click(object sender, EventArgs e)
        {
            if (!CheckLogin()) return;
            ShowChildForm(new frmEmployees());
        }

        private void mnuProduct_by_Category_Click(object sender, EventArgs e)
        {
            // ดูได้เลยไม่ต้อง Login แต่จำกัด 1 หน้าต่างเหมือนกัน
            ShowChildForm(new frmProduct_by_Category());
        }

        private void mnuEmployee_Sales_Click(object sender, EventArgs e)
        {
            ShowChildForm(new frmEmployees_Sales());
        }

        private void mnuPOS_Click(object sender, EventArgs e)
        {
            if (!CheckLogin()) return;
            ShowChildForm(new frmPOS());
        }

        private void mnuLogin_Click(object sender, EventArgs e)
        {
            frmLogin f = new frmLogin();
            if (f.ShowDialog() == DialogResult.OK)
            {
                this.employeeID = f.employeeID;
                this.employeeName = f.employeeName;
                this.position = f.position;

               
                mnuLogin.Visible = false;  
                mnuLogout.Visible = true;  
                                        
                if (position == "Sale Manager")
                {
                    showMenuManager(true);
                }
                else if (position == "Sale Representative")
                {
                    showMenuSalale(true);
                }

                this.Text = $"ระบบงาน Minimart - ผู้ปฏิบัติการ: {employeeName} ({position})";
            }
        }

        private void mnuLogout_Click(object sender, EventArgs e)
        {
            // 1. ปิดฟอร์มลูกที่เปิดค้างไว้
            foreach (Form child in this.MdiChildren) { child.Close(); }

            // 2. ล้างข้อมูล User
            employeeID = 0;
            employeeName = string.Empty;
            position = string.Empty;

            // 3. สลับปุ่มกลับ
            mnuLogin.Visible = true;   // แสดงปุ่มเข้าสู่ระบบ
            mnuLogout.Visible = false;  // ซ่อนปุ่มออกจากระบบ

            // 4. รีเซ็ตหัวข้อโปรแกรม
            this.Text = "ระบบงานร้านสะดวกซื้อ (Guest Mode)";

            // 5. โชว์เมนูทั้งหมด (เพื่อให้เป็นไปตามกฎ "โชว์เมนูไปก่อน")
            foreach (ToolStripMenuItem m in menuStrip1.Items)
            {
                if (m != mnuLogout) m.Visible = true;
            }
        }

        

        private void frmMinimar_Load(object sender, EventArgs e)
        {
            // 1. วนลูปโชว์ทุกเมนู
            foreach (ToolStripMenuItem m in menuStrip1.Items)
            {
                m.Visible = true;
            }

            // 2. ซ่อนปุ่ม "ออกจากระบบ" ไว้ก่อน (จะโชว์เมื่อ Login แล้วเท่านั้น)
            mnuLogout.Visible = false;

            // 3. รีเซ็ตค่าเริ่มต้น
            this.employeeID = 0;
            this.Text = "ระบบงานร้านสะดวกซื้อ (Guest Mode)";
        }

        private void SetMenuVisible(params ToolStripMenuItem[] menus)
        {
            // สั่งให้ทุกเมนูบนหน้าจอเป็น False (ซ่อน) ก่อน
            foreach (ToolStripMenuItem m in menuStrip1.Items)
            {
                m.Visible = false;
            }

            // สั่งให้เฉพาะเมนูที่ส่งมาใน Parameter เป็น True (แสดง)
            foreach (var m in menus)
            {
                m.Visible = true;
            }
        }

        private bool CheckLogin()
        {
            if (employeeID == 0)
            {
                MessageBox.Show("สิทธิ์การเข้าถึงจำกัด: กรุณาเข้าสู่ระบบก่อนทำการจัดการข้อมูล", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Information);
                mnuLogin_Click(this, EventArgs.Empty); 
                return employeeID != 0;
            }
            return true;
        }

        private void showMenuManager(bool v) => SetMenuVisible(mnuCRUD, mnuReport, mnuPOS, mnuLogout);
        private void showMenuSalale(bool v) => SetMenuVisible(mnuPOS, mnuReport, mnuLogout);

        private void ShowChildForm(Form f)
        {
            // วนลูปเช็คฟอร์มลูกทั้งหมดที่เปิดอยู่
            foreach (Form child in this.MdiChildren)
            {
                // ถ้าเจอชื่อคลาสเดียวกัน แสดงว่าเปิดค้างไว้แล้ว
                if (child.GetType() == f.GetType())
                {
                    child.Activate(); // เรียกขึ้นมาข้างหน้า
                    return; // จบการทำงาน ไม่เปิดซ้ำ
                }
            }

            // ถ้าหาไม่เจอ (ยังไม่เปิด) ให้เปิดใหม่
            f.MdiParent = this;
            f.Show();
        }
    }
}
