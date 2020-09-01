using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Boletim.Domains;

namespace API_Boletim.Interfaces
{
    interface IAluno
    {
        Aluno Cadastrar(Aluno aluno);
        List<Aluno> Ler();
        Aluno BuscarPorId(int id);
        Aluno Alterar(Aluno aluno);
        Aluno Excluir(Aluno aluno);
    }
}
