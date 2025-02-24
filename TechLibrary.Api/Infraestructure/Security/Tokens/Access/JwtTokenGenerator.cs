using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using TechLibrary.Api.Domain.Entities;

namespace TechLibrary.Api.Infraestructure.Security.Tokens.Access
{
    public class JwtTokenGenerator
    {
        public string Generate(User user)
        {
            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString())
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Expires = DateTime.UtcNow.AddMinutes(60),
                Subject = new ClaimsIdentity(claims),
                SigningCredentials = new SigningCredentials(SecurityKey(), SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var securityToken = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(securityToken); 
        }

        private SymmetricSecurityKey SecurityKey()
        {
            // Essa key precisa ser armazenada de forma segura
            // É ela quem vai determinar qual é a chave para criptografar as partes do token,
            // para garantir que só a sua api que consegue gerar tokens válidos, e também validar.
            // Para testar gerar uma password aleatório de 32 caracteres   
            // Lembrando que essa signingKey deve ser implementada com injeção de dependência
            // Inserir a key em Program.cs
            var signingKey = "";

            var symmetricKey = Encoding.UTF8.GetBytes(signingKey);

            return new SymmetricSecurityKey(symmetricKey);
        }
    }
}
