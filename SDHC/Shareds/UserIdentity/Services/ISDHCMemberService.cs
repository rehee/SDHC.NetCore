using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserIdentity.Services
{
  public interface ISDHCMemberService<IdentityResult, Claim, ClaimsPrincipal, UserLoginInfo>
  {
    IQueryable<IUserBase> Users { get; }
    IEnumerable<dynamic> UserValidators { get; }
    Task<IdentityResult> AccessFailedAsync(IUserBase user);
    Task<IdentityResult> AddClaimAsync(IUserBase user, Claim claim);
    Task<IdentityResult> AddClaimsAsync(IUserBase user, IEnumerable<Claim> claims);
    Task<IdentityResult> AddLoginAsync(IUserBase user, UserLoginInfo login);
    Task<IdentityResult> AddPasswordAsync(IUserBase user, string password);
    Task<IdentityResult> AddToRoleAsync(IUserBase user, string role);
    Task<IdentityResult> AddToRolesAsync(IUserBase user, IEnumerable<string> roles);
    Task<IdentityResult> ChangeEmailAsync(IUserBase user, string newEmail, string token);
    Task<IdentityResult> ChangePasswordAsync(IUserBase user, string currentPassword, string newPassword);
    Task<IdentityResult> ChangePhoneNumberAsync(IUserBase user, string phoneNumber, string token);
    Task<bool> CheckPasswordAsync(IUserBase user, string password);
    Task<IdentityResult> ConfirmEmailAsync(IUserBase user, string token);
    Task<int> CountRecoveryCodesAsync(IUserBase user);
    Task<IdentityResult> CreateAsync(IUserBase user);
    Task<IdentityResult> CreateAsync(IUserBase user, string password);
    Task<byte[]> CreateSecurityTokenAsync(IUserBase user);
    Task<IdentityResult> DeleteAsync(IUserBase user);
    public void Dispose();
    Task<IUserBase> FindByEmailAsync(string email);
    Task<IUserBase> FindByIdAsync(string userId);
    Task<IUserBase> FindByLoginAsync(string loginProvider, string providerKey);
    Task<IUserBase> FindByNameAsync(string userName);
    Task<string> GenerateChangeEmailTokenAsync(IUserBase user, string newEmail);
    Task<string> GenerateChangePhoneNumberTokenAsync(IUserBase user, string phoneNumber);
    Task<string> GenerateConcurrencyStampAsync(IUserBase user);
    Task<string> GenerateEmailConfirmationTokenAsync(IUserBase user);
    string GenerateNewAuthenticatorKey();
    Task<IEnumerable<string>> GenerateNewTwoFactorRecoveryCodesAsync(IUserBase user, int number);
    Task<string> GeneratePasswordResetTokenAsync(IUserBase user);
    Task<string> GenerateTwoFactorTokenAsync(IUserBase user, string tokenProvider);
    Task<string> GenerateUserTokenAsync(IUserBase user, string tokenProvider, string purpose);
    Task<int> GetAccessFailedCountAsync(IUserBase user);
    Task<string> GetAuthenticationTokenAsync(IUserBase user, string loginProvider, string tokenName);
    Task<string> GetAuthenticatorKeyAsync(IUserBase user);
    Task<IList<Claim>> GetClaimsAsync(IUserBase user);
    Task<string> GetEmailAsync(IUserBase user);
    Task<bool> GetLockoutEnabledAsync(IUserBase user);
    Task<DateTimeOffset?> GetLockoutEndDateAsync(IUserBase user);
    Task<IList<UserLoginInfo>> GetLoginsAsync(IUserBase user);
    Task<string> GetPhoneNumberAsync(IUserBase user);
    Task<IList<string>> GetRolesAsync(IUserBase user);
    Task<string> GetSecurityStampAsync(IUserBase user);
    Task<bool> GetTwoFactorEnabledAsync(IUserBase user);
    Task<IUserBase> GetUserAsync(ClaimsPrincipal principal);
    string GetUserId(ClaimsPrincipal principal);
    Task<string> GetUserIdAsync(IUserBase user);
    string GetUserName(ClaimsPrincipal principal);
    Task<string> GetUserNameAsync(IUserBase user);
    Task<IEnumerable<IUserBase>> GetUsersForClaimAsync(Claim claim);
    Task<IEnumerable<IUserBase>> GetUsersInRoleAsync(string roleName);
    Task<IList<string>> GetValidTwoFactorProvidersAsync(IUserBase user);
    Task<bool> HasPasswordAsync(IUserBase user);
    Task<bool> IsEmailConfirmedAsync(IUserBase user);
    Task<bool> IsInRoleAsync(IUserBase user, string role);
    Task<bool> IsLockedOutAsync(IUserBase user);
    Task<bool> IsPhoneNumberConfirmedAsync(IUserBase user);
    string NormalizeEmail(string email);
    string NormalizeName(string name);
    Task<IdentityResult> RedeemTwoFactorRecoveryCodeAsync(IUserBase user, string code);
    void RegisterTokenProvider(string providerName, dynamic provider);
    Task<IdentityResult> RemoveAuthenticationTokenAsync(IUserBase user, string loginProvider, string tokenName);
    Task<IdentityResult> RemoveClaimAsync(IUserBase user, Claim claim);
    Task<IdentityResult> RemoveClaimsAsync(IUserBase user, IEnumerable<Claim> claims);
    Task<IdentityResult> RemoveFromRoleAsync(IUserBase user, string role);
    Task<IdentityResult> RemoveFromRolesAsync(IUserBase user, IEnumerable<string> roles);
    Task<IdentityResult> RemoveLoginAsync(IUserBase user, string loginProvider, string providerKey);
    Task<IdentityResult> RemovePasswordAsync(IUserBase user);
    Task<IdentityResult> ReplaceClaimAsync(IUserBase user, Claim claim, Claim newClaim);
    Task<IdentityResult> ResetAccessFailedCountAsync(IUserBase user);
    Task<IdentityResult> ResetAuthenticatorKeyAsync(IUserBase user);
    Task<IdentityResult> ResetPasswordAsync(IUserBase user, string token, string newPassword);
    Task<IdentityResult> SetAuthenticationTokenAsync(IUserBase user, string loginProvider, string tokenName, string tokenValue);
    Task<IdentityResult> SetEmailAsync(IUserBase user, string email);
    Task<IdentityResult> SetLockoutEnabledAsync(IUserBase user, bool enabled);
    Task<IdentityResult> SetLockoutEndDateAsync(IUserBase user, DateTimeOffset? lockoutEnd);
    Task<IdentityResult> SetPhoneNumberAsync(IUserBase user, string phoneNumber);
    Task<IdentityResult> SetTwoFactorEnabledAsync(IUserBase user, bool enabled);
    Task<IdentityResult> SetUserNameAsync(IUserBase user, string userName);
    Task<IdentityResult> UpdateAsync(IUserBase user);
    Task UpdateNormalizedEmailAsync(IUserBase user);
    Task UpdateNormalizedUserNameAsync(IUserBase user);
    Task<IdentityResult> UpdateSecurityStampAsync(IUserBase user);
    Task<bool> VerifyChangePhoneNumberTokenAsync(IUserBase user, string token, string phoneNumber);
    Task<bool> VerifyTwoFactorTokenAsync(IUserBase user, string tokenProvider, string token);
    Task<bool> VerifyUserTokenAsync(IUserBase user, string tokenProvider, string purpose, string token);

  }
}
