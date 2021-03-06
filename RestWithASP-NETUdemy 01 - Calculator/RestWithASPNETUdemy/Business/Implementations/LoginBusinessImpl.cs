﻿using Microsoft.IdentityModel.Tokens;
using RestWithASPNETUdemy.Data.VO;
using RestWithASPNETUdemy.Repository;
using RestWithASPNETUdemy.Security.Configuration;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;

namespace RestWithASPNETUdemy.Business.Implementations
{
    public class LoginBusinessImpl : ILoginBusiness
    {
        private IUserRepository _repository;
        private SigningConfigurations _signingConfigurations;
        private TokenConfigurations _tokenConfigurations;

        public LoginBusinessImpl(IUserRepository repository, SigningConfigurations signingConfigurations, TokenConfigurations tokenConfigurations)
        {
            _repository = repository;
            _signingConfigurations = signingConfigurations;
            _tokenConfigurations = tokenConfigurations;
        }

        public object FindByLogin(UserVO user)
        {
            bool credentialIsValid = false;
            if (user != null && !string.IsNullOrWhiteSpace(user.Login))
            {
                var baseUser = _repository.FindByLogin(user.Login);
                credentialIsValid = (baseUser != null && user.Login == baseUser.Login && user.AccessKey == baseUser.AccessKey);
            }
            if (credentialIsValid)
            {
                ClaimsIdentity identity = new ClaimsIdentity(
                    new GenericIdentity(user.Login, "Login"),
                    new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                        new Claim(JwtRegisteredClaimNames.UniqueName, user.Login)
                    }
                );
                DateTime createDate = DateTime.Now;
                DateTime expirationDate = createDate + TimeSpan.FromSeconds(_tokenConfigurations.Seconds);
                var handler = new JwtSecurityTokenHandler();
                string token = CreateToken(identity, createDate, expirationDate, handler);
                return SuccesObject(createDate, expirationDate, token);
            } else
            {
                return ExceptionObject();
            }
        }

        private string CreateToken(ClaimsIdentity identity, DateTime createDate, DateTime expirationDate, JwtSecurityTokenHandler handler)
        {
            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _tokenConfigurations.Issuer,
                Audience = _tokenConfigurations.Audience,
                SigningCredentials = _signingConfigurations.SigningCredentials,
                Subject = identity,
                NotBefore = createDate,
                Expires = expirationDate
            });

            var token = handler.WriteToken(securityToken);
            return token;
        }

        private object SuccesObject(DateTime createDate, DateTime expirationDate, string token)
        {
            return new
            {
                autenticated = true,
                created = createDate.ToString("yyyy-MM-dd HH:mm:ss"),
                expiration = expirationDate.ToString("yyyy-MM-dd HH:mm:ss"),
                accessToken = token,
                message = "OK"
            };
        }

        private object ExceptionObject()
        {
            return new
            {
                autenticated = false,
                message = "Failed to authenticate"
            };
        }
    }
}
