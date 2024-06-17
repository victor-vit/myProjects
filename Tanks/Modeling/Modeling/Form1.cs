using System;
using System.Windows.Forms;

namespace Modeling
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            var logger = Log.getLog();
            logger.AddLog("program started. log created");
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;
            button7.Enabled = false;
            button8.Enabled = false;
            button9.Enabled = false;
            button10.Enabled = false;
            button11.Enabled = false;
            button12.Enabled = false;
            button13.Enabled = false;
            button14.Enabled = false;
        }

        int Exp = 280000;
        int Money = 113000;

        // Создание экземпляров классов
        BT7 bt7 = new BT7("БТ-7", 100);

        // Тяжелые танки
        // ------------------------------------------------------
        KV1 kv1 = new KV1("КВ-1", 200, 10000, 1000, 50);

        KV1S kv1s = new KV1S("КВ-1С", 400, 30000, 10000, 75);
        KV2 kv2 = new KV2("КВ-2", 560, 30000, 10000, 75);

        KV3 kv3 = new KV3("КВ-3", 450, 80000, 40000, 100);
        IS iS = new IS("ИС", 450, 80000, 40000, 100);
        // ------------------------------------------------------

        // Средние танки
        // ------------------------------------------------------
        T34 t34 = new T34("Т-34", 160, 10000, 1000, 50);

        T3485 t3485 = new T3485("Т-34-85", 250, 30000, 10000, 75);
        T43 t43 = new T43("Т-43", 250, 30000, 10000, 75);
        // ------------------------------------------------------

        // Легкие танки
        // ------------------------------------------------------
        A20 a20 = new A20("А-20", 160, 10000, 1000, 50);

        MT25 mt25 = new MT25("МТ-25", 200, 30000, 10000, 75);

        LTTB lttb = new LTTB("ЛТТБ", 310, 80000, 40000, 100);
        LTG ltg = new LTG("ЛТГ", 310, 80000, 40000, 100);
        // ------------------------------------------------------

        int overallDamage = 0;
        int overallShot = 0;
        int winDamage = 8000;
        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "Exp: " + Exp.ToString() + "     RUB: " + Money.ToString();
            button2.Enabled = true;
            button1.Enabled = false;
            MessageBox.Show($"Для победы нужно нанести {winDamage} урона");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            textBox2.Text += $"Исследован танк {bt7.TankName}\r\n";

            Random random = new Random();
            int randomNumber = random.Next(1, 4);
            textBox2.Text += $"Танк {bt7.TankName} нанес " + randomNumber * bt7.TankDamage + "  единиц урона\r\n";
            overallDamage += randomNumber * bt7.TankDamage;
            textBox3.Text = "Overall = " + overallDamage;
            overallShot += randomNumber;

            button2.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int exp = a20.ExploreTank();
            int money = a20.BuyTank();
            Exp = Exp - exp;
            Money = Money - money;
            if (Exp < 0 || Money < 0)
            {
                MessageBox.Show("Недостаточно ресурсов");
                Exp = Exp + exp;
                Money = Money + money;
            }
            else
            {
                a20.InstallOptics();
                textBox1.Text = "Exp: " + Exp.ToString() + "     RUB: " + Money.ToString();
                textBox2.Text += $"\r\nИсследован танк {a20.TankName}. Потрачено опыта: " + exp + ". Потрачено рублей: " + money + "\r\n";
                button6.Enabled = true;

                Random random = new Random();
                int randomNumber = random.Next(1, 6);
                textBox2.Text += $"Танк {a20.TankName} нанес " + randomNumber * a20.TankDamage + "  единиц урона\r\n";
                overallDamage += randomNumber * a20.TankDamage;
                textBox3.Text = "Overall = " + overallDamage;
                overallShot += randomNumber;
            }
            button3.Enabled = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int exp = t34.ExploreTank();
            int money = t34.BuyTank();
            Exp = Exp - exp;
            Money = Money - money;
            if (Exp < 0 || Money < 0)
            {
                MessageBox.Show("Недостаточно ресурсов");
                Exp = Exp + exp;
                Money = Money + money;
            }
            else
            {
                t34.InstallSupportEquipment();
                textBox1.Text = "Exp: " + Exp.ToString() + "     RUB: " + Money.ToString();
                textBox2.Text += $"\r\nИсследован танк {t34.TankName}. Потрачено опыта: " + exp + ". Потрачено рублей: " + money + "\r\n";
                button7.Enabled = true;
                button8.Enabled = true;

                Random random = new Random();
                int randomNumber = random.Next(1, 6);
                textBox2.Text += $"Танк {t34.TankName} нанес " + randomNumber * t34.TankDamage + "  единиц урона\r\n";
                overallDamage += randomNumber * t34.TankDamage;
                textBox3.Text = "Overall = " + overallDamage;
                overallShot += randomNumber;
            }
            button4.Enabled = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int exp = kv1.ExploreTank();
            int money = kv1.BuyTank();
            Exp = Exp - exp;
            Money = Money - money;
            if (Exp < 0 || Money < 0)
            {
                MessageBox.Show("Недостаточно ресурсов");
                Exp = Exp + exp;
                Money = Money + money;
            }
            else
            {
                kv1.InstallArmor();
                textBox1.Text = "Exp: " + Exp.ToString() + "     RUB: " + Money.ToString();
                textBox2.Text += $"\r\nИсследован танк {kv1.TankName}. Потрачено опыта: " + exp + ". Потрачено рублей: " + money + "\r\n";
                button9.Enabled = true;
                button10.Enabled = true;

                Random random = new Random();
                int randomNumber = random.Next(1, 5);
                textBox2.Text += $"Танк {kv1.TankName} нанес " + randomNumber * kv1.TankDamage + "  единиц урона\r\n";
                overallDamage += randomNumber * kv1.TankDamage;
                textBox3.Text = "Overall = " + overallDamage;
                overallShot += randomNumber;
            }
            button5.Enabled = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int exp = mt25.ExploreTank();
            int money = mt25.BuyTank();
            Exp = Exp - exp;
            Money = Money - money;
            if (Exp < 0 || Money < 0)
            {
                MessageBox.Show("Недостаточно ресурсов");
                Exp = Exp + exp;
                Money = Money + money;
            }
            else
            {
                mt25.InstallOptics(); 
                textBox1.Text = "Exp: " + Exp.ToString() + "     RUB: " + Money.ToString();
                textBox2.Text += $"\r\nИсследован танк {mt25.TankName}. Потрачено опыта: " + exp + ". Потрачено рублей: " + money + "\r\n";
                button11.Enabled = true;
                button12.Enabled = true;

                Random random = new Random();
                int randomNumber = random.Next(1, 7);
                textBox2.Text += $"Танк {mt25.TankName} нанес " + randomNumber * mt25.TankDamage + "  единиц урона\r\n";
                overallDamage += randomNumber * mt25.TankDamage;
                textBox3.Text = "Overall = " + overallDamage;
                overallShot += randomNumber;

                randomNumber = random.Next(1, 3);
                if (randomNumber == 1)
                {
                    int lightShot = mt25.MakeLightUpShot();
                    textBox2.Text += $"Танк {mt25.TankName} нанес " + lightShot + "  единиц урона с помощью выстрела засвета\r\n";
                    overallDamage += lightShot;
                    textBox3.Text = "Overall = " + overallDamage;
                    overallShot++;
                }
            }
            button6.Enabled = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int exp = t3485.ExploreTank();
            int money = t3485.BuyTank();
            Exp = Exp - exp;
            Money = Money - money;
            if (Exp < 0 || Money < 0)
            {
                MessageBox.Show("Недостаточно ресурсов");
                Exp = Exp + exp;
                Money = Money + money;
            }
            else
            {
                t3485.InstallSupportEquipment();
                textBox1.Text = "Exp: " + Exp.ToString() + "     RUB: " + Money.ToString();
                textBox2.Text += $"\r\nИсследован танк {t3485.TankName}. Потрачено опыта: " + exp + ". Потрачено рублей: " + money + "\r\n";

                Random random = new Random();
                int randomNumber = random.Next(1, 6);
                textBox2.Text += $"Танк {t3485.TankName} нанес " + randomNumber * t3485.TankDamage + "  единиц урона\r\n";
                overallDamage += randomNumber * t3485.TankDamage;
                textBox3.Text = "Overall = " + overallDamage;
                overallShot += randomNumber;

                randomNumber = random.Next(1, 3);
                if (randomNumber == 1)
                {
                    int supportShot = t3485.MakeSupportShot();
                    textBox2.Text += $"Танк {t3485.TankName} нанес " + supportShot + "  единиц урона с помощью выстрела поддержки\r\n";
                    overallDamage += supportShot;
                    textBox3.Text = "Overall = " + overallDamage;
                    overallShot++;
                }
            }
            button7.Enabled = false;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            int exp = t43.ExploreTank();
            int money = t43.BuyTank();
            Exp = Exp - exp;
            Money = Money - money;
            if (Exp < 0 || Money < 0)
            {
                MessageBox.Show("Недостаточно ресурсов");
                Exp = Exp + exp;
                Money = Money + money;
            }
            else
            {
                t43.InstallSupportEquipment();
                textBox1.Text = "Exp: " + Exp.ToString() + "     RUB: " + Money.ToString();
                textBox2.Text += $"\r\nИсследован танк {t43.TankName}. Потрачено опыта: " + exp + ". Потрачено рублей: " + money + "\r\n";

                Random random = new Random();
                int randomNumber = random.Next(1, 6);
                textBox2.Text += $"Танк {t43.TankName} нанес " + randomNumber * t43.TankDamage + "  единиц урона\r\n";
                overallDamage += randomNumber * t43.TankDamage;
                textBox3.Text = "Overall = " + overallDamage;
                overallShot += randomNumber;

                randomNumber = random.Next(1, 4);
                if (randomNumber == 1)
                {
                    int supportShot = t43.MakeSupportShot();
                    textBox2.Text += $"Танк {t43.TankName} нанес " + supportShot + "  единиц урона с помощью выстрела поддержки\r\n";
                    overallDamage += supportShot;
                    textBox3.Text = "Overall = " + overallDamage;
                    overallShot++;
                }
            }
            button8.Enabled = false;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            int exp = kv2.ExploreTank();
            int money = kv2.BuyTank();
            Exp = Exp - exp;
            Money = Money - money;
            if (Exp < 0 || Money < 0)
            {
                MessageBox.Show("Недостаточно ресурсов");
                Exp = Exp + exp;
                Money = Money + money;
            }
            else
            {
                kv2.InstallArmor();
                textBox1.Text = "Exp: " + Exp.ToString() + "     RUB: " + Money.ToString();
                textBox2.Text += $"\r\nИсследован танк {kv2.TankName}. Потрачено опыта: " + exp + ". Потрачено рублей: " + money + "\r\n";
                textBox2.Text += kv2.GetCollect() + "\r\n";

                Random random = new Random();
                int randomNumber = random.Next(1, 3);
                textBox2.Text += $"Танк {kv2.TankName} нанес " + randomNumber * kv2.TankDamage + "  единиц урона\r\n";
                overallDamage += randomNumber * kv2.TankDamage;
                textBox3.Text = "Overall = " + overallDamage;
                overallShot += randomNumber;

                randomNumber = random.Next(1, 5);
                if (randomNumber == 1)
                {
                    int powerfulShot = kv2.MakePowerfulShot();
                    textBox2.Text += $"Танк {kv2.TankName} нанес " + powerfulShot + "  единиц урона с помощью мощного выстрела\r\n";
                    overallDamage += powerfulShot;
                    textBox3.Text = "Overall = " + overallDamage;
                    overallShot++;
                }
            }
            button9.Enabled = false;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            int exp = kv1s.ExploreTank();
            int money = kv1s.BuyTank();
            Exp = Exp - exp;
            Money = Money - money;
            if (Exp < 0 || Money < 0)
            {
                MessageBox.Show("Недостаточно ресурсов");
                Exp = Exp + exp;
                Money = Money + money;
            }
            else
            {
                kv1s.InstallArmor();
                textBox1.Text = "Exp: " + Exp.ToString() + "     RUB: " + Money.ToString();
                textBox2.Text += $"\r\nИсследован танк {kv1s.TankName}. Потрачено опыта: " + exp + ". Потрачено рублей: " + money + "\r\n";

                Random random = new Random();
                int randomNumber = random.Next(1, 4);
                textBox2.Text += $"Танк {kv1s.TankName} нанес " + randomNumber * kv1s.TankDamage + "  единиц урона\r\n";
                overallDamage += randomNumber * kv1s.TankDamage;
                textBox3.Text = "Overall = " + overallDamage;
                button13.Enabled = true;
                button14.Enabled = true;
                overallShot += randomNumber;

                randomNumber = random.Next(1, 4);
                if (randomNumber == 1)
                {
                    int powerfulShot = kv1s.MakePowerfulShot();
                    textBox2.Text += $"Танк {kv1s.TankName} нанес " + powerfulShot + "  единиц урона с помощью мощного выстрела\r\n";
                    overallDamage += powerfulShot;
                    textBox3.Text = "Overall = " + overallDamage;
                    overallShot++;
                }
            }
            button10.Enabled = false;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            int exp = lttb.ExploreTank();
            int money = lttb.BuyTank();
            Exp = Exp - exp;
            Money = Money - money;
            if (Exp < 0 || Money < 0)
            {
                MessageBox.Show("Недостаточно ресурсов");
                Exp = Exp + exp;
                Money = Money + money;
            }
            else
            {
                lttb.InstallOptics();
                textBox1.Text = "Exp: " + Exp.ToString() + "     RUB: " + Money.ToString();
                textBox2.Text += $"\r\nИсследован танк {lttb.TankName}. Потрачено опыта: " + exp + ". Потрачено рублей: " + money + "\r\n";

                Random random = new Random();
                int randomNumber = random.Next(1, 8);
                textBox2.Text += $"Танк {lttb.TankName} нанес " + randomNumber * lttb.TankDamage + "  единиц урона\r\n";
                overallDamage += randomNumber * lttb.TankDamage;
                textBox3.Text = "Overall = " + overallDamage;
                overallShot += randomNumber;

                randomNumber = random.Next(1, 3);
                if (randomNumber == 1)
                {
                    int lightShot = lttb.MakeLightUpShot();
                    textBox2.Text += $"Танк {lttb.TankName} нанес " + lightShot + "  единиц урона с помощью выстрела засвета\r\n";
                    overallDamage += lightShot;
                    textBox3.Text = "Overall = " + overallDamage;
                    overallShot++;
                }

                randomNumber = random.Next(1, 3);
                int extrLightShot = lttb.MakeLightUpShot(10 * randomNumber);
                textBox2.Text += $"Танк {lttb.TankName} нанес " + extrLightShot + "  единиц урона с помощью дополнительного выстрела засвета\r\n";
                overallDamage += extrLightShot;
                textBox3.Text = "Overall = " + overallDamage;
                overallShot++;
            }
            button11.Enabled = false;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            int exp = ltg.ExploreTank();
            int money = ltg.BuyTank();
            Exp = Exp - exp;
            Money = Money - money;
            if (Exp < 0 || Money < 0)
            {
                MessageBox.Show("Недостаточно ресурсов");
                Exp = Exp + exp;
                Money = Money + money;
            }
            else
            {
                ltg.InstallOptics();
                textBox1.Text = "Exp: " + Exp.ToString() + "     RUB: " + Money.ToString();
                textBox2.Text += $"\r\nИсследован танк {ltg.TankName}. Потрачено опыта: " + exp + ". Потрачено рублей: " + money + "\r\n";

                Random random = new Random();
                int randomNumber = random.Next(1, 8);
                textBox2.Text += $"Танк {ltg.TankName} нанес " + randomNumber * ltg.TankDamage + "  единиц урона\r\n";
                overallDamage += randomNumber * ltg.TankDamage;
                textBox3.Text = "Overall = " + overallDamage;
                overallShot += randomNumber;

                randomNumber = random.Next(1, 3);
                if (randomNumber == 1)
                {
                    int lightShot = ltg.MakeLightUpShot();
                    textBox2.Text += $"Танк {ltg.TankName} нанес " + lightShot + "  единиц урона с помощью выстрела засвета\r\n";
                    overallDamage += lightShot;
                    textBox3.Text = "Overall = " + overallDamage;
                    overallShot++;
                }

                randomNumber = random.Next(1, 5);
                int randomNumber1 = random.Next(0, 3);
                int extrLightShot = ltg.MakeLightUpShot(10 * randomNumber, 10 * randomNumber1);
                textBox2.Text += $"Танк {ltg.TankName} нанес " + extrLightShot + "  единиц урона с помощью дополнительного выстрела засвета\r\n";
                overallDamage += extrLightShot;
                textBox3.Text = "Overall = " + overallDamage;
                overallShot++;
            }
            button12.Enabled = false;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            int exp = kv3.ExploreTank();
            int money = kv3.BuyTank();
            Exp = Exp - exp;
            Money = Money - money;
            if (Exp < 0 || Money < 0)
            {
                MessageBox.Show("Недостаточно ресурсов");
                Exp = Exp + exp;
                Money = Money + money;
            }
            else
            {
                kv3.InstallArmor();
                textBox1.Text = "Exp: " + Exp.ToString() + "     RUB: " + Money.ToString();
                textBox2.Text += $"\r\nИсследован танк {kv3.TankName}. Потрачено опыта: " + exp + ". Потрачено рублей: " + money + "\r\n";

                Random random = new Random();
                int randomNumber = random.Next(1, 5);
                textBox2.Text += $"Танк {kv3.TankName} нанес " + randomNumber * kv3.TankDamage + "  единиц урона\r\n";
                overallDamage += randomNumber * kv3.TankDamage;
                textBox3.Text = "Overall = " + overallDamage;
                button13.Enabled = true;
                button14.Enabled = true;
                overallShot += randomNumber;

                randomNumber = random.Next(1, 4);
                if (randomNumber == 1)
                {
                    int powerfulShot = kv3.MakePowerfulShot();
                    textBox2.Text += $"Танк {kv3.TankName} нанес " + powerfulShot + "  единиц урона с помощью мощного выстрела\r\n";
                    overallDamage += powerfulShot;
                    textBox3.Text = "Overall = " + overallDamage;
                    overallShot++;
                }

                randomNumber = random.Next(0, 2);
                int extrShot = kv3.MakePowerfulShot(randomNumber);
                textBox2.Text += $"Танк {kv3.TankName} нанес " + extrShot + "  единиц урона с помощью дополнительного мощного выстрела\r\n";
                overallDamage += extrShot;
                textBox3.Text = "Overall = " + overallDamage;
                overallShot++;
            }
            button13.Enabled = false;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            int exp = iS.ExploreTank();
            int money = iS.BuyTank();
            Exp = Exp - exp;
            Money = Money - money;
            if (Exp < 0 || Money < 0)
            {
                MessageBox.Show("Недостаточно ресурсов");
                Exp = Exp + exp;
                Money = Money + money;
            }
            else
            {
                iS.InstallArmor();
                textBox1.Text = "Exp: " + Exp.ToString() + "     RUB: " + Money.ToString();
                textBox2.Text += $"\r\nИсследован танк {iS.TankName}. Потрачено опыта: " + exp + ". Потрачено рублей: " + money + "\r\n";

                Random random = new Random();
                int randomNumber = random.Next(1, 5);
                textBox2.Text += $"Танк {iS.TankName} нанес " + randomNumber * iS.TankDamage + "  единиц урона\r\n";
                overallDamage += randomNumber * iS.TankDamage;
                textBox3.Text = "Overall = " + overallDamage;
                button13.Enabled = true;
                button14.Enabled = true;
                overallShot += randomNumber;

                randomNumber = random.Next(1, 4);
                if (randomNumber == 1)
                {
                    int powerfulShot = iS.MakePowerfulShot();
                    textBox2.Text += $"Танк {iS.TankName} нанес " + powerfulShot + "  единиц урона с помощью мощного выстрела\r\n";
                    overallDamage += powerfulShot;
                    textBox3.Text = "Overall = " + overallDamage;
                    overallShot++;
                }

                randomNumber = random.Next(0, 3);
                int randomNumber1 = random.Next(0, 2);
                int extrShot = iS.MakePowerfulShot(randomNumber, randomNumber1);
                textBox2.Text += $"Танк {iS.TankName} нанес " + extrShot + "  единиц урона с помощью дополнительного мощного выстрела\r\n";
                overallDamage += extrShot;
                textBox3.Text = "Overall = " + overallDamage;
                overallShot++;
            }
            button14.Enabled = false;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            var logger = Log.getLog();
            if (overallDamage > winDamage)
            {
                MessageBox.Show($"Ты нанес {overallDamage} урона и победил! Поздравляем!");
                logger.AddLog("you win");
            }
            else
            {
                MessageBox.Show($"Ты нанес {overallDamage} урона, но этого не хватило для победы!");
                logger.AddLog("you lose");
            }

            
            logger.AddLog("program finished\n");
            Close();

        }
        
        private void button16_Click(object sender, EventArgs e)
        {
            try
            {
                // Попытка деления на ноль
                double result = DivideNumbers(overallDamage, overallShot);
                MessageBox.Show($"Средний урон за выстрел: {Math.Round(result)}");
            }
            catch (MyDivideByZeroException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        static double DivideNumbers(int numerator, int denominator)
        {
            if (denominator == 0)
            {
                throw new MyDivideByZeroException(); // Генерация переопределенного исключения
            }
            return (double)numerator / denominator;
        }

        public delegate void MyDelegate();
        private void button17_Click(object sender, EventArgs e)
        {
            MyDelegate multiDelegate = null;
            multiDelegate += bt7.Shoot;
            multiDelegate += a20.Shoot;
            multiDelegate += mt25.Shoot;
            multiDelegate += ltg.Shoot;
            multiDelegate += lttb.Shoot;

            multiDelegate += kv1.Shoot;
            multiDelegate += kv1s.Shoot;
            multiDelegate += kv2.Shoot;
            multiDelegate += kv3.Shoot;
            multiDelegate += iS.Shoot;

            multiDelegate += t34.Shoot;
            multiDelegate += t3485.Shoot;
            multiDelegate += t43.Shoot;


            // Вызываем делегат, что вызовет все добавленные методы
            multiDelegate?.Invoke();
            MessageBox.Show("Делегат вызван. Данный про базовый урон танков сохранены в лог.");
        }
    }
}