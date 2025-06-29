﻿using API_Criarte.Domain.Interfaces;
using API_Criarte.Domain.Models;
using API_Criarte.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Criarte.Infra.Data.Repositories
{
    public class ResponsaveisTecnicosRepository : IResponsaveisTecnicosRepository
    {
        private readonly dbContext _dbContext;

        public ResponsaveisTecnicosRepository(dbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<ResponsaveisTecnicos>> GetResponsaveisTecnicos()
        {
            var responsaveis = await _dbContext.ResponsaveisTecnicos.ToListAsync();
            return responsaveis;
        }

        public async Task<List<ResponsaveisTecnicos>> GetResponsaveisTecnicosById(int idProjeto)
        {
            var responsaveis = await _dbContext.ResponsaveisTecnicos.AsNoTracking().Where(x => x.IdProjeto.Equals(idProjeto)).ToListAsync();
            return responsaveis;
        }

        public async Task<ResponsaveisTecnicos> CreateResponsaveisTecnicos(ResponsaveisTecnicos responsavel)
        {
            await _dbContext.ResponsaveisTecnicos.AddAsync(responsavel);
            _dbContext.SaveChanges();

            return responsavel;
        }

        public async Task<int> UpdateResponsaveisTecnicos(ResponsaveisTecnicos responsavel)
        {
            _dbContext.ResponsaveisTecnicos.Update(responsavel);
            var saved_responsavel = await _dbContext.SaveChangesAsync();

            return saved_responsavel;
        }
    }
}
