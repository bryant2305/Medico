using MedicoApp.Core.Application.Helpers;
using MedicoApp.Core.Application.Interfaces.Repositories;
using MedicoApp.Core.Application.Interfaces.Services;
using MedicoApp.Core.Application.ViewModels.Medico;
using MedicoApp.Core.Application.ViewModels.Paciente;
using MedicoApp.Core.Application.ViewModels.User;
using MedicoApp.Core.Domain.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicoApp.Core.Application.Services
{
    public class PacientesService : IPacientesService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserViewModel userViewModel;
        private readonly IPacientesRepository _pacientesRepository;
        public PacientesService(IPacientesRepository pacientesRepository, IHttpContextAccessor httpContextAccessor)
        {
            _pacientesRepository = pacientesRepository;
            _httpContextAccessor = httpContextAccessor;
            userViewModel = _httpContextAccessor.HttpContext.Session.Get<UserViewModel>("user");
        }
        public async Task<SavePacienteViewModel> Add(SavePacienteViewModel vm)
        {
            Pacientes paciente = new();
            paciente.Name = vm.Name;
            paciente.Apellido = vm.Apellido;
            paciente.Cedula = vm.Cedula;
            paciente.Fumador = vm.Fumador;
            paciente.Phone = vm.Phone;
            paciente.Alergias = vm.Alergias;
            paciente.Direccion = vm.Direccion;
            paciente.ImageUrl = paciente.ImageUrl;
            paciente.FechaNacimiento = paciente.FechaNacimiento;



            paciente = await _pacientesRepository.AddAsync(paciente);

            SavePacienteViewModel pacienteVm = new();

            pacienteVm.Id = paciente.Id;
            pacienteVm.Name = paciente.Name;
            pacienteVm.Apellido = paciente.Apellido;
            pacienteVm.Cedula = paciente.Cedula;
            pacienteVm.Fumador = paciente.Fumador;
            pacienteVm.Phone = paciente.Phone;
            pacienteVm.Alergias = paciente.Alergias;
            pacienteVm.Direccion = paciente.Direccion;
            pacienteVm.ImageUrl = paciente.ImageUrl;
            paciente.FechaNacimiento = paciente.FechaNacimiento;

            return pacienteVm;
        }

        public async Task Delete(int id)
        {
            var paciente = await _pacientesRepository.GetByIdAsync(id);
            await _pacientesRepository.DeleteAsync(paciente);
        }

        public async Task<List<PacienteViewModel>> GetAllViewModel()
        {
            var pacientelist = await _pacientesRepository.GetAllAsync();



            return pacientelist.Select(pacientelist => new PacienteViewModel
            {
                Name = pacientelist.Name,
                Apellido = pacientelist.Apellido,
                Id = pacientelist.Id,
                Cedula = pacientelist.Cedula,
                Direccion = pacientelist.Direccion,
                Phone = pacientelist.Phone,
                Fumador = pacientelist.Fumador,
                Alergias = pacientelist.Alergias,
                ImageUrl = pacientelist.ImageUrl,
                FechaNacimiento = pacientelist.FechaNacimiento

            }).ToList();
        }


        public async Task<SavePacienteViewModel> GetByIdSaveViewModel(int id)
        {
            var paciente = await _pacientesRepository.GetByIdAsync(id);

            SavePacienteViewModel vm = new(); ;
            vm.Id = paciente.Id;
            vm.Name = paciente.Name;
            vm.Apellido = paciente.Apellido;
            vm.Cedula = paciente.Cedula;
            vm.Alergias = paciente.Alergias;
            vm.Phone = paciente.Phone;
            vm.Fumador = paciente.Fumador;
            vm.Direccion = paciente.Direccion;
            vm.ImageUrl = paciente.ImageUrl;
            vm.FechaDeNacimiento = paciente.FechaNacimiento;

            return vm;
        }

        public async Task Update(SavePacienteViewModel vm)
        {
            Pacientes paciente = await _pacientesRepository.GetByIdAsync(vm.Id);
            paciente.Id = vm.Id;
            paciente.Name = vm.Name;
            paciente.Apellido = vm.Apellido;
            paciente.Cedula = vm.Cedula;
            paciente.Fumador = vm.Fumador;
            paciente.Phone = vm.Phone;
            paciente.Direccion = vm.Direccion;
            paciente.Alergias = vm.Alergias;
            paciente.ImageUrl = vm.ImageUrl;
            paciente.FechaNacimiento = vm.FechaDeNacimiento;

            await _pacientesRepository.UpdateAsync(paciente);
        }


    }
}


