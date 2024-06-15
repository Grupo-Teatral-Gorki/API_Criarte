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

    //partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
