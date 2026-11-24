using ConcensionariaAPI.Models;

namespace ConcensionariaAPI.Interface
{
    public interface IMarcaRepository
    {
        // R - Read: devolve todos os veiculos
        List<Marca> ListarTodos();

    
        void Atualizar(int id, Marca marca);

        // C - Create: cadastra um curso novo.
        void Cadastrar(Marca marca);

        void Deletar(int id);

        Marca? BuscarPorId(int  id);
    }
}
