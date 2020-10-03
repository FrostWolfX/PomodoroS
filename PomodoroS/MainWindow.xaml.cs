using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace PomodoroS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int maxTimeCounter = 3600;
        int minTimeCounter = 0;
        DispatcherTimer dispatcherTimer;
        int dispatcherCounter;
        public MainWindow()
        {
            InitializeComponent();
            StartTimer();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        void StartTimer()
        {
            dispatcherCounter = minTimeCounter;
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Interval = TimeSpan.FromMilliseconds(1000);
            dispatcherTimer.Tick += DispatcherTimer_Tick;
        }

        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            TimePomodoroLabel.Content = (dispatcherCounter++).ToString();
            if (dispatcherCounter > maxTimeCounter)
            {
                dispatcherCounter = minTimeCounter;
            }
        }

        private void StartPomodoroButton_Click(object sender, RoutedEventArgs e)
        {
            dispatcherTimer.Start();
        }

        private void StopPomodoroButton_Click(object sender, RoutedEventArgs e)
        {
            dispatcherTimer.Stop();
        }
    }
}
