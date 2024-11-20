using QLDSV.Model;
using QLDSV.View;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace QLDSV.Controller
{
    internal class LoginController
    {
        public string ConnectionString = ConfigurationManager.ConnectionStrings["Connectsql"].ConnectionString;


        public bool CheckLogin(string tenTK, string matKhau)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                string query = "SELECT * FROM TAIKHOAN WHERE tenTK = @tenTK";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@tenTK", tenTK);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Taikhoanmodel taikhoan = new Taikhoanmodel
                            {
                                tenTK = reader["tenTK"].ToString(),
                                matKhau = reader["matKhau"].ToString()
                            };

                            return matKhau == taikhoan.matKhau; // Kiểm tra mật khẩu đã nhập với mật khẩu đã mã hóa
                        }
                    }
                }
            }

            return false; // Nếu không tìm thấy tên tài khoản hoặc mật khẩu không khớp
        }


    }

}
