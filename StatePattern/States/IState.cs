using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern
{
    public interface IState<T>
    {
        void Enter(T entity);
        void Execute();
        void Exit();
    }
}