using Domain.Entites;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Identity
{
    public interface IJwtFactory
    {
        Task<SecurityToken> GenerateToken(AppUser user);
        
    }
}
