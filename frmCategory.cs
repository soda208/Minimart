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
    public partial class frmCategory : Form
    {



        public frmCategory()
        {
            InitializeComponent();
        }

        SqlConnection? conn; // ตัวแปรเชื่อมต่อ
        int categoryID = 0;
        string categoryName = string.Empty;
        string description = string.Empty;
        string Status = string.Empty; // แก้จาก public ... { get; set; } เป็นแบบนี้


        private void frmCategory_Load(object sender, EventArgs e)
        {
            conn = connectDB.ConnectMinimart();
            showdata("");

        }

        private void showdata(string str)
        {
            string sql = "SELECT * FROM Categories "
                        + "WHERE CategoryName Like @search"
                        + " OR Description LIKE @search";
            SqlCommand cmd = new SqlCommand(sql, conn);


            cmd.Parameters.AddWithValue("@search", "%" + str + "%");

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dgvCategory.DataSource = ds.Tables[0];
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            showdata(txtSearch.Text.Trim());
        }

        private void dgvCategory_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {

            if (e.RowIndex < 0) return;


            categoryID = Convert.ToInt32(dgvCategory.Rows[e.RowIndex].Cells[0].Value);
            categoryName = dgvCategory.Rows[e.RowIndex]
                .Cells[1].Value
                .ToString() ?? string.Empty;
            description = dgvCategory.Rows[e.RowIndex].Cells[2].Value.ToString() ?? string.Empty;

            // ส่วนทดสอบ 
            //string msg = categoryID.ToString() + "\n" + categoryName + "\n" + description;
            //MessageBox.Show(msg, "ข้อมูลที่เลือก");
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            frmEditCategory frm = new frmEditCategory();
            frm.categoryID = 0;
            frm.categoryName = string.Empty;
            frm.Description = string.Empty;
            frm.Status = "Insert";
            frm.ShowDialog();
            showdata("");
        }

        private void dgvCategory_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frmEditCategory frm = new frmEditCategory();
            frm.categoryID = categoryID;
            frm.categoryName = categoryName;
            frm.Description = description;
            frm.Status = "Update";
            frm.ShowDialog();
            showdata("");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (categoryID == 0)
            {
                MessageBox.Show("กรุณาเลือกประเภทสินค้าที่ต้องการลบ");
                return;
            }

            DialogResult dr = MessageBox.Show("คุณต้องการลบประเภทสินค้านี้ใช่หรือไม่", "ยืนยันการลบ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                try
                {
                    // --- โค้ดที่ทำงานกับฐานข้อมูลต้องอยู่ใน try ---
                    if (conn.State == ConnectionState.Closed) conn.Open();

                    string sql = "DELETE FROM Categories WHERE CategoryID = @CategoryID"; // แก้ SQL ให้ถูกต้อง
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@CategoryID", categoryID);

                    int rows = cmd.ExecuteNonQuery();

                    if (rows > 0)
                    {
                        MessageBox.Show("ลบประเภทสินค้าสำเร็จ");
                        showdata(""); // รีเฟรชข้อมูล
                    }
                    else
                    {
                        MessageBox.Show("ลบประเภทสินค้าไม่สำเร็จ");
                    }
                }
                catch (Exception ex)
                {
                    // --- ต้องมี catch เพื่อดักจับ Error ---
                    MessageBox.Show("เกิดข้อผิดพลาดในการลบ: " + ex.Message);
                }
                finally
                {
                    // --- ปิดการเชื่อมต่อเสมอ ---
                    if (conn.State == ConnectionState.Open) conn.Close();
                }
            }
        }






    }
}
