using PropertyChanged;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Caliburn.Micro.Hello
{
    [AddINotifyPropertyChangedInterface]
    public class MainWindowViewModel : Conductor<IViewModel>.Collection.OneActive, IShell
    {
        private static readonly Common.Logging.ILog logger = Common.Logging.LogManager.GetLogger<MainWindowViewModel>();
        public MainWindowViewModel(IEnumerable<IViewModel> modules)
        {
            logger.Debug($"Enter [MainWindowViewModel].");
            DisplayName = "MainWindow";
            Items.AddRange(modules);
            ActivateItem(Items.FirstOrDefault(vm => vm.GetType() ==typeof(IndicatorLightViewModel)));
            logger.Info($"Leave [MainWindowViewModel].");
        }


        protected override void OnDeactivate(bool close)
        {
            base.OnDeactivate(close);
        }
        protected override void OnActivate()
        {
            base.OnActivate();
        }
    }
}
