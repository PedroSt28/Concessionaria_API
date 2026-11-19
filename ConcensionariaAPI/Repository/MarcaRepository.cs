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
        public void Cadastrar(Marca nome)
        {
            _context.Marca.Add(nome);   // coloca na fila (marca para inserir)
            _context.SaveChanges();      // grava no banco
        }

        // SELECT * FROM Curso
        public List<Marca> ListarTodos()
        {
            return _context.Marca.ToList();   // ToList() -> busca todos os registros
        }

        // SELECT * FROM Curso WHERE IdCurso = @id
       

        public Veiculo? BuscarPorNome(string nome)
        {
            return _context.Veiculo.Find(nome);   // Find() -> busca pela chave primária (ou null)
        }
    }
}