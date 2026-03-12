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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        // ประกาศตัวแปรเชื่อมต่อและตัวแปรเก็บข้อมูลพนักงาน
        // ใช้ Property แทนตัวแปรธรรมดา
        // ใช้ Property แบบตัวพิมพ์เล็กตามที่คุณต้องการ
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int employeeID { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string employeeName { get; set; } = string.Empty;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string position { get; set; } = string.Empty;
        // ประกาศตัวเชื่อมต่อฐานข้อมูล
        SqlConnection? conn;
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUserName.Text.Trim();
            string password = txtPassword.Text.Trim();
            conn = connectDB.ConnectMinimart();

            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }

            string sql = "Select EmployeeID, SaleName=title+firstname+space(2)+lastname, Position"
                       + " from Employees"
                       + " where username = @usr and Password = @pwd";

            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@usr", username);
            cmd.Parameters.AddWithValue("@pwd", password);
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                employeeID = reader.GetInt32(0);
                employeeName = reader.GetString(1);
                position = reader.GetString(2);
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("ไม่มีข้อมูล username หรือ password!", "Login Failed",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void User1_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. เชื่อมต่อฐานข้อมูล
                using (SqlConnection conn = connectDB.ConnectMinimart())
                {
                    if (conn.State == ConnectionState.Closed) conn.Open();

                    // 2. ดึงข้อมูลพนักงานคนแรก (TOP 1) มาใช้งาน
                    string sql = "SELECT TOP 1 username, Password FROM Employees";

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        // 3. นำข้อมูลจาก Database มากรอกลงใน TextBox ทันที
                        txtUserName.Text = reader["username"].ToString();
                        txtPassword.Text = reader["Password"].ToString();

                        // (Optional) โฟกัสไปที่ปุ่ม Login เพื่อเตรียมกด Enter
                        btnLogin.Focus();
                    }
                    else
                    {
                        MessageBox.Show("ไม่พบข้อมูลพนักงานในระบบ", "แจ้งเตือน");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("เกิดข้อผิดพลาด: " + ex.Message);
            }
        }
    }
}

