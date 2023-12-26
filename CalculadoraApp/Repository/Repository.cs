using CalculadoraApp.Domain;
using Dapper;
using Infra;

namespace CalculadoraApp.Repository
{
    public class Repository : IRepository
    {
        private readonly BDsession _bdSession;
        public Repository(BDsession bdSession)
        {
            _bdSession = bdSession;
        }

        public bool InsertCount(double valorA, double valorB, string operacao, double resultado)
        {
            using (var db = _bdSession.Connection)
            {
                var conta = new Calculo() { valorA = valorA, valorB = valorB, operacao = operacao, resultado = resultado };
                //Comando SQL
                var query = "INSERT INTO CALCULADORA(VALORA, VALORB, OPERACAO, RESULTADO) VALUES (@valorA, @valorB, @operacao, @resultado)";
                //Parametros
                db.Execute(sql: query, param: conta);
                db.Close();
            }
            return true;
        }
        public IEnumerable<Calculo> GetCount()
        {
            List<Calculo> dados = new List<Calculo>();
            using (var db = _bdSession.Connection)
            {
                //Comando SQL
                var query = "SELECT * FROM CALCULADORA";
                //Parametros
                dados = db.Query<Calculo>(sql: query).ToList();
                db.Close();
            }
            return dados;
        }
    }
}
