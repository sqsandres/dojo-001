using Dojo.Bakery.BuildingBlocks.CustomExceptions;
using Dojo.Bakery.BuildingBlocks.WebCommons;
using Dojo.Bakery.BuildingBlocks.WebCommons.Models;
using Dojo.Bakery.Security.Domain;
using IdentityServer4;
using IdentityServer4.Configuration;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;
using System.Security.Claims;

namespace Dojo.Bakery.Security.API.Controllers
{
    /// <summary>
    ///   Controller for login and logout operations
    /// </summary>
    [ApiController]
    [Produces("application/json")]
    [Route("api/account")]
    [AllowAnonymous]
    public class AccountController : BaseController
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IdentityServerOptions _identityServerOptions;
        private readonly IdentityServerTools _tools;
        private readonly IMediator _mediator;
        private readonly ILogger<AccountController> _logger;
        /// <summary>Initializes a new instance of the <see cref="AccountController" /> class.</summary>
        /// <param name="mediator">The mediator.</param>
        /// <param name="signInManager">The sign in manager.</param>
        /// <param name="identityServerOptions">The identity server options.</param>
        /// <param name="tools">The tools.</param>
        /// <param name="logger">The logger.</param>
        public AccountController(
            IMediator mediator,
            SignInManager<ApplicationUser> signInManager,
            IdentityServerOptions identityServerOptions,
            IdentityServerTools tools,
            ILogger<AccountController> logger)
        {
            _mediator = mediator;
            _signInManager = signInManager;
            _identityServerOptions = identityServerOptions;
            _tools = tools;
            _logger = logger;
        }
        [HttpGet("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(string? returnUrl)
        {
            return ExternalLogin("oidc", returnUrl);
        }
        /// <summary>
        /// Handle logout page postback
        /// <response code="200">Returned if the operation was completed</response>
        /// <response code="400">Returned if the operation fails</response>
        /// </summary>
        [HttpPost("Logout")]
        [AllowAnonymous]
        public async Task<ActionResult<Response>> Logout()
        {
            if (User.Identity is { IsAuthenticated: false })
            {
                return Result(true);
            }
            await _signInManager.SignOutAsync();
            return Result(true);
        }
        /// <summary>
        /// Externals the login.
        /// </summary>
        /// <param name="provider">The provider.</param>
        /// <param name="returnUrl">The return URL.</param>
        /// <returns></returns>
        [HttpPost]
        [HttpGet]
        [AllowAnonymous]
        public IActionResult ExternalLogin(string provider, string? returnUrl = null)
        {
            // Request a redirect to the external login provider.
            var redirectUrl = Url.Action("ExternalLoginCallback", "Account", new { ReturnUrl = returnUrl });
            var properties = _signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
            return Challenge(properties, provider);
        }
        /// <summary>
        /// Externals the login callback.
        /// </summary>
        /// <param name="returnUrl">The return URL.</param>
        /// <param name="remoteError">The remote error.</param>
        /// <returns></returns>
        /// <exception cref="System.Security.SecurityException">
        /// Not info for external login was found
        /// or
        /// User email was not found
        /// or
        /// User was not found on our system
        /// or
        /// Login error. " + AzureIdentityErrorHelper.GetErrors(signInResult.Errors)
        /// </exception>
        [HttpGet("Callback")]
        [AllowAnonymous]
        public async Task<IActionResult> ExternalLoginCallback(string? returnUrl = null, string? remoteError = null)
        {
            if (remoteError != null)
            {
                throw new SecurityException(remoteError);
            }
            ExternalLoginInfo info = await _signInManager.GetExternalLoginInfoAsync();
            if (info == null)
            {
                throw new SecurityException("Not info for external login was found");
            }
            string email = info.Principal.FindFirstValue("preferred_username");
            if (string.IsNullOrEmpty(email))
            {
                throw new SecurityException("User email was not found");
            }

            List<Claim> claims = (from c in info.Principal.Identities.FirstOrDefault().Claims
                                 select c).ToList();
            /*
            ApplicationUser userFound = await _userManager.FindByEmailAsync(email);
            if (userFound == null)
            {
                throw new SecurityException("User was not found on our system");
            }
            IdentityResult signInResult = await _userManager.AddLoginAsync(userFound, info);
            if (!signInResult.Succeeded && !signInResult.Errors.Any(x => x.Code == "LoginAlreadyAssociated"))
            {
                throw new SecurityException("Login error. " + AzureIdentityErrorHelper.GetErrors(signInResult.Errors));
            }
            */
            //await _signInManager.SignInAsync(userFound, isPersistent: false);
            // Sign in the user with this external login provider if the user already has a login.
            //Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, isPersistent: false);
            //if (!result.Succeeded)
            //{
            //    throw new SecurityException("Login error");
            //}
            //ClaimsPrincipal claimsPrincipal = await _principalFactory.CreateAsync(userFound);
            /*
            if (claimsPrincipal == null)
            {
                throw new SecurityException("User was not found on our system");
            }
            List<Claim> claims = claimsPrincipal.Claims.ToList();
            claims.Add(new Claim(Core.ClaimTypes.TENANT_ID, tenant.NormalizedCanonicalName));
            if (claims.All(x => x.Type != "Grant"))
            {
                claims.Add(new Claim("Grant", "GeneralApp.User"));
            }
            List<ClaimGrant> userClaims = await _mediator.Send(new GetAllUserClaimByUserIdQuery() { Id = userFound.Id });
            foreach (var userClaim in userClaims)
            {
                claims.Add(new Claim("Grant", userClaim.Name));
            }*/
            //_logger.LogInformation($"[IdSe] Access to the system: {email}, tenant:{tenant.NormalizedCanonicalName}, claims: {format(claims)}");
            int lifeTimeInSeconds = Convert.ToInt32((DateTime.Now.AddDays(1).Date - DateTime.Now).TotalSeconds) + 18000;
            claims.Add(new Claim("Grant", "UserAccess"));
            string token = await _tools.IssueJwtAsync(
                lifeTimeInSeconds,
                _identityServerOptions.IssuerUri, claims
                //new List<Claim>() { 
                //    new Claim("Grant", "UserAccess"),
                //    //new Claim("oid", "YOUR_CLIENTID"),
                //    //new Claim(JwtRegisteredClaimNames.Sub, "YOUR_CLIENTID"),
                //    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                //}
                );
            return Redirect(returnUrl + "?Token=" + token);
        }
        private string format(List<Claim> claims)
        {
            return string.Join(",", from a in claims select a.Value);
        }
    }
}