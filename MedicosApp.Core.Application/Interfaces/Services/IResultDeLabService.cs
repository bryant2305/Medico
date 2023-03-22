using MedicoApp.Core.Application.ViewModels.ResultDeLab;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicoApp.Core.Application.Interfaces.Services
{
    public interface IResultDeLabService : IGenericService<SaveResultDeLabViewModel, ResultDeLabViewModel>
    {
        Task<List<ResultDeLabViewModel>> GetAllViewModelWithFilters(FilterResultDeLabViewModel filters);
    }
}
