namespace SUS.MVCFramework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ServiceCollection : IServiceCollection
    {
        private Dictionary<Type, Type> dependencyContainer
            = new Dictionary<Type, Type>();

        public void Add<TSource, TDestionation>()
        {
            this.dependencyContainer[typeof(TSource)] = typeof(TDestionation);
        }

        public object CreateInstance(Type type)
        {
            if (this.dependencyContainer.ContainsKey(type))
                type = dependencyContainer[type];

            var contructor = type.GetConstructors()
                .OrderBy(x => x.GetParameters().Count())
                .FirstOrDefault();

            var parameters = contructor.GetParameters();

            var instances = new List<object>();
            foreach (var parameter in parameters)
            {
                var returnInstance = CreateInstance(parameter.ParameterType);
                instances.Add(returnInstance);
            }

            var instanceOutput = contructor.Invoke(instances.ToArray());

            return instanceOutput;
        }
    }
}
