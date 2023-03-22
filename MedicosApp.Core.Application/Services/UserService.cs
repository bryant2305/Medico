using MedicoApp.Core.Application.Interfaces.Repositories;
using MedicoApp.Core.Application.Interfaces.Services;
using MedicoApp.Core.Application.ViewModels.User;
using MedicoApp.Core.Domain.Entities;
using MedicoApp.Core.Application.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicoApp.Core.Application.Helpers;

namespace MedicoApp.Core.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserViewModel> Login(LoginViewModel vm)
        {
            UserViewModel userVm = new();
            User user = await _userRepository.LoginAsync(vm);

            if (user == null)
            {
                return null;
            }

            userVm.Id = user.Id;
            userVm.Name = user.Name;
            userVm.Username = user.Username;
            userVm.Password = user.Password;
            userVm.Email = user.Email;
            userVm.Apellido = user.Apellido;
            userVm.Admin = user.Admin;

            return userVm;
        }

        public async Task Update(SaveUserViewModel vm)
        {
            User user = await _userRepository.GetByIdAsync(vm.Id);
            string passwordEncrypt = PasswordEncryptation.ComputeSha256Hash(vm.Password);
            user.Id = vm.Id;
            user.Name = vm.Name;
            user.Username = vm.Username;
            user.Password = passwordEncrypt;
            user.Email = vm.Email;
            user.Apellido = user.Apellido;
            user.Admin = user.Admin;

            await _userRepository.UpdateAsync(user);
        }

        public async Task<SaveUserViewModel> Add(SaveUserViewModel vm)
        {
            User user = new();
            user.Name = vm.Name;
            user.Username = vm.Username;
            user.Password = vm.Password;
            user.Email = vm.Email;
            user.Apellido = vm.Apellido;
            user.Admin = vm.Admin;


            user = await _userRepository.AddAsync(user);

            SaveUserViewModel userVm = new();

            userVm.Id = user.Id;
            userVm.Name = user.Name;
            userVm.Email = user.Email;
            userVm.Username = user.Username;
            userVm.Password = user.Password;
            userVm.Apellido = user.Apellido;
            userVm.Admin = user.Admin;

            return userVm;
        }

        public async Task Delete(int id)
        {
            var product = await _userRepository.GetByIdAsync(id);
            await _userRepository.DeleteAsync(product);
        }

        public async Task<SaveUserViewModel> GetByIdSaveViewModel(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);

            SaveUserViewModel vm = new();
            vm.Id = user.Id;
            vm.Name = user.Name;
            vm.Username = user.Username;
            vm.Password = user.Password;
            vm.Email = user.Email;
            vm.Apellido = user.Apellido;
            vm.Admin = user.Admin;
            return vm;
        }

        public async Task<List<UserViewModel>> GetAllViewModel()
        {
            var userList = await _userRepository.GetAllAsync();

            return userList.Select(user => new UserViewModel
            {
                Name = user.Name,
                Username = user.Username,
                Id = user.Id,
                Email = user.Email,
                Password = user.Password,
                Apellido = user.Apellido,
                Admin = user.Admin

            }).ToList();
        }
        public async Task<bool> IfUserExiste(SaveUserViewModel vm)
        {
            var user = await _userRepository.IfUserExits(vm);

            if (user != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
