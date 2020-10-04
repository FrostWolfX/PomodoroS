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
        private int MinTimeCounter = 0;
        private int RelaxTime;
        private int BigRelaxTime;

        private int RealTimerCounter;
        private DispatcherTimer dispatcherTimer;

        MainWindow Form = Application.Current.Windows[0] as MainWindow;

        //свойства переменных
        public OnePomodoro(int maxTime, int relaxTime, int bigRelaxTime)
        {
            RealTimerCounter = Math.Abs(maxTime);
            RelaxTime = Math.Abs(relaxTime);
            BigRelaxTime = Math.Abs(bigRelaxTime);
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
            if (RealTimerCounter-- > MinTimeCounter)
            {
                int resultMinutes = RealTimerCounter / 60;
                int resultSeconds = RealTimerCounter % 60;
                Form.TimePomodoroLabel.Content = $"{resultMinutes}:{resultSeconds}";

            }
            else
            {
                System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"C:\Windows\Media\chimes.wav");
                player.Play();
                dispatcherTimer.Stop();
            }
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
