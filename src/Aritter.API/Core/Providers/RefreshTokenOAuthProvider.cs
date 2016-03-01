using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Infrastructure;
using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace Aritter.API.Core.Providers
{
    internal class RefreshTokenOAuthProvider : IAuthenticationTokenProvider
    {
        // TODO: trocar para memory cache
        private static ConcurrentDictionary<string, AuthenticationTicket> refreshTokens = new ConcurrentDictionary<string, AuthenticationTicket>();

        public void Create(AuthenticationTokenCreateContext context)
        {
            var guid = Guid.NewGuid().ToString();

            context.Ticket.Properties.ExpiresUtc = context.Ticket.Properties.ExpiresUtc.GetValueOrDefault().LocalDateTime.AddMinutes(20);

            // maybe only create a handle the first time, then re-use
            refreshTokens.TryAdd(guid, context.Ticket);

            // consider storing only the hash of the handle
            context.SetToken(guid);
        }

        public async Task CreateAsync(AuthenticationTokenCreateContext context)
        {
            await Task.Run(() =>
            {
                Create(context);
            });
        }

        public void Receive(AuthenticationTokenReceiveContext context)
        {
            AuthenticationTicket ticket;

            if (refreshTokens.TryRemove(context.Token, out ticket))
            {
                context.SetTicket(ticket);
            }
        }

        public async Task ReceiveAsync(AuthenticationTokenReceiveContext context)
        {
            await Task.Run(() =>
            {
                Receive(context);
            });
        }
    }
}
