using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MinimartMIS
{
    public partial class frmEditEmployees : Form
    {
        // 1. เพิ่มบรรทัดนี้เพื่อประกาศตัวแปรเชื่อมต่อฐานข้อมูล
        SqlConnection conn = connectDB.ConnectMinimart();

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int EmployeeID { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Title { get; set; } = string.Empty;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Firstname { get; set; } = string.Empty;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Lastname { get; set; } = string.Empty;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Position { get; set; } = string.Empty;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Username { get; set; } = string.Empty;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Password { get; set; } = string.Empty;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Status { get; set; } = string.Empty;
        public frmEditEmployees()
        {
            InitializeComponent();
        }

        private void frmEditEmployees_Load(object sender, EventArgs e)
        {
            if (Status == "Update")
            {
                txtEmployeeID.Text = EmployeeID.ToString();
                cboTitle.Text = Title;
                txtFirstName.Text = Firstname;
                txtLastName.Text = Lastname;
                cboPosition.Text = Position;
                txtUserName.Text = Username;
                txtPassword.Text = Password;
                txtConfirmPassword.Text = Password;

                txtEmployeeID.ReadOnly = true;
            }
            else
            {
                txtEmployeeID.Text = "Auto";
                txtEmployeeID.ReadOnly = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // เช็คว่ารหัสผ่านตรงกันไหม
            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("รหัสผ่านไม่ตรงกัน กรุณาตรวจสอบอีกครั้ง", "แจ้งเตือน");
                return;
            }

            if (Status == "Insert")
            {
                InsertData();
            }
            else
            {
                UpdateData();
            }
        }

        private void UpdateData()
        {
            throw new NotImplementedException();
        }

        private void InsertData()
        {
            try
            {
                // 1. ตรวจสอบการเชื่อมต่อ
                if (conn!.State == ConnectionState.Closed) conn.Open();

                // 2. เรียกใช้ Store Procedure ที่สร้างไว้ใน SQL (InsertEmployees)
                SqlCommand cmd = new SqlCommand("InsertEmployees", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                // 3. ส่ง Parameter ให้ครบตามลำดับใน SQL Script
                cmd.Parameters.AddWithValue("@Title", cboTitle.Text);
                cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text.Trim());
                cmd.Parameters.AddWithValue("@LastName", txtLastName.Text.Trim());
                cmd.Parameters.AddWithValue("@Position", cboPosition.Text);
                cmd.Parameters.AddWithValue("@Username", txtUserName.Text.Trim());
                cmd.Parameters.AddWithValue("@Password", txtPassword.Text.Trim());

                // 4. สั่งให้ทำงาน
                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
                {
                    MessageBox.Show("เพิ่มข้อมูลพนักงานใหม่สำเร็จแล้วจ้า", "สำเร็จ");
                    this.Close(); // บันทึกเสร็จแล้วปิดหน้าแก้ไข
                }
            }
            catch (Exception ex)
            {
                // ถ้ามีปัญหาเรื่องชื่อตัวแปร หรือ SQL จะแจ้งเตือนที่นี่
                MessageBox.Show("เกิดข้อผิดพลาด: " + ex.Message);
            }
            finally
            {
                if (conn!.State == ConnectionState.Open) conn.Close();
            }
        }

        private void btnClearForm_Click(object sender, EventArgs e)
        {
            // ล้างค่าใน TextBox
            txtFirstName.Clear();
            txtLastName.Clear();
            txtUserName.Clear();
            txtPassword.Clear();
            txtConfirmPassword.Clear();

            // รีเซ็ต ComboBox ให้กลับไปเป็นค่าว่าง (ดัชนี -1)
            cboTitle.SelectedIndex = -1;
            cboPosition.SelectedIndex = -1;

            // เลื่อน Cursor ไปรอที่ช่องแรก (คำนำหน้า หรือ ชื่อ) เพื่อให้พร้อมกรอกใหม่
            cboTitle.Focus();
        }
    }
}
