using Discord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Butler.Core.ValueObjects
{
    internal class AuthVO
    {
        public string Token { get; init; }
        public TokenType? Type { get; init; }
    }
}
