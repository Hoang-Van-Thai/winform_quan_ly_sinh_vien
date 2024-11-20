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
    public partial class Lop : UserControl,IView
    {

        LopController controller = new LopController();
        public Lop()
        {
            InitializeComponent();
            LoadDataGrid();
            LoadKhoaToComboBox();
            dataGridViewlop.CellClick += DataGridViewlop_CellClick;


            this.Resize += (s, e) =>
            {
                panel1.Location = new Point((this.ClientSize.Width - panel1.Width) / 2,
                                            (this.ClientSize.Height - panel1.Height) / 2);
            };
        }

        private void LoadKhoaToComboBox()
        {
            KhoaController controller = new KhoaController();

            List<KhoaModel> listKhoa = controller.GetAllKhoa(); 

            if (listKhoa != null && listKhoa.Count > 0)
            {
                comkhoa.DataSource = listKhoa;     
                comkhoa.DisplayMember = "tenKhoa";   
                comkhoa.ValueMember = "maKhoa";      
            }
            else
            {
                MessageBox.Show("No data found in Khoa table.");
            }
        }


        public void GetDataFromText()
        {
            LopModel lop = new LopModel
            {
                maLop = textmalop.Text,
                tenLop = texttenlop.Text,
                maKhoa = comkhoa.Text
            };

            if (controller.IsExist(lop.maLop))  // Kiểm tra nếu mã lớp đã tồn tại
            {
                controller.Update(lop);  // Cập nhật lớp nếu đã tồn tại
                MessageBox.Show("Class updated successfully.");
            }
            else
            {
                controller.Add(lop);  // Thêm lớp mới nếu chưa tồn tại
                MessageBox.Show("New class added successfully.");
            }
        }

        public void SetDataToText(object item)
        {
            if (item is LopModel lop)
            {
                textmalop.Text = lop.maLop;
                texttenlop.Text = lop.tenLop;
                comkhoa.Text = lop.maKhoa;
            }
            else
            {
                throw new ArgumentException("Item must be of type LopModel");
            }
        }


        private void LoadDataGrid()
        {
            if (controller.Load())  // Tải toàn bộ dữ liệu lớp
            {
                List<LopModel> list = controller.Items
                    .OfType<LopModel>()
                    .ToList();

                if (list.Count > 0)
                {
                    dataGridViewlop.DataSource = list;
                    dataGridViewlop.CellClick += DataGridViewlop_CellClick;  // Xử lý sự kiện click trên DataGridView
                    dataGridViewlop.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
                else
                {
                    MessageBox.Show("No class data found.");
                }
            }
            else
            {
                MessageBox.Show("Failed to load class data.");
            }
        }

        private void DataGridViewlop_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewlop.Rows[e.RowIndex];

                textmalop.Text = row.Cells["maLop"].Value?.ToString();
                texttenlop.Text = row.Cells["tenLop"].Value?.ToString();
                comkhoa.Text = row.Cells["maKhoa"].Value?.ToString();
            }
        }

        private void save_Click(object sender, EventArgs e)
        {
           
                LopModel lop = new LopModel
                {
                    maLop = textmalop.Text,
                    tenLop = texttenlop.Text,
                    maKhoa = comkhoa.Text
                };

                if (!controller.IsExist(lop.maLop))
                {
                    controller.Add(lop);  // Thêm lớp mới nếu chưa tồn tại
                    MessageBox.Show("Class added successfully.");
                }
                else
                {
                    controller.Update(lop);  // Cập nhật lớp nếu đã tồn tại
                    MessageBox.Show("Class updated successfully.");
                }

                LoadDataGrid();  // Tải lại dữ liệu vào DataGridView sau khi lưu
        }

        private void delete_Click(object sender, EventArgs e)
        {
          
                if (!string.IsNullOrEmpty(textmalop.Text))
                {
                    controller.Delete(textmalop.Text);
                    MessageBox.Show("Class deleted successfully.");
                    LoadDataGrid();  // Tải lại dữ liệu vào DataGridView sau khi xóa
                }
                else
                {
                    MessageBox.Show("Please select a class to delete.");
                }
        }

        private void close_Click(object sender, EventArgs e)
        {
           
                this.close_Click(sender, e);

        }

        private void tim_Click(object sender, EventArgs e)
        {
           
                if (controller.Load(textmalop.Text))  // Tìm lớp theo mã lớp
                {
                    List<LopModel> list = controller.Items
                        .OfType<LopModel>()
                        .ToList();

                    if (list.Count > 0)
                    {
                        dataGridViewlop.DataSource = list;
                    }
                    else
                    {
                        MessageBox.Show("No matching class found.");
                    }
                }
                else
                {
                    MessageBox.Show("Failed to search for class.");
                }
         }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
