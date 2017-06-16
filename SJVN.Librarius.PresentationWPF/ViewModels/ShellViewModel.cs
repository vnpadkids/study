using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SJVN.Librarius.PresentationWPF.ViewModels
{
    public class ShellViewModel
    {
        private readonly IWindowManager windowManager;

        public ShellViewModel(IWindowManager windowManager)
        {
            this.windowManager = windowManager;
        }

        public void CloseProgramMenuItem()
        {
        }

        public void ManageCategoriesMenuItem()
        {
            windowManager.ShowWindow(IoC.Get<CategoryManagementViewModel>());
        }
    }
}
