using MedicoApp.Core.Application.ViewModels.Citas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicoApp.Core.Application.Interfaces.Services
{
    public interface ICitasService : IGenericService<SaveCitasViewModel, CitasViewModel>
    {

    }
}
