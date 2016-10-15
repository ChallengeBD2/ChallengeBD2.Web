using ChallengeBD2.GerenciadorDeDados.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeBD2.GerenciadorDeDados
{
    public class Agrupador
    {
        public List<DadosAgrupadosPorUniversidade> AgruparDadosPorUniversidade()
        {
            int cont = 1;
            var retorno = new List<DadosAgrupadosPorUniversidade>();
            using (var context = new Challenge_BDEntities())
            {
                var litaDePesos = (from pesoPost in context.PesoPostagens
                                   where pesoPost.Peso == 1
                                   group pesoPost by new { Instituicao = pesoPost.Instituicao } into g
                                   select new { g.Key.Instituicao, TotalPosts = g.Count() });

                foreach (var peso in litaDePesos)
                {
                    var dados = new DadosAgrupadosPorUniversidade();
                    dados.Rank = cont;
                    dados.Instituicao = peso.Instituicao;
                    dados.TotalPosts = context.Postagens.Count(p => p.Instituicao == peso.Instituicao);
                    dados.TotalPostsPositivos = peso.TotalPosts;
                    dados.Porcentagem = ((Double.Parse(dados.TotalPostsPositivos.ToString()) / Double.Parse(dados.TotalPosts.ToString())) * 100).ToString("N2");
                    dados.Porcentagem = dados.Porcentagem.Replace(",", ".");
                    retorno.Add(dados);
                    cont++;
                }
            }

            return retorno.OrderByDescending(o => o.Porcentagem).ToList();
        }

        public class DadosAgrupadosPorUniversidade
        {
            public int Rank { get; set; }
            public string Instituicao { get; set; }
            public int TotalPosts { get; set; }
            public int TotalPostsPositivos { get; set; }
            public string Porcentagem { get; set; }
        }
    }
}
