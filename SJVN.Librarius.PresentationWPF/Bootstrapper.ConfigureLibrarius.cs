using SJVN.Librarius.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using SJVN.Librarius.Infrastructure.DatabaseContext;
using SJVN.Librarius.Domain.Repositories;
using SJVN.Librarius.Infrastructure.Repositories;
using SJVN.Librarius.Domain.Services;
using SJVN.Librarius.PresentationWPF.ViewModels;

namespace SJVN.Librarius.PresentationWPF
{
    public partial class Bootstrapper
    {
        public void ConfigureLibrarius()
        {
            // Database Context
            container.Singleton<IDatabaseContext, LibrariusDbContext>();

            // Repositories
            container.PerRequest<IUnitOfWork, UnitOfWork>();
            container.PerRequest<IBookRepository, BookRepository>();

            // Services
            container.PerRequest<IBookService, BookService>();

            // ViewModel
            container.PerRequest<CategoryManagementViewModel>();
        }
    }
}
