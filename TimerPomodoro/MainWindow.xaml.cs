using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TimerPomodoro
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Class.OnePomodoro onePomodoro;
        int timePomodoro;
        int timeShortBreak;
        int timeLongBreak;
        int timeCounter = 4;

        public MainWindow()
        {
            InitializeComponent();
            timePomodoro = Int32.TryParse(TimePomodoro.Text, out timePomodoro) ? Convert.ToInt32(TimePomodoro.Text) : 25;
            timeShortBreak = Int32.TryParse(TimeShortBreak.Text, out timeShortBreak) ? Convert.ToInt32(TimeShortBreak.Text) : 5;
            timeLongBreak = Int32.TryParse(TimeLongBreak.Text, out timeLongBreak) ? Convert.ToInt32(TimeLongBreak.Text) : 15;
            onePomodoro = new Class.OnePomodoro(timePomodoro, timeShortBreak, timeLongBreak, timeCounter);
        }
        private void ButtonStartTimer_Click(object sender, RoutedEventArgs e)
        {
            onePomodoro.StartTimer();
        }

        private void ButtonStopTimer_Click(object sender, RoutedEventArgs e)
        {
            onePomodoro.StopTimer();
        }

        private void Form1_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            onePomodoro.StopTimer();
            timePomodoro = Int32.TryParse(TimePomodoro.Text, out timePomodoro) ? Convert.ToInt32(TimePomodoro.Text) : 25;
            timeShortBreak = Int32.TryParse(TimeShortBreak.Text, out timeShortBreak) ? Convert.ToInt32(TimeShortBreak.Text) : 5;
            timeLongBreak = Int32.TryParse(TimeLongBreak.Text, out timeLongBreak) ? Convert.ToInt32(TimeLongBreak.Text) : 15;
            onePomodoro = new Class.OnePomodoro(timePomodoro, timeShortBreak, timeLongBreak, timeCounter);
        }

        private static bool notNumber = false;
        private void TimePomodoro_KeyDown(object sender, KeyEventArgs e)
        {
            inputText(e);
        }
        private KeyEventArgs inputText(KeyEventArgs e)
        {
            e.Handled = true;
            if ((e.Key >= Key.D0 && e.Key <= Key.D9) || (e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9) || e.Key == Key.Back)
            {
                e.Handled = false;
            }
            return e;
        }

        private void TimeShortBreak_KeyDown(object sender, KeyEventArgs e)
        {
            inputText(e);
        }

        private void TimeLongBreak_KeyDown(object sender, KeyEventArgs e)
        {
            inputText(e);
        }
    }
}
