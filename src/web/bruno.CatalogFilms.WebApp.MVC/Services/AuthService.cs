﻿
using Microsoft.Extensions.Options;
using bruno.CatalogFilms.WebApp.MVC.Extensions;
using bruno.CatalogFilms.WebApp.MVC.Services.Interface;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using bruno.CatalogFilms.WebApp.MVC.Services;
using bruno.CatalogFilms.Model.View;
using bruno.CatalogFilms.Core;

namespace SmartStore.WebApp.MVC.Services
{
    public class AuthService : Service, IAuthService
    {
        private readonly HttpClient _httpClient;

        public AuthService(HttpClient httpClient, IOptions<AppSettings> settings)
        {
            httpClient.BaseAddress = new Uri(settings.Value.AuthUrl);

            _httpClient = httpClient;
        }

        public async Task<UserResponseLogin> Login(UserLogin userLogin)
        {
            var loginContent = GetContent(userLogin);

            var response = await _httpClient.PostAsync("/api/identity/Login", loginContent);

            if (!CustomContainErrorResponse(response))
            {
                return new UserResponseLogin
                {
                    ResponseResult = await DeserializeObjectResponse<ResponseResult>(response)
                };
            }

            return await DeserializeObjectResponse<UserResponseLogin>(response);
        }

        public async Task<UserResponseLogin> Register(UserRegister userRegister)
        {
            var registerContent = GetContent(userRegister);

            var response = await _httpClient.PostAsync("/api/identity/RegisterUser", registerContent);

            if (!CustomContainErrorResponse(response))
            {
                return new UserResponseLogin
                {
                    ResponseResult = await DeserializeObjectResponse<ResponseResult>(response)
                };
            }

            return await DeserializeObjectResponse<UserResponseLogin>(response);
        }
    }
}
