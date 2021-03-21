namespace _02.LegionSystem.Interfaces
{
    using System;

    public interface IEnemy : IComparable
    {
        int AttackSpeed { get; set; }

        int Health { get; set; }
    }
}
