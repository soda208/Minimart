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
    public partial class frmProduct_by_Category : Form
    {
        public frmProduct_by_Category()
        {
            InitializeComponent();
        }


        SqlConnection conn;
        private void frmProduct_by_Category_Load(object sender, EventArgs e)
        {
            conn = connectDB.ConnectMinimart();
            showCategory();
            showProduct(0);
        }

        private void showProduct(int categoryID)
        {
            string sql = "SELECT ProductID, ProductName, UnitPrice, UnitsInStock FROM Products";
            SqlCommand cmd;
            DataSet ds = new DataSet();

            if (categoryID == 0)
            {

                cmd = new SqlCommand(sql, conn);
            }
            else
            {

                sql += " WHERE CategoryID = @cid";
                cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@cid", categoryID);
            }
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            dgvProduct.DataSource = ds.Tables[0];
        }

        private void showCategory()
        {
            string sql = "SELECT * FROM Categories"; // เช็คชื่อตารางใน SQL ดีๆ ว่า Category หรือ Categories
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataSet ds = new DataSet(); // ประกาศชื่อ ds ให้ตรงกับบรรทัดถัดไป
            da.Fill(ds);

            dgvCategory.DataSource = ds.Tables[0];
        }

        private void dgvCategory_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int categoryID = Convert.ToInt32(dgvCategory.Rows[e.RowIndex].Cells[0].Value);
                showProduct(categoryID);
            }
        }

        private void Showall_Click(object sender, EventArgs e)
        {
            // เรียกฟังก์ชันแสดงสินค้าโดยส่งค่า 0 เพื่อดึงสินค้าทั้งหมด
            showProduct(0);
        }

       
    }
}
