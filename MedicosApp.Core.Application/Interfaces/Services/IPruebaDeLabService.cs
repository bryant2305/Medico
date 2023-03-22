using MedicoApp.Core.Application.ViewModels.PruebaDeLab;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicoApp.Core.Application.Interfaces.Services
{
    public interface IPruebaDeLabService : IGenericService<SavePruebaDeLabViewModel, PruebaDeLabViewModel>
    {
    }
}
