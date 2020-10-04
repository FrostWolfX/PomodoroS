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
        public MainWindow()
        {
            InitializeComponent();
        }
        //public string TextboxText
        //{
        //    get { return TimePomodoroLabel.Content.ToString(); }
        //    set { TimePomodoroLabel.Content = value; }
        //}
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
            onePomodoro = new Class.OnePomodoro(10, 5, 15);
        }
    }
}
