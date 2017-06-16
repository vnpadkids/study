using Caliburn.Micro;
using SJVN.Librarius.PresentationWPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SJVN.Librarius.PresentationWPF
{
    public partial class Bootstrapper : BootstrapperBase
    {
        private readonly SimpleContainer container;

        public Bootstrapper()
        {
            this.container = new SimpleContainer();

            Initialize();
        }

        protected override void Configure()
        {
            #region Caliburn.Micro

            container.Singleton<IWindowManager, WindowManager>();

            container.PerRequest<ShellViewModel>();
            #endregion

            ConfigureLibrarius();
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<ShellViewModel>();
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
    }
}
