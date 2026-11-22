using KASHOP.DAL.DTO.Requests;
using KASHOP.DAL.DTO.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace KASHOP.BLL
{
    public interface IAuthService
    {
        Task<( bool success , List<string> Errors)> RegisterAsync(RegisterRequest request) ;
        Task<(bool success, List<string> Errors , LoginResponse response)> LoginAsync(LoginRequest request);
        Task<(bool Success, string? Error)> ConfirmEmailAsync(string userId, string token);
    }
}
