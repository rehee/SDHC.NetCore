using Common.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using SDHC.UserAndRoles.Models;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using UserIdentity.Services;

namespace SDHC.UserAndRoles.Services
{
  public class SDHCSignInService<T> :
    ISDHCSignInService<IdentityResult, Claim, SignInResult, ClaimsPrincipal, AuthenticationProperties, AuthenticationScheme, ExternalLoginInfo>
    where T : SDHCUser, new()
  {
    private SignInManager<T> signInManager { get; }
    //public SDHCSignInService(SignInManager<T> signInManager)
    //{
    //  this.signInManager = signInManager;
    //}

    public Task<bool> CanSignInAsync(IUserBase user)
    {
      return signInManager.CanSignInAsync(user as T);
    }

    public Task<SignInResult> CheckPasswordSignInAsync(IUserBase user, string password, bool lockoutOnFailure)
    {
      return signInManager.CheckPasswordSignInAsync(user as T, password, lockoutOnFailure);
    }

    public async Task<dynamic> GetTwoFactorAuthenticationUserAsync()
    {
      return await signInManager.GetTwoFactorAuthenticationUserAsync();
    }

    public Task<bool> IsTwoFactorClientRememberedAsync(IUserBase user)
    {
      return signInManager.IsTwoFactorClientRememberedAsync(user as T);
    }

    public Task<ClaimsPrincipal> CreateUserPrincipalAsync(IUserBase user)
    {
      return signInManager.CreateUserPrincipalAsync(user as T);
    }

    public AuthenticationProperties ConfigureExternalAuthenticationProperties(string provider, string redirectUrl, string userId = null)
    {
      return signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl, userId);
    }

    public Task<SignInResult> ExternalLoginSignInAsync(string loginProvider, string providerKey, bool isPersistent, bool bypassTwoFactor)
    {
      return signInManager.ExternalLoginSignInAsync(loginProvider, providerKey, isPersistent, bypassTwoFactor);
    }

    public Task<SignInResult> ExternalLoginSignInAsync(string loginProvider, string providerKey, bool isPersistent)
    {
      return signInManager.ExternalLoginSignInAsync(loginProvider, providerKey, isPersistent);
    }

    public Task ForgetTwoFactorClientAsync()
    {
      return signInManager.ForgetTwoFactorClientAsync();
    }

    public Task<IEnumerable<AuthenticationScheme>> GetExternalAuthenticationSchemesAsync()
    {
      return signInManager.GetExternalAuthenticationSchemesAsync();
    }

    public Task<ExternalLoginInfo> GetExternalLoginInfoAsync(string expectedXsrf = null)
    {
      return signInManager.GetExternalLoginInfoAsync(expectedXsrf);
    }

    public bool IsSignedIn(ClaimsPrincipal principal)
    {
      return signInManager.IsSignedIn(principal);
    }

    public Task<SignInResult> PasswordSignInAsync(string userName, string password, bool isPersistent, bool lockoutOnFailure)
    {
      return signInManager.PasswordSignInAsync(userName, password, isPersistent, lockoutOnFailure);
    }

    public Task<SignInResult> PasswordSignInAsync(IUserBase user, string password, bool isPersistent, bool lockoutOnFailure)
    {
      return signInManager.PasswordSignInAsync(user as T, password, isPersistent, lockoutOnFailure);
    }

    public Task RefreshSignInAsync(IUserBase user)
    {
      return signInManager.RefreshSignInAsync(user as T);
    }

    public Task RememberTwoFactorClientAsync(IUserBase user)
    {
      return signInManager.RememberTwoFactorClientAsync(user as T);
    }

    public Task SignInAsync(IUserBase user, bool isPersistent, string authenticationMethod = null)
    {
      return signInManager.SignInAsync(user as T, isPersistent, authenticationMethod);
    }

    public Task SignInAsync(IUserBase user, AuthenticationProperties authenticationProperties, string authenticationMethod = null)
    {
      return signInManager.SignInAsync(user as T, authenticationProperties, authenticationMethod);
    }

    public Task SignInWithClaimsAsync(IUserBase user, AuthenticationProperties authenticationProperties, IEnumerable<Claim> additionalClaims)
    {
      return signInManager.SignInWithClaimsAsync(user as T, authenticationProperties, additionalClaims);
    }

    public Task SignInWithClaimsAsync(IUserBase user, bool isPersistent, IEnumerable<Claim> additionalClaims)
    {
      return signInManager.SignInWithClaimsAsync(user as T, isPersistent, additionalClaims);
    }

    public Task SignOutAsync()
    {
      return signInManager.SignOutAsync();
    }

    public Task<SignInResult> TwoFactorAuthenticatorSignInAsync(string code, bool isPersistent, bool rememberClient)
    {
      return signInManager.TwoFactorAuthenticatorSignInAsync(code, isPersistent, rememberClient);
    }

    public Task<SignInResult> TwoFactorRecoveryCodeSignInAsync(string recoveryCode)
    {
      return signInManager.TwoFactorRecoveryCodeSignInAsync(recoveryCode);
    }

    public Task<SignInResult> TwoFactorSignInAsync(string provider, string code, bool isPersistent, bool rememberClient)
    {
      return signInManager.TwoFactorSignInAsync(provider, code, isPersistent, rememberClient);
    }

    public Task<IdentityResult> UpdateExternalAuthenticationTokensAsync(ExternalLoginInfo externalLogin)
    {
      return signInManager.UpdateExternalAuthenticationTokensAsync(externalLogin);
    }

    public async Task<IUserBase> ValidateSecurityStampAsync(ClaimsPrincipal principal)
    {
      return await signInManager.ValidateSecurityStampAsync(principal);
    }

    public Task<bool> ValidateSecurityStampAsync(IUserBase user, string securityStamp)
    {
      return signInManager.ValidateSecurityStampAsync(user as T, securityStamp);
    }

    public async Task<IUserBase> ValidateTwoFactorSecurityStampAsync(ClaimsPrincipal principal)
    {
      return await signInManager.ValidateTwoFactorSecurityStampAsync(principal);
    }
  }
}
