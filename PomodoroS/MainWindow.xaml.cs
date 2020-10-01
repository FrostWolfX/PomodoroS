using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PomodoroS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            TimePomodoro.Content = SettingPomodoroTime.SelectedItem;
        }
        DateTime dateTime(int time)
        {
            DateTime timeNow = DateTime.Now;

            TimeSpan interval = new TimeSpan(0, time, 0);

            DateTime newTime = timeNow.Add(interval);

            return newTime;
        }

        private void SaveSettings_Click(object sender, RoutedEventArgs e)
        {

        }
        private void PomodoroStart_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(dateTime(Convert.ToInt32(SettingPomodoroTime.Text)).ToString());
        }
    }
}
