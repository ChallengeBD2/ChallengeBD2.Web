
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace ChallengeBD2.GerenciadorDeDados.Model
{

using System;
    using System.Collections.Generic;
    
public partial class Postagens
{

    public long IdPost { get; set; }

    public string Post { get; set; }

    public string IdUsuario { get; set; }

    public string Instituicao { get; set; }

    public Nullable<bool> PostagemProcessada { get; set; }



    public virtual PostagensProcessadas PostagensProcessadas { get; set; }

}

}
