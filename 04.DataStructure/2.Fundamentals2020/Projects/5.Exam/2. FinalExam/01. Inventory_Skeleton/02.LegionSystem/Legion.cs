namespace _02.LegionSystem
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Wintellect.PowerCollections;

    using Interfaces;

    public class Legion : IArmy
    {
        private readonly OrderedSet<IEnemy> enemies;

        public Legion()
        {
            this.enemies = new OrderedSet<IEnemy>();
        }

        public int Size => this.enemies.Count;

        public void Create(IEnemy enemy)
            => this.enemies.Add(enemy);

        public IEnemy GetByAttackSpeed(int speed)
        {
            for (int i = 0; i < this.Size; i++)
            {
                var curr = this.enemies[i];

                if (curr.AttackSpeed == speed)
                {
                    return curr;
                }
            }

            return null;
        }

        public bool Contains(IEnemy enemy)
            => this.enemies.Contains(enemy);
        
        public IEnemy GetFastest()
        {
            this.ValidateIfEmpty();

            return this.enemies.GetLast();
        }

        public IEnemy GetSlowest()
        {
            this.ValidateIfEmpty();

            return this.enemies.GetFirst();
        }

        public void ShootFastest()
        {
            this.ValidateIfEmpty();

            this.enemies.RemoveLast();
        }

        public void ShootSlowest()
        {
            this.ValidateIfEmpty();

            this.enemies.RemoveFirst();
        }

        public IEnemy[] GetOrderedByHealth()
        {
            var arr = this.enemies.ToArray();

            Array.Sort(arr, this.Comparer);

            return arr;
        }

        public List<IEnemy> GetFaster(int speed)
        {
            var enemiesFasterThanSpecifiedSpeed = new List<IEnemy>();

            for (int i = this.Size - 1; i >= 0; i--)
            {
                var curr = this.enemies[i];

                if (curr.AttackSpeed > speed)
                {
                    enemiesFasterThanSpecifiedSpeed.Add(curr);
                }
                else
                {
                    break;
                }
            }

            return enemiesFasterThanSpecifiedSpeed;
        }

        public List<IEnemy> GetSlower(int speed)
        {
            var enemiesFasterThanSpecifiedSpeed = new List<IEnemy>();

            for (int i = 0; i < this.Size; i++)
            {
                var curr = this.enemies[i];

                if (curr.AttackSpeed < speed)
                {
                    enemiesFasterThanSpecifiedSpeed.Add(curr);
                } 
                else
                {
                    break;
                }
            }

            return enemiesFasterThanSpecifiedSpeed;
        }

        private int Comparer(IEnemy a, IEnemy b)
        {
            return b.Health - a.Health;
        }

        private void ValidateIfEmpty()
        {
            if (this.Size == 0)
            {
                throw new InvalidOperationException("Legion has no enemies!");
            }
        }
    }
}
