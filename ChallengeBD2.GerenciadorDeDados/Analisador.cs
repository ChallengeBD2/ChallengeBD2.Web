using ChallengeBD2.GerenciadorDeDados.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeBD2.GerenciadorDeDados
{
    public class Analisador
    {
        public void AnalisarPostagens()
        {
            using (var context = new Challenge_BDEntities())
            {
                //Busca postagens não processadas
                var TodasPostagens = context.PostagensProcessadas.AsNoTracking().Include("Postagens").AsNoTracking().ToList();

                //Busca as Classificação dos termos
                var Termos = context.ClassificacaoTermo.ToList();

                //Varrer todas as postagens processados para adicionar ou retirar peso
                foreach (var postagem in TodasPostagens)
                {
                    foreach (var termo in Termos)
                    {
                        if(postagem.PostProcessado.Contains(" "+ termo.Termo +" "))
                        {
                            var pesoPostagens = new PesoPostagens();
                            pesoPostagens.IdTermo = termo.Id;
                            pesoPostagens.IdPost = postagem.IdPost;
                            pesoPostagens.Peso = termo.Peso;
                            pesoPostagens.Instituicao= postagem.Postagens.Instituicao;

                            context.PesoPostagens.Add(pesoPostagens);
                        }
                    }
                }

                context.SaveChanges();
            }
        }

    }
}
