using ConcensionariaAPI.Contexts;
using ConcensionariaAPI.Interface;
using ConcensionariaAPI.Models;

namespace ConcensionariaAPI.Repository
{
    public class VeiculoRepository : IVeiculoRepository
    {
        /*
          Injetar o Context: uma cozinha precisa do fogão (concessionariaContext)
          para fazer os pratos. Em vez de criar o Context sozinha,
          ela pede no construtor e a API entrega pronto.
          Isso se chama Injeção de Dependência.

          _context - convenção do C# para campo privado da classe.
      */
        private readonly ConcessionariaContext _context;

        // Injeção de dependência: a API entrega o ConcessionariaContext pronto.
        public VeiculoRepository(ConcessionariaContext context)
        {
            _context = context;
        }

        // INSERT INTO Curso
        public void Cadastrar(Veiculo veiculo)
        {
            _context.Veiculo.Add(veiculo);   // coloca na fila (veiculo para inserir)
            _context.SaveChanges();      // grava no banco
        }

        // SELECT * FROM Curso
        public List<Veiculo> ListarTodos()
        {
            return _context.Veiculo.ToList();   // ToList() -> busca todos os registros
        }

        // SELECT * FROM Curso WHERE IdCurso = @id
        public Veiculo? BuscarPorId(int id)
        {
            return _context.Veiculo.Find(id);   // Find() -> busca pela chave primária (ou null)
        }

        public void Atualizar(int id ,Veiculo? veiculo) 
        {
            Veiculo? veiculo_encontrado = _context.Veiculo.Find(id, veiculo);
            if(veiculo_encontrado != null) 
            {
                veiculo_encontrado.Cor = veiculo.Cor;
                veiculo_encontrado.Placa = veiculo.Placa;
                veiculo_encontrado.Preco = veiculo.Preco;  
                _context.SaveChanges() ;

            }
        }

        public void Deletar(int id) 
        {
            Veiculo? veiculo_encontrado = _context.Veiculo.Find(id);

            if( veiculo_encontrado != null) 
            {
                _context.Veiculo.Remove(veiculo_encontrado);
                _context.SaveChanges() ;
            }
        }
    }
}
