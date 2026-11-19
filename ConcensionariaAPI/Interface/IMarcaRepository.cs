using ConcensionariaAPI.Models;

namespace ConcensionariaAPI.Interface
{
    public interface IMarcaRepository
    {
        // R - Read: devolve todos os veiculos
        List<Marca> ListarTodos();

        // R - Read: busca um veiculo pelo Id (ou null se não achar).
        Veiculo? BuscarPorNome(string nome);

        // C - Create: cadastra um curso novo.
        void Cadastrar(Marca marca);
    }
}
