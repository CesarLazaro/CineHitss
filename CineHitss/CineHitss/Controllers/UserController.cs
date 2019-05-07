using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WCF;
namespace CineHitss.Controllers
{
    public class UserController : Controller
    {
        CineHitssEntities Entity = new CineHitssEntities();
        // GET: User
        public ActionResult Index()
        {
          return View();
        }
        // GET: User
        public ActionResult Login(string email,string password)
        {
            var result = Entity.Usuarios.FirstOrDefault(c => c.Mail.Equals(email) && c.Pass.Equals(password));    
            if (result!=null)
            {
                Session["User"] = result.ID;
                return RedirectToAction("Index", "Cine");
            }
            return View();
        }
        public ActionResult AftherLogin()
        {
            Session["User"] = 0;
            return RedirectToAction("Index", "Cine");
        }

        public ActionResult Account()
        {            
            int id=Convert.ToInt32(Session["User"]);
            Usuario model = Entity.Usuarios.FirstOrDefault(c => c.ID ==id);
            return View(model);
        }
        public ActionResult Boletos()
        {
            int userid = Convert.ToInt32(Session["User"]);
            var boletos = Entity.Boletoes.Where(c => c.UsuarioID == userid).ToList(); ;
            return View(boletos);
        }

    }
}