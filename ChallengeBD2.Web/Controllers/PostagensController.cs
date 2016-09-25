using ChallengeBD2.GerenciadorDeDados;
using ChallengeBD2.GerenciadorDeDados.Model;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ChallengeBD2.WebPage.Controllers
{
    public class PostagensController : Controller
    {
        public Processador Processador { get; set; }
        public List<Postagens> ListaPostagens { get; set; }
        public ActionResult Index()
        {
            Processador = new Processador();
            ListaPostagens = Processador.RetornarListaDePostagensSalvas();
            return View(ListaPostagens);
        }

        public ActionResult ProcessarPostagensBD()
        {
            Processador = new Processador();
            Processador.ProcessarPostagens();

            return View("Index",ListaPostagens);
        }

        public ActionResult AnalisarPostagens()
        {
            var Analisador = new Analisador();
            Analisador.AnalisarPostagens();

            return View("Index", ListaPostagens);
        }
    }
}