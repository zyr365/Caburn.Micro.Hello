using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows;

namespace Caliburn.Micro.Hello
{
    public class HelloBootstrapper : BootstrapperBase
    {
        public HelloBootstrapper()
        {
            Initialize();
        }
        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            //DisplayRootViewFor<MainWindowViewModel>();
            DisplayRootViewFor<ILogin>();
        }
        private SimpleContainer container;
        protected override void Configure()
        {
            container = new SimpleContainer();
            container.Singleton<IWindowManager, WindowManager>();
            container.Singleton<IEventAggregator, EventAggregator>();
            //container.Singleton<IViewModel, SimpleContainerViewModel>();
            container.Singleton<IViewModel, ShellViewModel>();
            container.Singleton<IViewModel, EventAggregatorViewModel>();
            container.Singleton<IViewModel, ConductorViewModel>();
            container.Singleton<IViewModel, IndicatorLightViewModel>();
            container.Singleton<IViewModel, MatchTemplateViewModel>();
            container.Singleton<IViewModel, FTPTestViewModel>();
            container.Singleton<IViewModel,SimpleContainerViewModel>("SimpleContainerViewModel");//注册实例方法1 有key
            //container.Singleton<SimpleContainerViewModel> ();//注册实例方法1 没有key
            container.Singleton<IViewModel,MemorandumViewModel>();//注册实例
            container.Singleton<IViewModel, HelpMeViewModel>();//注册实例
            #region 其它注册方法
            //container.RegisterSingleton(typeof(SimpleContainerViewModel), "SimpleContainerViewModel", typeof(SimpleContainerViewModel));//注册实例方法2
            //container.RegisterInstance(typeof(SimpleContainerViewModel), "SimpleContainerViewModel", new SimpleContainerViewModel()); //注册实例方法3
            #endregion
            //container.PerRequest<MainWindowViewModel>(); //按照请求注册实例方法1,非单实例
            container.Singleton<IShell,MainWindowViewModel>(); //按照请求注册实例方法1
            container.Singleton<ILogin,LoginViewModel>();
            //container.RegisterPerRequest(typeof(ShellViewModel), "ShellViewModel", typeof(ShellViewModel));//按照请求注册实例方法2
        }
        protected override object GetInstance(Type service, string key)
        {
            return container.GetInstance(service, key);
        }
        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return container.GetAllInstances(service);
        }
        protected override void BuildUp(object instance)
        {
            container.BuildUp(instance);
        }
        #region
        protected override IEnumerable<Assembly> SelectAssemblies()
        {
            return new[] { Assembly.GetExecutingAssembly() };
        }
        #endregion
    }
    public interface IViewModel
    {

    }
    public interface ILogin
    {

    }
    public interface IShell
    {

    }
}