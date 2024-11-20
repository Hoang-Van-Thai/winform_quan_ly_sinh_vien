using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDSV.View
{
    internal interface IView
    {
         void SetDataToText(Object item);
         void GetDataFromText();
    }
}
