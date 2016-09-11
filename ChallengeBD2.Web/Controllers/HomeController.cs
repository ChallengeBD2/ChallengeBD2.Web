using ChallengeBD2.GerenciadorDeDados;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChallengeBD2.WebPage.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }        

        public ActionResult LerArquivoDePostagens()
        {
            HttpPostedFileBase arquivo = Request.Files["MeuArquivo"];

            Coletor c = new Coletor();
          var listaPostagens  = c.LerPostagensDoArquivo(arquivo.InputStream);

            return View("Index", listaPostagens);
        }
    }
}