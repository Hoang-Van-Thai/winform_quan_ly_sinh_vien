using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDSV.Model
{
    internal class KhoaModel : IModel
    {
        public string maKhoa { get; set; }
        public string tenKhoa { get; set; }

        // Constructor có tham số maKhoa và tenKhoa
        public KhoaModel(string maKhoa, string tenKhoa)
        {
            this.maKhoa = maKhoa;
            this.tenKhoa = tenKhoa;
        }

        // Constructor mặc định (không tham số), nếu cần
        public KhoaModel()
        {
        }
    }
}

