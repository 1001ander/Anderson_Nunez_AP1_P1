using Anderson_Nunez_AP1_P1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace Anderson_Nunez_AP1_P1.DAL;

public class Contexto : DbContext 
{
    public Contexto(DbContextOptions<Contexto> options) : base(options) { }

    public DbSet<Aportes> Aportes { get; set; }

}
