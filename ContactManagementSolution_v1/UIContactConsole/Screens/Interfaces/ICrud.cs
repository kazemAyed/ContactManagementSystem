using BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIContactConsole.Screens.Delegates;

namespace UIContactConsole.Screens.Interfaces
{
    public interface ICrud<T>
    {
        T GetEntity(int id);
        T GetEntity(string name);

        void Add(AddDel addEntity);
        void Update(UpdateDel updateDel);
        void Delete(Func<int, bool> FuncDeletionEntityType);

        void GetAll();
    }

}
