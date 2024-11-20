using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using QLDSV.Model;
using System.Configuration;

namespace QLDSV.Controller
{
    internal class LopController : IController
    {
        public string ConnectionString = ConfigurationManager.ConnectionStrings["Connectsql"].ConnectionString;
        public List<IModel> Items { get; private set; } = new List<IModel>();

        // Thêm mới một lớp
        public bool Add(IModel model)
        {
            if (model is LopModel lop)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(ConnectionString))
                    {
                        conn.Open();
                        string query = "INSERT INTO LOP (maLop, tenLop, maKhoa) VALUES (@maLop, @tenLop, @maKhoa)";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@maLop", lop.maLop);
                            cmd.Parameters.AddWithValue("@tenLop", lop.tenLop);
                            cmd.Parameters.AddWithValue("@maKhoa", lop.maKhoa);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    // Thêm vào danh sách Items
                    Items.Add(lop);
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error while adding class: " + ex.Message);
                }
            }
            return false;
        }

        // Cập nhật thông tin lớp
        public bool Update(IModel model)
        {
            if (model is LopModel lop)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(ConnectionString))
                    {
                        conn.Open();
                        string query = "UPDATE LOP SET tenLop = @tenLop, maKhoa = @maKhoa WHERE maLop = @maLop";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@maLop", lop.maLop);
                            cmd.Parameters.AddWithValue("@tenLop", lop.tenLop);
                            cmd.Parameters.AddWithValue("@maKhoa", lop.maKhoa);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    // Cập nhật thông tin trong danh sách Items
                    var item = Items.OfType<LopModel>().FirstOrDefault(l => l.maLop == lop.maLop);
                    if (item != null)
                    {
                        item.tenLop = lop.tenLop;
                        item.maKhoa = lop.maKhoa;
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error while updating class: " + ex.Message);
                }
            }
            return false;
        }

        // Xóa lớp
        public bool Delete(object id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    string query = "DELETE FROM LOP WHERE maLop = @maLop";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@maLop", id);
                        cmd.ExecuteNonQuery();
                    }
                }

                // Xóa khỏi danh sách Items
                Items = Items.Where(l => ((LopModel)l).maLop != id.ToString()).ToList();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while deleting class: " + ex.Message);
                return false;
            }
        }

        // Tải toàn bộ danh sách lớp
        public bool Load()
        {
            try
            {
                List<IModel> lopList = new List<IModel>();
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    string query = "SELECT * FROM LOP";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var lop = new LopModel
                                {
                                    maLop = reader["maLop"].ToString(),
                                    tenLop = reader["tenLop"].ToString(),
                                    maKhoa = reader["maKhoa"].ToString()
                                };
                                lopList.Add(lop);
                            }
                        }
                    }
                }

                // Gán danh sách vào Items
                Items = lopList;
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while loading all class data: " + ex.Message);
                return false;
            }
        }

        // Tải thông tin lớp dựa vào ID
        public bool Load(object id)
        {
            try
            {
                LopModel lop = null;
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    string query = "SELECT * FROM LOP WHERE maLop = @maLop";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@maLop", id);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                lop = new LopModel
                                {
                                    maLop = reader["maLop"].ToString(),
                                    tenLop = reader["tenLop"].ToString(),
                                    maKhoa = reader["maKhoa"].ToString()
                                };
                            }
                        }
                    }
                }

                // Cập nhật Items nếu tìm thấy
                if (lop != null)
                {
                    Items = new List<IModel> { lop };
                    return true;
                }
                else
                {
                    MessageBox.Show("Class not found with the provided ID.");
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while loading specific class data: " + ex.Message);
                return false;
            }
        }

        // Đọc thông tin lớp dựa trên ID
        public IModel Read(object id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    string query = "SELECT * FROM LOP WHERE maLop = @maLop";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@maLop", id);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new LopModel
                                {
                                    maLop = reader["maLop"].ToString(),
                                    tenLop = reader["tenLop"].ToString(),
                                    maKhoa = reader["maKhoa"].ToString()
                                };
                            }
                        }
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while reading class data: " + ex.Message);
                return null;
            }
        }

        // Kiểm tra xem lớp có tồn tại không (dựa trên ID)
        public bool IsExist(object id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM LOP WHERE maLop = @maLop";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@maLop", id);
                        int count = (int)cmd.ExecuteScalar();
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while checking if class exists: " + ex.Message);
                return false;
            }
        }

        // Kiểm tra lớp có tồn tại không (dựa trên IModel)
        public bool IsExist(IModel model)
        {
            if (model is LopModel lop)
            {
                return IsExist(lop.maLop);
            }
            return false;
        }
    }
}
