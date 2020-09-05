using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_PetShop.Domains
{
    public class Raca
    {
        public int IdPet { get; set; }
        public string Descricao { get; set; }
        public int IdTipoDePet { get; set; }
    }
}