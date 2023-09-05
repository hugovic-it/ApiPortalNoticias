using ApiPortalNoticias.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ApiPortalNoticias.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorizaController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AutorizaController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public ActionResult<string> Get()
        {
            return "AutorizaController :: Acessado em : "
                + DateTime.Now.ToLongTimeString();
        }

        [HttpPost("register")]
        public async Task<ActionResult> RegisterUser([FromBody] UsuarioDTO model)
        {                                           //atraves do body, recebe um usuario DTO
            //if (!ModelState.IsValid) //if desncessario!  //mas verifica se o model/usuarioDTO é valido
            //{
            //    return BadRequest(ModelState.Values.SelectMany(e=>e.Errors));
            //}

            var user = new IdentityUser //cria uma instancia do IdentityUser
            {
                UserName = model.Email,
                Email = model.Email,
                EmailConfirmed = true
            };

            //result irá ser do tipo Identity.Result = cria o usuário com o metodo CreateAsync
            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)   //se falso, retorna um BadRequest
            {
                return BadRequest(result.Errors);
            }

            await _signInManager.SignInAsync(user, false); //loga o usuário
            return Ok();  //retorna Ok e gera o token
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] UsuarioDTO userInfo)
        {
            //verifica se o modelo é valido
            if (!ModelState.IsValid) //se falso, retorna BadRequest();
            {
                return BadRequest(ModelState.Values.SelectMany(e => e.Errors));
            }

            //verifica as credenciais do usuário e retorna um valor
            var result = await _signInManager.PasswordSignInAsync(userInfo.Email,
                userInfo.Password, isPersistent: false, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                return Ok();
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Login Inválido...");
                return BadRequest();
            }
        }

    }
}
