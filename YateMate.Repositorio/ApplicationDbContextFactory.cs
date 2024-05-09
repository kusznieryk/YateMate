using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace YateMate.Repositorio;

public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{   
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        var contextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseSqlite("DataSource=../YateMate.Repositorio/Data/app.db;Cache=Shared")
            .Options;
        return new ApplicationDbContext(contextOptions);
    }
}
