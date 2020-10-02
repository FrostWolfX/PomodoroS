using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace PomodoroS
{
    class SmallTimer
    {
        private int Minutes; 

        public SmallTimer(int minutes)
        {
            Minutes = minutes;
            Timer();
        }

        public void Timer()
        {
            // устанавливаем метод обратного вызова
            TimerCallback tm = new TimerCallback(Count);
            // создаем таймер
            Timer timer = new Timer(tm, Minutes, 0, 1000);
        }
        public void Count(object obj)
        {
            int x = (int)obj;
        }
    }
}
