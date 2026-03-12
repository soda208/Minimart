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
    public partial class frmPOS : Form
    {
        // 1. ประกาศตัวแปรเชื่อมต่อ (เหลือไว้ชุดเดียวพอครับ)
        SqlConnection conn;
        SqlTransaction tr;


        // 2. Property สำหรับรับข้อมูลพนักงาน
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int empID { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string empName { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string position { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string userName { get; set; }

        public frmPOS()
        {
            InitializeComponent();
        }



        private void ListViewFormat()
        {
            lsvProducts.Columns.Clear(); // ล้างคอลัมน์เก่าก่อนสร้างใหม่ป้องกันการซ้อน
            lsvProducts.Columns.Add("รหัสสินค้า", 120, HorizontalAlignment.Left);
            lsvProducts.Columns.Add("สินค้า", 170, HorizontalAlignment.Left);
            lsvProducts.Columns.Add("ราคา", 120, HorizontalAlignment.Right);
            lsvProducts.Columns.Add("จำนวน", 75, HorizontalAlignment.Right);
            lsvProducts.Columns.Add("รวมเป็นเงิน", 100, HorizontalAlignment.Right);

            lsvProducts.View = View.Details;
            lsvProducts.GridLines = true;
            lsvProducts.FullRowSelect = true;
        }

        private void ClearProductData()
        {
            txtProductID.Clear();
            txtProductName.Clear();
            txtUnitPrice.Text = "0";
            txtQuantity.Text = "1";
            txtTotal.Text = "0";
            txtProductID.Focus();
        }

        private void frmPOS_Load(object sender, EventArgs e)
        {
            // *** ต้องเพิ่มบรรทัดนี้ เพื่อให้ตัวแปร conn ไม่เป็น null ***
            conn = connectDB.ConnectMinimart();

            ListViewFormat();
            ClearProductData();

            // แสดงรหัสและชื่อพนักงาน (ถ้าตอนแรกเป็น 0 ก็จะโชว์เลข 0)
            txtEmployeeID.Text = this.empID.ToString();
            txtEmployeeName.Text = this.empName;
        }

        private void txtProductID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (string.IsNullOrEmpty(txtProductID.Text)) return;

                // เชื่อมต่อฐานข้อมูล (อ้างอิงตามสไตล์ frmCategory ที่คุณใช้)
                if (conn.State == ConnectionState.Closed) conn.Open();

                string sql = "SELECT ProductName, UnitPrice FROM Products WHERE ProductID = @pid";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@pid", txtProductID.Text);

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    txtProductName.Text = dr["ProductName"].ToString();
                    txtUnitPrice.Text = dr["UnitPrice"].ToString();
                    txtQuantity.Text = "1";
                    txtQuantity.Focus(); // ย้ายไปช่องจำนวนเพื่อให้พิมพ์ต่อได้เลย
                    CalculateTotal(); // เรียกฟังก์ชันคำนวณราคารวมรายชิ้น
                }
                else
                {
                    MessageBox.Show("ไม่พบรหัสสินค้านี้", "ผิดพลาด");
                    ClearProductData();
                }
                dr.Close();
                conn.Close();
            }
        }

        private void CalculateTotal()
        {
            double price = 0;
            int qty = 0;
            double.TryParse(txtUnitPrice.Text, out price);
            int.TryParse(txtQuantity.Text, out qty);
            double total = price * qty;
            txtTotal.Text = total.ToString("#,##0.00");
        }

        private void CalculateNetPrice()
        {
            double netPrice = 0;
            for (int i = 0; i < lsvProducts.Items.Count; i++)
            {
                netPrice += double.Parse(lsvProducts.Items[i].SubItems[4].Text);
            }
            lblNetPrice.Text = netPrice.ToString("#,##0.00");
        }

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            CalculateTotal();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtProductID.Text) || string.IsNullOrEmpty(txtProductName.Text)) return;

            for (int i = 0; i < lsvProducts.Items.Count; i++)
            {
                if (lsvProducts.Items[i].SubItems[0].Text == txtProductID.Text)
                {
                    int qty = int.Parse(lsvProducts.Items[i].SubItems[3].Text) + int.Parse(txtQuantity.Text);
                    double newTotal = double.Parse(lsvProducts.Items[i].SubItems[2].Text) * qty;
                    lsvProducts.Items[i].SubItems[3].Text = qty.ToString();
                    lsvProducts.Items[i].SubItems[4].Text = newTotal.ToString("#,##0.00");

                    CalculateNetPrice();
                    ClearProductData();
                    return;
                }
            }

            string[] item = { txtProductID.Text, txtProductName.Text, txtUnitPrice.Text, txtQuantity.Text, txtTotal.Text };
            ListViewItem lvi = new ListViewItem(item);
            lsvProducts.Items.Add(lvi);

            CalculateNetPrice();
            ClearProductData();

            // ปลดล็อกปุ่มบันทึกเมื่อมีสินค้า
            if (lsvProducts.Items.Count > 0) btnSave.Enabled = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            lsvProducts.Items.Clear();
            CalculateNetPrice();
            ClearProductData();
            btnSave.Enabled = false; // ล็อกปุ่มบันทึก
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (lsvProducts.Items.Count == 0) return;
            if (conn.State == ConnectionState.Closed) conn.Open();
            tr = conn.BeginTransaction();

            try
            {
                // 1. บันทึก Receipts (หัวใบเสร็จ)
                string sqlReceipt = "INSERT INTO Receipts (ReceiptDate, EmployeeID, TotalCash) " +
                                   "VALUES (GETDATE(), @EmpID, @Total)";
                SqlCommand cmdReceipt = new SqlCommand(sqlReceipt, conn, tr);
                cmdReceipt.Parameters.AddWithValue("@EmpID", txtEmployeeID.Text);
                cmdReceipt.Parameters.AddWithValue("@Total", double.Parse(lblNetPrice.Text.Replace(",", "")));
                cmdReceipt.ExecuteNonQuery();

                // 2. ดึงรหัสใบเสร็จล่าสุด (วิธีของอาจารย์ - ส่วนสีม่วง)
                string sqlGetID = "SELECT TOP 1 ReceiptID FROM Receipts ORDER BY ReceiptID DESC";
                SqlCommand comm1 = new SqlCommand(sqlGetID, conn, tr);
                SqlDataReader dr = comm1.ExecuteReader();
                int LastOrderID = 0;
                if (dr.Read())
                {
                    LastOrderID = dr.GetInt32(dr.GetOrdinal("ReceiptID"));
                }
                dr.Close();

                // 3. บันทึก Details และ ตัดสต็อก (วนลูปตามรายการใน ListView)
                string ls = "";
                for (int i = 0; i <= lsvProducts.Items.Count - 1; i++)
                {
                    // --- 3.1 บันทึกรายละเอียดการขาย (Stored Procedure แบบอาจารย์) ---
                    SqlCommand comm3 = new SqlCommand("InsertDetails", conn, tr);
                    comm3.CommandType = CommandType.StoredProcedure;

                    comm3.Parameters.AddWithValue("@ReceiptID", LastOrderID);
                    comm3.Parameters.AddWithValue("@productID", lsvProducts.Items[i].SubItems[0].Text);
                    comm3.Parameters.AddWithValue("@UnitPrice", double.Parse(lsvProducts.Items[i].SubItems[2].Text));
                    comm3.Parameters.AddWithValue("@Quantity", int.Parse(lsvProducts.Items[i].SubItems[3].Text));
                    comm3.ExecuteNonQuery();

                    // --- 3.2 เพิ่มคำสั่งตัดสต็อกสินค้า (Update Products) ---
                    string sqlUpdateStock = "UPDATE Products SET UnitsInStock = UnitsInStock - @Qty WHERE ProductID = @PID";
                    SqlCommand cmdStock = new SqlCommand(sqlUpdateStock, conn, tr);
                    cmdStock.Parameters.AddWithValue("@Qty", int.Parse(lsvProducts.Items[i].SubItems[3].Text));
                    cmdStock.Parameters.AddWithValue("@PID", lsvProducts.Items[i].SubItems[0].Text);
                    cmdStock.ExecuteNonQuery();

                    // รวบรวมข้อมูลไว้โชว์ตอนบันทึกเสร็จ
                    ls += lsvProducts.Items[i].SubItems[0].Text + "--" +
                          lsvProducts.Items[i].SubItems[1].Text + "--" +
                          lsvProducts.Items[i].SubItems[4].Text + Environment.NewLine;
                }

                tr.Commit(); // ยืนยันการบันทึกทั้งหมดลงฐานข้อมูล

                // แสดง Message สรุปการขาย
                string msg = "รหัสการขาย: " + LastOrderID.ToString() + Environment.NewLine + ls + "ยอดรวม: " + lblNetPrice.Text;
                MessageBox.Show(msg, "บันทึกข้อมูลเรียบร้อย");

                // ล้างหน้าจอหลังบันทึกเสร็จ
                lsvProducts.Items.Clear();
                CalculateNetPrice();
                ClearProductData();
                btnSave.Enabled = false; // ล็อกปุ่มบันทึกคืน
            }
            catch (Exception ex)
            {
                tr.Rollback(); // ถ้าพลาดให้ยกเลิกทั้งหมด (สต็อกจะไม่โดนตัดฟรี)
                MessageBox.Show("เกิดข้อผิดพลาด: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void txtEmployeeID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) // เมื่อกดปุ่ม Enter
            {
                if (string.IsNullOrEmpty(txtEmployeeID.Text)) return;

                // เปิดการเชื่อมต่อฐานข้อมูล
                if (conn.State == ConnectionState.Closed) conn.Open();

                // SQL ค้นหาชื่อ-นามสกุลพนักงาน
                string sql = "SELECT FirstName + ' ' + LastName AS EmpName FROM Employees WHERE EmployeeID = @eid";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@eid", txtEmployeeID.Text);

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    // ถ้าพบข้อมูล ให้แสดงชื่อใน txtEmployeeName
                    txtEmployeeName.Text = dr["EmpName"].ToString();
                    // ย้าย Focus ไปที่ช่องรหัสสินค้า เพื่อเตรียมขายของต่อ
                    txtProductID.Focus();
                }
                else
                {
                    // ถ้าไม่พบข้อมูล
                    MessageBox.Show("ไม่พบรหัสพนักงานนี้", "ผิดพลาด");
                    txtEmployeeID.Clear();
                    txtEmployeeName.Clear();
                    txtEmployeeID.Focus();
                }
                dr.Close();
                conn.Close();
            }
        }

        private void lsvProducts_DoubleClick(object sender, EventArgs e)
        {
            foreach (ListViewItem lvi in lsvProducts.SelectedItems)
            {
                lsvProducts.Items.Remove(lvi);
            }
            CalculateNetPrice();
            txtProductID.Focus();
        }
    }
}