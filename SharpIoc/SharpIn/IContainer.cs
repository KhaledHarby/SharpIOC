using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharp
{
    public interface IContainer
    {
        void Register<TImplementer, TConcrete>();
        void Register<TImplementer, TConcrete>(LifeCycle lifeCycle);
        TImplementer Resolve<TImplementer>();
        object Resolve(Type typeToResolve);

        bool IsRegistered(Type type);
        bool IsRegistered(Type type , LifeCycle lifeCycle);

        bool IsRegistered<T>();
        bool IsRegistered<T>(LifeCycle lifeCycle);

        bool IsRegistered<TImplementor, TConcrete>();
        bool IsRegistered<TImplementor, TConcrete>(LifeCycle lifeCycle);
    }
}
