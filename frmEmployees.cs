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
    public partial class frmEmployees : Form
    {

        SqlConnection conn = null;
        int employeeID = 0;
        string title = string.Empty;
        string firstname = string.Empty;
        string lastname = string.Empty;
        string position = string.Empty;
        string username = string.Empty;
        string password = string.Empty;
        public frmEmployees()
        {
            InitializeComponent();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            frmEditEmployees frm = new frmEditEmployees();
            frm.Status = "Insert";
            frm.EmployeeID = 0;
            frm.ShowDialog();
            showdata("");
        }

        private void showdata(string v)
        {

            string sql = "SELECT * FROM Employees WHERE FirstName LIKE @search OR LastName LIKE @search";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@search", "%" + v + "%");
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvEmployees.DataSource = dt;
        }

        private void dgvEmployees_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            frmEditEmployees frm = new frmEditEmployees();
            frm.Status = "Update";
            // ดึงค่าจาก DataGridView ส่งไปที่ Property ของหน้า Edit
            frm.EmployeeID = Convert.ToInt32(dgvEmployees.Rows[e.RowIndex].Cells["EmployeeID"].Value);
            frm.Title = dgvEmployees.Rows[e.RowIndex].Cells["Title"].Value.ToString() ?? "";
            frm.Firstname = dgvEmployees.Rows[e.RowIndex].Cells["FirstName"].Value.ToString() ?? "";
            frm.Lastname = dgvEmployees.Rows[e.RowIndex].Cells["LastName"].Value.ToString() ?? "";
            frm.Position = dgvEmployees.Rows[e.RowIndex].Cells["Position"].Value.ToString() ?? "";
            frm.Username = dgvEmployees.Rows[e.RowIndex].Cells["UserName"].Value.ToString() ?? "";
            frm.Password = dgvEmployees.Rows[e.RowIndex].Cells["Password"].Value.ToString() ?? "";

            frm.ShowDialog();
            showdata("");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // 1. เช็คก่อนว่าผู้ใช้ได้เลือกพนักงานคนที่จะลบหรือยัง
            if (employeeID == 0)
            {
                MessageBox.Show("กรุณาเลือกพนักงานที่ต้องการลบก่อนจ้า", "คำเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. ถามเพื่อความแน่ใจ (ยืนยันการลบ)
            string empName = firstname + " " + lastname;
            DialogResult dr = MessageBox.Show($"คุณแน่ใจหรือไม่ว่าต้องการลบพนักงาน: {empName}?", "ยืนยันการลบ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                try
                {
                    if (conn!.State == ConnectionState.Closed) conn.Open();

                    // 3. คำสั่ง SQL สำหรับลบพนักงาน
                    string sql = "DELETE FROM Employees WHERE EmployeeID = @EmpID";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@EmpID", employeeID);

                    int rows = cmd.ExecuteNonQuery();

                    if (rows > 0)
                    {
                        MessageBox.Show("ลบข้อมูลพนักงานเรียบร้อยแล้ว", "สำเร็จ");
                        employeeID = 0; // ล้างค่า ID ทิ้งหลังจากลบเสร็จ
                        showdata("");   // รีเฟรชตาราง DataGridView ให้เป็นปัจจุบัน
                    }
                }
                catch (Exception ex)
                {
                    // กรณีลบไม่ได้ เช่น พนักงานคนนี้ไปมีชื่ออยู่ในรายการขาย (ติด Foreign Key)
                    MessageBox.Show("ไม่สามารถลบได้ เนื่องจาก: " + ex.Message, "ข้อผิดพลาด");
                }
                finally
                {
                    if (conn!.State == ConnectionState.Open) conn.Close();
                }
            }
        }

        private void frmEmployees_Load(object sender, EventArgs e)
        {
            conn = connectDB.ConnectMinimart();
            showdata("");

        }

        private void dgvEmployees_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // ป้องกันการคลิกหัวตาราง
            if (e.RowIndex < 0) return;

            // ดึงค่าจากแถวที่เลือกมาเก็บไว้ในตัวแปร เพื่อเอาไปใช้ตอนกดปุ่ม "ลบ"
            employeeID = Convert.ToInt32(dgvEmployees.Rows[e.RowIndex].Cells["EmployeeID"].Value);
            firstname = dgvEmployees.Rows[e.RowIndex].Cells["FirstName"].Value?.ToString() ?? "";
            lastname = dgvEmployees.Rows[e.RowIndex].Cells["LastName"].Value?.ToString() ?? "";
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            // ทุกครั้งที่ตัวหนังสือเปลี่ยน ให้เรียก showdata และส่งค่าในช่องค้นหาไป
            showdata(txtSearch.Text.Trim());
        }
    }
}
