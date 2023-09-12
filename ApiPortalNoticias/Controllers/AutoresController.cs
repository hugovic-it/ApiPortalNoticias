using ApiPortalNoticias.Context;
using ApiPortalNoticias.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiPortalNoticias.Controllers;

[Authorize(AuthenticationSchemes = "Bearer")]
[Route("api/[controller]")]
[ApiController]
public class AutoresController : ControllerBase
{
    private readonly BancoDbContext _contexto;

	public AutoresController(BancoDbContext bancoDbContext)
	{
		_contexto= bancoDbContext;
	}

	[HttpGet]
	public ActionResult<IEnumerable<Autor>> Get()
	{
		var autores = _contexto.Autores.ToList(); 
		return Ok(autores);
	}

	[HttpGet("{id:int}")]
	public ActionResult<Autor> Get(int id)
	{
		var autor = _contexto.Autores.FirstOrDefault(x => x.AutorId == id);
		return Ok(autor);
	}

	[HttpPost]
	public  ActionResult<Autor> Post(Autor autor)
	{
		if(autor == null)
		{
			return BadRequest("Autor inválido!");
		}

		_contexto.Autores.Add(autor);
		_contexto.SaveChanges();

		return Ok(autor);
	}


	[HttpPut("{id:int}")]
	public ActionResult<Autor> Put(int id, Autor autor)
	{
		if(id != autor.AutorId)
		{
            return NotFound("Autor não encontrado!");
        }

		_contexto.Entry(autor).State = EntityState.Modified;
		_contexto.SaveChanges();

		return Ok(autor);
	}

	[HttpDelete("{id:int}")]
	public ActionResult Delete(int id)
	{
		var autor = _contexto.Autores.FirstOrDefault(x => x.AutorId == id);

		if(autor == null)
		{
			return NotFound("Autor não encontrado!");
		}
		_contexto.Remove(autor);
		_contexto.SaveChanges();

		return Ok(autor);
	}

}
