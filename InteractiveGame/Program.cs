using System;
using System.Collections.Generic;
// Суть игры будет заключаться во взаимодействии со внешним виртуальным ограниченным миром
// Нужно осуществить взаимодействие игрока с инвентарём и со внешним миром
// Игра будет пошаговой, то есть игрок может делать какие-то действия и каждое действие будет считаться ходом,
// - или какоето колличество действий будут считаться за 1 ход(нужно придумать)
// Осуществить взаимодействие с предметами: поднять из внешнего мира, положить в инвентарь, использовать, выкинуть и тд.
// Добавить в игру ПРЕДМЕТЫ которыми можно будет наносить урон, бить или стрелять, перезаряжать, выкидывать и взрывать и тд.
// 
//
//
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//
//
// Создать конкретный план разработки игры..
//
//
//
//===========================================================================================================================
//
//
//
/* План разработки игры:
 * 
 * 1. Первый шаг      -      создание ИНВЕНТАРЯ 
 * 2. Второй шаг      -      создание инвентаря ВНЕШНЕГО мира
 * 3. Третий шаг      -      обеспечить взаимодействие между ними
 * 4. Четвертый шаг   -      добавить ПРЕДМЕТЫ
 * 5. Пятый шаг       -      добавить взаимодействие с предметами
 * 6. Шестой шаг      -      реализовать очистку выброшеных вещей во внешний мир
 * ...
*/ 
namespace InteractiveGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int StartCapaciti = 4;
            InventoriMy Inventori = new InventoriMy(StartCapaciti);
            Inventori.Add(1, new Knife());
            Inventori.Add(4, new Pistol());
            Inventori.ShowInventoryContent();
            Console.WriteLine();
            Inventori.InventoryExtension(1);
            Inventori.ShowInventoryContent();
            Console.WriteLine();
            Inventori.InventoryExtension(1);
            Inventori.ShowInventoryContent();
            Console.WriteLine();
            Console.WriteLine("Будущая игра находится на этапе мозгования)))");
        }
    }
    abstract class Item
    {
        public abstract bool CanDamage { get; }
        public abstract bool CanHelp { get; }
    }
    abstract class Weapon: Item
    {
        public override bool CanDamage { get { return true; } }
        public override bool CanHelp => true;
        public abstract int Damage { get; }
        public abstract void Fire();
        public void Showinfo()
        {
            Console.WriteLine("{0} урон {1}", GetType().Name, Damage);
        }
    }
    class Pistol : Weapon
    {
        public override int Damage => 10;

        public override void Fire()
        {
            Console.WriteLine("Стреляю из объекта - {0}", GetType().Name);   
        }
    }
    class Knife : Weapon
    {
        public override int Damage => 7;

        public override void Fire()
        {
            Console.WriteLine("Ударил объектом - {0}", GetType().Name);
        }
    }
    class Book : Item
    {
        public override bool CanDamage => false;
        public override bool CanHelp => false;
    }
    class InventoryWorld
    {
        public List<Item> WorldInventory = new List<Item>() { new Book(), new Knife(), new Pistol()};
        public void Add(int position, Item item)
        {
            position = WorldInventory.Count;
            
        }
    }
    class InventoriMy
    {
        public InventoriMy(int capacity)
        {
            while (capacity > 0)
            {
                MyInventori.Add(null);
                capacity--;
            }
            Console.WriteLine("Создан пустой инвентарь на {0} слота", MyInventori.Count);
        }
        public List<Item> MyInventori = new List<Item>();

        public void Add(int position, Item item)
        {
            position--;
            MyInventori[position] = item;
        }
        public void ShowInventoryContent()
        {
            string Print = "      ";
            string Sep = "";
            foreach (var item in MyInventori)
            {
                if (item is null) Print += "|  Пусто  |      ";
                else Print += ("|  " + item.GetType().Name + "  |      ");
            }
            Sep = Sep.PadLeft(Print.Length, '=');

            Console.WriteLine(Sep + "\n" + Print + "\n" + Sep);
        }
        public void InventoryExtension(int quantity)
        {
            while (quantity > 0)
            {
                MyInventori.Add(null);
                quantity--;
            }
        }
    }
}
