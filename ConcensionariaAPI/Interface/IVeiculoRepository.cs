using ConcensionariaAPI.Models;

namespace ConcensionariaAPI.Interface
{
    public interface IVeiculoRepository
    {
        // R - Read: devolve todos os veiculos
        List<Veiculo> ListarTodos();

        // R - Read: busca um veiculo pelo Id (ou null se não achar).
        Veiculo? BuscarPorId(int id);

        // C - Create: cadastra um curso novo.
        void Cadastrar(Veiculo Veiculo);
    }
}
