using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aritter.API.Models
{
    /// <summary>
    /// Token de autenticação do usuário
    /// </summary>
    public class AuthenticationToken
    {
        /// <summary>
        /// Token
        /// </summary>
        public string AccessToken { get; set; }

        /// <summary>
        /// Tipo do Token
        /// </summary>
        public string TokenType { get; set; }

        /// <summary>
        /// Tempo em segundos para a expiração token
        /// </summary>
        public int ExpiresIn { get; set; }
    }
}
