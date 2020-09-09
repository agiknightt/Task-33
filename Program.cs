using System;

namespace Task_33
{
    class Program
    {
        static void Main(string[] args)
        {
            Fighters[] fighters = { new Fighters("Alex", 1000, 50, 15), new Fighters("Jora", 800, 90, 20), new Fighters("Gena", 500, 150, 10),
                                    new Fighters("Tolik", 1300, 30, 20), new Fighters("Artem", 2000, 25, 0)};
            int fighterId;

            for (int i = 0; i < fighters.Length; i++)
            {
                Console.Write(i + " ");
                fighters[i].ShowStats();
            }
            Console.Write("Введите номер первого бойца для боя : ");
            fighterId = Convert.ToInt32(Console.ReadLine());
            Fighters fighterOne = fighters[fighterId];
            
            Console.Write("Введите номер второго бойца для боя : ");
            fighterId = Convert.ToInt32(Console.ReadLine());
            Fighters fighterTwo = fighters[fighterId];

            while (fighterOne.Health > 0 && fighterTwo.Health > 0)
            {
                Console.WriteLine();
                fighterOne.TakeDamage(fighterTwo.Damage);
                fighterTwo.TakeDamage(fighterOne.Damage);

                fighterOne.ShowStats();
                fighterTwo.ShowStats();
            }
            Console.ReadKey();
        }
    }
    class Fighters
    {
        private string _name;
        private int _health;
        private int _damage;
        private int _armor;

        public Fighters(string name, int health, int damage, int armor)
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
    }
}
