﻿using API_Criarte.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Criarte.Domain.Interfaces
{
    public interface IProjetoRepository
    {
        Task<List<Projeto>> GetProjeto();
        Task<long> CreateProjeto(Projeto projeto);
        Task<int> UpdateProjeto(Projeto projeto);
        Task<int> AlterarStatus(int idProjeto, string status);
    }
}
