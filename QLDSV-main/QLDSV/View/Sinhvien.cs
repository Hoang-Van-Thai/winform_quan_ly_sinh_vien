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
    public partial class Sinhvien : UserControl, IView
    {
        SinhvienController controller = new SinhvienController();
        public Sinhvien()
        {
            InitializeComponent();
            LoadDataGrid();
            LoadLopToComboBox();
            dataGridViewsv.CellClick += DataGridViewsv_CellClick;

            this.Resize += (s, e) =>
            {
                panel1.Location = new Point((this.ClientSize.Width - panel1.Width) / 2,
                                            (this.ClientSize.Height - panel1.Height) / 2);
            };
        }

        public void SetDataToText(Object item)
        {
            if (item is SinhvienModel sinhVien)
            {
                textmasv.Text = sinhVien.maSV.ToString();
                texttensv.Text = sinhVien.tenSV;
                comlop.SelectedValue = sinhVien.maLop; // Giả sử bạn đã thiết lập combobox cho maLop
            }
            else
            {
                throw new ArgumentException("Item must be of type SinhvienModel");
            }
        }

        public void GetDataFromText()
        {
            int maSV;
            if (!int.TryParse(textmasv.Text, out maSV))
            {
                MessageBox.Show("Invalid student ID.");
                return;
            }

            SinhvienModel sinhVien = new SinhvienModel
            {
                maSV = maSV,
                tenSV = texttensv.Text,
                maLop = comlop.SelectedValue.ToString() // Lấy giá trị từ combobox
            };

            if (controller.IsExist(sinhVien.maSV))
            {
                controller.Update(sinhVien);
                MessageBox.Show("Student updated successfully.");
            }
            else
            {
                controller.Add(sinhVien);
                MessageBox.Show("New student added successfully.");
            }

            LoadDataGrid();
        }

        private void LoadComboBox()
        {
            // Giả sử bạn có phương thức lấy danh sách lớp từ controller
            var listLop = controller.Load(); // Phương thức này trả về danh sách các lớp

            comlop.DataSource = listLop;
            comlop.DisplayMember = "tenLop"; // Thuộc tính hiển thị
            comlop.ValueMember = "maLop"; // Thuộc tính giá trị
        }

        private void LoadLopToComboBox()
        {
          //  LopController controller = new LopController();
            // Giả sử bạn đã có một controller cho lớp (LopController)
            List<LopModel> listLop = controller.LoadAllLop(); // Hàm này sẽ trả về danh sách lớp từ cơ sở dữ liệu

            if (listLop != null && listLop.Count > 0)
            {
                comlop.DataSource = listLop; // Đặt nguồn dữ liệu cho ComboBox
                comlop.DisplayMember = "tenLop"; // Tên hiển thị cho mỗi mục trong ComboBox
                comlop.ValueMember = "maLop"; // Giá trị của mỗi mục (sẽ dùng để lưu vào database)
            }
            else
            {
                MessageBox.Show("No classes found.");
            }
        }




        private void LoadDataGrid()
        {
            if (controller.Load())
            {
                List<SinhvienModel> list = controller.Items
                    .OfType<SinhvienModel>()
                    .ToList();

                if (list.Count > 0)
                {
                    dataGridViewsv.DataSource = list;
                    dataGridViewsv.CellClick += DataGridViewsv_CellClick;
                    dataGridViewsv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
                else
                {
                    MessageBox.Show("No student data found.");
                }
            }
            else
            {
                MessageBox.Show("Failed to load student data.");
            }
        }

        private void DataGridViewsv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewsv.Rows[e.RowIndex];

                textmasv.Text = row.Cells["maSV"].Value?.ToString();
                texttensv.Text = row.Cells["tenSV"].Value?.ToString();
                comlop.SelectedValue = row.Cells["maLop"].Value?.ToString(); // Giả sử bạn đã thiết lập combobox cho maLop
            }
        }



        private void Sinhvien_Load(object sender, EventArgs e)
        {

        }

        private void save_Click(object sender, EventArgs e)
        {
          
                int maSV;
                if (!int.TryParse(textmasv.Text, out maSV))
                {
                    MessageBox.Show("Invalid student ID.");
                    return;
                }

                string tenSV = texttensv.Text;
                string maLop = comlop.SelectedValue.ToString(); // Lấy giá trị từ combobox

                SinhvienModel sinhVien = new SinhvienModel
                {
                    maSV = maSV,
                    tenSV = tenSV,
                    maLop = maLop
                };

                var sinhVienExists = controller.IsExist(maSV);

                if (sinhVienExists)
                {
                    controller.Update(sinhVien);
                    MessageBox.Show("Student updated successfully.");
                }
                else
                {
                    controller.Add(sinhVien);
                    MessageBox.Show("New student added successfully.");
                }

                LoadDataGrid();
        }

        private void delete_Click(object sender, EventArgs e)
        {
          
                int maSV;
                if (!int.TryParse(textmasv.Text, out maSV))
                {
                    MessageBox.Show("Invalid student ID.");
                    return;
                }

                if (controller.IsExist(maSV))
                {
                    controller.Delete(maSV);
                    MessageBox.Show("Student deleted successfully.");
                    LoadDataGrid();
                   // ClearFields(); // Giả sử bạn có hàm để xóa các trường nhập liệu
                }
                else
                {
                    MessageBox.Show("Student not found.");
                }
         }

        private void close_Click(object sender, EventArgs e)
        {
           
                Trangchu mainForm = (Trangchu)this.ParentForm; // Giả sử bạn có form chính tên Trangchu
                mainForm.Show();
                this.Dispose();
            

        }

        private void tim_Click(object sender, EventArgs e)
        {
          
                string maSV = textmasv.Text;

                var list = controller.Items
                    .OfType<SinhvienModel>() // Chuyển Items về kiểu SinhvienModel
                    .Where(sv => sv.maSV.ToString().Contains(maSV)) // Tìm kiếm theo mã sinh viên
                    .ToList();

                // Hiển thị danh sách kết quả tìm kiếm lên DataGridView
                dataGridViewsv.DataSource = list;
                dataGridViewsv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        
    }
}
