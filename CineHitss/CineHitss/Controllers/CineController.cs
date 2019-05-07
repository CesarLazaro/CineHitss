using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WCF;
namespace CineHitss.Controllers
{
    public class CineController : Controller
    {
        // GET: Cine
        CineHitssEntities Entity = new CineHitssEntities();
        public ActionResult Index()
        {
            var model = Entity.Ciudads.ToList();
            ViewBag.Ciudades = new SelectList(model, "ID", "CiudadN");
            return View();
        }
        public JsonResult GetCines(int CiudadID)
        {
            Entity.Configuration.ProxyCreationEnabled = false;
            var model = Entity.Cines.Where(c => c.CiudadID == CiudadID).ToList();
            return Json(model, JsonRequestBehavior.AllowGet);
        }
        public ActionResult FuncionesBefore(int CineID)
        {
            Session["CineName"]=CineID;
            return RedirectToAction("Funciones", "Cine");
        }
        [HttpGet]
        public ActionResult Funciones()
        {
            int id = Convert.ToInt32(Session["CineName"]);
            var model = Entity.Funcions.Where(c => c.CineID == id).ToList();
            return View(model);
        }
        [HttpPost]
        public ActionResult Funciones(string fecha,int genero,string clasificacion)
        {

            int id = Convert.ToInt32(Session["CineName"]);
            var model = Entity.Funcions.Where(c => c.CineID == id).ToList();
            List<Funcion> result = new List<Funcion>();
            if (fecha.Equals("D") && genero==0 && clasificacion.Equals("D"))
            {
                return View(model);
            }
            else
            {
                if (!fecha.Equals("D"))
                {
                    foreach (var a in model)
                    {
                        if (a.Fecha.Value.ToString("yyyy/MM/dd").Equals(fecha))
                        {
                            result.Add(a);
                        }
                    }
                }

                if (genero!=0)
                {
                    result = model.Where(c => c.Pelicula.GeneroID==genero).ToList();
                }
                if (!clasificacion.Equals("D"))
                {
                    result = model.Where(c => c.Pelicula.Clasificacion.Equals(clasificacion)).ToList();
                }
                return View(result);
            }
           
        }
        public ActionResult ComprarBoleto(int id)
        {
            Session["Funcion"] = id;
            return View(id);
        }
        public ActionResult MostraBoleto()
        {
            int funcionid = Convert.ToInt32(Session["Funcion"]);
            var funcion = Entity.Funcions.FirstOrDefault(c => c.ID == funcionid);
            Servicio.Service1Client rel = new Servicio.Service1Client();
            float precio = rel.total(funcionid);
            Boleto neww = new Boleto()
            {
                FuncionID = funcionid,
                Asiento = null,
                Total = precio,
                Estado = true

            };
            if (Convert.ToInt32(Session["User"]) != 0)
            {
                int userid = Convert.ToInt32(Session["User"]);
                Usuario usuario = Entity.Usuarios.FirstOrDefault(c => c.ID == userid);
                usuario.Puntos = usuario.Puntos + 10;
                neww.UsuarioID = userid;

            }
            else
            {
                neww.UsuarioID = null;
            }
            Entity.Boletoes.Add(neww);
            Entity.SaveChanges();
            return View(neww);
        }
    }
}