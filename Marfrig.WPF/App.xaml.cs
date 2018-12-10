using Marfrig.WPF.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Marfrig.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : System.Windows.Application
    {
        public static MainWindow TelaPrincipal()
        {
            return System.Windows.Application.Current.MainWindow as MainWindow;
        }

        private async void Application_Startup(object sender, StartupEventArgs e)
        {
            await AutenticacaoService.Autenticar();
        }
    }
}
