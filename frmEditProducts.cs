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
    public partial class frmEditProducts : Form
    {
        SqlConnection? conn;
        public frmEditProducts()
        {
            InitializeComponent();
        }

        // เพิ่ม Attribute [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)] 
        // เพื่อบอก Designer ว่าไม่ต้องพยายามเอาค่าพวกนี้ไปบันทึกในหน้าดีไซน์

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string status { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string pID { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string productID { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string productName { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public double unitPrice { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int unitsInStock { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int categoryID { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int discontinued { get; set; }

        private void setCbo()
        {
            // เปลี่ยนจาก SqlConnection conn = ... เป็นการเรียกใช้ตัวแปรระดับ Class
            conn = connectDB.ConnectMinimart();
            string sql = "SELECT CategoryID, CategoryName FROM Categories";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);

            cboCategory.DataSource = dt;
            cboCategory.ValueMember = "CategoryID";
            cboCategory.DisplayMember = "CategoryName";
            conn.Close();
        }

        private bool checkInputData()
        {
            // ตรวจสอบรหัสสินค้าห้ามว่าง
            if (txtProductID.Text.Trim() == "")
            {
                MessageBox.Show("รหัสสินค้าต้องไม่เป็นที่ว่าง", "เกิดข้อผิดพลาด");
                txtProductID.Focus();
                return false;
            }
            // ตรวจสอบชื่อสินค้าห้ามว่าง
            if (txtProductName.Text.Trim() == "")
            {
                MessageBox.Show("ชื่อสินค้าต้องไม่เป็นที่ว่าง", "เกิดข้อผิดพลาด");
                txtProductName.Focus();
                return false;
            }
            // ตรวจสอบราคาต้องเป็นตัวเลข
            double x = 0;
            if (!double.TryParse(txtUnitPrice.Text, out x))
            {
                MessageBox.Show("ราคาสินค้าต้องเป็นตัวเลขเท่านั้น", "เกิดข้อผิดพลาด");
                txtUnitPrice.Focus();
                return false;
            }
            // ตรวจสอบจำนวนต้องเป็นตัวเลข
            int y = 0;
            if (!int.TryParse(txtUnitsInStock.Text, out y))
            {
                MessageBox.Show("จำนวนสินค้าต้องเป็นตัวเลขเท่านั้น", "เกิดข้อผิดพลาด");
                txtUnitsInStock.Focus();
                return false;
            }
            return true;
        }



        private void frmEditProducts_Load(object sender, EventArgs e)
        {
            setCbo(); // โหลดข้อมูล ComboBox ก่อน
            if (status == "update")
            {
                this.Text = "แก้ไขข้อมูลสินค้า";
                txtProductID.Text = productID;
                txtProductName.Text = productName;
                txtUnitPrice.Text = unitPrice.ToString();
                txtUnitsInStock.Text = unitsInStock.ToString();
                cboCategory.SelectedValue = categoryID;
                txtProductID.Enabled = false; // ห้ามแก้รหัสสินค้า

                if (discontinued == 0) radContinued.Checked = true;
                else radDiscontinued.Checked = true;
            }
            else
            {
                this.Text = "เพิ่มข้อมูลสินค้าใหม่";
                txtProductID.Enabled = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (checkInputData() == false) return;

            conn = connectDB.ConnectMinimart();
            SqlCommand comm = new SqlCommand();
            comm.Connection = conn;

            if (status == "insert")
            {
                comm.CommandText = "INSERT INTO Products (ProductID, ProductName, UnitPrice, UnitsInStock, CategoryID, Discontinued) " +
                                   "VALUES (@pID, @pName, @pPrice, @pStock, @cID, @dis)";
            }
            else
            {
                comm.CommandText = "UPDATE Products SET ProductName=@pName, UnitPrice=@pPrice, UnitsInStock=@pStock, " +
                                   "CategoryID=@cID, Discontinued=@dis WHERE ProductID=@pID";
            }

            // --- แก้ไขจุดที่ 2: แปลง string จาก TextBox เป็นประเภทตัวเลขก่อนส่งไป Database ---
            comm.Parameters.AddWithValue("@pID", txtProductID.Text.Trim());
            comm.Parameters.AddWithValue("@pName", txtProductName.Text.Trim());
            comm.Parameters.AddWithValue("@pPrice", Convert.ToDouble(txtUnitPrice.Text.Trim())); // แปลงเป็น Double สำหรับ Money
            comm.Parameters.AddWithValue("@pStock", Convert.ToInt32(txtUnitsInStock.Text.Trim())); // แปลงเป็น Int สำหรับ Stocks
            comm.Parameters.AddWithValue("@cID", cboCategory.SelectedValue);
            comm.Parameters.AddWithValue("@dis", radContinued.Checked ? 0 : 1);

            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();
                comm.ExecuteNonQuery();
                MessageBox.Show("บันทึกข้อมูลเรียบร้อยแล้ว", "สำเร็จ");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("เกิดข้อผิดพลาด: " + ex.Message, "Error");
            }
            finally
            {
                conn.Close();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtProductID.Clear();
            txtProductName.Clear();
            txtUnitPrice.Clear();
            txtUnitsInStock.Clear();
            cboCategory.SelectedIndex = 0;
            radContinued.Checked = true;
            txtProductID.Focus();
        }
    }
}
