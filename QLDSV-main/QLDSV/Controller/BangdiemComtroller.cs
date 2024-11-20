using Microsoft.SqlServer.Server;
using QLDSV.Model;
using QLDSV.View;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDSV.Controller
{
    internal class BangdiemComtroller
    {

    
     

        public string ConnectionString = ConfigurationManager.ConnectionStrings["Connectsql"].ConnectionString;
        public List<IModel> Items { get; private set; } = new List<IModel>();

        // Thêm mới bảng điểm
        public bool Add(IModel model)
        {
            if (model is BangdiemModel bangdiem)
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    string query = "INSERT INTO BangDiem (maSV, maMH, tenSV, tenMH, diemThanhPhan, diemThi, diemTongKet, xepLoai) " +
                                   "VALUES (@maSV, @maMH, @tenSV, @tenMH, @diemThanhPhan, @diemThi, @diemTongKet, @xepLoai)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@maSV", bangdiem.maSV);
                        cmd.Parameters.AddWithValue("@maMH", bangdiem.maMH);
                        cmd.Parameters.AddWithValue("@tenSV", bangdiem.tenSV);
                        cmd.Parameters.AddWithValue("@tenMH", bangdiem.tenMH);
                        cmd.Parameters.AddWithValue("@diemThanhPhan", bangdiem.diemThanhPhan);
                        cmd.Parameters.AddWithValue("@diemThi", bangdiem.diemThi);
                        cmd.Parameters.AddWithValue("@diemTongKet", bangdiem.diemTongKet);
                        cmd.Parameters.AddWithValue("@xepLoai", bangdiem.xepLoai);

                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            return false;
        }

        // Cập nhật bảng điểm
        public bool Update(IModel model)
        {
            if (model is BangdiemModel bangdiem)
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    string query = "UPDATE BangDiem SET tenSV = @tenSV, tenMH = @tenMH, diemThanhPhan = @diemThanhPhan, " +
                                   "diemThi = @diemThi, diemTongKet = @diemTongKet, xepLoai = @xepLoai " +
                                   "WHERE maSV = @maSV AND maMH = @maMH";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@tenSV", bangdiem.tenSV);
                        cmd.Parameters.AddWithValue("@tenMH", bangdiem.tenMH);
                        cmd.Parameters.AddWithValue("@diemThanhPhan", bangdiem.diemThanhPhan);
                        cmd.Parameters.AddWithValue("@diemThi", bangdiem.diemThi);
                        cmd.Parameters.AddWithValue("@diemTongKet", bangdiem.diemTongKet);
                        cmd.Parameters.AddWithValue("@xepLoai", bangdiem.xepLoai);
                        cmd.Parameters.AddWithValue("@maSV", bangdiem.maSV);
                        cmd.Parameters.AddWithValue("@maMH", bangdiem.maMH);

                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            return false;
        }

        // Xóa bảng điểm
        public bool Delete(int maSV)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                string query = "DELETE FROM BangDiem WHERE maSV = @maSV ";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@maSV", maSV);
                  

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        // Kiểm tra bảng điểm có tồn tại không
        public bool IsExist(int maSV)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM BangDiem WHERE maSV = @maSV ";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@maSV", maSV);
        

                    return (int)cmd.ExecuteScalar() > 0;
                }
            }
        }

        // Đọc một bảng điểm dựa trên maSV và maMH
        public IModel Read(int maSV, string maMH)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                string query = "SELECT * FROM BangDiem WHERE maSV = @maSV AND maMH = @maMH";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@maSV", maSV);
                    cmd.Parameters.AddWithValue("@maMH", maMH);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new BangdiemModel
                            {
                                maSV = Convert.ToInt32(reader["maSV"]),
                                maMH = reader["maMH"].ToString(),
                                tenSV = reader["tenSV"].ToString(),
                                tenMH = reader["tenMH"].ToString(),
                                diemThanhPhan = Convert.ToSingle(reader["diemThanhPhan"]),
                                diemThi = Convert.ToSingle(reader["diemThi"]),
                                diemTongKet = Convert.ToSingle(reader["diemTongKet"]),
                                xepLoai = reader["xepLoai"].ToString()
                            };
                        }
                    }
                }
            }
            return null;
        }

        // Tải tất cả bảng điểm
        public bool Load()
        {
            List<IModel> listBangDiem = new List<IModel>();

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                string query = "SELECT * FROM BangDiem";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var bangdiem = new BangdiemModel
                            {
                                maSV = Convert.ToInt32(reader["maSV"]),
                                maMH = reader["maMH"].ToString(),
                                tenSV = reader["tenSV"].ToString(),
                                tenMH = reader["tenMH"].ToString(),
                                diemThanhPhan = Convert.ToSingle(reader["diemThanhPhan"]),
                                diemThi = Convert.ToSingle(reader["diemThi"]),
                                diemTongKet = Convert.ToSingle(reader["diemTongKet"]),
                                xepLoai = reader["xepLoai"].ToString()
                            };
                            listBangDiem.Add(bangdiem);
                        }
                    }
                }
            }

            this.Items = listBangDiem;
            return listBangDiem.Count > 0;
        }

        // Tải bảng điểm theo maSV
        public List<BangdiemModel> LoadByMaSV(int maSV)
        {
            List<BangdiemModel> listBangDiem = new List<BangdiemModel>();

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                string query = "SELECT * FROM BangDiem WHERE maSV = @maSV";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@maSV", maSV);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var bangdiem = new BangdiemModel
                            {
                                maSV = Convert.ToInt32(reader["maSV"]),
                                maMH = reader["maMH"].ToString(),
                                tenSV = reader["tenSV"].ToString(),
                                tenMH = reader["tenMH"].ToString(),
                                diemThanhPhan = Convert.ToSingle(reader["diemThanhPhan"]),
                                diemThi = Convert.ToSingle(reader["diemThi"]),
                                diemTongKet = Convert.ToSingle(reader["diemTongKet"]),
                                xepLoai = reader["xepLoai"].ToString()
                            };
                            listBangDiem.Add(bangdiem);
                        }
                    }
                }
            }

            return listBangDiem;
        }



    }
}
