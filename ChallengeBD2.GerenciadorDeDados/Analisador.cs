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
                //Busca postagens processadas
                var TodasPostagens = context.PostagensProcessadas.AsNoTracking().Include("Postagens").AsNoTracking().ToList();

                //Busca as Termos classificados
                var Termos = context.ClassificacaoTermo.ToList();

                //Varrer todas as postagens processadas para adicionar ou retirar peso.
                foreach (var postagem in TodasPostagens)
                {
                    //Procurar em cada postagem os termos a serem analisados
                    foreach (var termo in Termos)
                    {
                        if(postagem.PostProcessado.Contains(" "+ termo.Termo +" "))
                        {
                            //Cria nova item de vinculo das tabelas
                            var pesoPostagens = new PesoPostagens();
                            pesoPostagens.IdTermo = termo.Id;
                            pesoPostagens.IdPost = postagem.IdPost;
                            pesoPostagens.Peso = termo.Peso;
                            pesoPostagens.Instituicao= postagem.Postagens.Instituicao;

                            //Adiciona Tabela de Peso e Postagem
                            context.PesoPostagens.Add(pesoPostagens);
                        }
                    }
                }

                //Salva no banco de dados
                context.SaveChanges();
            }
        }

    }
}
