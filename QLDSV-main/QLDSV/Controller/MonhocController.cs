using QLDSV.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QLDSV.Controller
{
    internal class MonhocController : IController
    {
        public string ConnectionString = ConfigurationManager.ConnectionStrings["Connectsql"].ConnectionString;
        public List<IModel> Items { get; private set; } = new List<IModel>();

        // Lấy tất cả môn học
        public List<MonhocModel> GetAllMonhoc()
        {
            List<MonhocModel> listMonHoc = new List<MonhocModel>();

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                string query = "SELECT maMH, tenMH FROM MONHOC";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            MonhocModel monHoc = new MonhocModel
                            {
                                maMH = reader["maMH"].ToString(),
                                tenMH = reader["tenMH"].ToString()
                            };
                            listMonHoc.Add(monHoc);
                        }
                    }
                }
            }

            return listMonHoc;
        }

        // Thêm môn học mới
        public bool Add(IModel model)
        {
            if (model is MonhocModel monhoc)
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    string query = "INSERT INTO MONHOC (maMH, tenMH) VALUES (@maMH, @tenMH)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@maMH", monhoc.maMH);
                        cmd.Parameters.AddWithValue("@tenMH", monhoc.tenMH);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            return false;
        }

        // Cập nhật thông tin môn học
        public bool Update(IModel model)
        {
            if (model is MonhocModel monhoc)
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    string query = "UPDATE MONHOC SET tenMH = @tenMH WHERE maMH = @maMH";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@tenMH", monhoc.tenMH);
                        cmd.Parameters.AddWithValue("@maMH", monhoc.maMH);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            return false;
        }

        // Xóa môn học
        public bool Delete(object id)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                string query = "DELETE FROM MONHOC WHERE maMH = @maMH";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@maMH", id);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        // Kiểm tra môn học có tồn tại không (dựa vào mã môn học)
        public bool IsExist(object id)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM MONHOC WHERE maMH = @maMH";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@maMH", id);
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        // Kiểm tra môn học có tồn tại không (dựa trên đối tượng model)
        public bool IsExist(IModel model)
        {
            if (model is MonhocModel monhoc)
            {
                return IsExist(monhoc.maMH);
            }
            return false;
        }

        // Tải tất cả môn học vào Items
        public bool Load()
        {
            try
            {
                List<IModel> monhocList = new List<IModel>();
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    string query = "SELECT maMH, tenMH FROM MONHOC";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                MonhocModel monhoc = new MonhocModel
                                {
                                    maMH = reader["maMH"].ToString(),
                                    tenMH = reader["tenMH"].ToString()
                                };
                                monhocList.Add(monhoc);
                            }
                        }
                    }
                }
                this.Items = monhocList;
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while loading subject data: " + ex.Message);
                return false;
            }
        }

        // Tải một môn học dựa trên mã môn học
        public bool Load(object id)
        {
            try
            {
                MonhocModel monhoc = null;
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    string query = "SELECT maMH, tenMH FROM MONHOC WHERE maMH = @maMH";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@maMH", id);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                monhoc = new MonhocModel
                                {
                                    maMH = reader["maMH"].ToString(),
                                    tenMH = reader["tenMH"].ToString()
                                };
                            }
                        }
                    }
                }

                if (monhoc != null)
                {
                    this.Items = new List<IModel> { monhoc };
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while loading specific subject data: " + ex.Message);
                return false;
            }
        }

        // Đọc thông tin môn học dựa trên mã môn học
        public IModel Read(object id)
        {
            try
            {
                MonhocModel monHoc = null;

                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    string query = "SELECT maMH, tenMH FROM MONHOC WHERE maMH = @maMH";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@maMH", id);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                monHoc = new MonhocModel
                                {
                                    maMH = reader["maMH"].ToString(),
                                    tenMH = reader["tenMH"].ToString()
                                };
                            }
                        }
                    }
                }
                return monHoc;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while reading course data: " + ex.Message);
                return null;
            }
        }
    }
}
