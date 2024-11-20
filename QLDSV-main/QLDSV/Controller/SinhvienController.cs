using Microsoft.SqlServer.Server;
using QLDSV.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLDSV.Controller
{
    internal class SinhvienController
    {

        public string ConnectionString = ConfigurationManager.ConnectionStrings["Connectsql"].ConnectionString;
        public List<IModel> items = new List<IModel>();
        public List<IModel> Items { get; private set; }
        MonhocModel lop = new MonhocModel();


        public List<SinhvienModel> LoadAll()
        {
            List<SinhvienModel> sinhvienList = new List<SinhvienModel>();

            string query = "SELECT maSV, tenSV, maLop FROM Sinhvien"; // Câu lệnh SQL để lấy tất cả dữ liệu từ bảng Sinhvien

            using (SqlConnection connection = new SqlConnection(ConnectionString)) // Giả sử bạn có connectionString để kết nối database
            {
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        SinhvienModel sinhvien = new SinhvienModel
                        {
                            maSV = reader.GetInt32(0),
                            tenSV = reader.GetString(1),
                            maLop = reader.GetString(2)
                        };

                        sinhvienList.Add(sinhvien);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading students: " + ex.Message);
                }
            }

            return sinhvienList;
        }


        public bool Add(IModel model)
        {
            try
            {
                SinhvienModel sinhVien = model as SinhvienModel;
                if (sinhVien == null) return false;

                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    string query = "INSERT INTO SINHVIEN (maSV, tenSV, maLop) VALUES (@maSV, @tenSV, @maLop)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@maSV", sinhVien.maSV);
                        cmd.Parameters.AddWithValue("@tenSV", sinhVien.tenSV);
                        cmd.Parameters.AddWithValue("@maLop", sinhVien.maLop);
                        cmd.ExecuteNonQuery();
                    }
                }
                return true; 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while adding student: " + ex.Message);
                return false; 
            }
        }

        public bool Update(IModel model)
        {
            try
            {
                SinhvienModel sinhVien = model as SinhvienModel;
                if (sinhVien == null) return false;

                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    string query = "UPDATE SINHVIEN SET tenSV = @tenSV, maLop = @maLop WHERE maSV = @maSV";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@maSV", sinhVien.maSV);
                        cmd.Parameters.AddWithValue("@tenSV", sinhVien.tenSV);
                        cmd.Parameters.AddWithValue("@maLop", sinhVien.maLop);
                        cmd.ExecuteNonQuery();
                    }
                }
                return true; 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while updating student: " + ex.Message);
                return false; 
            }
        }

        public bool Delete(Object id)
        {
            try
            {
                int maSV = (int)id;

                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    string query = "DELETE FROM SINHVIEN WHERE maSV = @maSV";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@maSV", maSV);
                        cmd.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while deleting student: " + ex.Message);
                return false; 
            }
        }

        public bool Load()
        {
            try
            {
                List<SinhvienModel> sinhVienList = new List<SinhvienModel>();

                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    string query = "SELECT * FROM SINHVIEN";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                SinhvienModel sinhVien = new SinhvienModel
                                {
                                    maSV = (int)reader["maSV"],
                                    tenSV = reader["tenSV"].ToString(),
                                    maLop = reader["maLop"].ToString()
                                };
                                sinhVienList.Add(sinhVien);
                            }
                        }
                    }
                }
                this.Items = sinhVienList.Cast<IModel>().ToList();
                return true; 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while loading student data: " + ex.Message);
                return false; 
            }
        }


        public bool Load(Object id)
        {
            try
            {
                SinhvienModel sinhVien = null;

                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    string query = "SELECT * FROM SINHVIEN WHERE maSV = @maSV";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@maSV", id);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                sinhVien = new SinhvienModel
                                {
                                    maSV = (int)reader["maSV"],
                                    tenSV = reader["tenSV"].ToString(),
                                    maLop = reader["maLop"].ToString()
                                };
                            }
                        }
                    }
                }
                if (sinhVien != null)
                {
                    this.Items = new List<IModel> { sinhVien }; 
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while loading student data: " + ex.Message);
                return false; 
            }
        }

        public IModel Read(object id)
        {
            try
            {
                SinhvienModel sinhVien = null;

                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    string query = "SELECT * FROM SINHVIEN WHERE maSV = @maSV";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@maSV", id);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                sinhVien = new SinhvienModel
                                {
                                    maSV = reader["maSV"] != DBNull.Value ? (int)reader["maSV"] : 0,
                                    tenSV = reader["tenSV"].ToString(),
                                    maLop = reader["maLop"] != DBNull.Value ? reader["maLop"].ToString() : string.Empty
                                };
                            }
                        }
                    }
                }
                return sinhVien;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while reading student data: " + ex.Message);
                return null;
            }
        }

        public List<SinhvienModel> GetAllSinhvien()
        {
            List<SinhvienModel> listSinhVien = new List<SinhvienModel>();

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                string query = "SELECT maSV, tenSV, maLop FROM SINHVIEN";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            SinhvienModel sinhVien = new SinhvienModel
                            {
                                maSV = Convert.ToInt32(reader["maSV"]),
                                tenSV = reader["tenSV"].ToString(),
                                maLop = reader["maLop"].ToString()
                            };
                            listSinhVien.Add(sinhVien);
                        }
                    }
                }
            }

            return listSinhVien;
        }


        public List<LopModel> LoadAllLop()
        {
            List<LopModel> listLop = new List<LopModel>();

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                string query = "SELECT maLop, tenLop FROM Lop";
                SqlCommand cmd = new SqlCommand(query, conn);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        LopModel lop = new LopModel
                        {
                            maLop = reader["maLop"].ToString(),
                            tenLop = reader["tenLop"].ToString()
                        };
                        listLop.Add(lop);
                    }
                }
            }

            return listLop;
        }


        public bool IsExist(IModel model)
        {
            try
            {
                SinhvienModel sinhVien = model as SinhvienModel;
                if (sinhVien == null) return false;

                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM SINHVIEN WHERE maSV = @maSV";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@maSV", sinhVien.maSV);
                        int count = (int)cmd.ExecuteScalar();
                        return count > 0; 
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while checking student existence: " + ex.Message);
                return false; 
            }
        }

        public bool IsExist(object id)
        {
            try
            {
                int maSV = (int)id;

                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM SINHVIEN WHERE maSV = @maSV";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@maSV", maSV);
                        int count = (int)cmd.ExecuteScalar();
                        return count > 0; 
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while checking student existence: " + ex.Message);
                return false; 
            }
        }


    }
}
