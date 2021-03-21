using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.DogVet
{
    public class DogVet : IDogVet
    {
        private readonly Dictionary<string, Dog> dogsById;
        private readonly Dictionary<string, Dictionary<string, Dog>> ownerWithPets;

        public DogVet()
        {
            this.dogsById = new Dictionary<string, Dog>();
            this.ownerWithPets = new Dictionary<string, Dictionary<string, Dog>>();
        }

        public int Size => this.dogsById.Count;

        public void AddDog(Dog dog, Owner owner)
        {
            var dogId = dog.Id;
            var dogName = dog.Name;
            var ownerId = owner.Id;

            if (this.Contains(dog))
                throw new ArgumentException();

            this.dogsById[dogId] = dog;

            if (!this.ownerWithPets.ContainsKey(ownerId))
            {
                this.ownerWithPets[ownerId] = new Dictionary<string, Dog>();
            }

            if (this.ownerWithPets[ownerId].ContainsKey(dogName))
                throw new ArgumentException();

            this.ownerWithPets[ownerId][dogName] = dog;
            dog.Owner = owner;
        }

        public bool Contains(Dog dog)
            => this.dogsById.ContainsKey(dog.Id);

        public Dog GetDog(string name, string ownerId)
        {
            if (!this.ownerWithPets.ContainsKey(ownerId)
                || !this.ownerWithPets[ownerId].ContainsKey(name))
                throw new ArgumentException();

            return this.ownerWithPets[ownerId][name];
        }

        public Dog RemoveDog(string name, string ownerId)
        {
            if (!this.ownerWithPets.ContainsKey(ownerId)
               || !this.ownerWithPets[ownerId].ContainsKey(name))
                throw new ArgumentException();

            var dog = this.ownerWithPets[ownerId][name];

            this.dogsById.Remove(dog.Id);
            this.ownerWithPets[ownerId].Remove(dog.Name);
            dog.Owner = null;

            return dog;
        }

        public IEnumerable<Dog> GetDogsByOwner(string ownerId)
        {
            if (!this.ownerWithPets.ContainsKey(ownerId))
                throw new ArgumentException();

            return this.ownerWithPets[ownerId].Values;
        }

        public IEnumerable<Dog> GetDogsByBreed(Breed breed)
        {
            var dogsByBreed = this.dogsById
                .Values
                .Where(d => d.Breed == breed);

            if (dogsByBreed.Count() == 0)
                throw new ArgumentException();

            return dogsByBreed;
        }

        public void Vaccinate(string name, string ownerId)
        {
            if (!this.ownerWithPets.ContainsKey(ownerId)
              || !this.ownerWithPets[ownerId].ContainsKey(name))
                throw new ArgumentException();

            this.ownerWithPets[ownerId][name].Vaccines++; 
        }

        public void Rename(string oldName, string newName, string ownerId)
        {
            if (!this.ownerWithPets.ContainsKey(ownerId)
              || !this.ownerWithPets[ownerId].ContainsKey(oldName))
                throw new ArgumentException();

            var dog = this.ownerWithPets[ownerId][oldName];
            this.ownerWithPets[ownerId].Remove(oldName);
            dog.Name = newName;
            this.ownerWithPets[ownerId][newName] = dog;
        }

        public IEnumerable<Dog> GetAllDogsByAge(int age)
        {
            var dogsByAge = this.dogsById
               .Values
               .Where(d => d.Age == age);

            if (dogsByAge.Count() == 0)
                throw new ArgumentException();

            return dogsByAge;
        }

        public IEnumerable<Dog> GetDogsInAgeRange(int lo, int hi)
            => this.dogsById
               .Values
               .Where(d => lo <= d.Age && d.Age <= hi);

        public IEnumerable<Dog> GetAllOrderedByAgeThenByNameThenByOwnerNameAscending()
            => this.dogsById
            .Values
            .OrderBy(d => d.Age)
            .ThenBy(d => d.Name)
            .ThenBy(d => d.Owner.Name);
    }
}