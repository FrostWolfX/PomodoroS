using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;


namespace TimerPomodoro.Class
{
    class OnePomodoro
    {
        private int RelaxTime;
        private int BigRelaxTime;
        private int CountInterval;
        private int RealTimerCounter;
        private int TimeWork;
        private bool workTime = true;
        bool bigRelax = false;

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
                if (CountInterval % 2 == 0 && workTime == true)
                {
                    workTime = false;
                    RealTimerCounter = TimeWork;
                    Form.Attention.Content = "Time to work!";
                    Form.Form1.Title = "WORK";
                }
                if (CountInterval % 2 != 0 && workTime == true)
                {
                    Form.Attention.Content = "Relax time!";
                    Form.Form1.Title = "RELAX";
                }

                int resultMinutes = RealTimerCounter / 60;
                int resultSeconds = (RealTimerCounter) % 60;
                Form.TimePomodoroLabel.Content = $"{resultMinutes}:{resultSeconds}";
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
