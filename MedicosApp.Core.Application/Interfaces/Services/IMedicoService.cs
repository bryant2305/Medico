using MedicoApp.Core.Application.ViewModels.Medico;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicoApp.Core.Application.Interfaces.Services
{
    public interface IMedicoService : IGenericService<SaveMedicoViewModel, MedicoViewModel>
    {

    }
}
