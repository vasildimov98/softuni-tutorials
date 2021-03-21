namespace _01.RoyaleArena.Interfaces
{
    using System;

    public interface ICard : IComparable<BattleCard>
    {
        int Id { get; }

        CardType Type { get; set; }

        string Name { get; set; }

        double Damage { get; set; }

        double Swag { get; set; }
    }
}
