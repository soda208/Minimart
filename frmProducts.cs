using System.Data;
using Microsoft.Data.SqlClient;
using System.Windows.Forms; 

namespace MinimartMIS
{
    public partial class frmProducts : Form
    {
        public frmProducts()
        {
            InitializeComponent();
        }

        SqlConnection? conn; // ตัวแปรเชื่อมต่อ
        string productID = string.Empty; // เก็บค่ารหัสสินค้าที่เลือก
        string productName = string.Empty; // เพิ่มตัวนี้
        double unitPrice = 0;             // เพิ่มตัวนี้
        int unitsInStock = 0;            // เพิ่มตัวนี้

        private void showData()
        {
            conn = connectDB.ConnectMinimart();
            // ดึงคอลัมน์ Discontinued มาด้วย (เป็นคอลัมน์ลำดับที่ 6 ใน SQL หรือ Index 6 ใน DataGridView)
            string sql = "SELECT Products.ProductID, Products.ProductName, Products.UnitPrice, " +
                         "Products.UnitsInStock, Categories.CategoryName, Products.CategoryID, Products.Discontinued " +
                         "FROM Products INNER JOIN Categories " +
                         "ON Products.CategoryID = Categories.CategoryID";

            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);

            dgvProducts.DataSource = ds.Tables[0];

            // --- แก้ไขจุดที่ 1: เช็คจำนวนคอลัมน์ก่อนซ่อนเพื่อกัน Error ---
            if (dgvProducts.Columns.Count > 5)
            {
                dgvProducts.Columns[5].Visible = false; // ซ่อน CategoryID
                dgvProducts.Columns[6].Visible = false; // ซ่อน Discontinued (ถ้าไม่อยากโชว์ในตาราง)
            }
            conn.Close();
        }
        private void frmProducts_Load(object sender, EventArgs e)
        {
            showData(); // เมื่อเปิดฟอร์มขึ้นมา ให้เรียกใช้ฟังก์ชันแสดงข้อมูลทันที
        }

        private void dgvProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmEditProducts f = new frmEditProducts();
            f.status = "insert"; // ส่งค่าบอกหน้าสองว่าเป็นการเพิ่ม
            f.ShowDialog();      // เปิดหน้าจอแบบ Pop-up
            showData();          // เมื่อปิดหน้าสอง ให้โหลดข้อมูลในตารางใหม่ทันที
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(productID))
            {
                MessageBox.Show("กรุณาเลือกรายการที่จะลบก่อนครับ");
                return;
            }

            if (MessageBox.Show("คุณต้องการลบสินค้า " + productName + " ใช่หรือไม่?", "ยืนยันการลบ", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                conn = connectDB.ConnectMinimart();
                string sql = "DELETE FROM Products WHERE ProductID = @pid";
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.AddWithValue("@pid", productID);
                comm.ExecuteNonQuery();
                conn.Close();
                showData(); // แสดงข้อมูลใหม่หลังลบ
            }
        }

        private void dgvProducts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // ดึงตัวแปรแถวปัจจุบันออกมาเพื่อให้อ่านง่ายขึ้น
            DataGridViewRow row = dgvProducts.Rows[e.RowIndex];

            frmEditProducts f = new frmEditProducts();
            f.status = "update";

            // เปลี่ยนจาก Cells[0] เป็นชื่อ Column ที่ตั้งไว้ใน DataGridView
            f.productID = row.Cells["ProductID"].Value.ToString();
            f.productName = row.Cells["ProductName"].Value.ToString();

            // ใช้ Convert พร้อมเช็คค่าว่าง (ป้องกัน Error ซ้ำซ้อน)
            f.unitPrice = row.Cells["UnitPrice"].Value != DBNull.Value ? Convert.ToDouble(row.Cells["UnitPrice"].Value) : 0;
            f.unitsInStock = row.Cells["UnitsInStock"].Value != DBNull.Value ? Convert.ToInt32(row.Cells["UnitsInStock"].Value) : 0;
                f.categoryID = row.Cells["CategoryID"].Value != DBNull.Value ? Convert.ToInt32(row.Cells["CategoryID"].Value) : 0;

            // จุดที่ 3: ส่งสถานะ Discontinued
            f.discontinued = row.Cells["Discontinued"].Value != DBNull.Value ? Convert.ToInt32(row.Cells["Discontinued"].Value) : 0;

            f.ShowDialog();
            showData();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            conn = connectDB.ConnectMinimart();

            // แก้ไขจุดนี้: เพิ่ม CategoryID และ Discontinued เข้าไปใน SELECT ด้วย
            string sql = "SELECT Products.ProductID, Products.ProductName, Products.UnitPrice, " +
                         "Products.UnitsInStock, Categories.CategoryName, Products.CategoryID, Products.Discontinued " + // ดึงมาให้ครบ!
                         "FROM Products INNER JOIN Categories " +
                         "ON Products.CategoryID = Categories.CategoryID " +
                         "WHERE Products.ProductName LIKE @keyword OR Products.ProductID LIKE @keyword";

            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            da.SelectCommand.Parameters.AddWithValue("@keyword", "%" + txtSearch.Text.Trim() + "%");

            DataSet ds = new DataSet();
            da.Fill(ds);

            dgvProducts.DataSource = ds.Tables[0];

            // เพิ่มการซ่อนคอลัมน์เหมือนใน showData ด้วย เพื่อความสวยงาม
            if (dgvProducts.Columns.Count > 6)
            {
                // ตรวจสอบว่ามีคอลัมน์ชื่อนี้อยู่จริงไหมก่อนสั่งซ่อน
                if (dgvProducts.Columns.Contains("CategoryID")) dgvProducts.Columns["CategoryID"].Visible = false;
                if (dgvProducts.Columns.Contains("Discontinued")) dgvProducts.Columns["Discontinued"].Visible = false;
            }

            conn.Close();
        }

        private void dgvProducts_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // เก็บค่าจากแถวที่คลิก เพื่อเอาไว้ใช้ตอนกดปุ่ม "ลบ"
            productID = dgvProducts.Rows[e.RowIndex].Cells[0].Value.ToString();
            productName = dgvProducts.Rows[e.RowIndex].Cells[1].Value.ToString();
        }
    }
}
