using QLDSV.Controller;
using QLDSV.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Windows.Forms;

namespace QLDSV.View
{
    public partial class Monhoc : UserControl
    {
       MonhocController controller = new MonhocController();
        public Monhoc()
        {
            InitializeComponent();
            LoadDataGrid();
            dataGridView1.CellClick += DataGridView1_CellClick;

            this.Resize += (s, e) =>
            {
                panel1.Location = new Point((this.ClientSize.Width - panel1.Width) / 2,
                                            (this.ClientSize.Height - panel1.Height) / 2);
            };
        }

        public void GetDataFromText()
        {
            string maMH = txtmamh.Text; // Lấy mã môn học từ TextBox
            string tenMH = txttenmh.Text; // Lấy tên môn học từ TextBox

            MonhocModel monhoc = new MonhocModel
            {
                maMH = maMH,
                tenMH = tenMH
            };

            // Kiểm tra xem môn học đã tồn tại hay chưa
            if (controller.IsExist(maMH))
            {
                controller.Update(monhoc); // Cập nhật nếu môn học đã tồn tại
                MessageBox.Show("Mon hoc updated successfully.");
            }
            else
            {
                controller.Add(monhoc); // Thêm môn học mới nếu chưa tồn tại
                MessageBox.Show("New mon hoc added successfully.");
            }

            LoadDataGrid(); // Tải lại dữ liệu vào DataGridView
        }


        public void SetDataToText(Object item)
        {
            if (item is MonhocModel monhoc)
            {
                txtmamh.Text = monhoc.maMH; // Đặt mã môn học vào TextBox
                txttenmh.Text = monhoc.tenMH; // Đặt tên môn học vào TextBox
            }
            else
            {
                throw new ArgumentException("Item must be of type MonhocModel");
            }
        }


        private void LoadDataGrid()
        {
            if (controller.Load())
            {
                List<MonhocModel> list = controller.Items
                    .OfType<MonhocModel>()
                    .ToList();

                if (list.Count > 0)
                {
                    dataGridView1.DataSource = list; // Cập nhật DataGridView với danh sách môn học
                    dataGridView1.CellClick += DataGridView1_CellClick; // Thêm sự kiện click cho DataGridView
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Tự động điều chỉnh kích thước cột
                }
                else
                {
                    MessageBox.Show("No mon hoc data found.");
                }
            }
            else
            {
                MessageBox.Show("Failed to load mon hoc data.");
            }
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                // Gán giá trị từ các ô vào các TextBox tương ứng
                txtmamh.Text = row.Cells["maMH"].Value?.ToString();
                txttenmh.Text = row.Cells["tenMH"].Value?.ToString();
                // Nếu có thêm thuộc tính nào khác trong MonhocModel, bạn có thể gán ở đây
            }
        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void delete_Click(object sender, EventArgs e)
        {
          
                string maMH = txtmamh.Text; // Mã môn học

                if (controller.IsExist(maMH))
                {
                    controller.Delete(maMH); // Xóa môn học
                    MessageBox.Show("Mon hoc deleted successfully.");
                    LoadDataGrid(); // Tải lại dữ liệu vào DataGridView
                   
                }
                else
                {
                    MessageBox.Show("Mon hoc not found.");
                }
         }

        

        private void save_Click(object sender, EventArgs e)
        {
          
                string maMH = txtmamh.Text; // Mã môn học
                string tenMH = txttenmh.Text; // Tên môn học

                MonhocModel monhoc = new MonhocModel
                {
                    maMH = maMH,
                    tenMH = tenMH
                };

                var monhocExists = controller.IsExist(maMH); // Kiểm tra xem môn học đã tồn tại chưa

                if (monhocExists)
                {
                    controller.Update(monhoc); // Cập nhật thông tin môn học
                    MessageBox.Show("Mon hoc updated successfully.");
                }
                else
                {
                    controller.Add(monhoc); // Thêm môn học mới
                    MessageBox.Show("New mon hoc added successfully.");
                }

                LoadDataGrid(); // Tải lại dữ liệu vào DataGridView
         }

        private void timkiem_Click(object sender, EventArgs e)
        {
          
                string maMH = txtmamh.Text; // Mã môn học để tìm kiếm

                var list = controller.Items
                    .OfType<MonhocModel>() // Chuyển Items về kiểu MonhocModel
                    .Where(monhoc => monhoc.maMH.Contains(maMH)) // Tìm kiếm theo mã môn học
                    .ToList();

                // Hiển thị danh sách kết quả tìm kiếm lên DataGridView
                dataGridView1.DataSource = list;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Tự động điều chỉnh kích thước cột
         }

        private void close_Click(object sender, EventArgs e)
        {
            Trangchu mainForm = (Trangchu)this.ParentForm; // Trở về form chính
            mainForm.Show();
            this.Dispose();
        }
    }
}
