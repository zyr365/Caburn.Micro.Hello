using PropertyChanged;
using System.Threading;
using System.Windows;
using System.Windows.Media;
using Brush = System.Windows.Media.Brush;

namespace Caliburn.Micro.Hello
{
    [AddINotifyPropertyChangedInterface]
    public class IndicatorLightViewModel : Screen,IViewModel
    {
        public Visibility DisplaySwitch { get; set; } = Visibility.Hidden;
        public string LabelText { get; set; }

        public Brush ForeColor { get; set; }

        private Thread workTask;
        public IndicatorLightViewModel()
        {
            DisplayName = "IndicatorLight";
            ForeColor = new SolidColorBrush(Color.FromRgb(255, 0, 0));
        }
        public void StartBtn()
        {
            DisplaySwitch = Visibility.Visible;
            LabelText = "●";
            if (workTask == null || !workTask.IsAlive)
            {
                workTask = new Thread(IndicatorLightOperation);//添加线程 
                workTask.IsBackground = true;
                workTask.Start();
            }
        }
        public void StopBtn()
        {
            if (workTask == null || workTask.IsAlive)
            {
                workTask.Abort();
            }
            DisplaySwitch = Visibility.Hidden;
        }

        public void IndicatorLightOperation()
        {
            while (true)
            {
                Execute.OnUIThread(()=>
                {
                    if (((SolidColorBrush)ForeColor).Color.Equals(Color.FromRgb(255, 0, 0)))
                    {
                        ForeColor = new SolidColorBrush(Color.FromRgb(0, 255, 0));
                    }
                    else
                    {
                        ForeColor = new SolidColorBrush(Color.FromRgb(255, 0, 0));
                    }
                });
                Thread.Sleep(500);
            }

        }
    }
}
