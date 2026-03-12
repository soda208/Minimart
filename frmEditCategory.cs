using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MinimartMIS
{
    public partial class frmEditCategory : Form
    {
        public frmEditCategory()
        {
            InitializeComponent();
        }

        SqlConnection? conn; // ตัวแปรเชื่อมต่อ
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int categoryID { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string categoryName { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Description { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Status { get; set; }

        private void frmEditCategory_Load(object sender, EventArgs e)
        {
            conn = connectDB.ConnectMinimart();
            txtCategoryID.Text = categoryID.ToString();
            txtCategoryName.Text = categoryName.ToString();
            txtDescription.Text = Description.ToString();

            txtCategoryID.Enabled = false;
            txtCategoryName.Focus();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtCategoryID.Text = categoryID.ToString();
            txtCategoryName.Text = categoryName.ToString();
            txtDescription.Text = Description.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Status == "Insert") 
            {
                InsertData(); 
            }
            else if (Status == "Update") 
            {
                UpdateData();
            }
        }


        private void InsertData()
        {
            string sql = "Insert into Categories (CategoryName, Description) " +
    "Values (@CategoryName, @Description)";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@CategoryName", txtCategoryName.Text.Trim());
            cmd.Parameters.AddWithValue("@Description", txtDescription.Text.Trim());
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            int rows = cmd.ExecuteNonQuery();
            if (rows > 0)
            {
                MessageBox.Show("บันทึกข้อมูลเรียบร้อยแล้ว");
                this.Close();
            }
            else
            {
                MessageBox.Show("ไม่สามารถบันทึกข้อมูลได้");
            }
            this.Close();
        }

        private void UpdateData()
        {
            // 1. แก้ไขตัวสะกดจาก Updete เป็น Update
            string sql = "UPDATE Categories SET CategoryName = @CategoryName, "
                       + " Description = @Description "
                       + " WHERE CategoryID = @CategoryID";

            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@CategoryName", txtCategoryName.Text.Trim());
            cmd.Parameters.AddWithValue("@Description", txtDescription.Text.Trim());
            cmd.Parameters.AddWithValue("@CategoryID", categoryID); // อย่าลืมส่ง ID ไปด้วยเพื่อให้รู้ว่าจะแก้แถวไหน

            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }

            try
            {
                int row = cmd.ExecuteNonQuery();
                if (row > 0)
                {
                    MessageBox.Show("บันทึกข้อมูลเรียบร้อยแล้ว");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("ไม่สามารถบันทึกข้อมูลได้");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("เกิดข้อผิดพลาด SQL: " + ex.Message);
            }
        }


    }
}
