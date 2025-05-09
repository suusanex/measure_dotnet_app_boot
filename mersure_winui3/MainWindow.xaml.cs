using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace mersure_winui3
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();


            this.Activated += (s, e) =>
            {
                this.DispatcherQueue.TryEnqueue(async () =>
                {
                    IntPtr handle = NativeMethods.GetCurrentProcess();
                    NativeMethods.GetProcessTimes(handle, out NativeMethods.FILETIME creationTime, out _, out _, out _);

                    DateTime startTime = NativeMethods.FileTimeToDateTime(creationTime);
                    TimeSpan elapsed = DateTime.Now - startTime;
                    myButton.Content = $"From Process CreationTime:{elapsed}";
                });
            };
        }

        private void myButton_Click(object sender, RoutedEventArgs e)
        {
            myButton.Content = "Clicked";
        }

    }
}
