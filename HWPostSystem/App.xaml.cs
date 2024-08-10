using HWPostSystem.Views;
using System.Configuration;
using System.Data;
using System.Windows;

namespace HWPostSystem
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void ApplicationStart(object sender, StartupEventArgs e)
        {
            var loginView = new LoginView();
            loginView.Show();

            loginView.IsVisibleChanged += async (s, ev) =>
            {
                if (loginView.IsVisible == false && loginView.IsLoaded)
                {
                    await Task.Run(() =>
                    {
                        System.Threading.Thread.Sleep(100); // Give a brief delay to ensure the loginView is fully closed.
                    });

                    var mainView = new MainWindow();
                    mainView.Show();
                    //loginView.Close();
                    loginView.Dispatcher.Invoke(() => loginView.Close());
                }
            };

        }
    }

}
