﻿using OctagonPlatform.Models.FormsViewModels;
using System.Collections.Generic;

namespace OctagonPlatform.Models.InterfacesRepository
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAllUsers(int partnerId);

        IEnumerable<User> Search(string search, int partnerId);

        UserEditFormViewModel UserToEdit(int id);

        UserFormViewModel RenderUserFormViewModel(int parentId);

        ICollection<Permission> AddPermissionToUser(string[] permissions);

        UserBAViewModel GetAllBankAccount(string userId, bool toAttach);

        UserBAViewModel AddBankAccountToUser(string userId, string bankAccountId);

        UserBAViewModel DeAttachBankAccountToUser(int userId, int bankAccountId);

        void SaveUser(UserFormViewModel viewModel, string action);

        User UserDetails(int id);

        //Task<User> Validate(User user);

        void DeleteUser(int id);

        UserFormViewModel InitializeNewFormViewModel(UserFormViewModel viewModel);
        
    }
}
