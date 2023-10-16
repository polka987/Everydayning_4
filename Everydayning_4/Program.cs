using System.Net;

namespace Everydayning_4
{
    class Program
    {
        static int Day = DateTime.Now.Day;
        static List<zametka> us = new List<zametka>();
        static List<zametka> list = new List<zametka>()
        {
            new zametka("Заметка1","Описание1", DateTime.Now.ToShortDateString()),
            new zametka("Заметка1","Описание1", new DateTime(2023,10,1).ToShortDateString()),
            new zametka("Заметка1","Описание1", new DateTime(2023,10,10).ToShortDateString())
        };
        private static void Main(string[] args)
        {
            get_date(DateTime.Now.ToShortDateString());
            set_pointer(us.Count, 1);
        }
        static void read_zametka(int position)
        {
            ConsoleKeyInfo key;
            do
            {
                Console.Clear();
                Console.WriteLine("Название заметки: {0}", us[position - 1].Name);
                Console.WriteLine("---------------------------------------------");
                Console.WriteLine("Описание: {0}", us[position - 1].Description);
                Console.WriteLine("Escape - Выйти обратно");
                key = Console.ReadKey(true);
            } while (key.Key != ConsoleKey.Escape);
            get_date(new DateTime(2023, 10, Day).ToShortDateString());
        }
        static void get_date(string date)
        {
            Console.Clear();
            Console.WriteLine($"Планы на {date}");
            us.Clear();
            foreach (var item in list)
            {
                if (item.Date == date)
                {
                    Console.WriteLine($" {item.Name}");
                    us.Add(item);
                }
            }
        }
        static void set_pointer(int count, int start = 1)
        {
            ConsoleKeyInfo point;
            int pos = start;
            Console.SetCursorPosition(0, pos);
            Console.Write('>');
            do
            {
                point = Console.ReadKey(true);
                Console.SetCursorPosition(0, pos);
                Console.Write(' ');
                if (count != 0)
                {
                    if (point.Key == ConsoleKey.UpArrow)
                    {
                        pos--;
                        if (pos == start - 1) pos = count;
                    }
                    else if (point.Key == ConsoleKey.DownArrow)
                    {
                        pos++;
                        if (pos > count) pos = 1;
                    }
                }
                if (point.Key == ConsoleKey.LeftArrow)
                {
                    Day--;
                    if (Day == 0) Day = 31;
                    get_date(new DateTime(2023, 10, Day).ToShortDateString());
                }
                if (point.Key == ConsoleKey.RightArrow)
                {
                    Day++;
                    if (Day == 32) Day = 1;
                    get_date(new DateTime(2023, 10, Day).ToShortDateString());
                }

                Console.SetCursorPosition(0, pos);
                Console.Write('>');
            } while (point.Key != ConsoleKey.Enter && point.Key != ConsoleKey.Add);
            if (point.Key == ConsoleKey.Enter && us.Count > 0)
            {
                read_zametka(pos);
                set_pointer(us.Count, 1);
            }
            else if (point.Key == ConsoleKey.Add)
                add_zametka();
            else
            {
                set_pointer(count, start);
            }
        }
        static void add_zametka()
        {
            zametka new_zam = new zametka();
            Console.Clear();
            Console.WriteLine("Введите название заметки: ");
            new_zam.Name = Console.ReadLine();
            Console.WriteLine("Введите описание заметки: ");
            new_zam.Description = Console.ReadLine();
            new_zam.Date = new DateTime(2023, 10, Day).ToShortDateString();
            list.Add(new_zam);
            get_date(new DateTime(2023, 10, Day).ToShortDateString());
            set_pointer(us.Count, 1);
        }
    }
    class zametka
    {
        public string Name;
        public string Description;
        public string Date;
        public zametka() { }
        public zametka(string name, string description, string date)
        {
            Name = name;
            Description = description;
            Date = date;
        }
    }
}