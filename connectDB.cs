using Microsoft.Data.SqlClient;

namespace MinimartMIS
{
    internal class connectDB
    {
        public static SqlConnection ConnectMinimart()
        {
            // 1. กำหนดชื่อ Server เป็น localhost\SQLEXPRESS ตามที่คุณใช้งาน
            string server = @"localhost\SQLEXPRESS";

            // 2. ชื่อ Database ต้องตรงกับที่รันใน Script (MiniMart)
            string db = "MiniMart";

            // 3. สร้าง Connection String 
            // เพิ่ม TrustServerCertificate=True เพื่อแก้ปัญหา Error Encryption
            string strCon = string.Format("Data Source={0};Initial Catalog={1};"
                          + "Integrated Security=True;Encrypt=False;TrustServerCertificate=True", server, db);

            SqlConnection conn = new SqlConnection(strCon);
            conn.Open();

            return conn;
        }
    }
}