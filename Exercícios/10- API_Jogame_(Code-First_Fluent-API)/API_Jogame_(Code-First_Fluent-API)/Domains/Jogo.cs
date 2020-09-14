using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Jogame__Code_First_Fluent_API_.Domains
{
    public class Jogo
    {
        //PK
        public Guid IdJogo { get; set; }

        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime DataLancamento { get; set; }

        //Para relacionar Jogo com Jogador automaticamente.
        public ICollection<JogosJogadores> JogosJogadores { get; set; }
    }
}