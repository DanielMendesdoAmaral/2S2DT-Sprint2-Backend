using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EF_Core_Code_First.Domains;
using EF_Core_Code_First.Interfaces;
using EF_Core_Code_First.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EF_Core_Code_First.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        //Por que instanciamos como a interface e não como o repositório? Tem a ver com Injeção de Dependência. Uma dependência é simplesmente um objeto que a sua classe precisa para funcionar. Ao fazer a injeção de dependencia você coloca a responsabilidade das classes externas na classe que está chamando e não na classe chamada. Injeção de dependência é um Design Pattern que prega um tipo de controle externo, um container, uma classe, configurações via arquivo, etc., inserir uma dependência em uma outra classe. Tentando melhorar: "O padrão de injeção de dependências visa remover dependências desnecessárias entre as classes". Para entender o conceito é também necessário aprofundar o conhecimento em Inversão de Controle e um pouco do principio SOLID, afinal ele é a Letra D (Dependa de uma abstração e não de uma implementação).
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoController()
        {
            _produtoRepository = new ProdutoRepository();
        }

        // GET: <ProdutoController>
        /// <summary>
        ///     Quando acessada a rota acima com o método GET, é exibido todos os produtos cadastrados no banco de dados.
        /// </summary>
        /// <returns>Lista contendo todos os produtos cadastrados no banco de dados.</returns>
        [HttpGet]
        public List<Produto> Get()
        {
            return _produtoRepository.Ler();
        }

        // GET <ProdutoController>/5
        /// <summary>
        ///     Quando acessada a rota acima com o método GET, é exibido o produto cadastrado no banco de dados que tenha o id especificado.
        /// </summary>
        /// <param name="id">Id do produto desejado.</param>
        /// <returns>Retorna o produto que tem o id especificado.</returns>
        [HttpGet("{id}")]
        public Produto Get(Guid id)
        {
            return _produtoRepository.BuscarPorId(id);
        }

        // GET <ProdutoController>/Filtrar/Nome
        /// <summary>
        ///     Quando acessada a rota acima com o método GET, é exibido o produto cadastrado no banco de dados que contenha o nome especificado.
        /// </summary>
        /// <param name="nome">Nome do produto desejado.</param>
        /// <returns>Retorna o produto que tem o nome especificado.</returns>
        [HttpGet("{nome}")]
        public List<Produto> Get(string nome)
        {
            return _produtoRepository.BuscarPorNome(nome);
        }

        // POST <ProdutoController>
        /// <summary>
        ///     Quando acessada a rota acima com o método POST, é possível cadastrar um produto no banco de dados a partir de um objeto em JSON inserido no body da requisição.
        /// </summary>
        /// <param name="produto">Produto inserido no body da requisição que será cadastrado no banco de dados.</param>
        [HttpPost]
        public void Post([FromBody] Produto produto)
        {
            _produtoRepository.Adicionar(produto);
        }

        // PUT <ProdutoController>/5
        /// <summary>
        ///     Quando acessada a rota acima com o método PUT, é possível alterar um produto no banco de dados a partir de um objeto em JSON inserido no body da requisição.
        /// </summary>
        /// <param name="produtoAlterado">Produto já alterado, que irá substituir o produto a ser alterado.</param>
        [HttpPut]
        public void Put([FromBody] Produto produtoAlterado)
        {
            _produtoRepository.Alterar(produtoAlterado);
        }

        // DELETE <RacaController>/5
        /// <summary>
        ///     Quando acessada a rota acima com o método DELETE, o produto que contém o id especificado será deletado do banco de dados.
        /// </summary>
        /// <param name="id">Id do produto a ser deletado.</param>
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            _produtoRepository.Excluir(id);
        }
    }
}