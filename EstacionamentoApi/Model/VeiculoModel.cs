namespace EstacionamentoApi.Model
{
    public class VeiculoModel
    {
        public int Id { get; set; }
        public string Placa { get; private set; }
        public DateTime HoraEntrada { get; private set; }
        public DateTime HoraSaida { get; private set; }
        public decimal ValorPago { get; private set; }

        public VeiculoModel(string placa) 
        {
            Placa = placa;
            HoraEntrada = DateTime.Now;
        }

        public void DefinirSaida()
        {
            HoraSaida = DateTime.Now;
        }

        public void DefinirValor(decimal valorPago)
        {
            ValorPago = valorPago;
        }
    }
}
