using Common.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace UserIdentity.Services
{
  public interface ISDHCSignInService<TUser, IdentityResult, Claim, SignInResult, ClaimsPrincipal, AuthenticationProperties, AuthenticationScheme, ExternalLoginInfo>
  {
    Task<bool> CanSignInAsync(TUser user);
    Task<SignInResult> CheckPasswordSignInAsync(TUser user, string password, bool lockoutOnFailure);
    Task<dynamic> GetTwoFactorAuthenticationUserAsync();
    Task<bool> IsTwoFactorClientRememberedAsync(TUser user);
    Task<ClaimsPrincipal> CreateUserPrincipalAsync(TUser user);


    AuthenticationProperties ConfigureExternalAuthenticationProperties(string provider, string redirectUrl, string userId = null);
    Task<SignInResult> ExternalLoginSignInAsync(string loginProvider, string providerKey, bool isPersistent, bool bypassTwoFactor);
    Task<SignInResult> ExternalLoginSignInAsync(string loginProvider, string providerKey, bool isPersistent);
    Task ForgetTwoFactorClientAsync();
    Task<IEnumerable<AuthenticationScheme>> GetExternalAuthenticationSchemesAsync();
    Task<ExternalLoginInfo> GetExternalLoginInfoAsync(string expectedXsrf = null);
    bool IsSignedIn(ClaimsPrincipal principal);

    Task<SignInResult> PasswordSignInAsync(string userName, string password, bool isPersistent, bool lockoutOnFailure);
    Task<SignInResult> PasswordSignInAsync(TUser user, string password, bool isPersistent, bool lockoutOnFailure);
    Task RefreshSignInAsync(TUser user);
    Task RememberTwoFactorClientAsync(TUser user);
    Task SignInAsync(TUser user, bool isPersistent, string authenticationMethod = null);

    Task SignInAsync(TUser user, AuthenticationProperties authenticationProperties, string authenticationMethod = null);
    Task SignInWithClaimsAsync(TUser user, AuthenticationProperties authenticationProperties, IEnumerable<Claim> additionalClaims);
    Task SignInWithClaimsAsync(TUser user, bool isPersistent, IEnumerable<Claim> additionalClaims);
    Task SignOutAsync();
    Task<SignInResult> TwoFactorAuthenticatorSignInAsync(string code, bool isPersistent, bool rememberClient);
    Task<SignInResult> TwoFactorRecoveryCodeSignInAsync(string recoveryCode);
    Task<SignInResult> TwoFactorSignInAsync(string provider, string code, bool isPersistent, bool rememberClient);
    Task<IdentityResult> UpdateExternalAuthenticationTokensAsync(ExternalLoginInfo externalLogin);
    Task<TUser> ValidateSecurityStampAsync(ClaimsPrincipal principal);
    Task<bool> ValidateSecurityStampAsync(TUser user, string securityStamp);
    Task<TUser> ValidateTwoFactorSecurityStampAsync(ClaimsPrincipal principal);
  }
}
