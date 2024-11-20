using QLDSV.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDSV.Controller
{
    internal interface IController
    {
        List<IModel> Items { get; }
         bool Add(IModel model);
         bool Update(IModel model);
         bool Delete(Object id);
         IModel Read(object id);
         bool Load();
         bool Load(Object id);
         bool IsExist(Object id);
         bool IsExist(IModel model);
    }
}
