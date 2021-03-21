namespace _02.LegionSystem.Models
{
    using Interfaces;

    public class Enemy : IEnemy
    {
        public Enemy(int attackSpeed, int health)
        {
            this.AttackSpeed = attackSpeed;
            this.Health = health;
        }

        public int AttackSpeed { get; set; }

        public int Health { get; set; }

        public int CompareTo(object obj)
        {
            var otherEnemy = (IEnemy)obj;

            return this.AttackSpeed - otherEnemy.AttackSpeed;
        }

        public override bool Equals(object obj)
        {
            var otherEnemy = (IEnemy)obj;

            return this.AttackSpeed == otherEnemy.AttackSpeed;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
