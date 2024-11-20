using Microsoft.SqlServer.Server;
using QLDSV.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Windows.Forms;

namespace QLDSV.Controller
{
    internal class KhoaController : IController
    {


        public  string ConnectionString = ConfigurationManager.ConnectionStrings["Connectsql"].ConnectionString;
        public List<IModel> items = new List<IModel>();
        public List<IModel> Items { get; private set; }
       

        public bool Add(IModel model)
        {

            KhoaModel khoa = (KhoaModel)model;
         
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                string query = "INSERT INTO KHOA (maKhoa, tenKhoa) VALUES (@maKhoa, @tenKhoa)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {

                    cmd.Parameters.AddWithValue("@maKhoa", khoa.maKhoa);
                    cmd.Parameters.AddWithValue("@tenKhoa", khoa.tenKhoa);

                    cmd.ExecuteNonQuery();
                }
            }
            return true;
        }

        // Cập nhật thông tin của một khoa
        public bool Update(IModel model)
        {
            KhoaModel khoa = (KhoaModel)model;
            
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                string query = "UPDATE KHOA SET tenKhoa = @tenKhoa WHERE maKhoa = @maKhoa";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {

                    cmd.Parameters.AddWithValue("@maKhoa", khoa.maKhoa);
                    cmd.Parameters.AddWithValue("@tenKhoa", khoa.tenKhoa);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        // Xóa một khoa dựa trên mã khoa
        public bool Delete(object id)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                string query = "DELETE FROM KHOA WHERE maKhoa = @maKhoa";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@maKhoa", id);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        // Đọc thông tin của một khoa dựa trên mã khoa
        public IModel Read(object id)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                string query = "SELECT * FROM KHOA WHERE maKhoa = @maKhoa";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@maKhoa", id);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new KhoaModel
                            {
                                maKhoa = reader["maKhoa"] != DBNull.Value ? reader["maKhoa"].ToString() : string.Empty,
                                tenKhoa = reader["tenKhoa"] != DBNull.Value ? reader["tenKhoa"].ToString() : string.Empty
                            };
                        }
                        else
                        {
                            MessageBox.Show("No data found with the specified 'maKhoa'.");
                        }
                    }
                }
            }
            return null;
        }

        public List<KhoaModel> GetAllKhoa()
        {
            List<KhoaModel> listKhoa = new List<KhoaModel>();

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                string query = "SELECT maKhoa, tenKhoa FROM Khoa"; 
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            KhoaModel khoa = new KhoaModel
                            {
                                maKhoa = reader["maKhoa"].ToString(),
                                tenKhoa = reader["tenKhoa"].ToString()
                            };
                            listKhoa.Add(khoa);
                        }
                    }
                }
            }

            return listKhoa;
        }


        // Tải tất cả các khoa từ cơ sở dữ liệu
        public bool Load()
        {
            try
            {
                List<IModel> khoaList = new List<IModel>();
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    string query = "SELECT * FROM KHOA";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                KhoaModel khoa = new KhoaModel
                                {
                                    maKhoa = reader["maKhoa"].ToString(),
                                    tenKhoa = reader["tenKhoa"].ToString()
                                };
                                khoaList.Add(khoa);
                            }
                        }
                    }
                }
                this.Items = khoaList;  
                return true;  
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while loading khoa data: " + ex.Message);
                return false;  
            }
        }




        // Tải thông tin một khoa dựa trên mã khoa
        public bool Load(object id)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                string query = "SELECT * FROM KHOA WHERE maKhoa = @maKhoa";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@maKhoa", id);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        // Kiểm tra xem mã khoa có tồn tại trong cơ sở dữ liệu không
        public bool IsExist(object id)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                string query = "SELECT COUNT(1) FROM KHOA WHERE maKhoa = @maKhoa";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@maKhoa", id);
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        // Kiểm tra xem một khoa có tồn tại dựa trên các thuộc tính của nó
        public bool IsExist(IModel model)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                string query = "SELECT COUNT(1) FROM KHOA WHERE maKhoa = @maKhoa AND tenKhoa = @tenKhoa";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    KhoaModel khoa = (KhoaModel)model;
                    cmd.Parameters.AddWithValue("@maKhoa", khoa.maKhoa);
                    cmd.Parameters.AddWithValue("@tenKhoa", khoa.tenKhoa);

                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }

    }


}
