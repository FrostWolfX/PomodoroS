using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Threading.Tasks;

namespace PomodoroS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int timeMinute;
        public MainWindow()
        {
            InitializeComponent();
            timeMinute = Convert.ToInt32(SettingPomodoroTime.Text);
        }



        private void SaveSettings_Click(object sender, RoutedEventArgs e)
        {

        }
        private void PomodoroStart_Click(object sender, RoutedEventArgs e)
        {
            SmallTimer smallTimer = new SmallTimer(timeMinute);
        }
    }
}
