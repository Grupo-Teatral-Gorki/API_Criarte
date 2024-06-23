using API_Criarte.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace API_Criarte.Infra.Data.Context;

public partial class dbContext : DbContext
{
    public dbContext(DbContextOptions<dbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Usuarios> Usuarios { get; set; }
    public virtual DbSet<Proponentes> Proponentes { get; set; }
    public virtual DbSet<Modalidades> Modalidades { get; set; }
    public virtual DbSet<Edital> Edital { get; set; }
    public virtual DbSet<Segmento> Segmento { get; set; }
    public virtual DbSet<FontesFinanciamento> FontesFinanciamento { get; set; }
    public virtual DbSet<FonteFinanciamento> FonteFinanciamento { get; set; }
    public virtual DbSet<Projeto> Projeto { get; set; }
    public virtual DbSet<GrupoDespesas> GrupoDespesas { get; set; }
    public virtual DbSet<Rubrica> Rubrica { get; set; }
    public virtual DbSet<TipoUnidade> TipoUnidade { get; set; }
    public virtual DbSet<Despesas> Despesas { get; set; }
    public virtual DbSet<ResponsaveisTecnicos> ResponsaveisTecnicos { get; set; }
    public virtual DbSet<Locais> Locais { get; set; }
    public virtual DbSet<Integrantes> Integrantes { get; set; }
    public virtual DbSet<Detentores> Detentores { get; set; }

    //partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
