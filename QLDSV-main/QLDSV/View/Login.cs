using QLDSV.Controller;
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
    public partial class Login : UserControl
    {
        public Login()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dangnhap_Click(object sender, EventArgs e)
        {
           
                string tenTK = name.Text;   // Tên tài khoản người dùng nhập
                string matKhau = pass.Text; // Mật khẩu người dùng nhập

                if (string.IsNullOrEmpty(tenTK) || string.IsNullOrEmpty(matKhau))
                {
                    MessageBox.Show("Vui lòng nhập tên tài khoản và mật khẩu.");
                    return;
                }

                LoginController loginController = new LoginController();

                // Kiểm tra đăng nhập
                bool isLoginSuccessful = loginController.CheckLogin(tenTK, matKhau);

                if (isLoginSuccessful)
                {
                    MessageBox.Show("Đăng nhập thành công!");
                    // Mở form chính sau khi đăng nhập thành công
                    // Ví dụ: this.Hide(); new MainForm().Show();
                }
                else
                {
                    MessageBox.Show("Tên tài khoản hoặc mật khẩu không chính xác.");
                }
            

        }

        //private void dangnhap_Click(object sender, EventArgs e)
        //{

        //        string tenTK = name.Text;   // Tên tài khoản người dùng nhập
        //        string matKhau = pass.Text; // Mật khẩu người dùng nhập

        //        if (string.IsNullOrEmpty(tenTK) || string.IsNullOrEmpty(matKhau))
        //        {
        //            MessageBox.Show("Vui lòng nhập tên tài khoản và mật khẩu.");
        //            return;
        //        }

        //        LoginController loginController = new LoginController();
        //        bool isLoginSuccessful = loginController.CheckLogin(tenTK, matKhau);

        //        if (isLoginSuccessful)
        //        {
        //            MessageBox.Show("Đăng nhập thành công!");
        //            isLoggedIn = true;
        //            ShowFeatures(); // Hiển thị chức năng sau khi đăng nhập
        //            this.Close(); // Đóng form đăng nhập và quay về form chính
        //        }
        //        else
        //        {
        //            MessageBox.Show("Tên tài khoản hoặc mật khẩu không chính xác.");
        //        }


        //}


    }
}
