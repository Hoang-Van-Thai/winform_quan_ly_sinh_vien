using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace QLDSV.Model
{
    internal class Taikhoanmodel
    {
        public string tenTK { get; set; }
        public string matKhau { get; set; }

        //    public string HashPassword(string password)
        //    {
        //        using (SHA256 sha256Hash = SHA256.Create())
        //        {
        //            byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
        //            StringBuilder builder = new StringBuilder();
        //            foreach (byte byteValue in bytes)
        //            {
        //                builder.Append(byteValue.ToString("x2"));
        //            }
        //            return builder.ToString();
        //        }
        //    }

        //    // Kiểm tra mật khẩu có hợp lệ không
        //    public bool VerifyPassword(string enteredPassword)
        //    {
        //        return HashPassword(enteredPassword) == matKhau;
        //    }
        //}
    }
}
