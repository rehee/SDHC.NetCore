using Common.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace UserIdentity.Services
{
  public interface ISDHCSignInService<IdentityResult, Claim, SignInResult, ClaimsPrincipal, AuthenticationProperties, AuthenticationScheme, ExternalLoginInfo>
  {
    Task<bool> CanSignInAsync(IUserBase user);
    Task<SignInResult> CheckPasswordSignInAsync(IUserBase user, string password, bool lockoutOnFailure);
    Task<dynamic> GetTwoFactorAuthenticationUserAsync();
    Task<bool> IsTwoFactorClientRememberedAsync(IUserBase user);
    Task<ClaimsPrincipal> CreateUserPrincipalAsync(IUserBase user);


    AuthenticationProperties ConfigureExternalAuthenticationProperties(string provider, string redirectUrl, string userId = null);
    Task<SignInResult> ExternalLoginSignInAsync(string loginProvider, string providerKey, bool isPersistent, bool bypassTwoFactor);
    Task<SignInResult> ExternalLoginSignInAsync(string loginProvider, string providerKey, bool isPersistent);
    Task ForgetTwoFactorClientAsync();
    Task<IEnumerable<AuthenticationScheme>> GetExternalAuthenticationSchemesAsync();
    Task<ExternalLoginInfo> GetExternalLoginInfoAsync(string expectedXsrf = null);
    bool IsSignedIn(ClaimsPrincipal principal);

    Task<SignInResult> PasswordSignInAsync(string userName, string password, bool isPersistent, bool lockoutOnFailure);
    Task<SignInResult> PasswordSignInAsync(IUserBase user, string password, bool isPersistent, bool lockoutOnFailure);
    Task RefreshSignInAsync(IUserBase user);
    Task RememberTwoFactorClientAsync(IUserBase user);
    Task SignInAsync(IUserBase user, bool isPersistent, string authenticationMethod = null);

    Task SignInAsync(IUserBase user, AuthenticationProperties authenticationProperties, string authenticationMethod = null);
    Task SignInWithClaimsAsync(IUserBase user, AuthenticationProperties authenticationProperties, IEnumerable<Claim> additionalClaims);
    Task SignInWithClaimsAsync(IUserBase user, bool isPersistent, IEnumerable<Claim> additionalClaims);
    Task SignOutAsync();
    Task<SignInResult> TwoFactorAuthenticatorSignInAsync(string code, bool isPersistent, bool rememberClient);
    Task<SignInResult> TwoFactorRecoveryCodeSignInAsync(string recoveryCode);
    Task<SignInResult> TwoFactorSignInAsync(string provider, string code, bool isPersistent, bool rememberClient);
    Task<IdentityResult> UpdateExternalAuthenticationTokensAsync(ExternalLoginInfo externalLogin);
    Task<IUserBase> ValidateSecurityStampAsync(ClaimsPrincipal principal);
    Task<bool> ValidateSecurityStampAsync(IUserBase user, string securityStamp);
    Task<IUserBase> ValidateTwoFactorSecurityStampAsync(ClaimsPrincipal principal);
  }
}
