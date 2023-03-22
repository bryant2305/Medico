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
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MedicoApp.Core.Application.Services
{
    public class MedicoService : IMedicoService
    {
        private readonly IMedicoRepository _medicoRepository;


        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserViewModel userViewModel;

        public MedicoService(IMedicoRepository medicoRepository, IHttpContextAccessor httpContextAccessor)
        {
            _medicoRepository = medicoRepository;
            _httpContextAccessor = httpContextAccessor;
            userViewModel = _httpContextAccessor.HttpContext.Session.Get<UserViewModel>("user");
        }
        public async Task<SaveMedicoViewModel> Add(SaveMedicoViewModel vm)
        {
            Medicos medico = new();
            medico.Name = vm.Name;
            medico.Apellido = vm.Apellido;
            medico.Cedula = vm.Cedula;
            medico.Email = vm.Email;
            medico.Phone = vm.Phone;
            medico.ImageUrl = vm.ImageUrl;
            //medico.UserId = userViewModel.Id;

            medico = await _medicoRepository.AddAsync(medico);

            SaveMedicoViewModel medicoVm = new();

            medicoVm.Id = medico.Id;
            medicoVm.Name = medico.Name;
            medicoVm.Apellido = medico.Apellido;
            medicoVm.Cedula = medico.Cedula;
            medicoVm.Email = medico.Email;
            medicoVm.Phone = medico.Phone;
            medicoVm.ImageUrl = medico.ImageUrl;


            return medicoVm;
        }

        public async Task Delete(int id)
        {
            var medico = await _medicoRepository.GetByIdAsync(id);
            await _medicoRepository.DeleteAsync(medico);
        }

        public async Task<List<MedicoViewModel>> GetAllViewModel()
        {
            var medicoList = await _medicoRepository.GetAllAsync();

            return medicoList.Select(medico => new MedicoViewModel
            {
                Id = medico.Id,
                Name = medico.Name,
                Apellido = medico.Apellido,
                Cedula = medico.Cedula,
                Email = medico.Email,
                Phone = medico.Phone,
                ImageUrl = medico.ImageUrl,

            }).ToList();
        }

        public async Task<SaveMedicoViewModel> GetByIdSaveViewModel(int id)
        {
            var medico = await _medicoRepository.GetByIdAsync(id);

            SaveMedicoViewModel vm = new(); ;
            vm.Id = medico.Id;
            vm.Name = medico.Name;
            vm.Apellido = medico.Apellido;
            vm.Cedula = medico.Cedula;
            vm.Email = medico.Email;
            vm.Phone = medico.Phone;
            vm.ImageUrl = medico.ImageUrl;

            return vm;
        }

        public async Task Update(SaveMedicoViewModel vm)
        {
            Medicos medico = await _medicoRepository.GetByIdAsync(vm.Id);
            medico.Id = vm.Id;
            medico.Name = vm.Name;
            medico.Apellido = vm.Apellido;
            medico.Cedula = vm.Cedula;
            medico.Email = vm.Email;
            medico.Phone = vm.Phone;
            medico.ImageUrl = vm.ImageUrl;

            await _medicoRepository.UpdateAsync(medico);
        }

    }
}
