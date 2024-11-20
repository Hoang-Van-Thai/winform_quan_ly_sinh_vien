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
using System.Windows.Forms;

namespace QLDSV.View
{
    public partial class Khoa : UserControl, IView
    {
        KhoaController controller = new KhoaController();

        public Khoa()
        {
            InitializeComponent();
            LoadDataGrid();
            dataGridViewkhoa.CellClick += DataGridViewkhoa_CellClick;

            this.Resize += (s, e) =>
            {
                panel1.Location = new Point((this.ClientSize.Width - panel1.Width) / 2,
                                            (this.ClientSize.Height - panel1.Height) / 2);
            };
        }

        // Lấy dữ liệu từ các TextBox và thêm hoặc cập nhật khoa
        public void GetDataFromText()
        {
            KhoaModel khoa = new KhoaModel
            {
                maKhoa = txtma.Text,
                tenKhoa = txtten.Text
            };

            if (controller.IsExist(khoa.maKhoa))
            {
                controller.Update(khoa);
                MessageBox.Show("Khoa updated successfully.");
            }
            else
            {
                controller.Add(khoa);
                MessageBox.Show("New khoa added successfully.");
            }
        }

        // Đặt dữ liệu vào các TextBox từ một item
        public void SetDataToText(object item)
        {
            if (item is KhoaModel khoa)
            {
                txtma.Text = khoa.maKhoa;
                txtten.Text = khoa.tenKhoa;
            }
            else
            {
                throw new ArgumentException("Item must be of type KhoaModel");
            }
        }

        // Tải dữ liệu vào DataGridView
        private void LoadDataGrid()
        {
            if (controller.Load())
            {
                List<KhoaModel> list = controller.Items
                    .OfType<KhoaModel>()
                    .ToList();

                if (list.Count > 0)
                {
                    dataGridViewkhoa.DataSource = list;
                    dataGridViewkhoa.CellClick += DataGridViewkhoa_CellClick;
                    dataGridViewkhoa.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
                else
                {
                    MessageBox.Show("No khoa data found.");
                }
            }
            else
            {
                MessageBox.Show("Failed to load khoa data.");
            }
        }


        private void DataGridViewkhoa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewkhoa.Rows[e.RowIndex];

                txtma.Text = row.Cells["maKhoa"].Value?.ToString();
                txtten.Text = row.Cells["tenKhoa"].Value?.ToString();
            }
        }



        // Xóa dữ liệu trong các TextBox
        private void ClearFields()
        {
            txtma.Clear();
            txtten.Clear();
        }

        private void save_Click_1(object sender, EventArgs e)
        {
            string maKhoa = txtma.Text;
            string tenKhoa = txtten.Text;

            KhoaModel khoa = new KhoaModel(maKhoa, tenKhoa);
            var khoaExists = controller.IsExist(maKhoa);

            if (khoaExists)
            {
                controller.Update(khoa);
                MessageBox.Show("Khoa updated successfully.");
            }
            else
            {
                controller.Add(khoa);
                MessageBox.Show("New khoa added successfully.");
            }

            LoadDataGrid();
        }

        private void delete_Click_1(object sender, EventArgs e)
        {
            string maKhoa = txtma.Text;

            if (controller.IsExist(maKhoa))
            {
                controller.Delete(maKhoa);
                MessageBox.Show("Khoa deleted successfully.");
                LoadDataGrid();
                ClearFields();
            }
            else
            {
                MessageBox.Show("Khoa not found.");
            }
        }

        private void close_Click(object sender, EventArgs e)
        {
            Trangchu mainForm = (Trangchu)this.ParentForm;
            mainForm.Show();
            this.Dispose();
        }

        private void timkiem_Click(object sender, EventArgs e)
        {
            string maKhoa = txtma.Text;

            var list = controller.Items
        .OfType<KhoaModel>()  // Chuyển Items về kiểu KhoaModel
        .Where(khoa => khoa.maKhoa.Contains(maKhoa))  // Tìm kiếm theo mã khoa
        .ToList();

            // Hiển thị danh sách kết quả tìm kiếm lên DataGridView
            dataGridViewkhoa.DataSource = list;
            dataGridViewkhoa.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void Khoa_Load(object sender, EventArgs e)
        {

        }
    }

}
