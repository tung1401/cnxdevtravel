using CNXDevTravel.Core;
using CNXDevTravel.Model.RequestModel;
using CNXDevTravel.Model.ResponseModel;
using CNXDevTravel.Repository.Interfaces;
using CNXDevTravel.Service.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CNXDevTravel.Service.Implements
{
    public class UserService : IUserService
    {
        private IUserRepository _user;
        public UserService(IUserRepository user)
        {
            _user = user;
        }

        public AuthenModel Authen(LoginModel loginModel)
        {
            //Password should be encrypted with public RSA asymetric key
            var user = _user.Get(m => m.Username == loginModel.Username && m.Password == loginModel.Password);
            if(user != null)
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.UTF8.GetBytes(CNXDevTravelWebAPIConfig.TokenKey);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.Name, loginModel.Username),
                        new Claim(ClaimTypes.GivenName, user.Name)
                    }),
                    Expires = DateTime.UtcNow.AddHours(12),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var authenModel = new AuthenModel()
                {
                    Name = user.Name,
                    ProfileImage = user.ProfileImage,
                    Token = tokenHandler.WriteToken(token)
                };
                return authenModel;
            }
            return null;
        }
    }
}
