using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static ChallengeBD2.GerenciadorDeDados.Agrupador;

namespace ChallengeBD2.WebPage.Models
{
    public class ViewModelAgrupador
    {
        public ViewModelAgrupador()
        {
            nuvemPalavras = new NuvemPalavras();
        }
        public List<DadosAgrupadosPorUniversidade> ListaDadosAgrupadosPorUniversidade { get; set; }
        public NuvemPalavras nuvemPalavras { get; set; }
    }

    

    public class NuvemPalavras
    {
        public List<TermosPorUniversidade> Palavras { get; set; }
    }
}