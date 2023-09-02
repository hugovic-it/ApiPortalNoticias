using ApiPortalNoticias.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ApiPortalNoticias.Context;

public class BancoDbContext : IdentityDbContext
{
    public DbSet<Noticia> Noticias { get; set; }
    public DbSet<Autor> Autores { get; set; }

    public BancoDbContext(DbContextOptions<BancoDbContext> options) : base(options)
    {
    }


}
