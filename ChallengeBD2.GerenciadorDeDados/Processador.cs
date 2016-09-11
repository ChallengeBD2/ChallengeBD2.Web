using ChallengeBD2.GerenciadorDeDados.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeBD2.GerenciadorDeDados
{
    public class Processador
    {
        public List<Postagens> RetornarListaDePostagensSalvas()
        {
            var retorno = new List<Postagens>();

            using (var context = new Challenge_BDEntities())
            {
                retorno = context.Postagens.ToList();
            }

            return retorno;
        }

        public void ProcessarPostagens()
        {
            using (var context = new Challenge_BDEntities())
            {
                //Busca postagens não processadas
                var TodasPostagens = context.Postagens.Where(p => p.PostagemProcessada == false).ToList();

                //Varrer todas as postagens para retirar palavras
                foreach (var postagem in TodasPostagens)
                {
                    if (postagem.PostagensProcessadas == null)
                    {
                        var PostProc = new PostagensProcessadas();

                        string novoPost = postagem.Post.Replace(" a ", " ");
                        novoPost = novoPost.Replace(" o ", " ");
                        novoPost = novoPost.Replace(" com ", " ");
                        novoPost = novoPost.Replace(" como ", " ");

                        novoPost = novoPost.Replace(" na ", " ");
                        novoPost = novoPost.Replace(" nas ", " ");
                        novoPost = novoPost.Replace(" no ", " ");
                        novoPost = novoPost.Replace(" nos ", " ");

                        novoPost = novoPost.Replace(" de ", " ");
                        novoPost = novoPost.Replace(" da ", " ");
                        novoPost = novoPost.Replace(" das ", " ");
                        novoPost = novoPost.Replace(" do ", " ");
                        novoPost = novoPost.Replace(" dos ", " ");
                        novoPost = novoPost.Replace(" fui ", " ");
                        novoPost = novoPost.Replace(" la ", " ");

                        //Retirar citações de usuarios na postagem
                        while (novoPost.Contains("@"))
                        {
                            string a = novoPost.Substring(novoPost.IndexOf("@"));
                            string usu = "";

                            if(a.IndexOf(" ") == -1)
                                usu = a.Substring(a.IndexOf("@"));
                            else
                                usu = a.Substring(a.IndexOf("@"),a.IndexOf(" "));

                            novoPost = novoPost.Replace(usu, " ");
                        }

                        //Adiciona Novo registro
                        PostProc.PostProcessado = novoPost;
                        PostProc.IdPost = postagem.IdPost;
                        context.PostagensProcessadas.Add(PostProc);
                        context.SaveChanges();


                        ////Atualiza postagem anterior como já processada
                        //var postAntigo = context.Postagens.Where(p => p.IdPost == postagem.IdPost).FirstOrDefault();
                        //postAntigo.PostagemProcessada = true;

                        //context.SaveChanges();
                    }
                }

            }
        }
    }
}
