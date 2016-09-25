using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeBD2.GerenciadorDeDados
{
    public class Agrupador
    {
        //SELECT Sum([Peso]) TotalPeso ,[Instituicao]
        //FROM [PesoPostagens]
        //Group by[Instituicao]

        //SELECT ClassificacaoTermo.Termo ,PesoPostagens.Peso,Postagens.Post,Postagens.Instituicao
        //FROM PesoPostagens
        //Left JOIN ClassificacaoTermo ON PesoPostagens.IdTermo = ClassificacaoTermo.Id
        //Left JOIN Postagens ON PesoPostagens.IdPost = Postagens.IdPost
    }
}
