using System;
using System.ComponentModel;
using System.Threading;
using System.Windows;
using Xceed.Wpf.Toolkit;

namespace Caliburn.Micro.Hello
{
    /// <summary>
    /// MainWindowView.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindowView : Window
    {
        public MainWindowView()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            BusyIndicator.IsBusy = true;
            BusyIndicator.BusyContent = "Initializing...";
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += (o, a) =>
            {
                for (int index = 0; index < 1; index++)
                {
                    Dispatcher.Invoke(() =>
                    {
                        BusyIndicator.BusyContent = "Window Loading : " + index;
                    });
                    Thread.Sleep(new TimeSpan(0, 0, 1));
                }
            };
            worker.RunWorkerCompleted += (o, a) =>
            {
                BusyIndicator.IsBusy = false;
            };
            worker.RunWorkerAsync();
        }
    }

}

