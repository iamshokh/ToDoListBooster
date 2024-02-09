using Microsoft.IdentityModel.Tokens;
using StatusGeneric;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ToDoListBooster.Core.Security;
using ToDoListBooster.DataLayer.EfClasses;
using ToDoListBooster.DataLayer.EfCode;

namespace ToDoListBooster.BizLogicLayer.AccountService
{
    public class AccountService : StatusGenericHandler, IAccountService
    {
        private readonly JwtSettings _settings;
        private readonly EfCoreContext _context;
        public AccountService(EfCoreContext context, JwtSettings settings)
        {
            _settings = settings;
            _context = context;
        }

        public async Task<LoginResponseDto> Login(LoginDto dto)
        {
            try
            {
                var result = await AuthenticateAsync(dto.NameOrEmail, dto.Password);
                if (!IsValid)
                {
                    AddError("Ошибка при Аутентификации");
                    return null;
                }
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<LoginResponseDto> Regester(RegistrateDto dto)
        {
            try
            {
                var newUser = new User(dto.Password)
                {
                    UserName = dto.UserName,
                    Email = dto.Email
                };
                if (!IsValid)
                {
                    AddError("Ошибка при Регистрации");
                    return null;
                }
                _context.Users.Add(newUser);
                _context.SaveChanges();

                var result = await AuthenticateAsync(dto.UserName, dto.Password);

                return result;
            }
            catch (Exception)
            {
                throw;
            }

        }

        private async Task<LoginResponseDto> AuthenticateAsync(
            string nameOrEmail,
            string password
            )
        {
            if (!IsValidUser(nameOrEmail, password))
            {
                AddError("Неправильное имя пользователя или пароль");
                return null;
            }

            var tokenHandler = new JwtSecurityTokenHandler();

            var signingKey =
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.SecretKey));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = _settings.Issuer,
                Audience = _settings.Audience,
                Expires = DateTime.UtcNow.AddMinutes(_settings.ExpiresInMinutes),
                SigningCredentials = new SigningCredentials(signingKey,
                                                            SecurityAlgorithms.HmacSha256),
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, nameOrEmail),
                    new Claim(ClaimTypes.Role, "Admin")
                })
            };


            var token = tokenHandler.CreateToken(tokenDescriptor);
            var user = ByUserName(nameOrEmail);

            var result = new LoginResponseDto()
            {
                Token = tokenHandler.WriteToken(token),
                User = new UserDto() { UserName = user.UserName, Email = user.Email }
            };

            return result;
        }

        private bool IsValidUser(string nameOrEmail,
                                 string password)
        {
            if (string.IsNullOrWhiteSpace(nameOrEmail) ||
                string.IsNullOrWhiteSpace(password))
            {
                //AddError("Неправильное имя пользователя или пароль");
                return false;
            }

            var user = ByUserName(nameOrEmail);

            if (user == null || !user.IsValidPassword(password))
            {
                //ddError("Неправильное имя пользователя или пароль");
                return false;
            }

            return true;
        }

        private User ByUserName(string nameOrEmail)
        {
            var entity = _context.Set<User>()
                            .FirstOrDefault(a => a.UserName == nameOrEmail || a.Email == nameOrEmail);

            if (entity == null)
                throw new Exception("По вашему запросу запись не найдено");

            return entity;
        }
    }
}
