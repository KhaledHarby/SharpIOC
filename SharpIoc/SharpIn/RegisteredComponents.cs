using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharp
{
    internal class RegisteredComponents
    {
        private readonly IList<RegisteredObject> registeredObjects = new List<RegisteredObject>();

        private static RegisteredComponents _registeredComponents;
        private static object locker = new object();

        private RegisteredComponents()
        {
            registeredObjects = new List<RegisteredObject>();
        }


        protected internal object ResolveObject(Type typeToResolve)
        {
            var registeredObject = registeredObjects.FirstOrDefault(o => o.TypeToResolve == typeToResolve);
            if (registeredObject == null)
            {
                throw new TypeNotRegisteredException(string.Format(
                    "The type {0} has not been registered", typeToResolve.Name));
            }
            return GetInstance(registeredObject);
        }

        protected internal object GetInstance(RegisteredObject registeredObject)
        {
            if (registeredObject.Instance == null ||
                registeredObject.LifeCycle == LifeCycle.Transient)
            {
                var parameters = ResolveConstructorParameters(registeredObject);
                registeredObject.CreateInstance(parameters.ToArray());
            }
            return registeredObject.Instance;
        }


        protected internal IEnumerable<object> ResolveConstructorParameters(RegisteredObject registeredObject)
        {
            var constructorInfo = registeredObject.ConcreteType.GetConstructors().First();
            foreach (var parameter in constructorInfo.GetParameters())
            {
                yield return ResolveObject(parameter.ParameterType);
            }
        }

        protected internal void Register<TImplementer, TConcrete>()
        {
            Register<TImplementer, TConcrete>(LifeCycle.Singleton);
        }

        protected internal void Register<TImplementer, TConcrete>(LifeCycle lifeCycle)
        {
            registeredObjects.Add(new RegisteredObject(typeof(TImplementer), typeof(TConcrete), lifeCycle));
        }

        protected internal static RegisteredComponents getInstance()
        {
            lock (locker)
            {
                if (_registeredComponents == null)
                    _registeredComponents = new RegisteredComponents();


                return _registeredComponents;
            }
        }


        protected internal bool IsRegistered(Type type)
        {
            var registeredObject = registeredObjects.FirstOrDefault(o => o.TypeToResolve == type);
            return registeredObject == null ? false : true;
        }

        protected internal bool IsRegistered<T>(LifeCycle lifeCycle)
        {
            return IsRegistered(typeof(T), lifeCycle);
        }

        protected internal bool IsRegistered<TImplementor, TConcrete>()
        {
            var registeredObject = registeredObjects.FirstOrDefault(o => o.TypeToResolve == typeof(TImplementor) && o.ConcreteType == typeof(TConcrete));
            return registeredObject == null ? false : true;
        }

        protected internal bool IsRegistered<TImplementor, TConcrete>(LifeCycle lifeCycle)
        {
            var registeredObject = registeredObjects.FirstOrDefault(o => o.TypeToResolve == typeof(TImplementor) && o.ConcreteType == typeof(TConcrete) && o.LifeCycle == lifeCycle);
            return registeredObject == null ? false : true;
        }

        protected internal bool IsRegistered(Type type, LifeCycle lifeCycle)
        {
            var registeredObject = registeredObjects.FirstOrDefault(o => o.TypeToResolve == type && o.LifeCycle == lifeCycle);
            return registeredObject == null ? false : true;
        }
    }
}
