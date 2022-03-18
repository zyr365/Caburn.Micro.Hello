using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caliburn.Micro.Hello
{
    public class ConductorViewModel : Conductor<object>, IViewModel
    {
        public ConductorViewModel()
        {
            DisplayName = "Conductor";
            ShowPageOne();
        }
        public void ShowPageOne()
        {
            ActivateItem(new ShellViewModel());
        }

        public void ShowPageTwo()
        {
            ActivateItem(EventAggregatorViewModel.Instance);
        }

    }
}
