using KASHOP.DAL.DTO.Requests;
using System;
using System.Collections.Generic;
using System.Text;

namespace KASHOP.BLL.Settings
{
    public interface IAuthService
    {
        Task<( bool success , List<string> Errors)> RegisterAsync(RegisterRequest request) ;
    }
}
