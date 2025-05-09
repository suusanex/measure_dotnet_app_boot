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

namespace measure_wpf_dotnetf
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            Dispatcher.BeginInvoke(new Action(() =>
            {

                IntPtr handle = NativeMethods.GetCurrentProcess();
                NativeMethods.GetProcessTimes(handle, out NativeMethods.FILETIME creationTime, out _, out _, out _);

                DateTime startTime = NativeMethods.FileTimeToDateTime(creationTime);
                TimeSpan elapsed = DateTime.Now - startTime;

                MessageBox.Show($"From Process CreationTime:{elapsed}");

            }));


        }
    }
}
