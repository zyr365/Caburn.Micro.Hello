using Caliburn.Micro;
using System;
using System.Windows;
using System.Windows.Controls;
using Xceed.Wpf.Toolkit;

namespace Caliburn.Micro.Hello
{
    public class Loader : IResult
    {
        readonly string message;
        readonly bool hide;

        public Loader(string message)
        {
            this.message = message;
        }

        public Loader(bool hide)
        {
            this.hide = hide;
        }

        public void Execute(CoroutineExecutionContext context)
        {
            var view = context.View as FrameworkElement;
            while (view != null)
            {
                var busyIndicator = view as BusyIndicator;
                if (busyIndicator != null)
                {
                    if (!string.IsNullOrEmpty(message))
                        busyIndicator.BusyContent = message;
                    busyIndicator.IsBusy = !hide;
                    break;
                }

                view = view.Parent as FrameworkElement;
            }

            Completed(this, new ResultCompletionEventArgs());
        }

        public event EventHandler<ResultCompletionEventArgs> Completed = delegate { };

        public static IResult Show(string message = null)
        {
            return new Loader(message);
        }

        public static IResult Hide()
        {
            return new Loader(true);
        }
    }

    // public class Loader : IResult

    //{
    //    readonly string _str;
    //    public Loader(string str)
    //    {
    //        _str = str;
    //    }

    //    public void Execute(CoroutineExecutionContext context)
    //    {
    //         System.Windows.MessageBox.Show(_str + context.View);
    //         Completed(this, new ResultCompletionEventArgs());//这个方法一定要加到这里，这个方法完成后才会执行后边的方法
    //     }
    //     public event EventHandler<ResultCompletionEventArgs> Completed = (sender, args) =>
    //     {
    //         System.Windows.MessageBox.Show(((Loader)sender)._str);
    //      };

    // }

}


