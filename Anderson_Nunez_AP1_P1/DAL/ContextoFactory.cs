using Anderson_Nunez_AP1_P1.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Anderson_Nunez_AP1_P1.DAL;

namespace Anderson_Nunez_AP1_P1;

public class ContextoFactory : IDesignTimeDbContextFactory<Contexto>
{
    public Contexto CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<Contexto>();

        optionsBuilder.UseSqlServer("Server=ExamenP1.mssql.somee.com;packet size=4096;user id=anderUcne_SQLLogin_1;pwd=5j25clytiq;data source=ExamenP1.mssql.somee.com;persist security info=False;initial catalog=ExamenP1;TrustServerCertificate=True");

        return new Contexto(optionsBuilder.Options);
    }
}