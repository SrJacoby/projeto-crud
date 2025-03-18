using Microsoft.EntityFrameworkCore;
using Crud.Models;

public class CrudContext : DbContext
{
    public DbSet<CrudModel> Register { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=register.sqlite");
        base.OnConfiguring(optionsBuilder);
    }
}