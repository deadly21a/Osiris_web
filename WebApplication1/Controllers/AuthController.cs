using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebApplication1.Models; 

public class AuthController : Controller
{
    private readonly UserManager<ApplicationUser> _userManager;

    public AuthController()
    {
        _userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>());
    }

    
    private LoginViewModel GetUserInfo(ApplicationUser user)
    {
        if (user != null)
        {
            return new LoginViewModel
            {
                CCiUsuario = user.UserName,
                CDsNombre = user.Nombre, 
                CDsApellido = user.Apellido, 
                
            };
        }
        return null;
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
    {
        var user = await _userManager.FindAsync(model.CCiUsuario, model.CTxClave);
        if (user != null)
        {
            var userInfo = GetUserInfo(user);
            var loginViewModel = new LoginViewModel
            {
                CCiUsuario = userInfo.CCiUsuario,
                CDsNombre = userInfo.CDsNombre,
                CDsApellido = userInfo.CDsApellido
            };
            return RedirectToAction("Index", "Home", loginViewModel);
        }
        else
        {
            ModelState.AddModelError("", "Invalid login attempt.");
            return View(model);
        }
    }


}


