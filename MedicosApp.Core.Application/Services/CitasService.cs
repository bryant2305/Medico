using MedicoApp.Core.Application.Interfaces.Repositories;
using MedicoApp.Core.Application.Interfaces.Services;
using MedicoApp.Core.Application.ViewModels.Citas;
using MedicoApp.Core.Application.ViewModels.Medico;
using MedicoApp.Core.Domain.Entities;
using Microsoft.Build.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MedicoApp.Core.Application.Services.CitasService;

namespace MedicoApp.Core.Application.Services
{
    public class CitasService : ICitasService
    {

        private readonly ICitasRepository _citasRepository;


        public CitasService(ICitasRepository citasRepository, IPacientesRepository pacientesRepository)
        {
            _citasRepository = citasRepository;

        }

        public async Task Update(SaveCitasViewModel vm)
        {
            Citas citas = await _citasRepository.GetByIdAsync(vm.Id);
            citas.Id = vm.Id;
            citas.Name = vm.Name;
            citas.HoraDeLaCita = vm.HoraDeLaCita;
            citas.FechaDeLaCita = vm.FechaDeLaCita;
            citas.PacientesId = vm.PacienteId;
            citas.MedicosId = vm.MedicoId;

            await _citasRepository.UpdateAsync(citas);
        }

        public async Task<SaveCitasViewModel> Add(SaveCitasViewModel vm)
        {
            Citas citas = new();
            citas.Name = vm.Name;
            citas.PacientesId = vm.PacienteId;
            citas.MedicosId = vm.MedicoId;
            citas.HoraDeLaCita = vm.HoraDeLaCita;
            citas.FechaDeLaCita = vm.FechaDeLaCita;


            citas = await _citasRepository.AddAsync(citas);

            SaveCitasViewModel citasVm = new();

            citasVm.Id = citas.Id;
            citasVm.Name = citas.Name;
            citasVm.PacienteId = citas.PacientesId;
            citasVm.MedicoId = citas.MedicosId;
            citasVm.HoraDeLaCita = citas.HoraDeLaCita;
            citasVm.FechaDeLaCita = citas.FechaDeLaCita;



            return citasVm;
        }


        public async Task Delete(int id)
        {
            var citas = await _citasRepository.GetByIdAsync(id);
            await _citasRepository.DeleteAsync(citas);
        }

        public async Task<SaveCitasViewModel> GetByIdSaveViewModel(int id)
        {
            var citas = await _citasRepository.GetByIdAsync(id);

            SaveCitasViewModel vm = new();
            vm.Id = citas.Id;
            vm.Name = citas.Name;
            vm.HoraDeLaCita = citas.HoraDeLaCita;
            vm.FechaDeLaCita = citas.FechaDeLaCita;
            vm.PacienteId = citas.PacientesId;
            vm.MedicoId = citas.MedicosId;

            return vm;
        }

        public async Task<List<CitasViewModel>> GetAllViewModel()
        {
            var citasList = await _citasRepository.GetAllAsync();

            return citasList.Select(citas => new CitasViewModel
            {
                Name = citas.Name,
                HoraDeLaCita = citas.HoraDeLaCita,
                Id = citas.Id,
                FechaDeLaCita = citas.FechaDeLaCita,
                PacienteName = citas.Pacientes.Name,
                PacienteId = citas.Pacientes.Id,
                MedicoName = citas.Medicos.Name,
                MedicoId = citas.Medicos.Id

            }).ToList();
        }


    }
}

