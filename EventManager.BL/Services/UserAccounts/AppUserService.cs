using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Claims;
using BrockAllen.MembershipReboot;
using EventManager.BL.DTOs.UserAccounts;
using EventManager.BL.Miscellaneous.AccountPolicy;

namespace EventManager.BL.Services.UserAccounts
{
    public class AppUserService :EventManagerService, IAppUserService
    {
        private readonly UserAccountService<DAL.Entities.UserAccount> mCoreService;

        public AppUserService(UserAccountService<DAL.Entities.UserAccount> service)
        {
            mCoreService = service;
        }

        public Guid RegisterUserAccount(UserRegistrationDTO userRegistration, bool createAdmin = false)
        {
            using (UnitOfWorkProvider.Create())
            {
                var userClaims = new List<Claim>();

                if (createAdmin)
                {
                    userClaims.Add(new Claim(ClaimTypes.Role, Claims.Admin));
                }
                else
                {
                    // for the moment there is just Member role left
                    userClaims.Add(new Claim(ClaimTypes.Role, Claims.Member));
                }

                var account = mCoreService.CreateAccount(null, userRegistration.Password, userRegistration.Email, null,
                    null);

                AutoMapper.Mapper.Map(userRegistration, account);

                foreach (var claim in userClaims)
                {
                    mCoreService.AddClaim(account.ID, claim.Type, claim.Value);
                }

                mCoreService.Update(account);

                return account.ID;
            }
        }

        public Guid AuthenticateUser(UserLoginDTO loginDto)
        {
            DAL.Entities.UserAccount account;
            var result = mCoreService.Authenticate(loginDto.Username, loginDto.Password, out account);
            if (!result)
            {
                Debug.WriteLine($"Failed to authenticate user: {loginDto.Username}");
                return Guid.Empty;
            }
            return account.ID;
        }
    }
}
