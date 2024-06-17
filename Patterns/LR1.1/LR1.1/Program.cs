// А-08м-23 Белоус Виктор ЛР 1.1
// Номер по списку 9 => Вариант 1

// Используемые паттерны:
// 1) Abstract Factory  (по заданию)
// 2) Facade            (выбранный)

using System;
using System.IO;

namespace lab1_1
{
    // Определим общие интерфейсы двух Футбольных клубов
    public interface SpartakMoscow
    {
        int fcsmGoals();
        int fcsmPoints();
        int fcsmDerbi();
    }
    public interface Torpedo
    {
        int torGoals();
        int torPoints();
        int torDerbi();
    }
    // =======================================================

    // Кубок России - Спартак Москва
    public class cupFCSM : SpartakMoscow
    {
        public int fcsmGoals()
        {
            int goals = 15;
            return goals;
        }

        public int fcsmPoints()
        {
            int points = 12;
            return points;
        }

        public int fcsmDerbi()
        {
            int goal = 3;
            return goal;
        }
    }

    // Чемпионат России - Спартак Москва
    public class champFCSM : SpartakMoscow
    {
        public int fcsmGoals()
        {
            int goals = 37;
            return goals;
        }

        public int fcsmPoints()
        {
            int points = 31;
            return points;
        }

        public int fcsmDerbi()
        {
            int goal = 3;
            return goal;
        }
    }
    // =======================================================

    // Кубок России - Торпедо
    public class cupTOR : Torpedo
    {
        public int torGoals()
        {
            int goals = 7;
            return goals;
        }

        public int torPoints()
        {
            int points = 6;
            return points;
        }

        public int torDerbi()
        {
            int goal = 1;
            return goal;
        }
    }

    // Чемпионат России - Торпедо
    public class champTOR : Torpedo
    {
        public int torGoals()
        {
            int goals = 25;
            return goals;
        }

        public int torPoints()
        {
            int points = 22;
            return points;
        }
        public int torDerbi()
        {
            int goal = 1;
            return goal;
        }
    }
    // =======================================================

    interface AbstractFactory
    {
        SpartakMoscow getFCSM();
        Torpedo getTOR();
    }

    // =======================================================

    // Чемпионат России
    public class champFactory : AbstractFactory
    {
        public SpartakMoscow getFCSM()
        {
            return new champFCSM();
        }

        public Torpedo getTOR()
        {
            return new champTOR();
        }

       
    }

    // Кубок России
    public class cupFactory : AbstractFactory
    {
        public SpartakMoscow getFCSM()
        {
            return new cupFCSM();
        }

        public Torpedo getTOR()
        {
            return new cupTOR();
        }

    }
    // ===============================================================
    // Паттерн facade
    class Facade
    {
        private SpartakMoscow spartak;
        private Torpedo torpedo;
        public Facade()
        {
            spartak = new cupFCSM();
            torpedo = new cupTOR();
        }
        public void derbi()
        {
            Console.WriteLine("Спартак Москва {0} - {1} Торпедо", spartak.fcsmDerbi(), torpedo.torDerbi());
        }
    }

    // =============================================================
    // класс для логирования программы
    class Log
    {
        private static Log log;
        private Log() { }
        public static Log getLog()
        {
            if (log == null)
                log = new Log();
            return log;
        }
        public async void AddLog(string msg)
        {
            string path = "log.txt";
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                await writer.WriteLineAsync(DateTime.Now.ToString() + " " + msg);
            }
        }
    }
    // =============================================================

    // Основная программа
    internal class Program
    {
        static void Main(string[] args)
        {
            var logger = Log.getLog();
            logger.AddLog("program started. log created");
            bool Flag = true;
            AbstractFactory ifactory = null;

            while (Flag)
            {
                Console.WriteLine("Выберите турнир: ");
                Console.WriteLine("1 - Кубок России ");
                Console.WriteLine("2 - Чемпионат России ");
                var start = Console.ReadLine();
                
                if (start.Equals("1"))
                {
                    ifactory = new cupFactory();
                    logger.AddLog("cupFactory created");
                    Flag = false;
                    Console.Clear();
                    Console.WriteLine("Кубок России");
                }
                else if (start.Equals("2"))
                {
                    ifactory = new champFactory();
                    logger.AddLog("champFactory created");
                    Flag = false;
                    Console.Clear();
                    Console.WriteLine("Чемпионат России");
                }
                else
                {
                    Console.WriteLine("\nОшибка ввода\n");
                }
            }

            SpartakMoscow spartak = ifactory.getFCSM();
            logger.AddLog("Factory spartak created");
            Torpedo torpedo = ifactory.getTOR();
            logger.AddLog("Factory torpedo created");

            Flag = true;
            while (Flag)
            {
                Console.WriteLine("\nВыберите интересующую информацию: ");
                Console.WriteLine("1 - Количество голов ФК Спартак Москва в турнире ");
                Console.WriteLine("2 - Количество очков ФК Спартак Москва в турнире ");
                Console.WriteLine("3 - Количество голов ФК Торпедо Москва в турнире ");
                Console.WriteLine("4 - Количество очков ФК Торпедо Москва в турнире ");
                Console.WriteLine("5 - Результат дерби в финале Супер кубка");
                Console.WriteLine("6 - Завершить");

                var res = Console.ReadLine();       // выбранный пункт меню

                // удаление из консоли выбранного пункта для красивого отображения
                // ----------------------------------
                // Capture current cursor position
                var cursorTop = Console.CursorTop;
                var cursorLeft = Console.CursorLeft;

                // Clear the previous line (above the current position)
                Console.SetCursorPosition(0, cursorTop - 1);
                Console.Write(new string(' ', Console.BufferWidth));

                // Resume cusor at it's original position
                Console.SetCursorPosition(cursorLeft, cursorTop);
                // ----------------------------------

                switch (res)
                {
                    case "1":
                        Console.WriteLine("Количество голов ФК Спартак Москва в турнире: {0}", spartak.fcsmGoals().ToString());
                        logger.AddLog("method   <fcsmGoals>     called");
                        break;
                    case "2":
                        Console.WriteLine("Количество очков ФК Спартак Москва в турнире: {0}", spartak.fcsmPoints().ToString());
                        logger.AddLog("method   <fcsmPoints>    called");
                        break;
                    case "3":
                        Console.WriteLine("Количество голов ФК Торпедо Москва в турнире: {0}", torpedo.torGoals().ToString());
                        logger.AddLog("method   <torGoals>      called");
                        break;
                    case "4":
                        Console.WriteLine("Количество очков ФК Торпедо Москва в турнире: {0}", torpedo.torPoints().ToString());
                        logger.AddLog("method   <torPoints>     called");
                        break;
                    case "5":
                        Console.WriteLine("Результат дерби в финале Супер кубка России: ");                    
                        Facade facade = new Facade();
                        logger.AddLog("Facade class created");
                        facade.derbi();
                        logger.AddLog("method   <derbi>         called");
                        break;
                    case "6":
                        Console.WriteLine("Программа завершила выполнение. Нажмите ENTER...");
                        logger.AddLog("program finished\n");
                        Flag = false;
                        break;
                    default:
                        Console.WriteLine("\nОшибка ввода\n");
                        break;
                }
            }
            Console.ReadLine();
        }
    }
}