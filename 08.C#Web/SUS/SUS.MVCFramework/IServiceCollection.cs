namespace SUS.MVCFramework
{
    using System;

    public interface IServiceCollection
    {
        void Add<TSource, TDestionation>();

        object CreateInstance(Type type);
    }
}
