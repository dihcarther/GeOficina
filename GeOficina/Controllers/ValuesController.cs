using GeOficina.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GeOficina.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
      
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public AuthController(SignInManager<IdentityUser> signInManager, 
            UserManager<IdentityUser>userManager)
        {

           _signInManager = signInManager;
           _userManager = userManager;



        }



        [HttpPost("nova-conta")]

        public async Task<ActionResult> Registrar(Registro registerUser) {


            if (!ModelState.IsValid) return BadRequest(ModelState.Values.SelectMany( e =>e.Errors)) ;


            var user = new IdentityUser
            {
                UserName = registerUser.Cnpj,
                Email = registerUser.Email,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(user, registerUser.Password);
            if (!result.Succeeded) return BadRequest(result.Errors);
            await _signInManager.SignInAsync(user, false);

            return Ok();

        }




        [HttpPost("logar")]

        public async Task<ActionResult> Logar(Login loginUser)
        {


            if (!ModelState.IsValid) return BadRequest(ModelState.Values.SelectMany(e => e.Errors));


            var result = await _signInManager.PasswordSignInAsync(loginUser.Cnpj, loginUser.Password, false, true);

            if (result.Succeeded){ 
                return Ok();
            
            }
            
                return BadRequest("Usuario ou senha invalidos");


        }

    





    }
}
