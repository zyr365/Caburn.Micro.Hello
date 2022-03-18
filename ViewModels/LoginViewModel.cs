using PropertyChanged;
using System.Text;
using System.Windows;

namespace Caliburn.Micro.Hello
{
    [AddINotifyPropertyChangedInterface]
    public class LoginViewModel :Screen, ILogin
    {
        private static readonly log4net.ILog loginfo = log4net.LogManager.GetLogger("MainWindowViewModel");
        public UserInformation UserInformation { get; set; }
        public LoginViewModel()
        {
            loginfo.Debug($"Enter [LoginViewModel].");
            UserInformation = new UserInformation();
            loginfo.Debug($"Leave [LoginViewModel].");
        }
        public void BtnLogin()
        {
            var str = ValidateLoginData();
            if(!string.IsNullOrEmpty(str))
            {
                MessageBox.Show(str);
 
            }
            else 
            {
                var loginWindow = (Window)this.GetView();
                loginWindow.Hide();

                IShell mainWindowViewModel = IoC.Get<IShell>();
                IWindowManager windowManager = IoC.Get<IWindowManager>();
                windowManager.ShowDialog(mainWindowViewModel);
                this.TryClose();
            }

        }

        public void BtnClose()
        {
            this.TryClose();
        }

        public string ValidateLoginData()
        {
            StringBuilder sb = new StringBuilder();
            if (UserInformation.UserName == "zls20210502"
                    && UserInformation.Password == "12345678")
            {
                sb.Append("");
            }
            else
            {
                sb.AppendLine("账号或者密码输入有误,请检查！");
            }
            return sb.ToString();
        }
    }
}
