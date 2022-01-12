using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.Net.Http.Headers;

namespace UIBlazor.Data
{
    public class OpenIdConnectHandler : RemoteAuthenticationHandler<OpenIdConnectOptions>, IAuthenticationSignOutHandler
    {
        public OpenIdConnectHandler(IOptionsMonitor<OpenIdConnectOptions> options,
                                    ILoggerFactory logger,
                                    UrlEncoder encoder,
                                    ISystemClock clock) : base(options, logger, encoder, clock)
        {
        }

        protected override Task<HandleRequestResult> HandleRemoteAuthenticateAsync()
        {
            throw new ArgumentNullException();
        }

        public async Task SignOutAsync(AuthenticationProperties? properties)
        {
            var target = ResolveTarget(Options.ForwardSignOut);
            if (target != null)
            {
                await Context.SignOutAsync(target, properties);
            }
        }
    }
}
