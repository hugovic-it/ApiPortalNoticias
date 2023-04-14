using ApiPortalNoticias.Context;
using ApiPortalNoticias.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiPortalNoticias.Controllers;

[Route("api/[controller]")]
[ApiController]
public class NoticiasController : ControllerBase
{
    private readonly BancoDbContext _contexto;

    public NoticiasController(BancoDbContext bancoDbContext)
    {
        _contexto = bancoDbContext;
    }



    //  api/Noticias  Get()
    [HttpGet]
    public ActionResult<IEnumerable<Noticia>> Get()
    {
        List<Noticia> resultado = _contexto.Noticias.ToList();

        if (resultado is null)
        {
            return BadRequest("Get inválido!");
        }
        else
        {
            return Ok(resultado);
        }
    }

    //  api/Noticias/{id}  Get()
    [HttpGet ("{id:int}")]
    public ActionResult<Noticia> Get(int id) 
    {
        var noticia = _contexto.Noticias.FirstOrDefault(x => x.NoticiaId == id);
        if (noticia is null)
        {
            return BadRequest("Notícia inválida!");
        }
        return Ok(noticia);
    }

    //  api/Noticias  Post()
    [HttpPost]
    public IActionResult Post(Noticia noticia)
    {
        if (noticia is null)
        {
            return BadRequest("Notícia inválida!");
        }

        _contexto.Noticias.Add(noticia);
        _contexto.SaveChanges();

        return Ok(noticia);
    }

    //  api/Noticias  Put()
    [HttpPut("{id:int}")]
    public IActionResult Put(int id, Noticia noticia)
    {
        if( id != noticia.NoticiaId)
        {
            return BadRequest("Notícia inválida");
        }

        _contexto.Entry(noticia).State = EntityState.Modified;
        _contexto.SaveChanges();
        
        return Ok(noticia);
    }

    //  api/Noticias  Delete()
    [HttpDelete]
    public IActionResult Delete(int id)
    {
        var noticia = _contexto.Noticias.FirstOrDefault(x => x.NoticiaId == id);
        if(noticia is null) {
            return BadRequest("Notícia inválida");
        }

        _contexto.Noticias.Remove(noticia);
        _contexto.SaveChanges();
        return Ok(noticia);
    }

}