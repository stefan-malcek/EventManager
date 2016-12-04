using System;
using System.Collections.Generic;
using AutoMapper;
using EventManager.BL.DTOs.Filters;
using EventManager.BL.DTOs.Registrations;
using EventManager.BL.DTOs.UserAccounts;
using EventManager.BL.DTOs.Users;
using EventManager.BL.Queries;
using EventManager.BL.Repositories;
using EventManager.BL.Repositories.UserAccount;
using EventManager.DAL.Entities;

namespace EventManager.BL.Services.Users
{
    public class UserService : EventManagerService, IUserService
    {
        private readonly UserRepository _userRepository;
        private readonly UserAccountRepository _userAccountRepository;
        private readonly UserListQuery _userListQuery;

        public UserService(UserRepository userRepository, UserAccountRepository userAccountRepository, UserListQuery userListQuery)
        {
            _userRepository = userRepository;
            _userAccountRepository = userAccountRepository;
            _userListQuery = userListQuery;
        }

        public void CreateUser(UserRegistrationDTO userDto, Guid accountId)
        {
            using (var uow = UnitOfWorkProvider.Create())
            {
                var userAccount = _userAccountRepository.GetById(accountId);
                var user = Mapper.Map<User>(userDto);
                user.Account = userAccount;
                _userRepository.Insert(user);
                uow.Commit();
            }
        }

        public void UpdateUser(UserDTO userDto)
        {
            using (var uow = UnitOfWorkProvider.Create())
            {
                var user = _userRepository.GetById(userDto.Id);
                Mapper.Map(userDto, user);
                _userRepository.Update(user);
                uow.Commit();
            }
        }

        public void DeleteUser(int userId)
        {
            using (var uow = UnitOfWorkProvider.Create())
            {
                _userRepository.Delete(userId);
                uow.Commit();
            }
        }

        public UserDTO GetUser(int userId)
        {
            using (UnitOfWorkProvider.Create())
            {
                var user = _userRepository.GetById(userId);
                return user == null ? null : Mapper.Map<UserDTO>(user);
            }
        }

        public UserDTO GetUserAccortingToEmail(string email)
        {
            throw new NotImplementedException("Functionality will be implemented with authentication.");
        }

        public IEnumerable<UserDTO> ListUsers(UserFilter filter)
        {
            using (UnitOfWorkProvider.Create())
            {
                _userListQuery.Filter = filter;
                return _userListQuery.Execute() ?? new List<UserDTO>();
            }
        }
    }
}
