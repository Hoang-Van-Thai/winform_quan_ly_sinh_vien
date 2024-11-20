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
    public partial class Trangchu : Form
    {
        public Trangchu()
        {
            InitializeComponent();
           // HideFeatures();
        }

        private void thôngTinKhoaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Khoa khoa = new Khoa();
            panelTC.Controls.Clear();
            khoa.Dock = DockStyle.Fill;
            panelTC.Controls.Add(khoa);
            khoa.Show();
        }

        private void panelTC_Paint(object sender, PaintEventArgs e)
        {

        }

        private void thôngTinLớpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Lop lop = new Lop();
            panelTC.Controls.Clear();
            lop.Dock = DockStyle.Fill;
            panelTC .Controls.Add(lop);
            lop.Show();
        }

        private void mônToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Monhoc monhoc = new Monhoc();
            panelTC .Controls.Clear();
            monhoc.Dock = DockStyle.Fill;
            panelTC .Controls.Add(monhoc);
            monhoc.Show();

        }

        private void thôngTinSinhViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sinhvien sinhvien = new Sinhvien();
            panelTC .Controls.Clear();
            sinhvien.Dock = DockStyle.Fill;
            panelTC .Controls .Add(sinhvien);
            sinhvien.Show();
        }

        private void bảngĐiểmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bangdiem bangdiem = new Bangdiem();
            panelTC .Controls.Clear ();
            bangdiem.Dock = DockStyle.Fill;
            panelTC.Controls.Add(bangdiem);
            bangdiem.Show();
        }

        private void đăngNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            panelTC.Controls.Clear();
            login.Dock = DockStyle.Fill;
            panelTC.Controls .Add(login);
            login.Show();

        }

        //private bool isLoggedIn = false; // Ban đầu là false vì chưa đăng nhập


        //private void HideFeatures()
        //{
        //    // Ẩn các nút, menu, panel hoặc điều khiển khác
        //    someButton.Visible = false;
        //    anotherPanel.Visible = false;
        //    menuFeature.Visible = false;
        //}

        //private void ShowFeatures()
        //{
        //    if (isLoggedIn)
        //    {
        //        someButton.Visible = true;
        //        anotherPanel.Visible = true;
        //        menuFeature.Visible = true;
        //    }
        //}

        //private void someButton_Click(object sender, EventArgs e)
        //{
        //    if (!isLoggedIn)
        //    {
        //        MessageBox.Show("Bạn cần phải đăng nhập để sử dụng chức năng này.");
        //        return;
        //    }

        //    // Thực hiện chức năng nếu đã đăng nhập
        //    PerformSomeFeature();
        //}


    }
}
