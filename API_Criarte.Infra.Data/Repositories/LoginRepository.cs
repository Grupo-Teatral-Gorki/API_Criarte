using API_Criarte.Domain.Interfaces;
using API_Criarte.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API_Criarte.Domain.Models;
using Microsoft.EntityFrameworkCore;
using API_Criarte.Domain;

namespace API_Criarte.Infra.Data.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        private readonly dbContext _dbContext;

        public LoginRepository(dbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> VerifyExistingUser(string usuario)
        {
            var user = await _dbContext.Usuarios.AsNoTracking().Where(x => x.Usuario.Equals(usuario)).FirstOrDefaultAsync();
            if (user == null)
            {
                return false;
            }
            return true;
        }

        public async Task<ApiResponse> CreateUser(Usuarios login)
        {
            if (await VerifyExistingUser(login.Usuario))
            {
                return new ApiResponse(true, "Usuario já existe no sistema");
            }
            _dbContext.Usuarios.Add(login);
            _dbContext.SaveChanges();

            return new ApiResponse(false, "Usuario cadastrado com sucesso");
        }

        public async Task<Usuarios> GetUser(Usuarios login)
        {
            var usuario = await _dbContext.Usuarios.Where(x => x.Usuario == login.Usuario && x.Senha == login.Senha).FirstOrDefaultAsync();

            return usuario;
        }
    }
}
