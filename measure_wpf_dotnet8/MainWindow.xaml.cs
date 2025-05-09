using measure_wpf_dotnetf;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace measure_wpf_dotnet8
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {

            Dispatcher.BeginInvoke(() =>
            {

                IntPtr handle = NativeMethods.GetCurrentProcess();
                NativeMethods.GetProcessTimes(handle, out NativeMethods.FILETIME creationTime, out _, out _, out _);

                DateTime startTime = NativeMethods.FileTimeToDateTime(creationTime);
                TimeSpan elapsed = DateTime.Now - startTime;

                MessageBox.Show($"From Process CreationTime:{elapsed}");

            });
        }
    }
}