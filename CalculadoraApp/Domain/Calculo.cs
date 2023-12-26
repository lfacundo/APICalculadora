namespace CalculadoraApp.Domain
{
    public class Calculo
    {
        public string Id { get; set; }
        public double valorA { get; set; }
        public double valorB { get; set; }

        public string operacao { get; set; }

        public double resultado { get; set; }

        public DateTime? DataHora { get; set; }

    }
}
