using ChallengeBD2.GerenciadorDeDados;
using ChallengeBD2.WebPage.Models;
using System.Collections.Generic;
using System.Web.Mvc;
using static ChallengeBD2.GerenciadorDeDados.Agrupador;

namespace ChallengeBD2.WebPage.Controllers
{
    public class AgrupadorController : Controller
    {
        ViewModelAgrupador vmAgrup { get; set; }
        public ActionResult Index()
        {
            vmAgrup = new ViewModelAgrupador();

            var Agrupador = new Agrupador();
            //vmAgrup.ListaDadosAgrupadosPorUniversidade = Agrupador.AgruparDadosPorUniversidade();            
            vmAgrup.ListaDadosAgrupadosPorUniversidade = new List<DadosAgrupadosPorUniversidade>();

            vmAgrup.ListaDadosAgrupadosPorUniversidade.Add(new DadosAgrupadosPorUniversidade() { Rank = 1, Instituicao = "PUC MINAS", Porcentagem = "72", TotalPosts = 345, TotalPostsPositivos = 247 });
            vmAgrup.ListaDadosAgrupadosPorUniversidade.Add(new DadosAgrupadosPorUniversidade() { Rank = 2, Instituicao = "CEFET", Porcentagem = "69", TotalPosts = 48, TotalPostsPositivos = 33 });
            vmAgrup.ListaDadosAgrupadosPorUniversidade.Add(new DadosAgrupadosPorUniversidade() { Rank = 3, Instituicao = "UNA", Porcentagem = "64", TotalPosts = 22, TotalPostsPositivos = 14 });
            vmAgrup.ListaDadosAgrupadosPorUniversidade.Add(new DadosAgrupadosPorUniversidade() { Rank = 4, Instituicao = "ESTÁCIO", Porcentagem = "62", TotalPosts = 34, TotalPostsPositivos = 21 });
            vmAgrup.ListaDadosAgrupadosPorUniversidade.Add(new DadosAgrupadosPorUniversidade() { Rank = 5, Instituicao = "SENAC", Porcentagem = "60", TotalPosts = 48, TotalPostsPositivos = 29 });
            vmAgrup.ListaDadosAgrupadosPorUniversidade.Add(new DadosAgrupadosPorUniversidade() { Rank = 6, Instituicao = "UNOPAR", Porcentagem = "58", TotalPosts = 12, TotalPostsPositivos = 7 });
            vmAgrup.ListaDadosAgrupadosPorUniversidade.Add(new DadosAgrupadosPorUniversidade() { Rank = 7, Instituicao = "UNICESUMAR", Porcentagem = "58", TotalPosts = 26, TotalPostsPositivos = 15 });
            vmAgrup.ListaDadosAgrupadosPorUniversidade.Add(new DadosAgrupadosPorUniversidade() { Rank = 8, Instituicao = "UNIPAC", Porcentagem = "52", TotalPosts = 31, TotalPostsPositivos = 16 });
            vmAgrup.ListaDadosAgrupadosPorUniversidade.Add(new DadosAgrupadosPorUniversidade() { Rank = 9, Instituicao = "PITÁGORAS", Porcentagem = "48", TotalPosts = 80, TotalPostsPositivos = 38 });
            vmAgrup.ListaDadosAgrupadosPorUniversidade.Add(new DadosAgrupadosPorUniversidade() { Rank = 10, Instituicao = "UNINCOR", Porcentagem = "45", TotalPosts = 11, TotalPostsPositivos = 5 });

            return View(vmAgrup);
        }

        public ActionResult GerarNuvemDePalavras(string universidade)
        {
            vmAgrup = new ViewModelAgrupador();
            vmAgrup.nuvemPalavras = new NuvemPalavras();
            vmAgrup.nuvemPalavras.Palavras = new List<string>();
            vmAgrup.nuvemPalavras.Palavras.Add("Testee1");
            vmAgrup.nuvemPalavras.Palavras.Add("Testee2");
            vmAgrup.nuvemPalavras.Palavras.Add("Testee3");
            vmAgrup.nuvemPalavras.Palavras.Add("Testee4");
            vmAgrup.nuvemPalavras.Palavras.Add("Testee5");
            vmAgrup.nuvemPalavras.Palavras.Add("Testee6");
            vmAgrup.nuvemPalavras.Palavras.Add("Testee7");
            vmAgrup.nuvemPalavras.Palavras.Add("Testee8");
            vmAgrup.nuvemPalavras.Palavras.Add("Testee9");
            vmAgrup.nuvemPalavras.Palavras.Add("Testee10");
            vmAgrup.nuvemPalavras.Palavras.Add("Testee11");
            ViewBag.Title = universidade;
            return View("NuvemPalavras", vmAgrup.nuvemPalavras);
        }
    }
}