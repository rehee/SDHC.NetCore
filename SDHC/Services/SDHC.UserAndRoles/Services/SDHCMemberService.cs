using Common.Cruds;
using Common.NetCore.Models;
using Common.Services;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SDHC.UserAndRoles.Services
{
  public class SDHCMemberService<T> :
    ISDHCMemberService<T, IdentityResult, Claim, ClaimsPrincipal, UserLoginInfo, IUserValidator<T>, IUserTwoFactorTokenProvider<T>>
    where T : SDHCUser, new()
  {
    private readonly UserManager<T> u;
    private readonly ICrud crud;
    public SDHCMemberService(UserManager<T> u, ICrud crud)
    {
      this.u = u;
      this.crud = crud;
    }
    public IQueryable<T> Users => this.u.Users;

    public IEnumerable<IUserValidator<T>> UserValidators => this.u.UserValidators;

    public Task<IdentityResult> AccessFailedAsync(T user)
    {
      return this.u.AccessFailedAsync(user);
    }

    public Task<IdentityResult> AddClaimAsync(T user, Claim claim)
    {
      return u.AddClaimAsync(user, claim);
    }

    public Task<IdentityResult> AddClaimsAsync(T user, IEnumerable<Claim> claims)
    {
      return u.AddClaimsAsync(user, claims);
    }

    public Task<IdentityResult> AddLoginAsync(T user, UserLoginInfo login)
    {
      return u.AddLoginAsync(user, login);
    }

    public Task<IdentityResult> AddPasswordAsync(T user, string password)
    {
      return u.AddPasswordAsync(user, password);
    }

    public Task<IdentityResult> AddToRoleAsync(T user, string role)
    {
      return u.AddToRoleAsync(user, role);
    }

    public Task<IdentityResult> AddToRolesAsync(T user, IEnumerable<string> roles)
    {
      return u.AddToRolesAsync(user, roles);
    }

    public Task<IdentityResult> ChangeEmailAsync(T user, string newEmail, string token)
    {
      return u.ChangeEmailAsync(user, newEmail, token);
    }

    public Task<IdentityResult> ChangePasswordAsync(T user, string currentPassword, string newPassword)
    {
      return u.ChangePasswordAsync(user, currentPassword, newPassword);
    }

    public Task<IdentityResult> ChangePhoneNumberAsync(T user, string phoneNumber, string token)
    {
      return u.ChangePhoneNumberAsync(user, phoneNumber, token);
    }

    public Task<bool> CheckPasswordAsync(T user, string password)
    {
      return u.CheckPasswordAsync(user, password);
    }

    public Task<IdentityResult> ConfirmEmailAsync(T user, string token)
    {
      return u.ConfirmEmailAsync(user, token);
    }

    public Task<int> CountRecoveryCodesAsync(T user)
    {
      return u.CountRecoveryCodesAsync(user);
    }

    public Task<IdentityResult> CreateAsync(T user)
    {
      return u.CreateAsync(user);
    }

    public Task<IdentityResult> CreateAsync(T user, string password)
    {
      return u.CreateAsync(user, password);
    }

    public Task<byte[]> CreateSecurityTokenAsync(T user)
    {
      return u.CreateSecurityTokenAsync(user);
    }

    public Task<IdentityResult> DeleteAsync(T user)
    {
      return u.DeleteAsync(user);
    }

    public void Dispose()
    {
      u.Dispose();
      this.Dispose();
    }

    public async Task<T> FindByEmailAsync(string email)
    {
      return await u.FindByEmailAsync(email);
    }

    public async Task<T> FindByIdAsync(string userId)
    {
      return await u.FindByIdAsync(userId);
    }

    public async Task<T> FindByLoginAsync(string loginProvider, string providerKey)
    {
      return await u.FindByLoginAsync(loginProvider, providerKey);
    }

    public Task<T> FindByNameAsync(string userName)
    {
      return u.FindByNameAsync(userName);
      //return await Task<T>.Run(() =>
      //{
      //  var uperUserName = userName.ToUpper();
      //  //var d = u.Users.Where(b => b.NormalizedUserName == uperUserName).ToList();
      //  //return u.Users.Where(b => b.NormalizedUserName == uperUserName).FirstOrDefault();
      //  try
      //  {
      //    var user = this.crud.Read<T>(b => b.NormalizedUserName == uperUserName).ToList().FirstOrDefault();
      //    return user;
      //  }
      //  catch (Exception ex)
      //  {
      //    return null;
      //  }

      //});
    }

    public async Task<T> GetUserAsync(ClaimsPrincipal principal)
    {
      return await u.GetUserAsync(principal);
    }

    public string GetUserId(ClaimsPrincipal principal)
    {
      return u.GetUserId(principal);
    }

    public Task<string> GetUserIdAsync(T user)
    {
      return u.GetUserIdAsync(user);
    }

    public string GetUserName(ClaimsPrincipal principal)
    {
      return u.GetUserName(principal);
    }

    public Task<string> GetUserNameAsync(T user)
    {
      return u.GetUserNameAsync(user);
    }

    public async Task<IEnumerable<T>> GetUsersForClaimAsync(Claim claim)
    {
      var list = await u.GetUsersForClaimAsync(claim);
      return list.Select(b => b);
    }

    public async Task<IEnumerable<T>> GetUsersInRoleAsync(string roleName)
    {
      var list = await u.GetUsersInRoleAsync(roleName);
      return list.Select(b => b);
    }

    public Task<string> GenerateChangeEmailTokenAsync(T user, string newEmail)
    {
      return u.GenerateChangeEmailTokenAsync(user, newEmail);
    }

    public Task<string> GenerateChangePhoneNumberTokenAsync(T user, string phoneNumber)
    {
      return u.GenerateChangePhoneNumberTokenAsync(user, phoneNumber);
    }

    public Task<string> GenerateConcurrencyStampAsync(T user)
    {
      return u.GenerateConcurrencyStampAsync(user);
    }

    public Task<string> GenerateEmailConfirmationTokenAsync(T user)
    {
      return u.GenerateEmailConfirmationTokenAsync(user);
    }

    public string GenerateNewAuthenticatorKey()
    {
      return u.GenerateNewAuthenticatorKey();
    }

    public Task<IEnumerable<string>> GenerateNewTwoFactorRecoveryCodesAsync(T user, int number)
    {
      return u.GenerateNewTwoFactorRecoveryCodesAsync(user, number);
    }

    public Task<string> GeneratePasswordResetTokenAsync(T user)
    {
      return u.GeneratePasswordResetTokenAsync(user);
    }

    public Task<string> GenerateTwoFactorTokenAsync(T user, string tokenProvider)
    {
      return u.GenerateTwoFactorTokenAsync(user, tokenProvider);
    }

    public Task<string> GenerateUserTokenAsync(T user, string tokenProvider, string purpose)
    {
      return u.GenerateUserTokenAsync(user, tokenProvider, purpose);
    }

    public Task<int> GetAccessFailedCountAsync(T user)
    {
      return u.GetAccessFailedCountAsync(user);
    }

    public Task<string> GetAuthenticationTokenAsync(T user, string loginProvider, string tokenName)
    {
      return u.GetAuthenticationTokenAsync(user, loginProvider, tokenName);
    }

    public Task<string> GetAuthenticatorKeyAsync(T user)
    {
      return u.GetAuthenticatorKeyAsync(user);
    }

    public Task<IList<Claim>> GetClaimsAsync(T user)
    {
      return u.GetClaimsAsync(user);
    }

    public Task<string> GetEmailAsync(T user)
    {
      return u.GetEmailAsync(user);
    }

    public Task<bool> GetLockoutEnabledAsync(T user)
    {
      return u.GetLockoutEnabledAsync(user);
    }

    public Task<DateTimeOffset?> GetLockoutEndDateAsync(T user)
    {
      return u.GetLockoutEndDateAsync(user);
    }

    public Task<IList<UserLoginInfo>> GetLoginsAsync(T user)
    {
      return u.GetLoginsAsync(user);
    }

    public Task<string> GetPhoneNumberAsync(T user)
    {
      return u.GetPhoneNumberAsync(user);
    }

    public Task<IList<string>> GetRolesAsync(T user)
    {
      return u.GetRolesAsync(user);
    }

    public Task<string> GetSecurityStampAsync(T user)
    {
      return u.GetSecurityStampAsync(user);
    }

    public Task<bool> GetTwoFactorEnabledAsync(T user)
    {
      return u.GetTwoFactorEnabledAsync(user);
    }

    public Task<IList<string>> GetValidTwoFactorProvidersAsync(T user)
    {
      return u.GetValidTwoFactorProvidersAsync(user);
    }

    public Task<bool> HasPasswordAsync(T user)
    {
      return u.HasPasswordAsync(user);
    }

    public Task<bool> IsEmailConfirmedAsync(T user)
    {
      return u.IsEmailConfirmedAsync(user);
    }

    public Task<bool> IsInRoleAsync(T user, string role)
    {
      return u.IsInRoleAsync(user, role);
    }

    public Task<bool> IsLockedOutAsync(T user)
    {
      return u.IsLockedOutAsync(user);
    }

    public Task<bool> IsPhoneNumberConfirmedAsync(T user)
    {
      return u.IsPhoneNumberConfirmedAsync(user);
    }

    public string NormalizeEmail(string email)
    {
      return u.NormalizeEmail(email);
    }

    public string NormalizeName(string name)
    {
      return u.NormalizeName(name);
    }

    public Task<IdentityResult> RedeemTwoFactorRecoveryCodeAsync(T user, string code)
    {
      return u.RedeemTwoFactorRecoveryCodeAsync(user, code);
    }

    public void RegisterTokenProvider(string providerName, IUserTwoFactorTokenProvider<T> provider)
    {
      u.RegisterTokenProvider(providerName, provider);
    }

    public Task<IdentityResult> RemoveAuthenticationTokenAsync(T user, string loginProvider, string tokenName)
    {
      return u.RemoveAuthenticationTokenAsync(user, loginProvider, tokenName);
    }

    public Task<IdentityResult> RemoveClaimAsync(T user, Claim claim)
    {
      return u.RemoveClaimAsync(user, claim);
    }

    public Task<IdentityResult> RemoveClaimsAsync(T user, IEnumerable<Claim> claims)
    {
      return u.RemoveClaimsAsync(user, claims);
    }

    public Task<IdentityResult> RemoveFromRoleAsync(T user, string role)
    {
      return u.RemoveFromRoleAsync(user, role);
    }

    public Task<IdentityResult> RemoveFromRolesAsync(T user, IEnumerable<string> roles)
    {
      return u.RemoveFromRolesAsync(user, roles);
    }

    public Task<IdentityResult> RemoveLoginAsync(T user, string loginProvider, string providerKey)
    {
      return u.RemoveLoginAsync(user, loginProvider, providerKey);
    }

    public Task<IdentityResult> RemovePasswordAsync(T user)
    {
      return u.RemovePasswordAsync(user);
    }

    public Task<IdentityResult> ReplaceClaimAsync(T user, Claim claim, Claim newClaim)
    {
      return u.ReplaceClaimAsync(user, claim, newClaim);
    }

    public Task<IdentityResult> ResetAccessFailedCountAsync(T user)
    {
      return u.ResetAccessFailedCountAsync(user);
    }

    public Task<IdentityResult> ResetAuthenticatorKeyAsync(T user)
    {
      return u.ResetAuthenticatorKeyAsync(user);
    }

    public Task<IdentityResult> ResetPasswordAsync(T user, string token, string newPassword)
    {
      return u.ResetPasswordAsync(user, token, newPassword);
    }

    public Task<IdentityResult> SetUserNameAsync(T user, string userName)
    {
      return u.SetUserNameAsync(user, userName);
    }

    public Task<IdentityResult> SetAuthenticationTokenAsync(T user, string loginProvider, string tokenName, string tokenValue)
    {
      return u.SetAuthenticationTokenAsync(user, loginProvider, tokenName, tokenValue);
    }

    public Task<IdentityResult> SetEmailAsync(T user, string email)
    {
      return u.SetEmailAsync(user, email);
    }

    public Task<IdentityResult> SetLockoutEnabledAsync(T user, bool enabled)
    {
      return u.SetLockoutEnabledAsync(user, enabled);
    }

    public Task<IdentityResult> SetLockoutEndDateAsync(T user, DateTimeOffset? lockoutEnd)
    {
      return u.SetLockoutEndDateAsync(user, lockoutEnd);
    }

    public Task<IdentityResult> SetPhoneNumberAsync(T user, string phoneNumber)
    {
      return u.SetPhoneNumberAsync(user, phoneNumber);
    }

    public Task<IdentityResult> SetTwoFactorEnabledAsync(T user, bool enabled)
    {
      return u.SetTwoFactorEnabledAsync(user, enabled);
    }

    public Task<IdentityResult> UpdateAsync(T user)
    {
      return u.UpdateAsync(user);
    }

    public Task UpdateNormalizedEmailAsync(T user)
    {
      return u.UpdateNormalizedEmailAsync(user);
    }

    public Task UpdateNormalizedUserNameAsync(T user)
    {
      return u.UpdateNormalizedUserNameAsync(user);
    }

    public Task<IdentityResult> UpdateSecurityStampAsync(T user)
    {
      return u.UpdateSecurityStampAsync(user);
    }

    public Task<bool> VerifyChangePhoneNumberTokenAsync(T user, string token, string phoneNumber)
    {
      return u.VerifyChangePhoneNumberTokenAsync(user, token, phoneNumber);
    }

    public Task<bool> VerifyTwoFactorTokenAsync(T user, string tokenProvider, string token)
    {
      return u.VerifyTwoFactorTokenAsync(user, tokenProvider, token);
    }

    public Task<bool> VerifyUserTokenAsync(T user, string tokenProvider, string purpose, string token)
    {
      return u.VerifyUserTokenAsync(user, tokenProvider, purpose, token);
    }
  }
}
