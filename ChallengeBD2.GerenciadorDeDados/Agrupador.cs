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
                    dados.Instituicao = peso.Instituicao;
                    dados.TotalPosts = context.Postagens.Count(p => p.Instituicao == peso.Instituicao);
                    dados.TotalPostsValidos = context.PesoPostagens.Count(p => p.Instituicao == peso.Instituicao);
                    dados.TotalPostsPositivos = peso.TotalPosts;
                    dados.Porcentagem = ((Double.Parse(dados.TotalPostsPositivos.ToString()) / Double.Parse(dados.TotalPostsValidos.ToString())) * 100).ToString("N2");
                    dados.Porcentagem = dados.Porcentagem.Replace(",", ".");
                    retorno.Add(dados);
                }
            }
            var listaOrdenada = retorno.OrderByDescending(o => o.Porcentagem).ToList();
            foreach (var ret in listaOrdenada)
            {
                ret.Rank = cont;
                cont++;
            }

            return listaOrdenada;
        }

        public List<TermosPorUniversidade> BuscarTermosPorUniversidade(string Universidade)
        {
            int cont = 1;
            var retorno = new List<TermosPorUniversidade>();
            using (var context = new Challenge_BDEntities())
            {
                var listaTermos = (from PP in context.PesoPostagens
                                   join CT in context.ClassificacaoTermo on new { Id = PP.IdTermo } equals new { CT.Id }
                                   where PP.Instituicao == Universidade
                                   group PP by new { Termo = CT.Termo, Peso = CT.Peso, idTermo = CT.Id } into g
                                   select new { g.Key.Termo, g.Key.Peso, g.Key, idTermo = g.Key.idTermo });

                foreach (var termo in listaTermos)
                {
                    var dados = new TermosPorUniversidade();
                    dados.Termo = termo.Termo;
                    dados.AvaliacaoTermo = termo.Peso == 1 ? "TermoPositivo" : "TermoNegativo";
                    int qtdPost = context.PesoPostagens.Count(p => p.IdTermo == termo.idTermo && p.Instituicao == Universidade);
                    dados.TamanhoPalavra = qtdPost == 1 ? "15pt" : qtdPost > 10 ? "100pt" : qtdPost * 15 + "pt";
                    dados.baguncaPalavras = new Random().Next();
                    retorno.Add(dados);
                    cont++;
                }
            }

            return retorno.OrderByDescending(od => od.baguncaPalavras).ToList();
        }

        public class DadosAgrupadosPorUniversidade
        {
            public int Rank { get; set; }
            public string Instituicao { get; set; }
            public int TotalPosts { get; set; }
            public int TotalPostsValidos { get; set; }
            public int TotalPostsPositivos { get; set; }
            public string Porcentagem { get; set; }
        }

        public class TermosPorUniversidade
        {
            public string Termo { get; set; }
            public string AvaliacaoTermo { get; set; }
            public string TamanhoPalavra { get; set; }

            public int baguncaPalavras { get; set; }
        }
    }
}
