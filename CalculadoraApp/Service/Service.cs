using CalculadoraApp.Domain;
using CalculadoraApp.Repository;

namespace CalculadoraApp.Service
{
    public class Service : IService
    {
        private readonly IRepository _repository;
        public Service(IRepository repository)
        {
            _repository = repository;
        }
        public string Calculo(Calculo calculo)
        {
            string message;
            try
            {

                if (calculo.valorA != 0 && calculo.valorB != 0 && !string.IsNullOrEmpty(calculo.operacao))
                {
                    switch (calculo.operacao)
                    {
                        case "+":
                            calculo.resultado = calculo.valorA + calculo.valorB;
                            break;
                        case "-":
                            calculo.resultado = calculo.valorA - calculo.valorB;
                            break;
                        case "*":
                            calculo.resultado = calculo.valorA * calculo.valorB;
                            break;
                        case "/":
                            if (calculo.valorB != 0)
                            {
                                calculo.resultado = calculo.valorA / calculo.valorB;
                            }
                            else
                            {
                                Console.WriteLine("Divisão por zero não é permitida.");
                            }
                            break;
                        default:
                            Console.WriteLine("Operador não reconhecido.");
                            break;
                    };

                    var cad = _repository.InsertCount(calculo.valorA, calculo.valorB, calculo.operacao, calculo.resultado);
                    message = "Cálculo armazenado com sucesso";
                }
                else
                {
                    message = "Digite um valor diferente de 0";
                }
            } catch (Exception ex)
            {
                throw ex;
            }
            return message;
        }

        public IEnumerable<Calculo> Dados()
        {
            var cad = _repository.GetCount();
            return cad;
        }
    }
}
