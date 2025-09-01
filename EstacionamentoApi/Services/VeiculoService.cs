using EstacionamentoApi.Data;
using EstacionamentoApi.Model;
using Microsoft.EntityFrameworkCore;

namespace EstacionamentoApi.Services
{
    public class VeiculoService
    {
        private readonly VeiculoContext _context;

        public VeiculoService(VeiculoContext context)
        {
            _context = context;
        }

        public async Task<IResult> BuscarVeiculosAsync()
        {
            var veiculos = await _context.Veiculos.ToListAsync();
            
            return Results.Ok(veiculos);
        }
        public async Task<IResult> BuscarVeiculoAsync(string placa)
        {
            if (string.IsNullOrEmpty(placa))
                return Results.BadRequest("Placa digitada incorretamente");

            var veiculo = await _context.Veiculos.FirstOrDefaultAsync(x => x.Placa == placa.ToUpper());

            if (veiculo == null)
                return Results.BadRequest("Veiculo não encontrado");

            return Results.Ok(veiculo);
        }

        public async Task<IResult> RegistrarEntradaAsync(VeiculoRequest req)
        {
            if (string.IsNullOrEmpty(req.placa))
                return Results.BadRequest("placa não fornecida");

            var veiculo = new VeiculoModel(req.placa);
            await _context.Veiculos.AddAsync(veiculo);
            await  _context.SaveChangesAsync();

            return Results.Ok(veiculo);
        }

        public async Task<IResult> RegistrarSaidaAsync(int id)
        {
            var carro = await _context.Veiculos.FirstOrDefaultAsync(x => x.Id == id);

            if (carro == null)
                return Results.BadRequest("Carro não encontrado");

            if (carro.ValorPago != 0)
                return Results.BadRequest("Pagamento já realizado");

            carro.DefinirSaida();

            TimeSpan tempoEstacionado = carro.HoraSaida - carro.HoraEntrada;
            decimal valorPago = tempoEstacionado.Hours * 8;
            carro.DefinirValor(valorPago);
            await _context.SaveChangesAsync();

            return Results.Ok(carro);
        }
    }
}
