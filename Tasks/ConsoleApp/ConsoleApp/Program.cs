using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var animals = new List<Animal>
            {
                new Cat("vasia"),
                new Cat("petya"),
                new Dog("vasia"),
                new Dog("petya"),
                new Bird("vasia"),
                new Bird("petya"),
                new Snake("petya"),
            };

            Cat cat = new Cat("cat");
            Animal cat2 = new Cat("cat2");

            cat2.Talk();

            foreach(var animal in animals.Where(x => x is IWalkable).Cast<IWalkable>())
            {
                animal.Walk();
            }
        }
    }

    public interface IWalkable
    {
        void Walk();
    }

    abstract class Animal
    {
        private string _name;

        public Animal(string name)
        {
            _name = name;
        }

        public abstract void Talk();
    }

    class Cat : Animal, IWalkable
    {
        public Cat(string name) : base(name)
        {

        }

        public override void Talk()
        {
            Console.WriteLine("May");
        }

        public void Walk()
        {
            Console.WriteLine("Кот ходит");
        }
    }

    class Dog : Animal, IWalkable
    {
        public Dog(string name) : base(name)
        {

        }

        public override void Talk()
        {
            Console.WriteLine("Gav");
        }

        public void Walk()
        {
            Console.WriteLine("Сабака ходит");
        }
    }


    class Bird : Animal, IWalkable
    {
        public Bird(string name) : base(name)
        {

        }

        public override void Talk()
        {
            Console.WriteLine("Krek");
        }

        public void Walk()
        {
            Console.WriteLine("Птичка ходит");
        }
    }

    class Snake : Animal
    {
        public Snake(string name) : base(name)
        {

        }

        public override void Talk()
        {
            Console.WriteLine("Krek");
        }
    }
}
