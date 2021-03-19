using Common.Models;
using Microsoft.AspNetCore.Identity;
using SDHC.UserAndRoles.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using UserIdentity.Services;

namespace SDHC.UserAndRoles.Services
{
  public class SDHCMemberService<T> :
    ISDHCMemberService<IdentityResult, Claim, ClaimsPrincipal, UserLoginInfo>
    where T : SDHCUser, new()
  {
    private readonly UserManager<T> u;
    public SDHCMemberService(UserManager<T> u)
    {
      this.u = u;
    }
    public IQueryable<IUserBase> Users => this.u.Users;

    public IEnumerable<dynamic> UserValidators => this.u.UserValidators.Select(b => b as dynamic);

    public Task<IdentityResult> AccessFailedAsync(IUserBase user)
    {
      return this.u.AccessFailedAsync(user as T);
    }

    public Task<IdentityResult> AddClaimAsync(IUserBase user, Claim claim)
    {
      return u.AddClaimAsync(user as T, claim);
    }

    public Task<IdentityResult> AddClaimsAsync(IUserBase user, IEnumerable<Claim> claims)
    {
      return u.AddClaimsAsync(user as T, claims);
    }

    public Task<IdentityResult> AddLoginAsync(IUserBase user, UserLoginInfo login)
    {
      return u.AddLoginAsync(user as T, login);
    }

    public Task<IdentityResult> AddPasswordAsync(IUserBase user, string password)
    {
      return u.AddPasswordAsync(user as T, password);
    }

    public Task<IdentityResult> AddToRoleAsync(IUserBase user, string role)
    {
      return u.AddToRoleAsync(user as T, role);
    }

    public Task<IdentityResult> AddToRolesAsync(IUserBase user, IEnumerable<string> roles)
    {
      return u.AddToRolesAsync(user as T, roles);
    }

    public Task<IdentityResult> ChangeEmailAsync(IUserBase user, string newEmail, string token)
    {
      return u.ChangeEmailAsync(user as T, newEmail, token);
    }

    public Task<IdentityResult> ChangePasswordAsync(IUserBase user, string currentPassword, string newPassword)
    {
      return u.ChangePasswordAsync(user as T, currentPassword, newPassword);
    }

    public Task<IdentityResult> ChangePhoneNumberAsync(IUserBase user, string phoneNumber, string token)
    {
      return u.ChangePhoneNumberAsync(user as T, phoneNumber, token);
    }

    public Task<bool> CheckPasswordAsync(IUserBase user, string password)
    {
      return u.CheckPasswordAsync(user as T, password);
    }

    public Task<IdentityResult> ConfirmEmailAsync(IUserBase user, string token)
    {
      return u.ConfirmEmailAsync(user as T, token);
    }

    public Task<int> CountRecoveryCodesAsync(IUserBase user)
    {
      return u.CountRecoveryCodesAsync(user as T);
    }

    public Task<IdentityResult> CreateAsync(IUserBase user)
    {
      return u.CreateAsync(user as T);
    }

    public Task<IdentityResult> CreateAsync(IUserBase user, string password)
    {
      return u.CreateAsync(user as T, password);
    }

    public Task<byte[]> CreateSecurityTokenAsync(IUserBase user)
    {
      return u.CreateSecurityTokenAsync(user as T);
    }

    public Task<IdentityResult> DeleteAsync(IUserBase user)
    {
      return u.DeleteAsync(user as T);
    }

    public void Dispose()
    {
      u.Dispose();
      this.Dispose();
    }

    public async Task<IUserBase> FindByEmailAsync(string email)
    {
      return await u.FindByEmailAsync(email);
    }

    public async Task<IUserBase> FindByIdAsync(string userId)
    {
      return await u.FindByIdAsync(userId);
    }

    public async Task<IUserBase> FindByLoginAsync(string loginProvider, string providerKey)
    {
      return await u.FindByLoginAsync(loginProvider, providerKey);
    }

    public async Task<IUserBase> FindByNameAsync(string userName)
    {
      return await u.FindByNameAsync(userName);
    }

    public async Task<IUserBase> GetUserAsync(ClaimsPrincipal principal)
    {
      return await u.GetUserAsync(principal);
    }

    public string GetUserId(ClaimsPrincipal principal)
    {
      return u.GetUserId(principal);
    }

    public Task<string> GetUserIdAsync(IUserBase user)
    {
      return u.GetUserIdAsync(user as T);
    }

    public string GetUserName(ClaimsPrincipal principal)
    {
      return u.GetUserName(principal);
    }

    public Task<string> GetUserNameAsync(IUserBase user)
    {
      return u.GetUserNameAsync(user as T);
    }

    public async Task<IEnumerable<IUserBase>> GetUsersForClaimAsync(Claim claim)
    {
      var list = await u.GetUsersForClaimAsync(claim);
      return list.Select(b => b);
    }

    public async Task<IEnumerable<IUserBase>> GetUsersInRoleAsync(string roleName)
    {
      var list = await u.GetUsersInRoleAsync(roleName);
      return list.Select(b => b);
    }

    public Task<string> GenerateChangeEmailTokenAsync(IUserBase user, string newEmail)
    {
      return u.GenerateChangeEmailTokenAsync(user as T, newEmail);
    }

    public Task<string> GenerateChangePhoneNumberTokenAsync(IUserBase user, string phoneNumber)
    {
      return u.GenerateChangePhoneNumberTokenAsync(user as T, phoneNumber);
    }

    public Task<string> GenerateConcurrencyStampAsync(IUserBase user)
    {
      return u.GenerateConcurrencyStampAsync(user as T);
    }

    public Task<string> GenerateEmailConfirmationTokenAsync(IUserBase user)
    {
      return u.GenerateEmailConfirmationTokenAsync(user as T);
    }

    public string GenerateNewAuthenticatorKey()
    {
      return u.GenerateNewAuthenticatorKey();
    }

    public Task<IEnumerable<string>> GenerateNewTwoFactorRecoveryCodesAsync(IUserBase user, int number)
    {
      return u.GenerateNewTwoFactorRecoveryCodesAsync(user as T, number);
    }

    public Task<string> GeneratePasswordResetTokenAsync(IUserBase user)
    {
      return u.GeneratePasswordResetTokenAsync(user as T);
    }

    public Task<string> GenerateTwoFactorTokenAsync(IUserBase user, string tokenProvider)
    {
      return u.GenerateTwoFactorTokenAsync(user as T, tokenProvider);
    }

    public Task<string> GenerateUserTokenAsync(IUserBase user, string tokenProvider, string purpose)
    {
      return u.GenerateUserTokenAsync(user as T, tokenProvider, purpose);
    }

    public Task<int> GetAccessFailedCountAsync(IUserBase user)
    {
      return u.GetAccessFailedCountAsync(user as T);
    }

    public Task<string> GetAuthenticationTokenAsync(IUserBase user, string loginProvider, string tokenName)
    {
      return u.GetAuthenticationTokenAsync(user as T, loginProvider, tokenName);
    }

    public Task<string> GetAuthenticatorKeyAsync(IUserBase user)
    {
      return u.GetAuthenticatorKeyAsync(user as T);
    }

    public Task<IList<Claim>> GetClaimsAsync(IUserBase user)
    {
      return u.GetClaimsAsync(user as T);
    }

    public Task<string> GetEmailAsync(IUserBase user)
    {
      return u.GetEmailAsync(user as T);
    }

    public Task<bool> GetLockoutEnabledAsync(IUserBase user)
    {
      return u.GetLockoutEnabledAsync(user as T);
    }

    public Task<DateTimeOffset?> GetLockoutEndDateAsync(IUserBase user)
    {
      return u.GetLockoutEndDateAsync(user as T);
    }

    public Task<IList<UserLoginInfo>> GetLoginsAsync(IUserBase user)
    {
      return u.GetLoginsAsync(user as T);
    }

    public Task<string> GetPhoneNumberAsync(IUserBase user)
    {
      return u.GetPhoneNumberAsync(user as T);
    }

    public Task<IList<string>> GetRolesAsync(IUserBase user)
    {
      return u.GetRolesAsync(user as T);
    }

    public Task<string> GetSecurityStampAsync(IUserBase user)
    {
      return u.GetSecurityStampAsync(user as T);
    }

    public Task<bool> GetTwoFactorEnabledAsync(IUserBase user)
    {
      return u.GetTwoFactorEnabledAsync(user as T);
    }

    public Task<IList<string>> GetValidTwoFactorProvidersAsync(IUserBase user)
    {
      return u.GetValidTwoFactorProvidersAsync(user as T);
    }

    public Task<bool> HasPasswordAsync(IUserBase user)
    {
      return u.HasPasswordAsync(user as T);
    }

    public Task<bool> IsEmailConfirmedAsync(IUserBase user)
    {
      return u.IsEmailConfirmedAsync(user as T);
    }

    public Task<bool> IsInRoleAsync(IUserBase user, string role)
    {
      return u.IsInRoleAsync(user as T, role);
    }

    public Task<bool> IsLockedOutAsync(IUserBase user)
    {
      return u.IsLockedOutAsync(user as T);
    }

    public Task<bool> IsPhoneNumberConfirmedAsync(IUserBase user)
    {
      return u.IsPhoneNumberConfirmedAsync(user as T);
    }

    public string NormalizeEmail(string email)
    {
      return u.NormalizeEmail(email);
    }

    public string NormalizeName(string name)
    {
      return u.NormalizeName(name);
    }

    public Task<IdentityResult> RedeemTwoFactorRecoveryCodeAsync(IUserBase user, string code)
    {
      return u.RedeemTwoFactorRecoveryCodeAsync(user as T, code);
    }

    public void RegisterTokenProvider(string providerName, dynamic provider)
    {
      u.RegisterTokenProvider(providerName, provider);
    }

    public Task<IdentityResult> RemoveAuthenticationTokenAsync(IUserBase user, string loginProvider, string tokenName)
    {
      return u.RemoveAuthenticationTokenAsync(user as T, loginProvider, tokenName);
    }

    public Task<IdentityResult> RemoveClaimAsync(IUserBase user, Claim claim)
    {
      return u.RemoveClaimAsync(user as T, claim);
    }

    public Task<IdentityResult> RemoveClaimsAsync(IUserBase user, IEnumerable<Claim> claims)
    {
      return u.RemoveClaimsAsync(user as T, claims);
    }

    public Task<IdentityResult> RemoveFromRoleAsync(IUserBase user, string role)
    {
      return u.RemoveFromRoleAsync(user as T, role);
    }

    public Task<IdentityResult> RemoveFromRolesAsync(IUserBase user, IEnumerable<string> roles)
    {
      return u.RemoveFromRolesAsync(user as T, roles);
    }

    public Task<IdentityResult> RemoveLoginAsync(IUserBase user, string loginProvider, string providerKey)
    {
      return u.RemoveLoginAsync(user as T, loginProvider, providerKey);
    }

    public Task<IdentityResult> RemovePasswordAsync(IUserBase user)
    {
      return u.RemovePasswordAsync(user as T);
    }

    public Task<IdentityResult> ReplaceClaimAsync(IUserBase user, Claim claim, Claim newClaim)
    {
      return u.ReplaceClaimAsync(user as T, claim, newClaim);
    }

    public Task<IdentityResult> ResetAccessFailedCountAsync(IUserBase user)
    {
      return u.ResetAccessFailedCountAsync(user as T);
    }

    public Task<IdentityResult> ResetAuthenticatorKeyAsync(IUserBase user)
    {
      return u.ResetAuthenticatorKeyAsync(user as T);
    }

    public Task<IdentityResult> ResetPasswordAsync(IUserBase user, string token, string newPassword)
    {
      return u.ResetPasswordAsync(user as T, token, newPassword);
    }

    public Task<IdentityResult> SetUserNameAsync(IUserBase user, string userName)
    {
      return u.SetUserNameAsync(user as T, userName);
    }

    public Task<IdentityResult> SetAuthenticationTokenAsync(IUserBase user, string loginProvider, string tokenName, string tokenValue)
    {
      return u.SetAuthenticationTokenAsync(user as T, loginProvider, tokenName, tokenValue);
    }

    public Task<IdentityResult> SetEmailAsync(IUserBase user, string email)
    {
      return u.SetEmailAsync(user as T, email);
    }

    public Task<IdentityResult> SetLockoutEnabledAsync(IUserBase user, bool enabled)
    {
      return u.SetLockoutEnabledAsync(user as T, enabled);
    }

    public Task<IdentityResult> SetLockoutEndDateAsync(IUserBase user, DateTimeOffset? lockoutEnd)
    {
      return u.SetLockoutEndDateAsync(user as T, lockoutEnd);
    }

    public Task<IdentityResult> SetPhoneNumberAsync(IUserBase user, string phoneNumber)
    {
      return u.SetPhoneNumberAsync(user as T, phoneNumber);
    }

    public Task<IdentityResult> SetTwoFactorEnabledAsync(IUserBase user, bool enabled)
    {
      return u.SetTwoFactorEnabledAsync(user as T, enabled);
    }

    public Task<IdentityResult> UpdateAsync(IUserBase user)
    {
      return u.UpdateAsync(user as T);
    }

    public Task UpdateNormalizedEmailAsync(IUserBase user)
    {
      return u.UpdateNormalizedEmailAsync(user as T);
    }

    public Task UpdateNormalizedUserNameAsync(IUserBase user)
    {
      return u.UpdateNormalizedUserNameAsync(user as T);
    }

    public Task<IdentityResult> UpdateSecurityStampAsync(IUserBase user)
    {
      return u.UpdateSecurityStampAsync(user as T);
    }

    public Task<bool> VerifyChangePhoneNumberTokenAsync(IUserBase user, string token, string phoneNumber)
    {
      return u.VerifyChangePhoneNumberTokenAsync(user as T, token, phoneNumber);
    }

    public Task<bool> VerifyTwoFactorTokenAsync(IUserBase user, string tokenProvider, string token)
    {
      return u.VerifyTwoFactorTokenAsync(user as T, tokenProvider, token);
    }

    public Task<bool> VerifyUserTokenAsync(IUserBase user, string tokenProvider, string purpose, string token)
    {
      return u.VerifyUserTokenAsync(user as T, tokenProvider, purpose, token);
    }
  }
}
