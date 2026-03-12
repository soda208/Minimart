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
    public partial class frmEmployees_Sales : Form
    {
        public frmEmployees_Sales()
        {
            InitializeComponent();
        }
        // 1. ประกาศตัวแปรเชื่อมต่อฐานข้อมูล
        SqlConnection conn;

        private void frmEmployees_Sales_Load(object sender, EventArgs e)
        {
            conn = connectDB.ConnectMinimart();
            showEmployees(); // เรียกฟังก์ชันที่เราแยกออกมา
            showReceipt(0);
        }

        private void showEmployees()
        {
            string sql = "SELECT EmployeeID, FirstName + ' ' + LastName AS EmployeeName FROM Employees";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dgvEmployees.DataSource = ds.Tables[0];
        }
        private void showReceipt(int empID)
        {
            SqlCommand cmd = null;
            if (empID == 0)
            {
                string sql = "Select ReceiptID, " +
                             "FORMAT(ReceiptDate, 'dd/MM/yyyy') AS ReceiptDate, " +
                             "FORMAT(TotalCash, 'N2') AS TotalCash " +
                             "from Receipts r join Employees e on r.EmployeeID = e.EmployeeID";
                cmd = new SqlCommand(sql, conn);
            }
            else
            {
                string sql = "Select ReceiptID, " +
                             "FORMAT(ReceiptDate, 'dd/MM/yyyy') AS ReceiptDate, " +
                             "FORMAT(TotalCash, 'N2') AS TotalCash " +
                             "from Receipts r join Employees e on r.EmployeeID = e.EmployeeID " +
                             "where e.EmployeeID = @empID";
                cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@empID", empID);
            }
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dgvReceipt.DataSource = ds.Tables[0];
        }

        private void dgvEmployees_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            // ตรวจสอบว่าคลิกโดนแถวข้อมูล (ไม่ใช่ส่วนหัวตาราง)
            if (e.RowIndex >= 0)
            {
                // 1. ดึงค่า EmployeeID จากคอลัมน์แรก (Index 0) ของแถวที่ถูกคลิก
                int empID = Convert.ToInt32(dgvEmployees.Rows[e.RowIndex].Cells[0].Value);

                // 2. ส่งค่า empID ไปที่ฟังก์ชัน showReceipt เพื่อโหลดข้อมูลใบเสร็จใหม่
                showReceipt(empID);
            }
        }
    }
}
