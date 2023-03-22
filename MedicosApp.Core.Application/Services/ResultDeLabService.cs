using MedicoApp.Core.Application.Interfaces.Repositories;
using MedicoApp.Core.Application.Interfaces.Services;
using MedicoApp.Core.Application.ViewModels.Medico;
using MedicoApp.Core.Application.ViewModels.ResultDeLab;
using MedicoApp.Core.Application.ViewModels.User;
using MedicoApp.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicoApp.Core.Application.Services
{
    public class ResultDeLabService : IResultDeLabService
    {
        private readonly IResultDeLabRepository _resultDeLabRepository;

        public ResultDeLabService(IResultDeLabRepository resultDeLabRepository)
        {
            _resultDeLabRepository = resultDeLabRepository;
        }

        public async Task<SaveResultDeLabViewModel> Add(SaveResultDeLabViewModel vm)
        {
            ResultDeLab resultDeLab = new();
            resultDeLab.Id = vm.Id;
            resultDeLab.Name = vm.Name;
            resultDeLab.Apellido = vm.Apellido;
            resultDeLab.PacienteId = vm.PacienteId;
            resultDeLab.PruebaDeLabId = vm.PruebaDeLabId;


            resultDeLab = await _resultDeLabRepository.AddAsync(resultDeLab);

            SaveResultDeLabViewModel resultDeLabVm = new();

            resultDeLabVm.Id = resultDeLab.Id;
            resultDeLabVm.Name = resultDeLab.Name;
            resultDeLabVm.Apellido = resultDeLab.Apellido;
            resultDeLabVm.PacienteId = resultDeLab.PacienteId;
            resultDeLabVm.PruebaDeLabId = resultDeLab.PruebaDeLabId;

            return resultDeLabVm;
        }



        public async Task Delete(int id)
        {
            var resultDeLab = await _resultDeLabRepository.GetByIdAsync(id);
            await _resultDeLabRepository.DeleteAsync(resultDeLab);
        }

        public async Task<List<ResultDeLabViewModel>> GetAllViewModel()
        {
            var resultDeLablist = await _resultDeLabRepository.GetAllAsync();

            return resultDeLablist.Select(resultDeLab => new ResultDeLabViewModel
            {
                Id = resultDeLab.Id,
                Name = resultDeLab.Name,
                Apellido = resultDeLab.Apellido,
                PacienteId = resultDeLab.Pacientes.Id,
                PruebaDeLabId = resultDeLab.PruebaDeLab.Id,
                PacienteName = resultDeLab.Pacientes.Name,
                PruebaDeLabName = resultDeLab.PruebaDeLab.Name

            }).ToList();
        }

        public async Task<SaveResultDeLabViewModel> GetByIdSaveViewModel(int id)
        {
            var resultDeLab = await _resultDeLabRepository.GetByIdAsync(id);

            SaveResultDeLabViewModel vm = new(); ;
            vm.Id = resultDeLab.Id;
            vm.Name = resultDeLab.Name;
            vm.Apellido = resultDeLab.Apellido;
            vm.PacienteId = resultDeLab.PacienteId;
            vm.PruebaDeLabId = resultDeLab.PruebaDeLabId;

            return vm;
        }

        public async Task Update(SaveResultDeLabViewModel vm)
        {
            ResultDeLab resultDeLab = await _resultDeLabRepository.GetByIdAsync(vm.Id);
            resultDeLab.Id = vm.Id;
            resultDeLab.Name = vm.Name;
            resultDeLab.Apellido = vm.Apellido;
            resultDeLab.PacienteId = vm.PacienteId;
            resultDeLab.PruebaDeLabId = vm.PruebaDeLabId;



            await _resultDeLabRepository.UpdateAsync(resultDeLab);
        }

        public async Task<List<ResultDeLabViewModel>> GetAllViewModelWithFilters(FilterResultDeLabViewModel filters)
        {
            var resultdelablist = await _resultDeLabRepository.GetAllAsync();

            var listViewModels = resultdelablist.Select(resultDeLab => new ResultDeLabViewModel
            {
                Name = resultDeLab.Name,
                Apellido = resultDeLab.Apellido,
                Id = resultDeLab.Id,
                PacienteId = resultDeLab.Pacientes.Id,
                PacienteName = resultDeLab.Pacientes.Name,
                PruebaDeLabId = resultDeLab.PruebaDeLab.Id,
                PruebaDeLabName = resultDeLab.PruebaDeLab.Name,




            }).ToList();

            if (filters.PacienteId != null)
            {
                listViewModels = listViewModels.Where(resultDeLab => resultDeLab.PacienteId == filters.PacienteId.Value).ToList();
            }

            return listViewModels;
        }


    }

}
