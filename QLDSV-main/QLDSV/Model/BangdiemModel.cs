using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDSV.Model
{
    internal class BangdiemModel:IModel
    {
        public string tenSV {  get; set; }
        public string tenMH { get; set; }
        public float diemThanhPhan { get; set; }
        public float diemThi { get; set;}
        public float diemTongKet { get; set; }
        public string xepLoai {  get; set; }
        public int maSV { get;set; }
        public string maMH { get; set; }
    }
}
