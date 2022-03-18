using PropertyChanged;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using Xceed.Wpf.Toolkit;
using MessageBox = System.Windows.MessageBox;

namespace Caliburn.Micro.Hello
{
    [AddINotifyPropertyChangedInterface]
    public class SimpleContainerViewModel : Screen, IViewModel
    {
        public string TextContent { get; set; }
        private IEventAggregator eventAggregator;
        public bool IsShow { get; set; }
        public SimpleContainerViewModel()
        {
            DisplayName = "SimpleContainer";
        }
        public void ClickCtr()
        {
            TextContent = "I am  a  SimpleContainerView,ClickCtr";
            //NotifyOfPropertyChange(() => TextContent);
        }
        public void ClickBtn()
        {
            TextContent = "I am  a  SimpleContainerView,ClickBtn";
            //NotifyOfPropertyChange(() => TextContent);
        }

        public void EventTest()
        {
            IsShow = true;
            this.eventAggregator = IoC.Get<IEventAggregator>();
            //方法1 同步ui发布事件
            this.eventAggregator.PublishOnUIThread("i am a chinese");
            //方法2 开线程去发布
            this.eventAggregator.Publish(new PersonInfoEven() {
                Name = "ZYR", Age = 18, Sex = "man" }, 
                action =>
            {
                //方式①
                //Task.Factory.StartNew(action);
                //方式②
                Task.Run(action);
            });
            Task.Run(() =>
            {
                Thread.Sleep(1000);
                IsShow = false;
                //MessageBox.Show("事件已成功发送!");
            });
        }
        public IEnumerable<IResult> EventTest_test()
        {
               yield return  Loader.Show("load.....");

              yield return  Loader.Show("Ok!");
        }
    }
}
