using PropertyChanged;

namespace Caliburn.Micro.Hello
{
    [AddINotifyPropertyChangedInterface]
    public class EventAggregatorViewModel : Screen ,IViewModel, IHandle<string>, IHandle<object>, IHandle<PersonInfoEven>
    {
        private readonly IEventAggregator eventAggregator;
        public string PersonInfo { get; set; }
        public string StringInfo { get; set; }
        public string ObjectInfo { get; set; }
        public EventAggregatorViewModel()
        {
            DisplayName = "EventAggregator";
            this.eventAggregator = IoC.Get<IEventAggregator>(); 
              this.eventAggregator.Subscribe(this);
        }
        private static EventAggregatorViewModel instance;
        private static object locker = new object();
        /// <summary>
        /// 双检锁
        /// </summary>
        public static EventAggregatorViewModel Instance
        {
            get
            {
                if (instance == null)
                {
                    lock(locker)
                    {
                        if (instance == null)
                        {
                            instance = new EventAggregatorViewModel();
                        }
                    }
                }
                return instance;
            }
        }
        public void Handle(string message)
        {
            StringInfo = message.ToString();
        }
        /// <summary>
        /// 因为字符串是从System.Object派生的，所以在发布字符串消息时将调用这个处理程序
        /// </summary>
        /// <param name="message"></param>
        public void Handle(object message)
        {
            ObjectInfo = message.ToString();
        }
        public void Handle(PersonInfoEven message)
        {
            PersonInfo = message.ToString();
        }
        protected override void OnDeactivate(bool close)
        {
            this.eventAggregator.Unsubscribe(this);
            base.OnDeactivate(close);
        }
    }
}
