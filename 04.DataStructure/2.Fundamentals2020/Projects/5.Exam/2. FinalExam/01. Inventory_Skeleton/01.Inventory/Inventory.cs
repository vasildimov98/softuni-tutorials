namespace _01.Inventory
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    using Models;
    using Interfaces;

    public class Inventory : IHolder
    {
        private readonly List<IWeapon> weapons;

        public Inventory()
        {
            this.weapons = new List<IWeapon>();
        }

        public int Capacity => this.weapons.Count;

        public void Add(IWeapon weapon)
            => this.weapons.Add(weapon);

        public IWeapon GetById(int id)
        {
            foreach (var weapon in this.weapons)
            {
                if (weapon.Id == id)
                {
                    return weapon;
                }
            }

            return null;
        }

        public bool Contains(IWeapon weapon)
            => this.GetById(weapon.Id) != null;

        public int Refill(IWeapon weapon, int ammunition)
        {
            this.ValidateWeaponExists(weapon);

            if (weapon.Ammunition + ammunition >= weapon.MaxCapacity)
            {
                weapon.Ammunition = weapon.MaxCapacity;
            }
            else
            {
                weapon.Ammunition += ammunition;
            }

            return weapon.Ammunition;
        }

        public bool Fire(IWeapon weapon, int ammunition)
        {
            this.ValidateWeaponExists(weapon);

            if (weapon.Ammunition < ammunition)
            {
                return false;
            }

            weapon.Ammunition -= ammunition;

            return true;
        }

        public IWeapon RemoveById(int id)
        {
            this.ValidateId(id);

            var weapon = this.GetById(id);
            this.weapons.RemoveAt(id);

            return weapon;
        }

        public void Clear()
        {
            this.weapons.Clear();
        }

        public List<IWeapon> RetrieveAll()
        {
            if (this.Capacity == 0)
            {
                return new List<IWeapon>();
            }

            return new List<IWeapon>(this.weapons);
        }

        public void Swap(IWeapon firstWeapon, IWeapon secondWeapon)
        {
            this.ValidateWeaponExists(firstWeapon);
            this.ValidateWeaponExists(secondWeapon);

            if (firstWeapon.Category == secondWeapon.Category)
            {
                var firstIndex = this.weapons.IndexOf(firstWeapon);
                var secondIndex = this.weapons.IndexOf(secondWeapon);
                this.Swap(firstIndex, secondIndex);
            }
        }

        public List<IWeapon> RetriveInRange(Category lower, Category upper)
        {
            var lowerInt = (int)lower;
            var upperInt = (int)upper;

            var weaponsInRange = new List<IWeapon>();

            for (int i = 0; i < this.Capacity; i++)
            {
                var curr = this.weapons[i];

                if ((int)curr.Category >= lowerInt && upperInt >= (int)curr.Category)
                {
                    weaponsInRange.Add(curr);
                }
            }

            return weaponsInRange;
        }

        public void EmptyArsenal(Category category)
        {
            for (int i = 0; i < this.Capacity; i++)
            {
                var curr = this.weapons[i];

                if (curr.Category == category)
                {
                    curr.Ammunition = 0;
                }
            }
        }

        public int RemoveHeavy()
            => this.weapons.RemoveAll(w => w.Category == Category.Heavy);

        public IEnumerator GetEnumerator()
            => this.weapons.GetEnumerator();

        private void ValidateId(int id)
        {
            if (id < 0 || id >= this.Capacity)
            {
                throw new InvalidOperationException("Weapon does not exist in inventory!");
            }
        }

        private void ValidateWeaponExists(IWeapon weapon)
        {
            if (!this.Contains(weapon))
            {
                throw new InvalidOperationException("Weapon does not exist in inventory!");
            }
        }

        private void Swap(int firstIndex, int secondIdex)
        {
            var temp = this.weapons[firstIndex];
            this.weapons[firstIndex] = this.weapons[secondIdex];
            this.weapons[secondIdex] = temp;
        }
    }
}
