using System;
using System.IO;

namespace Modeling
{
    // класс для логирования программы
    public class Log
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


    // Определение интерфейсов
    // =============================================================
    // Способности танка
    interface ITank
    {
        void Shoot();
    }
    // Исследование танка (для 1 - 4 уровня)
    interface IExplore
    {
        int ExploreTank();
    }
    // Покупка танка (для 2 - 4 уровня)
    interface IBuy
    {
        int BuyTank();
    }
    // Броня - характеристика тяжелого танка
    interface IArmor
    {
        void InstallArmor();
    }
    // Поддержка - характеристика среднего танка
    interface ISupport
    {
        void InstallSupportEquipment();
    }
    // Засвет - характеристика легкого танка
    interface ILightUp
    {
        void InstallOptics();
    }
    // =============================================================

    // Уровень 1
    // =============================================================
    public class BT7 : IExplore, ITank
    {
        public string TankName;
        public int TankDamage;

        public BT7(string name, int damage) 
        {
            TankName = name;
            TankDamage = damage;
        }

        public virtual int ExploreTank()
        {
            var logger = Log.getLog();
            logger.AddLog(TankName + " is explored");
            return 0;
        }

        public void Shoot()
        {
            var logger = Log.getLog();
            logger.AddLog(TankName + " damage = " + TankDamage);
        }
    }
    // =============================================================

    // Уровень 2
    // =============================================================
    public class KV1 : BT7, IBuy, IArmor
    {
        public int TankExperience;
        public int TankPrice;
        public int TankArmor;
        public KV1(string name, int damage, int experience, int price, int armor) : base(name, damage)
        {
            TankName = name;
            TankDamage = damage;
            TankExperience = experience;
            TankPrice = price;
            TankArmor = armor;
        }

        public override int ExploreTank() 
        {
            var logger = Log.getLog();
            logger.AddLog(TankName + " is explored for " + TankExperience + " experience points");
            return TankExperience;
        }

        public int BuyTank()
        {
            var logger = Log.getLog();
            logger.AddLog(TankName + " is bought for " + TankPrice + " RUB");
            return TankPrice;
        }

        public void InstallArmor()
        {
            var logger = Log.getLog();
            logger.AddLog("Armor installed on " + TankName + ". TankArmor = " + TankArmor);
        }
    }


    public class T34 : BT7, IBuy, ISupport
    {
        public int TankExperience;
        public int TankPrice;
        public int TankSupport;
        public T34(string name, int damage, int experience, int price, int support) : base(name, damage)
        {
            TankName = name;
            TankDamage = damage;
            TankExperience = experience;
            TankPrice = price;
            TankSupport = support;
        }

        public override int ExploreTank()
        {
            var logger = Log.getLog();
            logger.AddLog(TankName + " is explored for " + TankExperience + " experience points");
            return TankExperience;
        }

        public int BuyTank()
        {
            var logger = Log.getLog();
            logger.AddLog(TankName + " is bought for " + TankPrice + " RUB");
            return TankPrice;
        }

        public void InstallSupportEquipment()
        {
            var logger = Log.getLog();
            logger.AddLog("Support equipment installed on " + TankName + ". TankSupport = " + TankSupport);
        }
    }

    public class A20 : BT7, IBuy, ILightUp
    {
        public int TankExperience;
        public int TankPrice;
        public int TankLightUp;
        public A20(string name, int damage, int experience, int price, int light_up) : base(name, damage)
        {
            TankName = name;
            TankDamage = damage;
            TankExperience = experience;
            TankPrice = price;
            TankLightUp = light_up;
        }

        public override int ExploreTank()
        {
            var logger = Log.getLog();
            logger.AddLog(TankName + " is explored for " + TankExperience + " experience points");
            return TankExperience;
        }

        public int BuyTank()
        {
            var logger = Log.getLog();
            logger.AddLog(TankName + " is bought for " + TankPrice + " RUB");
            return TankPrice;
        }

        public void InstallOptics()
        {
            var logger = Log.getLog();
            logger.AddLog("Optics installed on " + TankName + ". TankLightUp = " + TankLightUp);
        }
    }
    // =============================================================

    // Уровень 3
    // =============================================================
    public class KV1S : KV1
    {
        public KV1S(string name, int damage, int experience, int price, int armor) : base(name, damage, experience, price, armor)
        {
            TankName = name;
            TankDamage = damage;
            TankExperience = experience;
            TankPrice = price;
            TankArmor = armor;
        }

        public int MakePowerfulShot()
        {
            var logger = Log.getLog();
            logger.AddLog(TankName + " made powerful shot");
            return TankDamage * 2;
        }
    }

    public class KV2 : KV1
    {
        public KV2(string name, int damage, int experience, int price, int armor) : base(name, damage, experience, price, armor)
        {
            TankName = name;
            TankDamage = damage;
            TankExperience = experience;
            TankPrice = price;
            TankArmor = armor;
        }

        public int MakePowerfulShot()
        {
            var logger = Log.getLog();
            logger.AddLog(TankName + " made powerful shot");
            return TankDamage * 3;
        }

        public string GetCollect()
        {
            var logger = Log.getLog();
            logger.AddLog(TankName + " GetCollect");
            return "This is a unique collectible tank!";
        }
    }

    public class T3485 : T34
    {
        public T3485(string name, int damage, int experience, int price, int support) : base(name, damage, experience, price, support)
        {
            TankName = name;
            TankDamage = damage;
            TankExperience = experience;
            TankPrice = price;
            TankSupport = support;
        }

        public int MakeSupportShot()
        {
            var logger = Log.getLog();
            logger.AddLog(TankName + " made support shot");
            return TankDamage + 20;
        }
    }

    public class T43 : T34
    {
        public T43(string name, int damage, int experience, int price, int support) : base(name, damage, experience, price, support)
        {
            TankName = name;
            TankDamage = damage;
            TankExperience = experience;
            TankPrice = price;
            TankSupport = support;
        }

        public int MakeSupportShot()
        {
            var logger = Log.getLog();
            logger.AddLog(TankName + " made support shot");
            return TankDamage + 30;
        }
    }

    public class MT25 : A20
    {
        public MT25(string name, int damage, int experience, int price, int light_up) : base(name, damage, experience, price, light_up)
        {
            TankName = name;
            TankDamage = damage;
            TankExperience = experience;
            TankPrice = price;
            TankLightUp = light_up;
        }

        public int MakeLightUpShot()
        {
            var logger = Log.getLog();
            logger.AddLog(TankName + " made light up shot");
            return TankDamage - 20;
        }
    }

    // =============================================================

    // Уровень 4
    // =============================================================
    public class KV3 : KV1S
    {
        public KV3(string name, int damage, int experience, int price, int armor) : base(name, damage, experience, price, armor)
        {
            TankName = name;
            TankDamage = damage;
            TankExperience = experience;
            TankPrice = price;
            TankArmor = armor;
        }

        public int MakePowerfulShot(int chance)
        {
            var logger = Log.getLog();
            logger.AddLog(TankName + " made powerful shot");
            return TankDamage * (2 + chance);
        }
    }

    public class IS : KV1S
    {
        public IS(string name, int damage, int experience, int price, int armor) : base(name, damage, experience, price, armor)
        {
            TankName = name;
            TankDamage = damage;
            TankExperience = experience;
            TankPrice = price;
            TankArmor = armor;
        }

        public int MakePowerfulShot(int chance1, int chance2)
        {
            var logger = Log.getLog();
            logger.AddLog(TankName + " made powerful shot");
            return TankDamage * (2 + chance1 - chance2);
        }
    }

    public class LTTB : MT25
    {
        public LTTB(string name, int damage, int experience, int price, int light_up) : base(name, damage, experience, price, light_up)
        {
            TankName = name;
            TankDamage = damage;
            TankExperience = experience;
            TankPrice = price;
            TankLightUp = light_up;
        }

        public int MakeLightUpShot(int chance)
        {
            var logger = Log.getLog();
            logger.AddLog(TankName + " made light up shot");
            return TankDamage - 20 + chance;
        }
    }

    public class LTG : MT25
    {
        public LTG(string name, int damage, int experience, int price, int light_up) : base(name, damage, experience, price, light_up)
        {
            TankName = name;
            TankDamage = damage;
            TankExperience = experience;
            TankPrice = price;
            TankLightUp = light_up;
        }

        public int MakeLightUpShot(int chance1, int chance2)
        {
            var logger = Log.getLog();
            logger.AddLog(TankName + " made light up shot");
            return TankDamage - 20 + chance1 - chance2;
        }
    }
    // =============================================================

    public class MyDivideByZeroException : DivideByZeroException
    {
        public MyDivideByZeroException() : base("Деление на ноль невозможно (переопределенное исключение).")
        {
            // Конструктор без параметров вызывает базовый конструктор с сообщением об ошибке
        }

        public MyDivideByZeroException(string message) : base(message)
        {
            // Конструктор с параметром для сообщения об ошибке
        }
    }
}
