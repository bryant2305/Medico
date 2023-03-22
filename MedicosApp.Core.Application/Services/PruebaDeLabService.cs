using MedicoApp.Core.Application.Interfaces.Repositories;
using MedicoApp.Core.Application.Interfaces.Services;
using MedicoApp.Core.Application.ViewModels.Paciente;
using MedicoApp.Core.Application.ViewModels.PruebaDeLab;
using MedicoApp.Core.Application.ViewModels.User;
using MedicoApp.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicoApp.Core.Application.Services
{
    public class PruebaDeLabService : IPruebaDeLabService
    {

        private readonly IPruebaDeLabRepository _pruebaDeLabRepository;

        public PruebaDeLabService(IPruebaDeLabRepository pruebaDeLabRepository)
        {
            _pruebaDeLabRepository = pruebaDeLabRepository;
        }
        public async Task<SavePruebaDeLabViewModel> Add(SavePruebaDeLabViewModel vm)
        {
            PruebaDeLab pruebadelab = new();
            pruebadelab.Name = vm.Name;



            pruebadelab = await _pruebaDeLabRepository.AddAsync(pruebadelab);

            SavePruebaDeLabViewModel pruebadelabVm = new();

            pruebadelabVm.Id = pruebadelab.Id;
            pruebadelabVm.Name = pruebadelab.Name;


            return pruebadelabVm;
        }

        public async Task Delete(int id)
        {
            var pruebadelab = await _pruebaDeLabRepository.GetByIdAsync(id);
            await _pruebaDeLabRepository.DeleteAsync(pruebadelab);
        }

        public async Task<List<PruebaDeLabViewModel>> GetAllViewModel()
        {
            var pruebadelablist = await _pruebaDeLabRepository.GetAllAsync();

            return pruebadelablist.Select(pruebadelablist => new PruebaDeLabViewModel
            {
                Name = pruebadelablist.Name,
                Id = pruebadelablist.Id

            }).ToList();
        }

        public async Task<SavePruebaDeLabViewModel> GetByIdSaveViewModel(int id)
        {
            var pruebadelab = await _pruebaDeLabRepository.GetByIdAsync(id);

            SavePruebaDeLabViewModel vm = new(); ;
            vm.Id = pruebadelab.Id;
            vm.Name = pruebadelab.Name;


            return vm;
        }

        public async Task Update(SavePruebaDeLabViewModel vm)
        {
            PruebaDeLab pruebadelab = await _pruebaDeLabRepository.GetByIdAsync(vm.Id);
            pruebadelab.Id = vm.Id;
            pruebadelab.Name = vm.Name;


            await _pruebaDeLabRepository.UpdateAsync(pruebadelab);
        }



    }
}
