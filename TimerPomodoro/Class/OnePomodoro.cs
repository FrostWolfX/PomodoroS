using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using System.Drawing;


namespace TimerPomodoro.Class
{
    class OnePomodoro
    {
        private int RelaxTime;
        private int BigRelaxTime;
        private int CountInterval;
        private int RealTimerCounter;
        private int TimeWork;
        private string nameForm = "";
        private bool workTime = true;
        private bool bigRelax = false;

        private DispatcherTimer dispatcherTimer;
        readonly MainWindow Form = Application.Current.Windows[0] as MainWindow;

        //свойства переменных
        public OnePomodoro(int maxTime, int relaxTime, int bigRelaxTime, int countInterval)
        {
            //получаю секунды
            RealTimerCounter = Math.Abs(maxTime) * 60;
            TimeWork = Math.Abs(maxTime) * 60;
            RelaxTime = Math.Abs(relaxTime) * 60;
            BigRelaxTime = Math.Abs(bigRelaxTime) * 60;
            CountInterval = Math.Abs(countInterval);
            Timer1();
        }

        //функция таймера
        private void Timer1()
        {
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += DispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
        }

        //метод выполняется каждую секунду
        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            //остановка таймера после большого перерыва
            if (RealTimerCounter <= 0 && bigRelax == true)
            {
                dispatcherTimer.Stop();
            }
            //время уменьшается по 1 сек и выводится
            else if (RealTimerCounter-- > 0)
            {
                int resultMinutes = RealTimerCounter / 60;
                int resultSeconds = (RealTimerCounter) % 60;
                string timeToLabel = textTime(resultMinutes, resultSeconds);
                if (CountInterval % 2 == 0 && workTime == true)
                {
                    workTime = false;
                    RealTimerCounter = TimeWork;
<<<<<<< HEAD
                    nameForm = iconAndNameForm("WORK ", "Time to work!", "work.ico");
                }
                if (CountInterval % 2 != 0 && workTime == true)
                {
                    nameForm = iconAndNameForm("RELAX ", "Relax time!", "relax.ico");
=======
                    Form.Attention.Content = "Time to work!";
                    nameForm = "WORK ";
                    Form.Form1.Title = "WORK ";
                    Form.Form1.Icon = BitmapFrame.Create(new Uri("work.ico", UriKind.RelativeOrAbsolute));
                }
                if (CountInterval % 2 != 0 && workTime == true)
                {
                    Form.Attention.Content = "Relax time!";
                    nameForm = "RELAX ";
                    Form.Form1.Title = "RELAX ";
                    Form.Form1.Icon = BitmapFrame.Create(new Uri("relax.ico", UriKind.RelativeOrAbsolute));
>>>>>>> develop
                }
                Form.Form1.Title = nameForm + timeToLabel;


                Form.TimePomodoroLabel.Content = timeToLabel;
            }
            //если время закончилось, происходит звуковое оповещение и переключенние на перерыв/работу/большой перерыв
            else
            {
                //звуковое оповещение
                System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"C:\Windows\Media\Alarm04.wav");
                player.Play();
                dispatcherTimer.Stop();
                workTime = false;

                ///метод проверки чекед на то что прошел маленький перерыв
                
                //маленький перерыв после помидора
                if (CountInterval-- >= 0 && workTime == false)
                {
                    workTime = true;
                    TimerShort();
                }
                //большой перерыв после нескольких помидоров
                else if (CountInterval < 0)
                {
                    bigRelax = true;
                    TimerLong();
                }
            }
        }

        string textTime(int resultMinutes, int resultSeconds)
        {
<<<<<<< HEAD
            //вывод правильного времени с 2 числами например 04:45
=======
>>>>>>> develop
            if (resultMinutes.ToString().Length % 2 == 1 && resultSeconds.ToString().Length % 2 == 1)
            {
                return $"0{resultMinutes}:0{resultSeconds}";
            }
            if (resultMinutes.ToString().Length % 2 == 1)
            {
                if (resultSeconds.ToString().Length % 2 == 1)
                {
                    return $"{resultMinutes}:0{resultSeconds}";
                }
                return $"0{resultMinutes}:{resultSeconds}";
            }
            else if (resultSeconds.ToString().Length % 2 == 1)
            {
                if (resultMinutes.ToString().Length % 2 == 1)
                {
                    return $"{resultMinutes}:0{resultSeconds}";
                }
                return $"{resultMinutes}:0{resultSeconds}";
            }
            else
            {
                return $"{resultMinutes}:{resultSeconds}";
            }
<<<<<<< HEAD
        }
        string iconAndNameForm(string nameForm, string textTimer, string nameIcon)
        {
            Form.Attention.Content = textTimer;
            Form.Form1.Title = nameForm;
            Form.Form1.Icon = BitmapFrame.Create(new Uri(nameIcon, UriKind.RelativeOrAbsolute));
            return nameForm;
=======
            
>>>>>>> develop
        }

        private void TimerShort()
        {
            RealTimerCounter = RelaxTime;
            dispatcherTimer.Start();
        }
        private void TimerLong()
        {
            RealTimerCounter = BigRelaxTime;
            dispatcherTimer.Start();
        }
        //кнопка старт
        public void StartTimer()
        {
            dispatcherTimer.Start();
        }
        //кнопка стоп
        public void StopTimer()
        {
            dispatcherTimer.Stop();
        }
    }
}
