using System;
using System.IO;

namespace WindowsFormsApp1
{
    // =============================================================
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
    // =============================================================

    // Определение интерфейсов
    // =============================================================
    interface IArrival
    {
        void ArrivalToMatch();
    }

    interface IWarmUp
    {
        void StartWarmUp();
        void FinishWarmUp();
    }

    interface IPressConference
    {
        void GiveAnAnswer();
    }

    interface IDress
    {
        void DressUp();
    }
    // =============================================================

    
    public class Person : IArrival, IPressConference
    {
        public string PersonName;
        public Person(string name)
        {
            PersonName = name;
        }

        public virtual void ApplauseForTheFans()
        {
            var logger = Log.getLog();
            logger.AddLog(PersonName + " applaused for the fans");
        }

        public void ArrivalToMatch()
        {
            var logger = Log.getLog();
            logger.AddLog(PersonName + " arrived at the match");
        }
        public void GiveAnAnswer()
        {
            var logger = Log.getLog();
            string answer1 = "It was an interesting match.";
            string answer2 = "Thanks to the fans for their support.";

            logger.AddLog("Start Press Conference");
            logger.AddLog("Correspondent: Are you happy with the game?");
            logger.AddLog(PersonName + ": " + answer1);
            logger.AddLog("Correspondent: What can you say about the fans?");
            logger.AddLog(PersonName + ": " + answer2);
            logger.AddLog("Finish Press Conference");
        }
    }

    public class Player : Person, IDress, IWarmUp
    {
        public int PhysicalForm;
        public int Finishing;
        public int Defending;
        public Player(string name, int physicalForm, int finishing, int defending) : base(name)
        {
            PhysicalForm = physicalForm;
            Finishing = finishing;
            Defending = defending;
        }

        public int TotalBasedSkills()
        {
            return PhysicalForm + Finishing + Defending;
        }
        public void DressUp()
        {
            var logger = Log.getLog();
            logger.AddLog(PersonName + " dressed up");
        }

        public void StartWarmUp()
        {
            var logger = Log.getLog();
            logger.AddLog(PersonName + " started warm up");
        }

        public void FinishWarmUp()
        {
            var logger = Log.getLog();
            logger.AddLog(PersonName + " finished warm up");
        }

    }

    public class Coach : Person, IWarmUp
    {        
        public string Team;
        public Coach(string name, string team) : base(name)
        {
            Team = team;
        }
        public override void ApplauseForTheFans()
        {
            var logger = Log.getLog();
            logger.AddLog(PersonName + " greeted the fans");
        }
        public void StartWarmUp()
        {
            var logger = Log.getLog();
            logger.AddLog("Head Coach " + PersonName + " started warm up");
        }

        public void FinishWarmUp()
        {
            var logger = Log.getLog();
            logger.AddLog("Head Coach " + PersonName + " finished warm up");
        }

        public void GiveAnAnswer(string replica)
        {
            var logger = Log.getLog();
            string answer1 = "I'm waiting for a good game. I want to please our fans";
            string answer2 = "My team " + Team +  " is ready to show spectacular football";

            logger.AddLog("Start Press Conference by " + replica);
            logger.AddLog("Correspondent: What do you expect from this game?");
            logger.AddLog(PersonName + ": " + answer1);
            logger.AddLog("Correspondent: Is your team physically well prepared?");
            logger.AddLog(PersonName + ": " + answer2);
            logger.AddLog("Finish Press Conference by" + replica);
        }
    }

    public class Forward : Player
    {
        public string skill = "Finishing";
        public Forward(string name, int physicalForm, int finishing, int defending) : base(name, physicalForm, finishing, defending)
        {
        }

        public void TrainFinishing()
        {
            var logger = Log.getLog();
            logger.AddLog(PersonName + " finishing before train = " + Finishing);
            Random rand = new Random();
            double randomNumber, result;
            int attempts = 50;
            int goals = 0;

            for (int i = 0; i < attempts; i++)
            {
                randomNumber = rand.NextDouble() * (1.1 - 0.9) + 0.9;
                if ((randomNumber + PhysicalForm / 100.0) >= 1.0)
                {
                    goals++;
                }
            }

            result = 100.0 * goals / attempts;
            if (result >= 80)
            {
                Finishing = Finishing + 5;
            }
            else
            {
                if (result >= 60)
                {
                    Finishing = Finishing + 2;
                }
                else
                {
                    if (result >= 50)
                    {
                        Finishing = Finishing + 1;
                    }
                    else
                    {
                        Finishing = Finishing - 2;
                    }
                }
            }
            logger.AddLog(PersonName + " finishing after train = " + Finishing);
        }
    }

    public class Defender : Player
    {
        public string skill = "Defending";
        public Defender(string name, int physicalForm, int finishing, int defending) : base(name, physicalForm, finishing, defending)
        {
        }

        public void TrainDefending()
        {
            var logger = Log.getLog();
            logger.AddLog(PersonName + " defending before train = " + Defending);
            Random rand = new Random();
            double randomNumber, result;
            int attempts = 50;
            int goals = 0;

            for (int i = 0; i < attempts; i++)
            {
                randomNumber = rand.NextDouble() * (1.1 - 0.9) + 0.9;
                if ((randomNumber + PhysicalForm / 100.0) >= 1.0)
                {
                    goals++;
                }
            }

            result = 100.0 * goals / attempts;
            if (result >= 75)
            {
                Defending = Defending + 5;
            }
            else
            {
                if (result >= 60)
                {
                    Defending = Defending + 2;
                }
                else
                {
                    if (result >= 40)
                    {
                        Defending = Defending + 1;
                    }
                    else
                    {
                        Defending = Defending - 2;
                    }
                }
            }
            logger.AddLog(PersonName + " defending after train = " + Defending);
        }
    }

    public class Goalkeeper : Player
    {
        public int Saves;
        public string skill = "Saves";
        public Goalkeeper(string name, int physicalForm, int finishing, int defending, int saves) : base(name, physicalForm, finishing, defending)
        {
            Saves = saves;
        }

        public void TrainSaves()
        {
            var logger = Log.getLog();
            logger.AddLog(PersonName + " saves before train = " + Saves);
            Random rand = new Random();
            double randomNumber, result;
            int attempts = 50;
            int goals = 0;

            for (int i = 0; i < attempts; i++)
            {
                randomNumber = rand.NextDouble() * (1.1 - 0.9) + 0.9;
                if ((randomNumber + PhysicalForm / 100.0) >= 1.0)
                {
                    goals++;
                }
            }

            result = 100.0 * goals / attempts;
            if (result >= 90)
            {
                Saves = Saves + 5;
            }
            else
            {
                if (result >= 60)
                {
                    Saves = Saves + 2;
                }
                else
                {
                    if (result >= 40)
                    {
                        Saves = Saves + 1;
                    }
                    else
                    {
                        Saves = Saves - 2;
                    }
                }
            }
            logger.AddLog(PersonName + " saves after train = " + Saves);
        }
    }

    public class CenterForward : Forward
    {
        public string skill2 = "Driblings";
        public int Driblings;
        public CenterForward(string name, int physicalForm, int finishing, int defending, int driblings) : base(name, physicalForm, finishing, defending)
        {
            Driblings = driblings;
        }

        public void TrainDriblings()
        {
            var logger = Log.getLog();
            logger.AddLog(PersonName + " Driblings before train = " + Driblings);
            Random rand = new Random();
            double randomNumber, result;
            int attempts = 50;
            int goals = 0;

            for (int i = 0; i < attempts; i++)
            {
                randomNumber = rand.NextDouble() * (1.1 - 0.9) + 0.9;
                if ((randomNumber / 100.0) >= 1.0)
                {
                    goals++;
                }
            }

            result = 100.0 * goals / attempts;
            if (result >= 75)
            {
                Driblings = Driblings + 5;
            }
            else
            {
                if (result >= 55)
                {
                    Driblings = Driblings + 2;
                }
                else
                {
                    if (result >= 45)
                    {
                        Driblings = Driblings + 1;
                    }
                    else
                    {
                        Driblings = Driblings - 2;
                    }
                }
            }
            logger.AddLog(PersonName + " Driblings after train = " + Driblings);
        }
    }

    public class Striker : Forward
    {
        public string skill2 = "Heading";
        public int Heading;
        public Striker(string name, int physicalForm, int finishing, int defending, int heading) : base(name, physicalForm, finishing, defending)
        {
            Heading = heading;
        }

        public void TrainHeading()
        {
            var logger = Log.getLog();
            logger.AddLog(PersonName + " Heading before train = " + Heading);
            Random rand = new Random();
            double randomNumber, result;
            int attempts = 50;
            int goals = 0;

            for (int i = 0; i < attempts; i++)
            {
                randomNumber = rand.NextDouble() * (1.1 - 0.9) + 0.9;
                if ((randomNumber / 100.0) >= 1.0)
                {
                    goals++;
                }
            }

            result = 100.0 * goals / attempts;
            if (result >= 70)
            {
                Heading = Heading + 5;
            }
            else
            {
                if (result >= 60)
                {
                    Heading = Heading + 2;
                }
                else
                {
                    if (result >= 50)
                    {
                        Heading = Heading + 1;
                    }
                    else
                    {
                        Heading = Heading - 2;
                    }
                }
            }
            logger.AddLog(PersonName + " Heading after train = " + Heading);
        }
    }

    public class Game
    {
        public int goals_team1 = 0;
        public int goals_team2 = 0;
        public string GameResult(int skill1, int skill2, int saves1, int saves2, int finishing11, int finishing12,
            int finishing21, int finishing22, int def11, int def12, int def21, int def22, int head1, int head2,
            int dribling1, int dribling2)
        {
            // общий навык команды влияет на то, как много атак она создаст за игру
            // больше навык => больше атак => больше возможностей забить гол
            string res = "";
            int attack1 = 0;
            int attack2 = 0;
            var logger = Log.getLog();
            
            Random rand = new Random();
            double randomNumber = rand.NextDouble() * (1.1 - 0.9) + 0.9;
            attack1 = (int)(randomNumber * skill1 / 10.0);
            logger.AddLog("Random number to attack1 = " + randomNumber);
            logger.AddLog("attack1 = " + attack1);

            randomNumber = rand.NextDouble() * (1.1 - 0.9) + 0.9;
            attack2 = (int)(randomNumber * skill2 / 10.0);
            logger.AddLog("Random number to attack2 = " + randomNumber);
            logger.AddLog("attack2 = " + attack2 + "\n");

            // цикл по всем атакам команды team1
            int goal;

            string name = "";
            double Pgoal;

            for (int i = 1; i <= attack1; i++)
            {
                Pgoal = ((rand.NextDouble() * (1.1 - 0.9) + 0.9) * dribling1 * (100 - (rand.NextDouble() * (1.1 - 0.9) + 0.9) * def12) 
                    + (rand.NextDouble() * (1.1 - 0.9) + 0.9) * head1 * (100 - (rand.NextDouble() * (1.1 - 0.9) + 0.9) * def22) 
                    + (100 - (rand.NextDouble() * (1.1 - 0.9) + 0.9) * saves2) * 
                    ((rand.NextDouble() * (1.1 - 0.9) + 0.9)* finishing11 + (rand.NextDouble() * (1.1 - 0.9) + 0.9) * finishing21)) / 1000;
                logger.AddLog(Pgoal.ToString());
                
                if (Pgoal > 8.0)
                {
                    goals_team1++;
                    // определение автора забитого мяча
                    goal = rand.Next(1, 101);
                    if ((goal >= 1) && (goal < 2))
                    {
                        name = "GK";
                    }
                    if ((goal >= 2) && (goal <= 11))
                    {
                        name = "DEF1";
                    }
                    if ((goal >= 12) && (goal <= 21))
                    {
                        name = "DEF2";
                    }
                    if ((goal >= 22) && (goal <= 55))
                    {
                        name = "CF";
                    }
                    if ((goal >= 56) && (goal <= 100))
                    {
                        name = "ST";
                    }
                    res += goals_team1.ToString() + " 1" + name + "\r\n";
                    logger.AddLog("Team1. goal no. " + goals_team1.ToString() + " by " + name);
                }
                

            }

            // цикл по всем атакам команды team2
            for (int i = 1; i <= attack2; i++)
            {
                Pgoal = ((rand.NextDouble() * (1.1 - 0.9) + 0.9) * dribling2 * (100 - (rand.NextDouble() * (1.1 - 0.9) + 0.9) * def11)
                    + (rand.NextDouble() * (1.1 - 0.9) + 0.9) * head2 * (100 - (rand.NextDouble() * (1.1 - 0.9) + 0.9) * def21)
                    + (100 - (rand.NextDouble() * (1.1 - 0.9) + 0.9) * saves1) *
                    ((rand.NextDouble() * (1.1 - 0.9) + 0.9) * finishing12 + (rand.NextDouble() * (1.1 - 0.9) + 0.9) * finishing22)) / 1000;
                logger.AddLog(Pgoal.ToString());

                if (Pgoal > 8.0)
                {
                    goals_team2++;
                    // определение автора забитого мяча
                    goal = rand.Next(1, 101);
                    if ((goal >= 1) && (goal < 2))
                    {
                        name = "GK";
                    }
                    if ((goal >= 2) && (goal <= 11))
                    {
                        name = "DEF1";
                    }
                    if ((goal >= 12) && (goal <= 21))
                    {
                        name = "DEF2";
                    }
                    if ((goal >= 22) && (goal <= 55))
                    {
                        name = "CF";
                    }
                    if ((goal >= 56) && (goal <= 100))
                    {
                        name = "ST";
                    }
                    res += goals_team2.ToString() + " 2" + name + "\r\n";
                    logger.AddLog("Team2. goal no. " + goals_team2.ToString() + " by " + name);
                }
            }
            logger.AddLog("\n" + res);
            return res;
        }
    }

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