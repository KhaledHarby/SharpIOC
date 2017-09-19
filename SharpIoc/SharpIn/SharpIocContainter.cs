using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharp
{
    public class SharpIocContainter : IContainer
    {
        private readonly RegisteredComponents registeredComponent;



        public SharpIocContainter()
        {
            registeredComponent = RegisteredComponents.getInstance();
        }



        public void Register<TImplementer, TConcrete>()
        {
            registeredComponent.Register<TImplementer, TConcrete>(LifeCycle.Singleton);
        }

        public void Register<TImplementer, TConcrete>(LifeCycle lifeCycle)
        {
            registeredComponent.Register<TImplementer, TConcrete>(lifeCycle);
        }

        public TImplementer Resolve<TImplementer>()
        {
            return (TImplementer)registeredComponent.ResolveObject(typeof(TImplementer));
        }

        public object Resolve(Type typeToResolve)
        {
            return registeredComponent.ResolveObject(typeToResolve);

        }

        private object ResolveObject(Type typeToResolve)
        {
            return registeredComponent.ResolveObject(typeToResolve);
        }

        private object GetInstance(RegisteredObject registeredObject)
        {
            return registeredComponent.GetInstance(registeredObject);
        }

        private IEnumerable<object> ResolveConstructorParameters(RegisteredObject registeredObject)
        {
            return registeredComponent.ResolveConstructorParameters(registeredObject);
        }

        public bool IsRegistered(Type type)
        {
            return registeredComponent.IsRegistered(type);
        }

        public bool IsRegistered<T>()
        {
            return registeredComponent.IsRegistered(typeof(T));
        }

        public bool IsRegistered(Type type, LifeCycle lifeCycle)
        {
            return registeredComponent.IsRegistered(type, lifeCycle);
        }

        public bool IsRegistered<T>(LifeCycle lifeCycle)
        {
            return registeredComponent.IsRegistered(typeof(T), lifeCycle);
        }

        public bool IsRegistered<TImplementor, TConcrete>()
        {
            return registeredComponent.IsRegistered<TImplementor, TConcrete>();
        }

        public bool IsRegistered<TImplementor, TConcrete>(LifeCycle lifeCycle)
        {
            return registeredComponent.IsRegistered<TImplementor, TConcrete>(lifeCycle);
        }
    }
}
