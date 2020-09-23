using System;

namespace Task_33
{
    class Program
    {
        static void Main(string[] args)
        {
            Fighter[] fighters = { new Warrior("Alex", 1000, 50, 15), new Knight("Jora", 800, 90, 20), new Rogue("Gena", 500, 150, 10),
                                   new Berserker("Tolik", 1300, 30, 20), new Damager("Artem", 2000, 25, 0)};            
            int fighterId;

            for (int i = 0; i < fighters.Length; i++)
            {
                Console.Write(i + " ");
                fighters[i].ShowStats();
            }
            Console.Write("Введите номер первого бойца для боя : ");
            fighterId = Convert.ToInt32(Console.ReadLine());
            Fighter fighterOne = fighters[fighterId];
            
            Console.Write("Введите номер второго бойца для боя : ");
            fighterId = Convert.ToInt32(Console.ReadLine());
            Fighter fighterTwo = fighters[fighterId];

            while (fighterOne.Health > 0 && fighterTwo.Health > 0)
            {
                Console.WriteLine();
                fighterOne.Skill();
                fighterTwo.Skill();

                fighterOne.TakeDamage(fighterTwo.Damage);                
                fighterTwo.TakeDamage(fighterOne.Damage);

                fighterOne.ShowStats();
                fighterTwo.ShowStats();
            }
            Console.ReadKey();
        }
    }
    abstract class Fighter
    {
        protected string _name;
        protected int _health;
        protected int _damage;
        protected int _armor;

        public Fighter(string name, int health, int damage, int armor)
        {
            _name = name;
            _health = health;
            _damage = damage;
            _armor = armor;
        }
        public int Health
        {
            get
            {
                return _health;
            }
        }
        public int Damage
        {
            get
            {
                return _damage;
            }
        }
        public void ShowStats()
        {
            Console.WriteLine($"Имя - {_name}, Жизней - {_health}, Урон - {_damage}, Защиты - {_armor}.");
        }
        public void TakeDamage(int damage)
        {
            _health -= damage - _armor;
        }
        public abstract void Skill();
    }

    class Warrior : Fighter
    {
        public Warrior(string name, int health, int damage, int armor) : base(name, health, damage, armor)
        {
            _name = name;
            _health = health;
            _damage = damage;
            _armor = armor;
        }
        public override void Skill()
        {
            _health += _damage;
        }
    }
    class Knight : Fighter
    {
        public Knight(string name, int health, int damage, int armor) : base(name, health, damage, armor)
        {
            _name = name;
            _health = health;
            _damage = damage;
            _armor = armor;
        }
        public override void Skill()
        {
            _armor += 3;
        }
    }
    class Rogue : Fighter
    {
        public Rogue(string name, int health, int damage, int armor) : base(name, health, damage, armor)
        {
            _name = name;
            _health = health;
            _damage = damage;
            _armor = armor;
        }
        public override void Skill()
        {
            _damage += 5;
        }
    }
    class Berserker : Fighter
    {
        private int _step = 0;
        public Berserker(string name, int health, int damage, int armor) : base(name, health, damage, armor)
        {
            _name = name;
            _health = health;
            _damage = damage;
            _armor = armor;
        }
        public override void Skill()
        {
            _step += 1;

            if(_step % 2 == 0)
            {
                _damage += 100;
            }
            if(_step % 3 == 0)
            {
                _damage -= 100;
            }
        }
    }
    class Damager : Fighter
    {
        private int _step = 0;
        public Damager(string name, int health, int damage, int armor) : base(name, health, damage, armor)
        {
            _name = name;
            _health = health;
            _damage = damage;
            _armor = armor;
        }
        public override void Skill()
        {
            if (_step % 3 == 0)
            {
                _health += 50;
            }
        }
    }
}
