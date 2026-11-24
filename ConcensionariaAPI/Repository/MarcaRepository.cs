using ConcensionariaAPI.Contexts;
using ConcensionariaAPI.Interface;
using ConcensionariaAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ConcensionariaAPI.Repository
{
    public class MarcaRepository : IMarcaRepository
    {
        /*
         Injetar o Context: uma cozinha precisa do fogão (EscolaContext)
         para fazer os pratos. Em vez de criar o Context sozinha,
         ela pede no construtor e a API entrega pronto.
         Isso se chama Injeção de Dependência.

         _context - convenção do C# para campo privado da classe.
     */
        private readonly ConcessionariaContext _context;

        // Injeção de dependência: a API entrega o EscolaContext pronto.
        public MarcaRepository(ConcessionariaContext context)
        {
            _context = context;
        }

        // INSERT INTO Curso
        public void Cadastrar(Marca marca)
        {
            _context.Marca.Add(marca);   // coloca na fila (marca para inserir)
            _context.SaveChanges();      // grava no banco
        }

        // SELECT * FROM Curso
        public List<Marca> ListarTodos()
        {
            return _context.Marca.ToList();   // ToList() -> busca todos os registros
        }

        // SELECT * FROM Curso WHERE IdCurso = @id
       

        public Marca? BuscarPorId(int id)
        {
            return _context.Marca.Find(id);   // Find() -> busca pela chave primária (ou null)
        }

        public void Deletar(int id)
        {
            Marca? marca_encontrado = _context.Marca.Find(id);

            if (marca_encontrado != null)
            {
                _context.Marca.Remove(marca_encontrado);
                _context.SaveChanges();
            }
        }

            public void Atualizar(int id, Marca marca) 
           {
            Marca? marca_encontrada = _context.Marca.Find(id, marca);

            if (marca_encontrada != null) 
            {
                marca_encontrada.Nome = marca.Nome;
                marca_encontrada.PaisOrigem = marca.PaisOrigem;
                _context.SaveChanges();
            }

           }

       
    }

    }
