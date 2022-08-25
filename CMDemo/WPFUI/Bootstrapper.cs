using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Caliburn.Micro;
using WPFUI.ViewModels;

namespace WPFUI
{
    public class Bootstrapper : BootstrapperBase
    {
        public Bootstrapper()
        {
            Initialize();
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            // Obs.: Tive que usar o pacote de versão 4.0.173 inves do 4.0.210 pelo fato desse paramentro não ter mais suporte
            // ao método DisplayRootViewFor, sendo alterado por um método asincrono (DisplayRootViewForAsync) no qual,
            // não atualiza a tela instantaneamente.
            // Para efeitos de estudo, vou manter a versão que tem suporte ao método usado no curso.
            DisplayRootViewFor<ShellViewModel>();
        }
    }
}
