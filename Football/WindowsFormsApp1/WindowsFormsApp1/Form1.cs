using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;


namespace WindowsFormsApp1
{
    
    public partial class Form1 : Form
    { 
        public Form1()
        {
            var logger = Log.getLog();
            logger.AddLog("program started. log created");
            InitializeComponent();
            textBox4.TextAlign = HorizontalAlignment.Center;
            textBox4.Text = coach_team1.Team + " " + " : " + " " + coach_team2.Team;
            button3.Enabled = false;
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        
        // Создание экземпляров классов
        Coach coach_team1 = new Coach("Karpin Valery Georgievich", "Spartak Moscow");
        Defender defender1_team1 = new Defender("George Dzhikiya", 4, 20, 78);
        Defender defender2_team1 = new Defender("Srdjan Babic", 5, 18, 81);
        CenterForward centerForward_team1 = new CenterForward("Mikhail Ignatov", 4, 75, 34, 80);
        Striker striker_team1 = new Striker("Alexander Sobolev", 5, 77, 15, 81);
        Goalkeeper goalkeeper_team1 = new Goalkeeper("Alexander Selikhov", 4, 5, 6, 76);

        Coach coach_team2 = new Coach("Rebrov Artem Gennadievich", "Torpedo Moscow");
        Defender defender1_team2 = new Defender("Ilya Kutepov", 3, 31, 74);
        Defender defender2_team2 = new Defender("Stas Samsonov", 5, 18, 76);
        CenterForward centerForward_team2 = new CenterForward("Petr Zuev", 4, 74, 27, 81);
        Striker striker_team2 = new Striker("Quincy Promes", 5, 82, 11, 84);
        Goalkeeper goalkeeper_team2= new Goalkeeper("Alexander Maksimenko", 5, 4, 8, 78);

        Forward forward = new Forward("Ronaldo", 2, 78, 20);
        Player player = new Player("Stas Karpow", 5, 20, 10);

        // кнопка Finish
        private void button1_Click(object sender, EventArgs e)
        {
            var logger = Log.getLog();
            logger.AddLog("program finished\n");
            Close();
            
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            button2.Enabled = false;
            // прибытие команд
            // ========================================================================================
            coach_team1.ArrivalToMatch();
            goalkeeper_team1.ArrivalToMatch();
            defender1_team1.ArrivalToMatch();
            defender2_team1.ArrivalToMatch();
            centerForward_team1.ArrivalToMatch();
            striker_team1.ArrivalToMatch();
            textBox1.Text += "Команда " + coach_team1.Team + " прибыла на игру\r\n";
            await Task.Delay(1000);

            coach_team2.ArrivalToMatch();
            goalkeeper_team2.ArrivalToMatch();
            defender1_team2.ArrivalToMatch();
            defender2_team2.ArrivalToMatch();
            centerForward_team2.ArrivalToMatch();
            striker_team2.ArrivalToMatch();
            textBox1.Text += "Команда " + coach_team2.Team + " прибыла на игру\r\n";
            await Task.Delay(1000);
            // ========================================================================================

            // пресса до матча у тренеров
            // ========================================================================================
            string replica = "Head Coach Team " + coach_team1.Team;
            coach_team1.GiveAnAnswer(replica);
            textBox1.Text += "Главный тренер команды " + coach_team1.Team + " " + coach_team1.PersonName + " дал интервью перед матчем\r\n";
            await Task.Delay(1000);

            replica = "Head Coach Team " + coach_team2.Team;
            coach_team2.GiveAnAnswer(replica);
            textBox1.Text += "Главный тренер команды " + coach_team2.Team + " " + coach_team2.PersonName + " дал интервью перед матчем\r\n";
            await Task.Delay(1000);
            // ========================================================================================

            // разминка
            // ========================================================================================
            goalkeeper_team1.DressUp();
            defender1_team1.DressUp();
            defender2_team1.DressUp();
            centerForward_team1.DressUp();
            striker_team1.DressUp();

            coach_team1.StartWarmUp();

            goalkeeper_team1.StartWarmUp();
            defender1_team1.StartWarmUp();
            defender2_team1.StartWarmUp();
            centerForward_team1.StartWarmUp();
            striker_team1.StartWarmUp();

            textBox1.Text += "Команда " + coach_team1.Team +  " начала разминку\r\n";
            await Task.Delay(1000);

            goalkeeper_team2.DressUp();
            defender1_team2.DressUp();
            defender2_team2.DressUp();
            centerForward_team2.DressUp();
            striker_team2.DressUp();

            coach_team2.StartWarmUp();

            goalkeeper_team2.StartWarmUp();
            defender1_team2.StartWarmUp();
            defender2_team2.StartWarmUp();
            centerForward_team2.StartWarmUp();
            striker_team2.StartWarmUp();

            textBox1.Text += "Команда " + coach_team2.Team + " начала разминку\r\n";
            await Task.Delay(1000);

            textBox1.Text += "\r\n";
            textBox1.Text += "Команда " + coach_team1.Team + " показатели до разминки\r\n";
            textBox1.Text += goalkeeper_team1.PersonName + ": навык - " + goalkeeper_team1.skill + " = " + goalkeeper_team1.Saves.ToString() + "\r\n";
            textBox1.Text += defender1_team1.PersonName + ": навык - " + defender1_team1.skill + " = " + defender1_team1.Defending.ToString() + "\r\n";
            textBox1.Text += defender2_team1.PersonName + ": навык - " + defender2_team1.skill + " = " + defender2_team1.Defending.ToString() + "\r\n";
            textBox1.Text += centerForward_team1.PersonName + ": навык - " + centerForward_team1.skill + " = " + centerForward_team1.Finishing.ToString() + "\r\n";
            textBox1.Text += centerForward_team1.PersonName + ": навык - " + centerForward_team1.skill2 + " = " + centerForward_team1.Driblings.ToString() + "\r\n";
            textBox1.Text += striker_team1.PersonName + ": навык - " + striker_team1.skill + " = " + striker_team1.Finishing.ToString() + "\r\n";
            textBox1.Text += striker_team1.PersonName + ": навык - " + striker_team1.skill2 + " = " + striker_team1.Heading.ToString() + "\r\n";
            textBox1.Text += "\r\n";

            goalkeeper_team1.TrainSaves();
            defender1_team1.TrainDefending();
            defender2_team1.TrainDefending();
            centerForward_team1.TrainFinishing();
            centerForward_team1.TrainDriblings();
            striker_team1.TrainFinishing();
            striker_team1.TrainHeading();

            await Task.Delay(1000);
            textBox1.Text += "Команда " + coach_team1.Team + " показатели после разминки\r\n";
            textBox1.Text += goalkeeper_team1.PersonName + ": навык - " + goalkeeper_team1.skill + " = " + goalkeeper_team1.Saves.ToString() + "\r\n";
            textBox1.Text += defender1_team1.PersonName + ": навык - " + defender1_team1.skill + " = " + defender1_team1.Defending.ToString() + "\r\n";
            textBox1.Text += defender2_team1.PersonName + ": навык - " + defender2_team1.skill + " = " + defender2_team1.Defending.ToString() + "\r\n";
            textBox1.Text += centerForward_team1.PersonName + ": навык - " + centerForward_team1.skill + " = " + centerForward_team1.Finishing.ToString() + "\r\n";
            textBox1.Text += centerForward_team1.PersonName + ": навык - " + centerForward_team1.skill2 + " = " + centerForward_team1.Driblings.ToString() + "\r\n";
            textBox1.Text += striker_team1.PersonName + ": навык - " + striker_team1.skill + " = " + striker_team1.Finishing.ToString() + "\r\n";
            textBox1.Text += striker_team1.PersonName + ": навык - " + striker_team1.skill2 + " = " + striker_team1.Heading.ToString() + "\r\n";
            textBox1.Text += "\r\n";

            await Task.Delay(1000);
            textBox1.Text += "Команда " + coach_team2.Team + " показатели до разминки\r\n";
            textBox1.Text += goalkeeper_team2.PersonName + ": навык - " + goalkeeper_team2.skill + " = " + goalkeeper_team2.Saves.ToString() + "\r\n";
            textBox1.Text += defender1_team2.PersonName + ": навык - " + defender1_team2.skill + " = " + defender1_team2.Defending.ToString() + "\r\n";
            textBox1.Text += defender2_team2.PersonName + ": навык - " + defender2_team2.skill + " = " + defender2_team2.Defending.ToString() + "\r\n";
            textBox1.Text += centerForward_team2.PersonName + ": навык - " + centerForward_team2.skill + " = " + centerForward_team2.Finishing.ToString() + "\r\n";
            textBox1.Text += centerForward_team2.PersonName + ": навык - " + centerForward_team2.skill2 + " = " + centerForward_team2.Driblings.ToString() + "\r\n";
            textBox1.Text += striker_team2.PersonName + ": навык - " + striker_team2.skill + " = " + striker_team2.Finishing.ToString() + "\r\n";
            textBox1.Text += striker_team2.PersonName + ": навык - " + striker_team2.skill2 + " = " + striker_team2.Heading.ToString() + "\r\n";
            textBox1.Text += "\r\n";

            goalkeeper_team2.TrainSaves();
            defender1_team2.TrainDefending();
            defender2_team2.TrainDefending();
            centerForward_team2.TrainFinishing();
            centerForward_team2.TrainDriblings();
            striker_team2.TrainFinishing();
            striker_team2.TrainHeading();

            await Task.Delay(1000);
            textBox1.Text += "Команда " + coach_team2.Team + " показатели после разминки\r\n";
            textBox1.Text += goalkeeper_team2.PersonName + ": навык - " + goalkeeper_team2.skill + " = " + goalkeeper_team2.Saves.ToString() + "\r\n";
            textBox1.Text += defender1_team2.PersonName + ": навык - " + defender1_team2.skill + " = " + defender1_team2.Defending.ToString() + "\r\n";
            textBox1.Text += defender2_team2.PersonName + ": навык - " + defender2_team2.skill + " = " + defender2_team2.Defending.ToString() + "\r\n";
            textBox1.Text += centerForward_team2.PersonName + ": навык - " + centerForward_team2.skill + " = " + centerForward_team2.Finishing.ToString() + "\r\n";
            textBox1.Text += centerForward_team2.PersonName + ": навык - " + centerForward_team2.skill2 + " = " + centerForward_team2.Driblings.ToString() + "\r\n";
            textBox1.Text += striker_team2.PersonName + ": навык - " + striker_team2.skill + " = " + striker_team2.Finishing.ToString() + "\r\n";
            textBox1.Text += striker_team2.PersonName + ": навык - " + striker_team2.skill2 + " = " + striker_team2.Heading.ToString() + "\r\n";
            textBox1.Text += "\r\n";

            await Task.Delay(1000);
            coach_team1.FinishWarmUp();
            goalkeeper_team1.FinishWarmUp();
            defender1_team1.FinishWarmUp();
            defender2_team1.FinishWarmUp();
            centerForward_team1.FinishWarmUp();
            striker_team1.FinishWarmUp();

            textBox1.Text += "Команда " + coach_team1.Team + " завершила разминку\r\n";
            await Task.Delay(1000);

            coach_team2.FinishWarmUp();
            goalkeeper_team2.FinishWarmUp();
            defender1_team2.FinishWarmUp();
            defender2_team2.FinishWarmUp();
            centerForward_team2.FinishWarmUp();
            striker_team2.FinishWarmUp();

            textBox1.Text += "Команда " + coach_team2.Team + " завершила разминку\r\n";
            // ========================================================================================
            button3.Enabled = true;
            MessageBox.Show("Для начала игры нажмите кнопку Начать матч");
        }

        Game game = new Game();
        public delegate void MyDelegate();
        private async void button3_Click(object sender, EventArgs e)
        {
            button3.Enabled = false;
            var logger = Log.getLog();
            logger.AddLog("WINForm match started\n");
            int a = 0;
            string question1 = "Победит ли " + coach_team1.Team + "?";
            string question2 = "Победит ли " + coach_team2.Team + "?";
            string question3 = "Будет ли ничья? ";
            string question4 = "Будет ли забито больше 5 голов? ";

            Random random = new Random();
            int randomNumber = random.Next(1, 5); // Генерируем случайное число от 1 до 4

            Console.WriteLine($"Случайное число: {randomNumber}");

            switch (randomNumber)
            {
                case 1:
                    // Показываем MessageBox с двумя кнопками на выбор: "Да" и "Нет"
                    DialogResult result = MessageBox.Show(question1, "Сделайте прогноз", MessageBoxButtons.YesNo);

                    // Проверяем результат выбора кнопки
                    if (result == DialogResult.Yes)
                    {
                        a = 1;
                        textBox5.Text += "Вы дали прогноз: " + question1 + " - ДА";
                    }
                    else if (result == DialogResult.No)
                    {
                        a = 2;
                        textBox5.Text += "Вы дали прогноз: " + question1 + " - НЕТ";
                    }

                    
                    break;
                case 2:
                    // Показываем MessageBox с двумя кнопками на выбор: "Да" и "Нет"
                    result = MessageBox.Show(question2, "Сделайте прогноз", MessageBoxButtons.YesNo);

                    // Проверяем результат выбора кнопки
                    if (result == DialogResult.Yes)
                    {
                        a = 1;
                        textBox5.Text += "Вы дали прогноз: " + question2 + " - ДА";
                    }
                    else if (result == DialogResult.No)
                    {
                        a = 2;
                        textBox5.Text += "Вы дали прогноз: " + question2 + " - НЕТ";
                    }
                    break;
                case 3:
                    // Показываем MessageBox с двумя кнопками на выбор: "Да" и "Нет"
                    result = MessageBox.Show(question3, "Сделайте прогноз", MessageBoxButtons.YesNo);

                    // Проверяем результат выбора кнопки
                    if (result == DialogResult.Yes)
                    {
                        a = 1;
                        textBox5.Text += "Вы дали прогноз: " + question3 + " - ДА";
                    }
                    else if (result == DialogResult.No)
                    {
                        a = 2;
                        textBox5.Text += "Вы дали прогноз: " + question3 + " - НЕТ";
                    }
                    break;
                case 4:
                    // Показываем MessageBox с двумя кнопками на выбор: "Да" и "Нет"
                    result = MessageBox.Show(question4, "Сделайте прогноз", MessageBoxButtons.YesNo);

                    // Проверяем результат выбора кнопки
                    if (result == DialogResult.Yes)
                    {
                        a = 1;
                        textBox5.Text += "Вы дали прогноз: " + question4 + " - ДА";
                    }
                    else if (result == DialogResult.No)
                    {
                        a = 2;
                        textBox5.Text += "Вы дали прогноз: " + question4 + " - НЕТ";
                    }
                    break;
                default:
                    break;
            }

           
            // Создаем словарь для хранения соответствия позиции игрока и его имени
            Dictionary<string, string> players = new Dictionary<string, string>
            {
                { goalkeeper_team1.PersonName, "1GK" },
                { defender1_team1.PersonName, "1DEF1" },
                { defender2_team1.PersonName , "1DEF2" },
                { centerForward_team1.PersonName , "1CF" },
                { striker_team1.PersonName , "1ST" },
                { goalkeeper_team2.PersonName , "2GK" },
                { defender1_team2.PersonName , "2DEF1" },
                { defender2_team2.PersonName , "2DEF2" },
                { centerForward_team2.PersonName , "2CF" },
                { striker_team2.PersonName , "2ST" },
            };

            await Task.Delay(1000);
            coach_team1.ApplauseForTheFans();
            goalkeeper_team1.ApplauseForTheFans();
            defender1_team1.ApplauseForTheFans();
            defender2_team1.ApplauseForTheFans();
            centerForward_team1.ApplauseForTheFans();
            striker_team1.ApplauseForTheFans();
            textBox5.Text += "\r\nКоманда " + coach_team1.Team + " поприветствовала фанатов\r\n";

            await Task.Delay(1000);
            coach_team2.ApplauseForTheFans();
            goalkeeper_team2.ApplauseForTheFans();
            defender1_team2.ApplauseForTheFans();
            defender2_team2.ApplauseForTheFans();
            centerForward_team2.ApplauseForTheFans();
            striker_team2.ApplauseForTheFans();
            textBox5.Text += "Команда " + coach_team2.Team + " поприветствовала фанатов\r\n";

            textBox5.Text += "Матч начался\r\n";
            await Task.Delay(1000);

            int totalSkills_team1 = goalkeeper_team1.TotalBasedSkills() + goalkeeper_team1.Saves + defender1_team1.TotalBasedSkills()
                + defender2_team1.TotalBasedSkills() + centerForward_team1.TotalBasedSkills() + centerForward_team1.Driblings
                + striker_team1.TotalBasedSkills() + striker_team1.Heading;
            textBox5.Text += "Общие навыки команды " + coach_team1.Team + " составляют " + totalSkills_team1.ToString() + " очков\r\n";

            int totalSkills_team2 = goalkeeper_team2.TotalBasedSkills() + goalkeeper_team2.Saves + defender1_team2.TotalBasedSkills()
                + defender2_team2.TotalBasedSkills() + centerForward_team2.TotalBasedSkills() + centerForward_team2.Driblings
                + striker_team2.TotalBasedSkills() + striker_team2.Heading;
            textBox5.Text += "Общие навыки команды " + coach_team2.Team + " составляют " + totalSkills_team2.ToString() + " очков\r\n";

            string resultGame = game.GameResult(totalSkills_team1, totalSkills_team2, goalkeeper_team1.Saves, 
                goalkeeper_team2.Saves, centerForward_team1.Finishing,
                centerForward_team2.Finishing, striker_team1.Finishing, striker_team2.Finishing, defender1_team1.Defending,
                defender1_team2.Defending, defender2_team1.Defending, defender2_team2.Defending, striker_team1.Heading,
                striker_team2.Heading, centerForward_team1.Driblings, centerForward_team2.Driblings);
            
            await Task.Delay(1000);
            //textBox1.Text += resultGame + "\r\n";

            // Разделяем исходную строку на строки по символу новой строки
            //string[] lines = resultGame.Split(''\r\n');
            string[] lines = resultGame.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            // Создаем переменную для хранения преобразованной строки
            string output1 = "";
            string output2 = "";

            // Проходим по каждой строке в массиве lines
            foreach (string line in lines)
            {
                string[] parts = line.Split(' ');
                string searchValue = parts[1];
                string key = players.FirstOrDefault(x => x.Value == searchValue).Key;

                if (key != null)
                {
                    char firstChar = searchValue[0];
                    if (firstChar == '1')
                    {
                        output1 += key + "\r\n";
                    }
                    if (firstChar == '2')
                    {
                        output2 += key + "\r\n";
                    }
                }
                else
                {
                    MessageBox.Show("Value not found in the dictionary.");
                }
            }

            textBox2.Text += output1;
            textBox3.TextAlign = HorizontalAlignment.Right;
            textBox3.Text += output2;

            int lineCount1 = textBox2.Lines.Length;
            if (lineCount1 > 0) { lineCount1--; }
            int lineCount2 = textBox3.Lines.Length;
            if (lineCount2 > 0) { lineCount2--; }

            textBox4.TextAlign = HorizontalAlignment.Center;
            textBox4.Text = coach_team1.Team + " " + lineCount1.ToString() + " : " + lineCount2.ToString() + " " + coach_team2.Team;
            textBox5.Text += "Матч закончился\r\n";
            await Task.Delay(1000);
            textBox5.Text += "\r\n";
            await Task.Delay(1000);

            switch (randomNumber)
            {
                case 1:
                    if ((lineCount1 > lineCount2 && a == 1) || (lineCount1 <= lineCount2 && a == 2))
                    {
                        textBox5.Text += "Ваш прогноз оказался верным!\r\n";
                    }
                    else
                    {
                        textBox5.Text += "Ваш прогноз оказался ошибочным\r\n";
                    }
                    break;
                case 2:
                    if ((lineCount1 < lineCount2 && a == 1) || (lineCount1 >= lineCount2 && a == 2))
                    {
                        textBox5.Text += "Ваш прогноз оказался верным!\r\n";
                    }
                    else
                    {
                        textBox5.Text += "Ваш прогноз оказался ошибочным\r\n";
                    }
                    break;
                case 3:
                    if ((lineCount1 == lineCount2 && a == 1) || (lineCount1 != lineCount2 && a == 2))
                    {
                        textBox5.Text += "Ваш прогноз оказался верным!\r\n";
                    }
                    else
                    {
                        textBox5.Text += "Ваш прогноз оказался ошибочным\r\n";
                    }
                    break;
                case 4:
                    if ((lineCount1 + lineCount2 > 5 && a == 1) || (lineCount1 + lineCount2 <= 5 && a == 2))
                    {
                        textBox5.Text += "Ваш прогноз оказался верным!\r\n";
                    }
                    else
                    {
                        textBox5.Text += "Ваш прогноз оказался ошибочным\r\n";
                    }
                    break;
                default:
                    
                    break;
            }

            // пресса после игры
            // ========================================================================================

            MyDelegate multiDelegate = null;
            // Добавляем методы в делегат
            multiDelegate += coach_team1.ApplauseForTheFans;
            multiDelegate += coach_team1.GiveAnAnswer;
            multiDelegate += coach_team1.ApplauseForTheFans;
            textBox5.Text += "\r\n";
            textBox5.Text += coach_team1.PersonName + " дал интервью после матча\r\n";
            await Task.Delay(1000);

            multiDelegate += coach_team2.ApplauseForTheFans;
            multiDelegate += coach_team2.GiveAnAnswer;
            multiDelegate += coach_team2.ApplauseForTheFans;
            textBox5.Text += coach_team2.PersonName + " дал интервью после матча\r\n";
            await Task.Delay(1000);
            // Вызываем делегат, что вызовет все добавленные методы
            multiDelegate?.Invoke();
            // ========================================================================================

            textBox5.Text += "\r\nПодсчет коэффициента голов команд\r\n";
            try
            {
                // Попытка деления на ноль
                double result = DivideNumbers(lineCount1, lineCount2);
                textBox5.Text += "Коэффициент голов: " + coach_team1.Team + " к " + coach_team2.Team + " = " + result + "\r\n"; 
            }
            catch (MyDivideByZeroException ex)
            {
                textBox5.Text += "Ошибка деления на ноль: ";
                textBox5.Text += (ex.Message);
                textBox5.Text += "\r\n\r\n";
                logger.AddLog(ex.Message + "\n");
            }

            try
            {
                // Попытка деления на ноль
                double result = DivideNumbers(lineCount2, lineCount1);
                textBox5.Text += "Коэффициент голов: " + coach_team2.Team + " к " + coach_team1.Team + " = " + result + "\r\n";
            }
            catch (MyDivideByZeroException ex)
            {
                textBox5.Text += "Ошибка деления на ноль: ";
                textBox5.Text += (ex.Message);
                textBox5.Text += "\r\n";
                logger.AddLog(ex.Message + "\n");
            }
            logger.AddLog("WINForm match finished\n");
        }

        static double DivideNumbers(int numerator, int denominator)
        {
            if (denominator == 0)
            {
                throw new MyDivideByZeroException(); // Генерация переопределенного исключения
            }
            return (double)numerator / denominator;
        }

    }
}