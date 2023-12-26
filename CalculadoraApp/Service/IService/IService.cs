using CalculadoraApp.Domain;

namespace CalculadoraApp.Service
{
    public interface IService
    {
        public string Calculo(Calculo calculo);
        public IEnumerable<Calculo> Dados();
    }
}
