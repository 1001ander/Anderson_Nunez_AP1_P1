using Microsoft.EntityFrameworkCore;

namespace Anderson_Nunez_AP1_P1.DAL;

public class Contexto : DbContext 
{
    public Contexto(DbContextOptions<Contexto> options) : base(options) { }

}
