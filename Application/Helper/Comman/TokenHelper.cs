using Domains.Entities.Users;
using System.Security.Cryptography;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;


namespace Application.Helper.Comman
{
    public static class TokenHelper
    {
        public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }
               
        public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public static string GetJWTToken(UserEntity user, RoleEntity role)
        {
            List<Claim> claims = new List<Claim>()
            {
                 new Claim("Id",user.UserId.ToString()),
                new Claim(ClaimTypes.Name,user.FirstName + " " + user.MiddleName + " " + user.LastName),
                new Claim("Role", string.IsNullOrWhiteSpace(role.RoleName) ? "unknown": role.RoleName)
            };

            SymmetricSecurityKey securitykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("MIGfMA0GCSqGSIb3DQEBAQUAA4GNADCBiQKBgQCbFbJIzWVoIkIQ9nEmOn5DVcyqDWNXEmkYwMf0BGp1E2INwkMtSDr0SxNhFvctFizLsFkyvHfc KxFGVIUhauUDzeAlDhnmy0BO"));
            SigningCredentials credentials = new SigningCredentials(securitykey, SecurityAlgorithms.HmacSha256Signature);
            JwtSecurityToken securityToken = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: credentials);

            string token = new JwtSecurityTokenHandler().WriteToken(securityToken);


            return token ?? string.Empty;


        }
    }
}
