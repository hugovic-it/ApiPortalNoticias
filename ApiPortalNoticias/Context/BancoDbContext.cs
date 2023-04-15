using ApiPortalNoticias.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ApiPortalNoticias.Context;

public class BancoDbContext : DbContext
{
    public DbSet<Noticia> Noticias { get; set; }
    public DbSet<Autor> Autores { get; set; }

    public BancoDbContext(DbContextOptions<BancoDbContext> options) : base(options)
    {
    }


}
