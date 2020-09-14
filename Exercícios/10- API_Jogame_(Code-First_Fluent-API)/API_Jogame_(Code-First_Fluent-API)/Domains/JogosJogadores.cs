using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Jogame__Code_First_Fluent_API_.Domains
{
    public class JogosJogadores
    {
        //PK
        public Guid IdJogosJogadores { get; set; }

        public Guid IdJogo { get; set; }
        public Guid IdJogador { get; set; }
    }
}