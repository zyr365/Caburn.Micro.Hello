using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caliburn.Micro.Hello.Models
{
    public class ShowScreen : IResult
    {
        readonly Type screenType;
        readonly string name;
        [Import]
        public IShell Shell { get; set; }

        public ShowScreen(string name)
        {
            this.name = name;
        }

        public ShowScreen(Type screenType)
        {
            this.screenType = screenType;
        }
        public void Execute(CoroutineExecutionContext context)
        {
            var screen = !string.IsNullOrEmpty(name)
                ? IoC.Get<object>(name)
                : IoC.GetInstance(screenType, null);

            //Shell.ActivateItem(screen);
            Completed(this, new ResultCompletionEventArgs());
        }

        public event EventHandler<ResultCompletionEventArgs> Completed = delegate { };

        public static ShowScreen Of<T>()
        {
            return new ShowScreen(typeof(T));
        }
    }
}
