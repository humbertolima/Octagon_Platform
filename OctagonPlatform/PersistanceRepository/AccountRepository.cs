﻿using OctagonPlatform.Helpers;
using OctagonPlatform.Models;
using OctagonPlatform.Models.FormsViewModels;
using OctagonPlatform.Models.InterfacesRepository;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Security;

namespace OctagonPlatform.PersistanceRepository
{
    public class AccountRepository: GenericRepository<User>, IAccountRepository
    {
        public UserLoginViewModel Login(UserLoginViewModel userLogin)
        {
            try
            {
                var user = Table.Where(u => u.UserName == userLogin.UserName && !u.Deleted && !u.IsLocked)
                    .Include(x => x.Partner).SingleOrDefault();
                if (user != null)
                {
                    var key = user.Key;
                    var hash = Cryptography.EncodePassword(userLogin.Password, key);

                    if (user.Password == hash)
                    {
                        return new UserLoginViewModel()
                        {
                            UserName = userLogin.UserName,
                            Logo = user.Partner.Logo,
                            Partner = user.Partner,
                            BusinessName = user.Partner.BusinessName
                        };
                    }
                }

                var userTrying = Table.SingleOrDefault(u => u.UserName == userLogin.UserName && !u.Deleted);
                if (userTrying == null)
                    return userLogin;

                if (userTrying.IsLocked)
                {
                    userLogin.IsLocked = true;
                    return userLogin;
                }


                if (userLogin.TriesToLogin <= 3)
                {
                    userLogin.TriesToLogin++;
                    return userLogin;
                }

                userTrying.IsLocked = true;
                Save();
                userLogin.IsLocked = true;
                return userLogin;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public void Logout()
        {
            try { 
            FormsAuthentication.SignOut();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}