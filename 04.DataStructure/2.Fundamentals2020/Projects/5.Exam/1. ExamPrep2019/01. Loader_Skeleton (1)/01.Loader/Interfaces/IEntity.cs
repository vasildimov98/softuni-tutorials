namespace _01.Loader.Interfaces
{
    using System;
    using System.Collections.Generic;

    using Models;

    public interface IEntity : IComparable
    {
        int Id { get; set; }

        int? ParentId { get; set; }

        BaseEntityStatus Status { get; set; }

        List<IEntity> Children { get; }

        void AddChild(IEntity child);
    }
}
