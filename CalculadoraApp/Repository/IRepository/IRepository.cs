using CalculadoraApp.Domain;

namespace CalculadoraApp.Repository
{
    public interface IRepository
    {
        public bool InsertCount(double valorA, double valorB, string operacao, double resultado);
        public IEnumerable<Calculo> GetCount();
    }
}
