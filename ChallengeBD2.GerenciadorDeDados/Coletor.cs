using ChallengeBD2.GerenciadorDeDados.Model;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeBD2.GerenciadorDeDados
{
    public class Coletor
    {
        public List<DadosTwitteR> listaDadosTwitteR { get; set; }
        public List<DadosTwitteR> LerPostagensDoArquivo(Stream arquivo)
        {
            listaDadosTwitteR = new List<DadosTwitteR>();
            StreamReader csvreader = new StreamReader(arquivo, Encoding.UTF8);
            //var csv = new CsvReader(csvreader);
            while (!csvreader.EndOfStream)
            {
                var line = csvreader.ReadLine();
                var dados = line.Split(',');

                foreach (var d in dados)
                {
                    var dadosTwitterR = new DadosTwitteR();
                    var post = d.Trim();
                    if (post != string.Empty)
                    {
                        dadosTwitterR.id = post.Remove('"');
                        dadosTwitterR.id = post.Substring(0, post.IndexOf(" "));

                        dadosTwitterR.text = post.Replace(dadosTwitterR.id, "");
                        dadosTwitterR.text = dadosTwitterR.text.Remove('"');

                        listaDadosTwitteR.Add(dadosTwitterR);
                    }
                }
            }

            return listaDadosTwitteR;
        }

        public void SalvarPostagemDoArquivo()
        {
            using (var context = new Challenge_BDEntities())
            {

            }
        }
    }

    public class DadosTwitteR
    {
        public string id { get; set; }
        public string text { get; set; }
        public string favorited { get; set; }
        public string favoriteCount { get; set; }
        public string replyToSN { get; set; }
        public string created { get; set; }
        public string truncated { get; set; }
        public string replyToSID { get; set; }
        public string replyToUID { get; set; }
        public string statusSource { get; set; }
        public string screenName { get; set; }
        public string retweetCount { get; set; }
        public string isRetweet { get; set; }
        public string retweeted { get; set; }
        public string longitude { get; set; }
        public string latitude { get; set; }
        public string location { get; set; }
        public string language { get; set; }
        public string profileImageURL { get; set; }
    }
}
