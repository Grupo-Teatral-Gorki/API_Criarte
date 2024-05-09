using API_Criarte.Domain.Models;
using API_Criarte.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Criarte.Domain.Interfaces
{
    public interface ILoginRepository
    {
        Task<ApiResponse<object>> CreateUser(Usuarios login);
        Task<Usuarios> GetUser(Usuarios login);
        Task<Usuarios> GetUserByToken(string token);
        Task<int> UpdateUser(Usuarios user);
        Task<bool> VerifyExistingUser(string usuario);
        Task<int> SaveToken(string user, string token);
    }
}
