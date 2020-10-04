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
        private bool Pomodoro = true;

        private DispatcherTimer dispatcherTimer;

        MainWindow Form = Application.Current.Windows[0] as MainWindow;

        //свойства переменных
        public OnePomodoro(int maxTime, int relaxTime, int bigRelaxTime, int countInterval)
        {
            //получаю секунды
            RealTimerCounter = Math.Abs(maxTime) * 60;
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
            if (RealTimerCounter-- > 0)
            {
                int resultMinutes = RealTimerCounter / 60;
                int resultSeconds = (RealTimerCounter) % 60;
                Form.TimePomodoroLabel.Content = $"{resultMinutes}:{resultSeconds}";

            }
            else
            {
                System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"C:\Windows\Media\chimes.wav");
                player.Play();
                dispatcherTimer.Stop();
                ///метод проверки чекед на то что прошел маленький перерыв
                if (CountInterval-- > 0)
                {
                    TimerShort();
                }
                else if (CountInterval == 0)
                {
                    TimerLong();
                }
            }
        }

        private void TimerShort()
        {
            Pomodoro = false;
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
